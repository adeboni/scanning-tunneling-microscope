/**************************************************************************/
/*

LTC2326-16 library for Teensy 3.1
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

*/
/**************************************************************************/

#include "Arduino.h"
#include "LTC2326_16.h"
#include "SPIFIFO.h"


/**************************************************************************/
/*
    Constructor
*/
/**************************************************************************/

LTC2326_16::LTC2326_16(byte cs, byte cnv, byte busy)
{
  pinMode(cs, OUTPUT);
  pinMode(cnv, OUTPUT);
  pinMode(busy, INPUT);
  digitalWrite(cs, HIGH);
  digitalWrite(cnv, LOW);
  _cs = cs;
  _cnv = cnv;
  _busy = busy;
}


/**************************************************************************/
/*
    Initiate a conversion.
*/
/**************************************************************************/

void LTC2326_16::convert()
{
    digitalWriteFast(_cnv, HIGH);
}


/**************************************************************************/
/*
    Check whether ADC is busy doing a conversion. Returns true if conversion
    is in progress (BUSY pin is HIGH), false otherwise.
*/
/**************************************************************************/

bool LTC2326_16::busy()
{
    bool status;
    status = (bool)digitalRead(_busy);
    return status;
}


/**************************************************************************/
/*
    Setup the SPI port at 24 MHz.
*/
/**************************************************************************/

void LTC2326_16::begin()
{
    SPIFIFO.begin(_cs, SPI_CLOCK_24MHz, SPI_MODE1);
}


/**************************************************************************/
/*
    Read the ADC data register.
*/
/**************************************************************************/

int16_t LTC2326_16::read()
{
    int16_t val;

    digitalWriteFast(_cnv, LOW); // Reset CNV for another conversion later on
    SPIFIFO.write16(0);
    val = SPIFIFO.read();
    
    return val;
}

