/**************************************************************************/
/*

DAC8814 library for Teensy 3.1
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
#include "DAC8814.h"
#include "SPIFIFO.h"


/**************************************************************************/
/*
    Constructor
*/
/**************************************************************************/

DAC8814::DAC8814(byte cs, byte ldac)
{
  pinMode(cs, OUTPUT);
  pinMode(ldac, OUTPUT);
  digitalWrite(cs, HIGH);
  digitalWrite(ldac, LOW);
  _cs = cs;
  _ldac = ldac;
}


/**************************************************************************/
/*
    Setup the SPI port at 24 MHz.
*/
/**************************************************************************/

void DAC8814::begin()
{
    SPIFIFO.begin(_cs, SPI_CLOCK_24MHz, SPI_MODE0);
}


/**************************************************************************/
/*
    Set the output of a single DAC channel.   
*/
/**************************************************************************/

void DAC8814::setOutput(uint16_t val, byte ch)
{
    SPIFIFO.write(ch, SPI_CONTINUE);
    SPIFIFO.write16(val);
    SPIFIFO.read();
    SPIFIFO.read();
}

