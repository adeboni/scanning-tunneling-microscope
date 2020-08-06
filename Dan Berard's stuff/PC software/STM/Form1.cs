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
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;

namespace STM
{
    public partial class Form1 : Form
    {

        public class SPM
        {
            public static byte xyBits; // Horizontal scanner resolution
            public static byte zBits;
            public static byte eBits;
            public static byte biasBits;
            public static byte setpointBits;
            public static decimal biasLSBsize; // mV
            public static decimal xyLSBsize; // nm per LSB
            public static decimal zLSBsize; // nm per LSB
            public static decimal setpointLSBsize; // nm per LSB
            public static decimal transimpedance; // mV/nA
            public static Boolean enabled = true;
            public static Boolean engaged = false;
        }

        public class ImgData
        {
            public static Bitmap imgA = null; // Left image - topography
            public static Bitmap imgB = null; // Right image - error signal
            public static int imgSize = 512; // Pixels
            public static int zScale = 100000; // LSBs
            public static int iScale = 1000; // LSBs
            public static int[,] dataZTrace = new int[imgSize, imgSize]; // Raw data from the STM
            public static int[,] dataZRetrace = new int[imgSize, imgSize];
            public static int[,] dataETrace = new int[imgSize, imgSize];
            public static int[,] dataERetrace = new int[imgSize, imgSize];
            public static String saveDir; // Directory to save the images to
            public static uint saveNumber = 1; // Frame number to save
        }
              
  
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Create images:
            ImgData.imgA = new Bitmap(
                (UInt16)numericUpDown_imgSize.Value, 
                (UInt16)numericUpDown_imgSize.Value, 
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pictureBox1.Image = ImgData.imgA;
            pictureBox1.Refresh();
            ImgData.imgB = new Bitmap(
                (UInt16)numericUpDown_imgSize.Value,
                (UInt16)numericUpDown_imgSize.Value,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pictureBox2.Image = ImgData.imgB;
            pictureBox2.Refresh();

            // Load user settings:
            SPM.xyBits = Properties.Settings.Default.xyBits;
            SPM.zBits = Properties.Settings.Default.zBits;
            SPM.eBits = Properties.Settings.Default.eBits;
            SPM.biasBits = Properties.Settings.Default.biasBits;
            SPM.setpointBits = Properties.Settings.Default.setpointBits;
            SPM.xyLSBsize = Properties.Settings.Default.xyLSBsize;
            SPM.zLSBsize = Properties.Settings.Default.zLSBsize;
            SPM.biasLSBsize = Properties.Settings.Default.biasLSBsize;
            SPM.setpointLSBsize = Properties.Settings.Default.setpointLSBsize;
            SPM.transimpedance = Properties.Settings.Default.transimpedance;
            ImgData.saveDir = Properties.Settings.Default.saveDirectory;

            numericUpDown_scanSize.Maximum = SPM.xyLSBsize * (1 << SPM.xyBits);
            numericUpDown_scanSize.Minimum = SPM.xyLSBsize * 10;

            // Prepare trace/retrace plot:
            chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Series1"].Color = System.Drawing.Color.Red;
            chart1.Series["Series2"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Series2"].Color = System.Drawing.Color.Blue;
            chart1.ChartAreas[0].AxisX.Maximum = (UInt16)numericUpDown_imgSize.Value;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = (UInt32)numericUpDown_scale.Value;
            chart1.ChartAreas[0].AxisY.Minimum = -(UInt32)numericUpDown_scale.Value;
            DoubleBuffered = true;

            string[] serialPorts;
            serialPorts = System.IO.Ports.SerialPort.GetPortNames();
            comboBox_COMPort.Items.AddRange(serialPorts);
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }


        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close serial port:
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("SD"); // Send a command to the SPM to disable serial communications
                serialPort1.DataReceived -= DataReceivedHandler;
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                serialPort1.Close();
            }

            // Save user settings:
            Properties.Settings.Default.xyBits = SPM.xyBits;
            Properties.Settings.Default.zBits = SPM.zBits;
            Properties.Settings.Default.eBits = SPM.eBits;
            Properties.Settings.Default.biasBits = SPM.biasBits;
            Properties.Settings.Default.setpointBits = SPM.setpointBits;
            Properties.Settings.Default.xyLSBsize = SPM.xyLSBsize;
            Properties.Settings.Default.zLSBsize = SPM.zLSBsize;
            Properties.Settings.Default.biasLSBsize = SPM.biasLSBsize;
            Properties.Settings.Default.setpointLSBsize = SPM.setpointLSBsize;
            Properties.Settings.Default.transimpedance = SPM.transimpedance;
            Properties.Settings.Default.saveDirectory = ImgData.saveDir;
            Properties.Settings.Default.Save();

            Application.ExitThread();
            Application.Exit();
        }


