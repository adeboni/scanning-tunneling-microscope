/**************************************************************************/
/*

Scanning Tunneling Microscope Feedback and Scan Controller for Teensy 3.X
Last updated Oct 14, 2015
http://dberard.com/home-built-stm/


 * Copyright (c) Daniel Berard, daniel.berard@mail.mcgill.ca
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * 1. The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
 * BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
 * ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.


This program uses an intervalTimer to call an ISR at a time interval defined
by "dt" (see #define statements below). The ISR increments the scan, reads the 
ADC, performs PI calculations, sigma-delta calculations, updates the X, Y, and 
Z DACs and stores acquired data in buffers. Data is sent over USB when the 
scanner finishes scanning and re-scanning a line.

Set the CPU speed to 96 MHz optimized (overclock) or faster.
Cut the small trace on the bottom of the Teensy board to separate Vin from VUSB,
since the Teensy is being powered from an external 5V supply.

STM analog PCB to Teensy 3.1 connections:

All GNDs -> Teensy GND
+5V -> Vin
~CS_DAC -> pin 20
~LDAC -> pin 17
~CS_ADC -> pin 21
CNV -> pin 4
BUSY -> pin 3
MISO_ADC -> pin 12
MOSI_DAC -> pin 11
Serial indicator LED -> pin 0
Tunneling indicator LED -> pin 1
SCK_ADC and SCK_DAC -> pin 13.

*/
/**************************************************************************/


// Pin definitions:
#define CS_DAC 20                          // DAC chip select pin
#define LDAC 17                            // Load DAC pin, not currently used
#define CS_ADC 21                          // ADC chip select pin
#define CNV 4                              // ADC CNV pin - initiates a conversion
#define BUSY 3                             // ADC BUSY pin
#define SERIAL_LED 0                       // Indicates serial data transmission
#define TUNNEL_LED 1                       // Indicates tunneling


// DAC channel addresses:
#define DAC_CH_X 2
#define DAC_CH_Y 1
#define DAC_CH_Z 0
#define DAC_CH_BIAS 3


// DAC and ADC resolution:
#define DAC_BITS 16                        // Actual DAC resolution
#define POSITION_BITS 20                   // Sigma-delta resolution
#define ADC_BITS 16


// Default scan settings:
#define SCAN_SIZE 100000 // ~160 nm        // Scan size in LSBs
#define IMAGE_PIXELS 512                   // Scan size in pixels
#define LINE_RATE 1                        // Number of scan lines/second
#define SETPOINT 328 // 1 nA               // Tunneling current setpoint in LSBs
#define BIAS 328 // 100 mV                 // Sample bias in LSBs
#define KP 0                               // Proportional gain
#define KI 300000                          // Integral gain


// Constants:
#define INVERT_Z true                      // Inverts the Z output signal from the DAC
#define ENGAGE_SCANNER_STEP_SIZE 50        // Number of LSBs to step the scanner by during engage
#define ENGAGE_MOTOR_STEP_SIZE 1           // Number of steps to move the motor by during engage
#define dt 40                              // Time step for scanning and PI control in microseconds
#define DATA_BUFFER_LENGTH 16386           // Number of bytes in each ping-pong buffer for data storage. Need 2 bytes for line number + 16 bytes/pixel.
#define SCAN_COUNTER_LIMIT 0x40000000      // Scan counter counts from -SCAN_COUNTER_LIMIT to SCAN_COUNTER_LIMIT-1


/**************************************************************************/

#include <SPIFIFO.h>
#include "logTable.h"
#include "DAC8814.h"
#include "LTC2326_16.h"


/**************************************************************************/
/*
    Variable declarations
*/
/**************************************************************************/


// Scan parameters:
float lineRate = LINE_RATE; // Scan lines per second
unsigned int pixelsPerLine = IMAGE_PIXELS * 2;
unsigned int samplesPerPixel;
int scanSize = SCAN_SIZE; // Size of the scan in LSBs
int bias = BIAS; // Sample bias in LSBs
boolean scanningEnabled = false;
boolean engaged = false;


// Scan counters. Counts from -SCAN_COUNTER_LIMIT to SCAN_COUNTER_LIMIT - 1
// regardless of scan size, then counts back down when the scan direction reverses.
volatile int xCount = -SCAN_COUNTER_LIMIT; // X-axis scan counter
volatile int yCount = -SCAN_COUNTER_LIMIT; // Y-axis scan counter
volatile int dx = 0, dy = 0; // Scan counter increments


