/***************************************************************/
/*
    Scanning Tunneling Microscope Control Software
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
/***************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form2_Load);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            numericUpDown_xyResolution.Value = Form1.SPM.xyBits;
            numericUpDown_zResolution.Value = Form1.SPM.zBits;
            numericUpDown_errorResolution.Value = Form1.SPM.eBits;
            numericUpDown_biasResolution.Value = Form1.SPM.biasBits;
            numericUpDown_setpointResolution.Value = Form1.SPM.setpointBits;
            numericUpDown_xyTravel.Value = Form1.SPM.xyLSBsize * (1 << Form1.SPM.xyBits);
            numericUpDown_zTravel.Value = Form1.SPM.zLSBsize * (1 << Form1.SPM.zBits);
            numericUpDown_biasRange.Value = Form1.SPM.biasLSBsize * (1 << Form1.SPM.biasBits) / 1000.0M;
            numericUpDown_ADCRange.Value = Form1.SPM.setpointLSBsize * (1 << Form1.SPM.setpointBits) / 1000.0M;
            numericUpDown_STMPreampGain.Value = Form1.SPM.transimpedance / 1000.0M;
        }

        private void ScanControlsGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Form1.SPM.xyBits = (byte)numericUpDown_xyResolution.Value;
            Form1.SPM.zBits = (byte)numericUpDown_zResolution.Value;
            Form1.SPM.eBits = (byte)numericUpDown_errorResolution.Value;
            Form1.SPM.biasBits = (byte)numericUpDown_biasResolution.Value;
            Form1.SPM.setpointBits = (byte)numericUpDown_setpointResolution.Value;
            Form1.SPM.xyLSBsize = numericUpDown_xyTravel.Value / (1 << Form1.SPM.xyBits);
            Form1.SPM.zLSBsize = numericUpDown_zTravel.Value / (1 << Form1.SPM.zBits);
            Form1.SPM.biasLSBsize = numericUpDown_biasRange.Value * 1000.0M / (1 << Form1.SPM.biasBits);
            Form1.SPM.setpointLSBsize = numericUpDown_ADCRange.Value * 1000.0M / (1 << Form1.SPM.setpointBits);
            Form1.SPM.transimpedance = numericUpDown_STMPreampGain.Value * 1000.0M;
            this.Close();
        }
    }
}