        /***********************************************************************************/
        /*
            Process a line of data sent from the SPM:
        */
        /***********************************************************************************/

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            int line; // Scan line number sent from the SPM
            int dir = 0; // 0 = scanning down, 1 = scanning up
            int imgBytes = 3; // Image bytes. There are 3 bytes per pixel in the display images (R, G, B).
            int dataBytes = 4; // Number of bytes per data point sent from the SPM
            int numPixels = ImgData.imgSize; // Make a copy of the image size in pixels in case it is modified
            Rectangle dimension = new Rectangle(0, 0, numPixels, numPixels);
            int[] lineValuesZ = new int[numPixels]; // Buffer for processing Z data
            int[] lineValuesE = new int[numPixels]; // Buffer for processing error signal data
            byte[] pixelValuesDispZ = new byte[numPixels * imgBytes]; //for 8-bit "RGB" display image
            byte[] pixelValuesDispI = new byte[numPixels * imgBytes]; //for 8-bit "RGB" display image
            int maxZ = (1 << (SPM.zBits - 1)); // Maximum Z counts
            int maxE = (1 << (SPM.eBits - 1)); // Maximum error signal counts
            int length = 16386; // Length of byte array sent from the SPM
            int offset = 2; // Number of bytes at start of byte array that are not data points (there are 2 bytes for line number)
            byte[] serialDataByteArray = new byte[length]; // Buffer to read the serial data into
            

            for (int i = 0; i < length; i++)
            {
                serialDataByteArray[i] = (byte)255;
            }