// Sample, pixel and line counters:
volatile unsigned int sampleCounter = 0, pixelCounter = 0, lineCounter = 0;
volatile int zAvg = 0, eAvg = 0; // Accumulates Z and error samples for later averaging


// Ping-pong buffers:
byte data1[DATA_BUFFER_LENGTH], data2[DATA_BUFFER_LENGTH]; // Data buffers
volatile boolean fillData1 = true; // Indicates which buffer to fill
volatile boolean sendData = false; // Indicates that data is ready to be sent over USB
boolean serialEnabled = false; // Enables serial transfer of data


// Position variables:
const int MAX_Z = (1 << (POSITION_BITS - 1)) - 1; // Maximum Z value
int xo = 0, yo = 0; // Scan offsets
volatile int x = 0, y = 0, z = 0; // Scanner coordinates in LSBs


// PI variables:
boolean pidEnabled = true; // Setting this to false desiables PI control
int setpoint = SETPOINT, setpointLog; // setpointLog = log(|setpoint|)
int Kp = KP, Ki = KI; // Proportional and integral gains
volatile int16_t input; // ADC input data
volatile int error = 0; // PID error signal
volatile int64_t iTerm = 0; // Integral term
const int64_t MAX_ITERM = MAX_Z * 0x100000000; // Maximum integral term. Used to prevent windup.


// Sigma-delta variables:
int sigmaX = 0, sigmaY = 0, sigmaZ = 0; // Sigma-delta integrators
const unsigned int shift = POSITION_BITS - DAC_BITS; // Number of bits to increase DAC resolution by using sigma-delta algorithm


// Timers:
IntervalTimer scanTimer;


// Data converters:
DAC8814 dac(CS_DAC, LDAC); // 16-bit quad DAC
LTC2326_16 adc(CS_ADC, CNV, BUSY); // 16-bit ADC
const int MAX_DAC_OUT = (1 << (DAC_BITS - 1)) - 1; // DAC upper bound
const int MIN_DAC_OUT = -(1 << (DAC_BITS - 1)); // DAC lower bound
boolean saturationCompensation = true; // The LTC2326-16 seems to output 0 when its input saturates. This is a temporary fix.


/**************************************************************************/
/*
    Setup
*/
/**************************************************************************/

void setup()
{
  pinMode(SERIAL_LED, OUTPUT);
  pinMode(TUNNEL_LED, OUTPUT);
  digitalWrite(SERIAL_LED, LOW);
  digitalWrite(TUNNEL_LED, LOW);

  // Set the sample bias:
  dac.begin();
  dac.setOutput((uint16_t)(bias + MAX_DAC_OUT + 1), DAC_CH_BIAS);
  
  setpointLog = logTable[abs(SETPOINT)]; // Take the log of the setpoint
  updateStepSizes(); // Compute the scan counter step sizes  
  adc.convert(); // Start an ADC conversion

  // Start the scan/PI/sigma-delta timer:
  scanTimer.priority(0);
  scanTimer.begin(incrementScan, dt);
}


/**************************************************************************/
/*
    Loop
*/
/**************************************************************************/

