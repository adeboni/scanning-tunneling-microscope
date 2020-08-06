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


This function reads incoming serial data and compares it to a list of 
commands used to control the microscope.

*/
/**************************************************************************/

void checkSerial()
{
  
  String serialString;
  
  if(Serial.available() > 0)
  {
    for(int i = 0; i < 2; i++)  // Accepts 2 char commands
    {
      delay(1); // This seems to be necessary, not sure why
      char inChar = Serial.read();
      serialString += inChar;
    }
  }
  serialCommand(serialString);
  serialString = "";
}

/**************************************************************************/

void serialCommand(String str)
{
  
  String command = "00";
  
  if (str.length() > 0)
  {     
      // Get the first 2 characters of str and store them in command:
      for(int i = 0; i < 2; i++)
      {
        command[i] = str[i];
      }
      
      
      if(command == "SE") // Enable serial communications
      {
        Serial.begin(115200);
        Serial.println("SE");
        serialEnabled = true;
        digitalWriteFast(SERIAL_LED, HIGH);
      }
      
      
      else if(command == "SD") // Disable serial communications
      {
        serialEnabled = false;
        Serial.flush();
        Serial.end();
        digitalWriteFast(SERIAL_LED, LOW);
      } 
      
      
      else if(command == "SS") // Scan size in LSBs
      {
        boolean scanningEnabledOnCommand = scanningEnabled;
        int new_scanSize = Serial.parseInt();
        int xNew, yNew;
        
        // Calculate position to move to:
        xNew = (int)(((float)(x - xo) * (float)new_scanSize) / (float)scanSize) + xo;
        yNew = (int)(((float)(y - yo) * (float)new_scanSize) / (float)scanSize) + yo;
        
        scanningEnabled = false; // Pause the scan
        
        if(new_scanSize > scanSize) // Update scanSize, then move
        {
          scanSize = new_scanSize;
          moveTip(xNew, yNew);
        }
        else // Move, then update scanSize
        {
          moveTip(xNew, yNew);
          scanSize = new_scanSize;
        }
        if(scanningEnabledOnCommand) scanningEnabled = true; // Resume scanning
      }
      
      
      else if(command == "IP") // Image pixels
      {        
        boolean scanningEnabledOnCommand = scanningEnabled;
        pixelsPerLine = Serial.parseInt() * 2;
        resetScan();
        if(scanningEnabledOnCommand) scanningEnabled = true;
      }
      
      
      else if(command == "LR") // Line rate in Hz
      {
        boolean scanningEnabledOnCommand = scanningEnabled;
        lineRate = (float)Serial.parseInt() / 100.0f; // Line rate is multiplied by 100 for the transmission
        while(pixelCounter != 0); // Wait for the scanner to finish scanning a line
        scanningEnabled = false; // Pause the scan
        updateStepSizes();
        if(scanningEnabledOnCommand) scanningEnabled = true; // Resume scan
      }
     
      
      else if(command == "XO") // X-offset
      {
        boolean scanningEnabledOnCommand = scanningEnabled;
        int previous_xo = xo;
        int new_xo = Serial.parseInt();
        scanningEnabled = false; // Pause the scan
        xo = new_xo;
        moveTip(x - previous_xo + xo, y); // Move over by (xo, yo)
        if(scanningEnabledOnCommand) scanningEnabled = true; // Resume scan
      } 
      
      
      else if(command == "YO") // Y-offset
      {
        boolean scanningEnabledOnCommand = scanningEnabled;
        int previous_yo = yo;
        int new_yo = Serial.parseInt();
        scanningEnabled = false;
        yo = new_yo;
        moveTip(x, y - previous_yo + yo);
        if(scanningEnabledOnCommand) scanningEnabled = true;
      } 
      
      
      else if(command == "SP") // Setpoint in LSBs
      {
        setpoint = Serial.parseInt();
        setpointLog = logTable[abs(setpoint)];       
      } 
      
      
      else if(command == "SB") // Sample bias in LSBs
      {
        bias = Serial.parseInt();
        noInterrupts();
        dac.setOutput((uint16_t)(bias + 32768), DAC_CH_BIAS); // Set the sample bias
        interrupts();          
      }
      
      
      else if(command == "KP") // P gain
      {
        Kp = Serial.parseInt();          
      } 
      
      
      else if(command == "KI") // I gain
      {
        Ki = Serial.parseInt() * dt;        
      }
      
      
      else if(command == "EN") // Enable scanning
      {
        resetScan();
        scanningEnabled = true; 
      } 
      
      
      else if(command == "DL") // Disable scanning
      {
        scanningEnabled = false;          
      } 
      
      
      else if(command == "TE") // Tip engage
      {        
        engage();          
      } 
      
      
      else if(command == "TR") // Tip retract
      {        
        retract();          
      }
  }
}

/**************************************************************************/