                if (serialPort1.IsOpen)
                {
                    try
                    {
                        // Check if we've received the header message denoting the start of a scanned line:
                        String serialData = serialPort1.ReadLine();
                        if (serialData.Equals("DATA\r"))
                        {
                            System.Threading.Thread.Sleep(10);
                            /*while(serialPort1.BytesToRead < length)
                            {
                                // Wait for all the data to be received...
                            }*/
                            serialPort1.Read(serialDataByteArray, 0, length); // Read data from serial port
                            // Extract the line number:
                            line = (int)(((int)serialDataByteArray[0] << 8) | (int)serialDataByteArray[1]);
                            if (line >= numPixels)
                            {
                                line = (int)(numPixels * 2 - 1 - line);
                                dir = 1;
                            }

                            for (int i = 0; i < numPixels; i++)
                            {
                                byte[] zt = new byte[dataBytes]; // Bytes for Z-trace data
                                byte[] zr = new byte[dataBytes]; // Bytes for Z-retrace data
                                byte[] et = new byte[dataBytes]; // Bytes for error-trace data
                                byte[] er = new byte[dataBytes]; // Bytes for error-retrace data

                                // Extract the individual bytes from the serial data:
                                for (int j = 0; j < dataBytes; j++)
                                {
                                    zt[j] = ((byte)serialDataByteArray[dataBytes * i + j + offset]);
                                    zr[j] = ((byte)serialDataByteArray[dataBytes * (i + numPixels) + j + offset]);
                                    et[j] = ((byte)serialDataByteArray[dataBytes * (i + numPixels * 2) + j + offset]);
                                    er[j] = ((byte)serialDataByteArray[dataBytes * (i + numPixels * 3) + j + offset]);
                                }

                                // Combine data bytes into 32-bit integers and add them to the main data arrays:
                                ImgData.dataZTrace[line, i] = 
                                    (int)((int)zt[0] << 24 | (int)zt[1] << 16 | (int)zt[2] << 8 | (int)zt[3]);
                                ImgData.dataZRetrace[line, numPixels - 1 - i] = 
                                    (int)((int)zr[0] << 24 | (int)zr[1] << 16 | (int)zr[2] << 8 | (int)zr[3]);
                                ImgData.dataETrace[line, i] = 
                                    (int)((int)et[0] << 24 | (int)et[1] << 16 | (int)et[2] << 8 | (int)et[3]);
                                ImgData.dataERetrace[line, numPixels - 1 - i] = 
                                    (int)((int)er[0] << 24 | (int)er[1] << 16 | (int)er[2] << 8 | (int)er[3]);

                                // Add the new data points to data processing buffers: 
                                lineValuesZ[i] = ImgData.dataZTrace[line, i];
                                lineValuesE[i] = ImgData.dataETrace[line, i];
                            }

                            // Compute the average value of the new data:
                            int lineMeanZ = (int)lineValuesZ.Average();
                            int lineMeanE = (int)lineValuesE.Average();

                            // Modify the chart:
                            chart1.Invoke(new MethodInvoker(delegate
                            {
                                // Clear chart:
                                foreach (var series in chart1.Series)
                                {
                                   chart1.Invoke(new MethodInvoker(delegate { series.Points.Clear(); }));
                                }
                                // Plot new data points:
                                for (int i = 0; i < ImgData.imgSize; i++)
                                {
                                    chart1.Series["Series1"].Points.AddXY(
                                        i, (ImgData.dataZTrace[line, i] - lineMeanZ) * SPM.zLSBsize);
                                    chart1.Series["Series2"].Points.AddXY(
                                        i, (ImgData.dataZRetrace[line, i] - lineMeanZ) * SPM.zLSBsize); //dataRetrace is mirrored
                                }
                            }));

                            // Modify the Z signal indicator bar:
                            progressBarZ.Invoke(new MethodInvoker(delegate
                            {
                                // Value of indicator bar is the average of the scanned line:
                                if (lineMeanZ + maxZ < progressBarZ.Maximum)
                                {
                                    progressBarZ.Value = lineMeanZ + maxZ;
                                }
                            }));


                            // Process the new data for display:
                            for (int i = 0; i < numPixels; i++)
                            {
                                // Subtract mean:
                                lineValuesZ[i] = lineValuesZ[i] - lineMeanZ;
                                // Adjust contrast:
                                lineValuesZ[i] = lineValuesZ[i] * (maxZ / ImgData.zScale);
                                lineValuesE[i] = lineValuesE[i] * (maxE / ImgData.iScale);
                                // Saturate if too large:
                                lineValuesZ[i] = lineValuesZ[i] > maxZ - 1 ? maxZ - 1 : lineValuesZ[i];
                                lineValuesE[i] = lineValuesE[i] > maxE - 1 ? maxE - 1 : lineValuesE[i];
                                lineValuesZ[i] = lineValuesZ[i] < -maxZ ? -maxZ : lineValuesZ[i];
                                lineValuesE[i] = lineValuesE[i] < -maxE ? -maxE : lineValuesE[i];
                                // Extract the upper byte of the new data to be added to the 8-bit display image:
                                byte msbZ = (byte)(((lineValuesZ[i] + maxZ) >> (SPM.zBits - 8)) & 0xFFu);
                                byte msbI = (byte)(((lineValuesE[i] + maxE) >> (SPM.eBits - 8)) & 0xFFu);
                                // Add these bytes to arrays that will be added to the display images:
                                for (int l = 0; l < 3; l++)
                                {
                                    pixelValuesDispZ[i * imgBytes + l] = msbZ;
                                    pixelValuesDispI[i * imgBytes + l] = msbI;
                                }
                            }

                            // Add the scanned line Z data to the 1st display image:
                            BitmapData displayImageData1 = 
                                ImgData.imgA.LockBits(dimension, ImageLockMode.ReadWrite, ImgData.imgA.PixelFormat);
                            IntPtr pixelStartAddressDisp = displayImageData1.Scan0;
                            System.Runtime.InteropServices.Marshal.Copy(
                                pixelValuesDispZ, 
                                0, 
                                pixelStartAddressDisp + line * numPixels * imgBytes, 
                                numPixels * imgBytes);
                            ImgData.imgA.UnlockBits(displayImageData1);

                            // Add the scanned line error signal data to the 2nd display image:
                            BitmapData displayImageData2 = 
                                ImgData.imgB.LockBits(dimension, ImageLockMode.ReadWrite, ImgData.imgB.PixelFormat);
                            pixelStartAddressDisp = displayImageData2.Scan0;
                            System.Runtime.InteropServices.Marshal.Copy(
                                pixelValuesDispI, 
                                0, 
                                pixelStartAddressDisp + line * numPixels * imgBytes, 
                                numPixels * imgBytes);
                            ImgData.imgB.UnlockBits(displayImageData2);

                            // Update the pictureBoxes:
                            if (ImgData.imgA.Width == numPixels)
                            {
                                pictureBox1.Invoke(new MethodInvoker(delegate
                                {
                                    pictureBox1.Image = ImgData.imgA;
                                    pictureBox1.Refresh();
                                    if (pictureBox1.Image != null) pictureBox1.InitialImage.Dispose();
                                }));
                                pictureBox2.Invoke(new MethodInvoker(delegate
                                {
                                    pictureBox2.Image = ImgData.imgB;
                                    pictureBox2.Refresh();
                                    if (pictureBox2.Image != null) pictureBox2.InitialImage.Dispose();
                                }));
                            }

                            // If we've reached the top or bottom scan line, prepare and save a 16-bit image
                            if ((line == 0 && dir == 1) || (line == numPixels - 1 && dir == 0))
                            {
                                // Start a separate thread to prevent hiccups
                                new Thread(() =>
                                {
                                    Thread.CurrentThread.IsBackground = true;

                                    // Create 16-bit data arrays:
                                    ushort[,] dataZTrace16 = new ushort[numPixels, numPixels];
                                    ushort[,] dataETrace16 = new ushort[numPixels, numPixels];

                                    // File name to save data:
                                    String saveFileName = ImgData.saveDir + textBox_fileName.Text;

                                    // Convert the acquired data to 16-bit and store it in the 16-bit data arrays:
                                    for (int i = 0; i < numPixels; ++i)
                                    {
                                        for (int j = 0; j < numPixels; ++j)
                                        {
                                            dataZTrace16[i, j] = 
                                                (ushort)((ImgData.dataZTrace[i, j] >> (SPM.zBits - 16)) + (1 << 15));
                                            dataETrace16[i, j] = 
                                                (ushort)((ImgData.dataETrace[i, j] >> (SPM.eBits - 16)) + (1 << 15));
                                        }
                                    }
                                    // Add numbers to the end of the filenames for the images if overwriting of previous images
                                    // is not wanted, and save the images:
                                    ushort[][,] data16 = {dataZTrace16, dataETrace16};

                                    if (!checkBox_Overwrite.Checked)
                                    {
                                        saveBitmap(data16, saveFileName + "_" + Convert.ToString(ImgData.saveNumber));
                                        ImgData.saveNumber++;
                                    }
                                    // Otherwise, don't change the filename, and save the images:
                                    else
                                    {
                                        saveBitmap(data16, saveFileName);
                                    }
                                }).Start();
                                     
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                }
        }



        /***********************************************************************************/
        /*
            Save data as 16-bit TIFF stack:
        */
        /***********************************************************************************/

        private void saveBitmap(ushort[][,] data, string filename)
        {
            int imgSize = data[0].GetUpperBound(0) + 1; // Get image size from data[0] array size
            // Metadata info:
            decimal imgSize_nm = numericUpDown_scanSize.Value;
            decimal lineRate = numericUpDown_lineRate.Value;
            decimal bias = numericUpDown_bias.Value;
            decimal setpoint = numericUpDown_setpoint.Value;
            String comment = imgSize_nm + " nm, " + lineRate + " Hz, " + bias + " mV, " + setpoint + " nA, ";
            String date = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            //Create bitmaps to save raw data in 16-bit grayscale format:
            int numPages = data.Length; // Create a tiff page for each array passed in data
            WriteableBitmap[] bitmap = new WriteableBitmap[numPages];
            BitmapMetadata[] metadata = new BitmapMetadata[numPages];
            BitmapFrame[] bitmapFrame = new BitmapFrame[numPages];
            TiffBitmapEncoder encoder = new TiffBitmapEncoder(); // Encoder

            encoder.Compression = TiffCompressOption.None; // No compression

            // Loop over tiff frames:
            for (int i = 0; i < numPages; i++)
            {
                bitmap[i] = new WriteableBitmap(imgSize, imgSize, 96, 96, PixelFormats.Gray16, null);
                // Save scan settings and date taken in image metadata: 
                metadata[i] = new BitmapMetadata("tiff");                           
                metadata[i].DateTaken = date;
                metadata[i].Comment = comment;

                // Convert data arrays to bitmaps:
                ushort[] pixels = new ushort[imgSize * imgSize];

                for (int j = 0; j < imgSize; ++j)
                {
                    for (int k = 0; k < imgSize; ++k)
                    {
                        pixels[j * imgSize + k] = data[i][j, k];
                    }
                }

                // Add pixels to bitmap:
                bitmap[i].WritePixels(new System.Windows.Int32Rect(0, 0, imgSize, imgSize), pixels, imgSize * 2, 0);

                // Add frames and metadata:
                bitmapFrame[i] = BitmapFrame.Create(bitmap[i]);
                encoder.Frames.Add(BitmapFrame.Create(
                    bitmapFrame[i], bitmapFrame[i].Thumbnail, metadata[i], bitmapFrame[i].ColorContexts));
            }           

            // Save the image:
            using (var stream = System.IO.File.Create(filename + ".tif"))
                encoder.Save(stream);
        }


        /***********************************************************************************/
        /*
            Form controls:
        */
        /***********************************************************************************/

        private void button_BrowseSaveDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog1.SelectedPath != "")
                {
                    ImgData.saveDir = folderBrowserDialog1.SelectedPath + "\\";
                }
            }
        }