void loop()
{
  checkSerial(); // Check for incoming serial commands. See "SerialCommands" tab.
  
  // Illuminate tunelling LED if the tunneling current is > setpoint/2:
  if(abs(input) > setpoint >> 1) digitalWriteFast(TUNNEL_LED, HIGH);
  else digitalWriteFast(TUNNEL_LED, LOW);
  
  // Send data over USB if a line has been scanned and re-scanned:
  if(sendData)
  {    
    if(!fillData1) // Print data1
    {
      data1[0] = (byte)((lineCounter >> 8) & 0xFF); // High byte
      data1[1] = (byte)(lineCounter & 0xFF); // Low byte
      
      if(serialEnabled)
      {
        Serial.println("DATA");
        Serial.write(data1, DATA_BUFFER_LENGTH);
      }
      
      // Uncomment this block to print human-readable data to the serial port:
      /*
      for(unsigned int i = 0; i < pixelsPerLine * 2; i++) // Loop over pixels
      {
        Serial.print((int)((int)data1[4*i+2] << 24 | (int)data1[4*i+3] << 16 |(int)data1[4*i+4] << 8 |(int)data1[4*i+5]));
        Serial.print(" ");
      }
      */
    }
    else
    {
      data2[0] = (byte)((lineCounter >> 8) & 0xFF); // High byte
      data2[1] = (byte)(lineCounter & 0xFF); // Low byte
      
      if(serialEnabled)
      {
        Serial.println("DATA");
        Serial.write(data2, DATA_BUFFER_LENGTH);
      }
      
      // Uncomment this block to print human-readable data to the serial port:
      /*
      for(unsigned int i = 0; i < pixelsPerLine * 2; i++) // Loop over pixels
      {
        Serial.print((int)((int)data2[4*i+2] << 24 | (int)data2[4*i+3] << 16 |(int)data2[4*i+4] << 8 |(int)data2[4*i+5]));
        Serial.print(" ");
      }
      */     
    }
    Serial.println();
    
    sendData = false;
  }
}


/**************************************************************************/
/*
    Increment the scan, perform PI calculations, sigma-delta calculations,
    update the x, y and z DACs, store data in buffers.
*/
/**************************************************************************/

void incrementScan(void) // This interrupt runs in about ~18 us at 96 MHz
{  
  static int xout, yout, zout;
  static int64_t pTerm;
  
  //////////////////////////////////////////////////////////////////////
  // Increment the scan:
  //////////////////////////////////////////////////////////////////////
  
  if(scanningEnabled)
  {
    if(xCount <= -SCAN_COUNTER_LIMIT || xCount >= SCAN_COUNTER_LIMIT - 1 - dx) dx = -dx; // Reverse at the end of a line
    xCount += dx;
    x = (int)(((int64_t)xCount * (int64_t)scanSize) >> 31) + xo;
    if(yCount <= -SCAN_COUNTER_LIMIT || yCount >= SCAN_COUNTER_LIMIT - 1 - dy) dy = -dy; // Reverse and the end of a scan
    yCount += dy;
    y = (int)(((int64_t)yCount * (int64_t)scanSize) >> 31) + yo;
    if(yCount <= -SCAN_COUNTER_LIMIT) lineCounter = 0; // Just in case the scan and acquisition become desynchronized...
  }
  
  //////////////////////////////////////////////////////////////////////
  // Perform PI calculations:
  //////////////////////////////////////////////////////////////////////
  
  adc.begin(); // Set up the SPI port to communicate with the ADC
  input = adc.read(); // Read the ADC data over SPI
  if(saturationCompensation & (input == 0) & (z != -MAX_Z)) input = 32767; // Compensate for the LTC2326-16 saturation issue
  error = logTable[abs((int16_t)input)] - setpointLog; // Negative error = tip too far from sample
  
  if(pidEnabled)
  {
    pTerm = (int64_t)Kp * (int64_t)error;
    iTerm += (int64_t)Ki * (int64_t)error;
    if(iTerm > MAX_ITERM) iTerm = MAX_ITERM; // Constrain the integral term to prevent windup
    else if (iTerm < -MAX_ITERM) iTerm = -MAX_ITERM;
    z = (int)(((pTerm + iTerm) >> 32) & 0xFFFFFFFF);
    z = saturate(z, MAX_Z, -MAX_Z);
  }
  adc.convert(); // Initiate a new conversion. Data will be ready by the next time this interrupt runs.  
  
  
  //////////////////////////////////////////////////////////////////////
  // Perform sigma-delta calculations and update scanner DACs:
  //////////////////////////////////////////////////////////////////////
  
  dac.begin();
  xout = sigmaDelta(x, &sigmaX, shift);
  xout = saturate(xout, MAX_DAC_OUT, MIN_DAC_OUT);
  dac.setOutput((uint16_t)(xout + MAX_DAC_OUT + 1), DAC_CH_X);
  yout = sigmaDelta(y, &sigmaY, shift);
  yout = saturate(yout, MAX_DAC_OUT, MIN_DAC_OUT);
  dac.setOutput((uint16_t)(yout + MAX_DAC_OUT + 1), DAC_CH_Y);
  zout = sigmaDelta(z, &sigmaZ, shift);
  if(INVERT_Z) zout = -zout;
  zout = saturate(zout, MAX_DAC_OUT, MIN_DAC_OUT);
  dac.setOutput((uint16_t)(zout + MAX_DAC_OUT + 1), DAC_CH_Z);
  
  //////////////////////////////////////////////////////////////////////
  // Store data in buffer arrays and update counters:
  //////////////////////////////////////////////////////////////////////
  
  if(scanningEnabled)
  {
    zAvg += z; // Accumulate data for averaging
    eAvg += error;
    sampleCounter++;
    
    if(sampleCounter >= samplesPerPixel) // If enough samples have been acquired for one pixel
    {
      unsigned int indexZ = (pixelCounter << 2) + 2; // Index for Z data point in data buffer
      unsigned int indexE = indexZ + (pixelsPerLine << 2);  // Index for error data point in data buffer
      
      zAvg = zAvg / (int)samplesPerPixel; // Compute the average of acquired samples
      eAvg = eAvg / (int)samplesPerPixel;
            
      if(fillData1)
      {
        data1[indexZ]     = (byte)((zAvg >> 24) & 0xFF); // High byte Z
        data1[indexZ + 1] = (byte)((zAvg >> 16) & 0xFF);
        data1[indexZ + 2] = (byte)((zAvg >> 8) & 0xFF);
        data1[indexZ + 3] = (byte)(zAvg & 0xFF);         // Low byte Z
        data1[indexE]     = (byte)((eAvg >> 24) & 0xFF); // High byte E
        data1[indexE + 1] = (byte)((eAvg >> 16) & 0xFF);
        data1[indexE + 2] = (byte)((eAvg >> 8) & 0xFF);
        data1[indexE + 3] = (byte)(eAvg & 0xFF);         // Low byte E
      }
      else
      {
        data2[indexZ]     = (byte)((zAvg >> 24) & 0xFF); // High byte Z
        data2[indexZ + 1] = (byte)((zAvg >> 16) & 0xFF);
        data2[indexZ + 2] = (byte)((zAvg >> 8) & 0xFF);
        data2[indexZ + 3] = (byte)(zAvg & 0xFF);         // Low byte Z
        data2[indexE]     = (byte)((eAvg >> 24) & 0xFF); // High byte E
        data2[indexE + 1] = (byte)((eAvg >> 16) & 0xFF);
        data2[indexE + 2] = (byte)((eAvg >> 8) & 0xFF);
        data2[indexE + 3] = (byte)(eAvg & 0xFF);         // Low byte E
      }
      pixelCounter++;      
      sampleCounter = 0;
      zAvg = 0;
      eAvg = 0;
      
      if(pixelCounter >= pixelsPerLine)
      {
        pixelCounter = 0;
        fillData1 = !fillData1;
        sendData = true;
        lineCounter++;
        if(lineCounter >= pixelsPerLine)
          {
            lineCounter = 0;
          }
      }
    }
  }
}


/**************************************************************************/
/*
  Sigma delta. Used to produce a PWM output between LSBs of a DAC to 
  effectively increase its resolution. The DAC output must be low-pass 
  filtered to smooth out the PWM.
  
  Based on Tim Wescott's example here:
  http://www.embedded.com/design/configurable-systems/4006431/Sigma-delta-techniques-extend-DAC-resolution
*/
/**************************************************************************/

int sigmaDelta(int in, int *sigma, unsigned int shift)
{
  int out;
  
  *sigma += in; // Add desired input to sigma-delta integrator
  out = *sigma >> shift; // Truncate to the number of actual DAC bits
  *sigma -= out << shift; // Shift the DAC output value and subtract it from the integrator
  return out;
}
  
/**************************************************************************/
/*
  Saturate a value if it falls outside of max or min
*/
/**************************************************************************/

int saturate(int val, int max, int min)
{
  if(val > max) val = max;
  else if (val < min) val = min;
  return val;
}


/**************************************************************************/
/*
  This function updates scan stepsizes without changing the scan direction.
*/
/**************************************************************************/

void updateStepSizes()
{
  unsigned int new_samplesPerPixel = (unsigned int)(1000000.0f / (lineRate * (float)dt * (float)pixelsPerLine));
  int new_dx = (SCAN_COUNTER_LIMIT - 1)/ ((int)new_samplesPerPixel * (int)pixelsPerLine) * 4;
  int new_dy = new_dx / (int)pixelsPerLine;
  
  noInterrupts();
  samplesPerPixel = new_samplesPerPixel;
  if(dx > 0) dx = new_dx;
  else dx = -new_dx;
  if(dy > 0) dy = new_dy;
  else dy = -new_dy;
  interrupts();
}