        private void button_COMPortRefresh_Click(object sender, EventArgs e)
        {
            comboBox_COMPort.Items.Clear();
            comboBox_COMPort.Items.AddRange(SerialPort.GetPortNames());
        }

        private void comboBox_COMPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox_COMPort.Text;
            try
            {
                // Open serial port:
                serialPort1.Open();
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();

                // Enable serial comms and set scan parameters:
                serialPort1.Write("SE");
                Int16 bias = (Int16)(numericUpDown_bias.Value / SPM.biasLSBsize);
                setBias(bias);
                Int16 setpoint = (Int16)(numericUpDown_setpoint.Value * SPM.transimpedance / SPM.setpointLSBsize);
                setSetpoint(setpoint);
                UInt16 imgSize = (UInt16)numericUpDown_imgSize.Value;
                setImgSize(imgSize);
                int scanSize = (int)(numericUpDown_scanSize.Value / SPM.xyLSBsize);
                setscanSize(scanSize);
                decimal lineRate = (decimal)numericUpDown_lineRate.Value;
                setlineRate(lineRate);
                int Kp = (int)numericUpDownPGain.Value;
                setKp(Kp);
                int Ki = (int)numericUpDownIGain.Value;
                setKi(Ki);

                ImgData.zScale = (int)(numericUpDown_scale.Value / SPM.zLSBsize);
                ImgData.iScale = (int)numericUpDown_eScale.Value;
                chart1.ChartAreas[0].AxisY.Maximum = (double)numericUpDown_scale.Value;
                chart1.ChartAreas[0].AxisY.Minimum = -(double)numericUpDown_scale.Value;
                
                // Create new bitmaps:
                ImgData.imgA = new Bitmap(
                    (UInt16)numericUpDown_imgSize.Value, 
                    (UInt16)numericUpDown_imgSize.Value, 
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                pictureBox1.Image = ImgData.imgA;
                pictureBox1.Refresh();
                ImgData.imgB = new Bitmap(
                    (UInt16)numericUpDown_imgSize.Value,
                    (UInt16)numericUpDown_imgSize.Value,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                pictureBox2.Image = ImgData.imgB;
                pictureBox2.Refresh();
            }
            catch
            {
                MessageBox.Show("There was an error. Please make sure that the correct port " +
                    "was selected, and the device plugged in.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            engage();
        }

        private void button_Retract_Click(object sender, EventArgs e)
        {
            retract();
        }

        private void numericUpDown_bias_ValueChanged(object sender, EventArgs e)
        {
            Int16 bias = (Int16)(numericUpDown_bias.Value / SPM.biasLSBsize);
            setBias(bias);
        }

        private void numericUpDown_setpoint_ValueChanged(object sender, EventArgs e)
        {
            Int16 setpoint = (Int16)(numericUpDown_setpoint.Value * SPM.transimpedance / SPM.setpointLSBsize);
            setSetpoint(setpoint);
        }

        private void numericUpDown_imgSize_ValueChanged(object sender, EventArgs e)
        {
            UInt16 imgSize = (UInt16)numericUpDown_imgSize.Value;
            setImgSize(imgSize);

            ImgData.imgA = new Bitmap(imgSize, imgSize, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pictureBox1.Invoke(new MethodInvoker(delegate
            {
                pictureBox1.Image = ImgData.imgA;
                pictureBox1.Refresh();
            }));

            ImgData.imgB = new Bitmap(imgSize, imgSize, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pictureBox2.Invoke(new MethodInvoker(delegate
            {
                pictureBox2.Image = ImgData.imgB;
                pictureBox2.Refresh();
            }));

            chart1.Invoke(new MethodInvoker(delegate
            {
                chart1.ChartAreas[0].AxisX.Maximum = imgSize;
            }));

            ImgData.dataZTrace = new Int32[imgSize, imgSize];
            ImgData.dataZRetrace = new Int32[imgSize, imgSize];
            ImgData.dataETrace = new Int32[imgSize, imgSize];
            ImgData.dataERetrace = new Int32[imgSize, imgSize];
            ImgData.imgSize = imgSize;
        }

        private void numericUpDown_scanSize_ValueChanged(object sender, EventArgs e)
        {
            int scanSize = (int)(numericUpDown_scanSize.Value / SPM.xyLSBsize);
            setscanSize(scanSize);
        }

        private void numericUpDown_lineRate_ValueChanged(object sender, EventArgs e)
        {
            decimal lineRate = numericUpDown_lineRate.Value;
            setlineRate(lineRate);
        }

        private void numericUpDownPGain_ValueChanged(object sender, EventArgs e)
        {
            int Kp = (int)numericUpDownPGain.Value;
            setKp(Kp);
        }

        private void numericUpDownIGain_ValueChanged(object sender, EventArgs e)
        {
            int Ki = (int)numericUpDownIGain.Value;
            setKi(Ki);
        }

        private void numericUpDown_scale_ValueChanged(object sender, EventArgs e)
        {
            ImgData.zScale = (int)(numericUpDown_scale.Value / SPM.zLSBsize);
            chart1.ChartAreas[0].AxisY.Maximum = (double)numericUpDown_scale.Value;
            chart1.ChartAreas[0].AxisY.Minimum = -(double)numericUpDown_scale.Value;
        }

        private void numericUpDown_eScale_ValueChanged(object sender, EventArgs e)
        {
            ImgData.iScale = (int)numericUpDown_eScale.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            System.Drawing.Point coordinates = me.Location;

            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int scanSize = (int)numericUpDown_scanSize.Value;
                int x0 = (coordinates.X - pictureBox1.Width / 2) * scanSize;
                int y0 = (coordinates.Y - pictureBox1.Height / 2) * scanSize;
                setOffset(x0, y0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ImgData.saveNumber = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form configForm = new Form2();
            configForm.ShowDialog();
        }


        /***********************************************************************************/
        /*
            Serial commands:
        */
        /***********************************************************************************/

        public void setBias(Int16 bias)
        {
            string command = "SB " + bias;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void setSetpoint(Int16 setpoint)
        {
            string command = "SP " + setpoint;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void setImgSize(UInt16 imgSize)
        {
            string command = "IP " + imgSize;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void setscanSize(int scanSize)
        {
            string command = "SS " + scanSize;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void setOffset(int x0, int y0)
        {
            string command1 = "XO " + x0;
            string command2 = "YO " + y0;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command1);
                System.Threading.Thread.Sleep(10);
                serialPort1.Write(command2);
            }
        }
        
        public void setlineRate(decimal lineRate)
        {
            // Multiply lineRate by 100 for transmission:
            string command = "LR " + (int)(lineRate * 100.0M);

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void setKp(int Kp)
        {
            string command = "KP " + Kp;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void setKi(int Ki)
        {
            string command = "KI " + Ki;

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void engage()
        {
            string command = "TE";

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void retract()
        {
            string command = "TR";

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void enableScanning()
        {
            string command = "EN";

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }

        public void disableScanning()
        {
            string command = "DL";

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(command);
            }
        }
    }
}