/**************************************************************************/
/*
    Move the scanner to the scan start position.
*/
/**************************************************************************/

void resetScan()
{
  int xStart = -(scanSize >> 1) + xo;
  int yStart = -(scanSize >> 1) + yo;
  
  scanningEnabled = false; // disable scanning
  
  // Reset counters etc:
  noInterrupts();
  xCount = -SCAN_COUNTER_LIMIT;
  yCount = -SCAN_COUNTER_LIMIT;
  dx = 0;
  dy = 0;
  updateStepSizes(); // Re-calculate step sizes
  sampleCounter = 0;
  pixelCounter = 0;
  lineCounter = 0;
  zAvg = 0;
  eAvg = 0;
  fillData1 = true;
  interrupts();
  
  // Move to start position:
  moveTip(xStart, yStart);
}


/**************************************************************************/
/*
    Move from (x,y) to (xf,yf). The tip moves at the current scanning speed.
*/
/**************************************************************************/

void moveTip(int xf, int yf)
{
  int stepSize = abs((int)(((int64_t)dx * (int64_t)scanSize) >> 31));
  
  scanningEnabled = false;
  
  while (x > xf) {
    x -= stepSize;
    waitTimeStep(); // Wait for incrementScan() to update the DAC
  }
  while (x < xf) {
    x += stepSize;
    waitTimeStep();
  }
  while (y > yf) {
    y -= stepSize;
    waitTimeStep();
  }
  while (y < yf) {
    y += stepSize;
    waitTimeStep();
  }
}


/**************************************************************************/
/*
    Wait for on time interval dt.
*/
/**************************************************************************/

void waitTimeStep()
{
  unsigned int t = micros();
  while (micros() - t <= dt)
  {
    // Wait...
  }
}


/**************************************************************************/
/*
    Currently, this function only starts the scan and enables the Z feedback
    loop. For use with manual coarse approach. Will be replaced later with 
    a motorized approach function.
*/
/**************************************************************************/

boolean engage()
{
  scanningEnabled = true;
  engaged = true;
  pidEnabled = true;
  return true;
}


/**************************************************************************/
/*
    Retracts the scanner without using the approach motor. This function 
    only moves the scanner Z-axis, not the approach motor.
*/
/**************************************************************************/

void retract()
{

  scanningEnabled = false;
  pidEnabled = false;
  engaged = false;
  z = MAX_Z; // Fully retract the Z-piezo
  digitalWrite(TUNNEL_LED, LOW);
}


/**************************************************************************/
/*
    Engage the scanner without using the approach motor. This function 
    only moves the scanner Z-axis, not the approach motor. Returns true
    if the surface was detected, false otherwise. This function is not
    currently used.
*/
/**************************************************************************

boolean engageScanner()
{  
  if(!engaged)
  {
    pidEnabled = false;
    scanningEnabled = false;
    saturationCompensation = false;
  
    while (error < 0 && z > -MAX_Z)
    {
      z -= ENGAGE_SCANNER_STEP_SIZE;
      waitTimeStep();
    }
    
    // If scanner is not fully extended after approach, it has found the surface. Enable PID:
    if (z > -MAX_Z)
    {
      pidEnabled = true;
      engaged = true;
      saturationCompensation = true;
      digitalWrite(TUNNEL_LED, HIGH);
    }
    else // Fully retract the Z-piezo:
    {
      retract();
    }
  }
  return engaged;
}


/**************************************************************************/
/*
    Move the approach motor by the specified amount.
*/
/**************************************************************************

void stepMotor(int stepSize, int dir)
{
  
}

/**************************************************************************/
/*
  This function sweeps the bias voltage from its current value to minus its 
  current value while reading the current at every point.
*/
/**************************************************************************

void IVCurve()
{
  
}


/**************************************************************************/
/*
  This function retracts the Z-piezo by a specified distance while reading 
  the current at every point.
*/
/**************************************************************************

void IVCurve()
{
  
}


/***************************************************************/
