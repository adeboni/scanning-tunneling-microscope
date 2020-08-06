namespace STM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.scanButton = new System.Windows.Forms.Button();
            this.label_bias = new System.Windows.Forms.Label();
            this.label_setpoint = new System.Windows.Forms.Label();
            this.label_volts = new System.Windows.Forms.Label();
            this.label_nanoamps = new System.Windows.Forms.Label();
            this.label_imgSize = new System.Windows.Forms.Label();
            this.label_stepSize = new System.Windows.Forms.Label();
            this.lebel_timeStep = new System.Windows.Forms.Label();
            this.label_pixels = new System.Windows.Forms.Label();
            this.label_nanometers = new System.Windows.Forms.Label();
            this.label_microseconds = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown_bias = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_setpoint = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_imgSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_scanSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_lineRate = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDown_scale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownPGain = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownIGain = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.numericUpDown_eScale = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBarZ = new System.Windows.Forms.ProgressBar();
            this.ScanControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.button_Retract = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_COMPortRefresh = new System.Windows.Forms.Button();
            this.comboBox_COMPort = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.checkBox_Overwrite = new System.Windows.Forms.CheckBox();
            this.button_BrowseSaveDirectory = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_imgSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_scanSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_lineRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_eScale)).BeginInit();
            this.ScanControlsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM16";
            this.serialPort1.ReadBufferSize = 262144;
            // 
            // scanButton
            // 
            this.scanButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.scanButton.Location = new System.Drawing.Point(12, 269);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(120, 53);
            this.scanButton.TabIndex = 1;
            this.scanButton.Text = "Engage tip";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_bias
            // 
            this.label_bias.AutoSize = true;
            this.label_bias.Location = new System.Drawing.Point(1128, 38);
            this.label_bias.Name = "label_bias";
            this.label_bias.Size = new System.Drawing.Size(68, 13);
            this.label_bias.TabIndex = 7;
            this.label_bias.Text = "Sample Bias:";
            // 
            // label_setpoint
            // 
            this.label_setpoint.AutoSize = true;
            this.label_setpoint.Location = new System.Drawing.Point(1147, 64);
            this.label_setpoint.Name = "label_setpoint";
            this.label_setpoint.Size = new System.Drawing.Size(49, 13);
            this.label_setpoint.TabIndex = 8;
            this.label_setpoint.Text = "Setpoint:";
            // 
            // label_volts
            // 
            this.label_volts.AutoSize = true;
            this.label_volts.Location = new System.Drawing.Point(1290, 38);
            this.label_volts.Name = "label_volts";
            this.label_volts.Size = new System.Drawing.Size(22, 13);
            this.label_volts.TabIndex = 9;
            this.label_volts.Text = "mV";
            // 
            // label_nanoamps
            // 
            this.label_nanoamps.AutoSize = true;
            this.label_nanoamps.Location = new System.Drawing.Point(1290, 64);
            this.label_nanoamps.Name = "label_nanoamps";
            this.label_nanoamps.Size = new System.Drawing.Size(20, 13);
            this.label_nanoamps.TabIndex = 10;
            this.label_nanoamps.Text = "nA";
            // 
            // label_imgSize
            // 
            this.label_imgSize.AutoSize = true;
            this.label_imgSize.Location = new System.Drawing.Point(1108, 89);
            this.label_imgSize.Name = "label_imgSize";
            this.label_imgSize.Size = new System.Drawing.Size(88, 13);
            this.label_imgSize.TabIndex = 11;
            this.label_imgSize.Text = "Scan Resolution:";
            // 
            // label_stepSize
            // 
            this.label_stepSize.AutoSize = true;
            this.label_stepSize.Location = new System.Drawing.Point(1137, 116);
            this.label_stepSize.Name = "label_stepSize";
            this.label_stepSize.Size = new System.Drawing.Size(58, 13);
            this.label_stepSize.TabIndex = 12;
            this.label_stepSize.Text = "Scan Size:";
            // 
            // lebel_timeStep
            // 
            this.lebel_timeStep.AutoSize = true;
            this.lebel_timeStep.Location = new System.Drawing.Point(1137, 142);
            this.lebel_timeStep.Name = "lebel_timeStep";
            this.lebel_timeStep.Size = new System.Drawing.Size(56, 13);
            this.lebel_timeStep.TabIndex = 13;
            this.lebel_timeStep.Text = "Line Rate:";
            // 
            // label_pixels
            // 
            this.label_pixels.AutoSize = true;
            this.label_pixels.Location = new System.Drawing.Point(1290, 90);
            this.label_pixels.Name = "label_pixels";
            this.label_pixels.Size = new System.Drawing.Size(34, 13);
            this.label_pixels.TabIndex = 14;
            this.label_pixels.Text = "Pixels";
            // 
            // label_nanometers
            // 
            this.label_nanometers.AutoSize = true;
            this.label_nanometers.Location = new System.Drawing.Point(1290, 116);
            this.label_nanometers.Name = "label_nanometers";
            this.label_nanometers.Size = new System.Drawing.Size(21, 13);
            this.label_nanometers.TabIndex = 15;
            this.label_nanometers.Text = "nm";
            // 
            // label_microseconds
            // 
            this.label_microseconds.AutoSize = true;
            this.label_microseconds.Location = new System.Drawing.Point(1290, 142);
            this.label_microseconds.Name = "label_microseconds";
            this.label_microseconds.Size = new System.Drawing.Size(20, 13);
            this.label_microseconds.TabIndex = 16;
            this.label_microseconds.Text = "Hz";
            // 
            // numericUpDown_bias
            // 
            this.numericUpDown_bias.Increment = new decimal(new int[] {
            305175781,
            0,
            0,
            589824});
            this.numericUpDown_bias.Location = new System.Drawing.Point(1202, 36);
            this.numericUpDown_bias.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_bias.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_bias.Name = "numericUpDown_bias";
            this.numericUpDown_bias.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_bias.TabIndex = 17;
            this.numericUpDown_bias.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_bias.ValueChanged += new System.EventHandler(this.numericUpDown_bias_ValueChanged);
            // 
            // numericUpDown_setpoint
            // 
            this.numericUpDown_setpoint.DecimalPlaces = 2;
            this.numericUpDown_setpoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_setpoint.Location = new System.Drawing.Point(1202, 62);
            this.numericUpDown_setpoint.Name = "numericUpDown_setpoint";
            this.numericUpDown_setpoint.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_setpoint.TabIndex = 18;
            this.numericUpDown_setpoint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_setpoint.ValueChanged += new System.EventHandler(this.numericUpDown_setpoint_ValueChanged);
            // 
            // numericUpDown_imgSize
            // 
            this.numericUpDown_imgSize.Location = new System.Drawing.Point(1202, 87);
            this.numericUpDown_imgSize.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericUpDown_imgSize.Name = "numericUpDown_imgSize";
            this.numericUpDown_imgSize.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_imgSize.TabIndex = 19;
            this.numericUpDown_imgSize.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.numericUpDown_imgSize.ValueChanged += new System.EventHandler(this.numericUpDown_imgSize_ValueChanged);
            // 
            // numericUpDown_scanSize
            // 
            this.numericUpDown_scanSize.Increment = new decimal(new int[] {
            168,
            0,
            0,
            327680});
            this.numericUpDown_scanSize.Location = new System.Drawing.Point(1202, 113);
            this.numericUpDown_scanSize.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.numericUpDown_scanSize.Name = "numericUpDown_scanSize";
            this.numericUpDown_scanSize.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_scanSize.TabIndex = 20;
            this.numericUpDown_scanSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_scanSize.ValueChanged += new System.EventHandler(this.numericUpDown_scanSize_ValueChanged);
            // 
            // numericUpDown_lineRate
            // 
            this.numericUpDown_lineRate.DecimalPlaces = 2;
            this.numericUpDown_lineRate.Location = new System.Drawing.Point(1202, 139);
            this.numericUpDown_lineRate.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_lineRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_lineRate.Name = "numericUpDown_lineRate";
            this.numericUpDown_lineRate.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_lineRate.TabIndex = 21;
            this.numericUpDown_lineRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_lineRate.ValueChanged += new System.EventHandler(this.numericUpDown_lineRate_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisY.Title = "Height (nm)";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 530);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.Blue;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Color = System.Drawing.Color.Red;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1030, 161);
            this.chart1.TabIndex = 23;
            this.chart1.Text = "chart1";
            // 
            // numericUpDown_scale
            // 
            this.numericUpDown_scale.DecimalPlaces = 2;
            this.numericUpDown_scale.Location = new System.Drawing.Point(1202, 217);
            this.numericUpDown_scale.Maximum = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            this.numericUpDown_scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_scale.Name = "numericUpDown_scale";
            this.numericUpDown_scale.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_scale.TabIndex = 26;
            this.numericUpDown_scale.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_scale.ValueChanged += new System.EventHandler(this.numericUpDown_scale_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1290, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "nm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1148, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Z-Scale:";
            // 
            // numericUpDownPGain
            // 
            this.numericUpDownPGain.Location = new System.Drawing.Point(1202, 165);
            this.numericUpDownPGain.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownPGain.Name = "numericUpDownPGain";
            this.numericUpDownPGain.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownPGain.TabIndex = 29;
            this.numericUpDownPGain.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPGain.ValueChanged += new System.EventHandler(this.numericUpDownPGain_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1153, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "P-Gain:";
            // 
            // numericUpDownIGain
            // 
            this.numericUpDownIGain.Location = new System.Drawing.Point(1202, 191);
            this.numericUpDownIGain.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownIGain.Name = "numericUpDownIGain";
            this.numericUpDownIGain.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownIGain.TabIndex = 32;
            this.numericUpDownIGain.Value = new decimal(new int[] {
            300000,
            0,
            0,
            0});
            this.numericUpDownIGain.ValueChanged += new System.EventHandler(this.numericUpDownIGain_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "I-Gain:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(530, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(512, 512);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // numericUpDown_eScale
            // 
            this.numericUpDown_eScale.Location = new System.Drawing.Point(1202, 243);
            this.numericUpDown_eScale.Maximum = new decimal(new int[] {
            524287,
            0,
            0,
            0});
            this.numericUpDown_eScale.Name = "numericUpDown_eScale";
            this.numericUpDown_eScale.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_eScale.TabIndex = 40;
            this.numericUpDown_eScale.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_eScale.ValueChanged += new System.EventHandler(this.numericUpDown_eScale_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1290, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "LSBs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "E-Scale:";
            // 
            // progressBarZ
            // 
            this.progressBarZ.Location = new System.Drawing.Point(6, 19);
            this.progressBarZ.Maximum = 1048576;
            this.progressBarZ.Name = "progressBarZ";
            this.progressBarZ.Size = new System.Drawing.Size(271, 23);
            this.progressBarZ.TabIndex = 41;
            this.progressBarZ.Value = 524288;
            // 
            // ScanControlsGroupBox
            // 
            this.ScanControlsGroupBox.Controls.Add(this.button_Retract);
            this.ScanControlsGroupBox.Controls.Add(this.label5);
            this.ScanControlsGroupBox.Controls.Add(this.label6);
            this.ScanControlsGroupBox.Controls.Add(this.scanButton);
            this.ScanControlsGroupBox.Location = new System.Drawing.Point(1064, 12);
            this.ScanControlsGroupBox.Name = "ScanControlsGroupBox";
            this.ScanControlsGroupBox.Size = new System.Drawing.Size(274, 338);
            this.ScanControlsGroupBox.TabIndex = 42;
            this.ScanControlsGroupBox.TabStop = false;
            this.ScanControlsGroupBox.Text = "Scan Controls";
            // 
            // button_Retract
            // 
            this.button_Retract.Location = new System.Drawing.Point(138, 269);
            this.button_Retract.Name = "button_Retract";
            this.button_Retract.Size = new System.Drawing.Size(120, 53);
            this.button_Retract.TabIndex = 48;
            this.button_Retract.Text = "Retract tip";
            this.button_Retract.UseVisualStyleBackColor = true;
            this.button_Retract.Click += new System.EventHandler(this.button_Retract_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.progressBarZ);
            this.groupBox1.Location = new System.Drawing.Point(1064, 566);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 64);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Z-piezo voltage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Extended";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(223, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Retracted";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_COMPortRefresh);
            this.groupBox3.Controls.Add(this.comboBox_COMPort);
            this.groupBox3.Location = new System.Drawing.Point(1064, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 52);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "COM port";
            // 
            // button_COMPortRefresh
            // 
            this.button_COMPortRefresh.Location = new System.Drawing.Point(111, 17);
            this.button_COMPortRefresh.Name = "button_COMPortRefresh";
            this.button_COMPortRefresh.Size = new System.Drawing.Size(75, 23);
            this.button_COMPortRefresh.TabIndex = 1;
            this.button_COMPortRefresh.Text = "Refresh";
            this.button_COMPortRefresh.UseVisualStyleBackColor = true;
            this.button_COMPortRefresh.Click += new System.EventHandler(this.button_COMPortRefresh_Click);
            // 
            // comboBox_COMPort
            // 
            this.comboBox_COMPort.FormattingEnabled = true;
            this.comboBox_COMPort.Location = new System.Drawing.Point(6, 19);
            this.comboBox_COMPort.Name = "comboBox_COMPort";
            this.comboBox_COMPort.Size = new System.Drawing.Size(97, 21);
            this.comboBox_COMPort.TabIndex = 0;
            this.comboBox_COMPort.SelectedIndexChanged += new System.EventHandler(this.comboBox_COMPort_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox_fileName);
            this.groupBox4.Controls.Add(this.checkBox_Overwrite);
            this.groupBox4.Controls.Add(this.button_BrowseSaveDirectory);
            this.groupBox4.Location = new System.Drawing.Point(1064, 455);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 88);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Save directory";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "File name:";
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Location = new System.Drawing.Point(73, 56);
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.Size = new System.Drawing.Size(173, 20);
            this.textBox_fileName.TabIndex = 48;
            this.textBox_fileName.Text = "STM_Scan";
            this.textBox_fileName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBox_Overwrite
            // 
            this.checkBox_Overwrite.AutoSize = true;
            this.checkBox_Overwrite.Checked = true;
            this.checkBox_Overwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Overwrite.Location = new System.Drawing.Point(106, 23);
            this.checkBox_Overwrite.Name = "checkBox_Overwrite";
            this.checkBox_Overwrite.Size = new System.Drawing.Size(145, 17);
            this.checkBox_Overwrite.TabIndex = 1;
            this.checkBox_Overwrite.Text = "Overwrite previous scans";
            this.checkBox_Overwrite.UseVisualStyleBackColor = true;
            // 
            // button_BrowseSaveDirectory
            // 
            this.button_BrowseSaveDirectory.Location = new System.Drawing.Point(6, 19);
            this.button_BrowseSaveDirectory.Name = "button_BrowseSaveDirectory";
            this.button_BrowseSaveDirectory.Size = new System.Drawing.Size(75, 23);
            this.button_BrowseSaveDirectory.TabIndex = 0;
            this.button_BrowseSaveDirectory.Text = "Browse";
            this.button_BrowseSaveDirectory.UseVisualStyleBackColor = true;
            this.button_BrowseSaveDirectory.Click += new System.EventHandler(this.button_BrowseSaveDirectory_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1212, 668);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "STM Configuration";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1362, 703);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.numericUpDown_eScale);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.numericUpDownIGain);
            this.Controls.Add(this.numericUpDownPGain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_scale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDown_lineRate);
            this.Controls.Add(this.numericUpDown_scanSize);
            this.Controls.Add(this.numericUpDown_imgSize);
            this.Controls.Add(this.numericUpDown_setpoint);
            this.Controls.Add(this.numericUpDown_bias);
            this.Controls.Add(this.label_microseconds);
            this.Controls.Add(this.label_nanometers);
            this.Controls.Add(this.label_pixels);
            this.Controls.Add(this.lebel_timeStep);
            this.Controls.Add(this.label_stepSize);
            this.Controls.Add(this.label_imgSize);
            this.Controls.Add(this.label_nanoamps);
            this.Controls.Add(this.label_volts);
            this.Controls.Add(this.label_setpoint);
            this.Controls.Add(this.label_bias);
            this.Controls.Add(this.ScanControlsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "STM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_imgSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_scanSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_lineRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_eScale)).EndInit();
            this.ScanControlsGroupBox.ResumeLayout(false);
            this.ScanControlsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Label label_bias;
        private System.Windows.Forms.Label label_setpoint;
        private System.Windows.Forms.Label label_volts;
        private System.Windows.Forms.Label label_nanoamps;
        private System.Windows.Forms.Label label_imgSize;
        private System.Windows.Forms.Label label_stepSize;
        private System.Windows.Forms.Label lebel_timeStep;
        private System.Windows.Forms.Label label_pixels;
        private System.Windows.Forms.Label label_nanometers;
        private System.Windows.Forms.Label label_microseconds;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown_bias;
        private System.Windows.Forms.NumericUpDown numericUpDown_setpoint;
        private System.Windows.Forms.NumericUpDown numericUpDown_imgSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_scanSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_lineRate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown numericUpDown_scale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownPGain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownIGain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown_eScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBarZ;
        private System.Windows.Forms.GroupBox ScanControlsGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_COMPortRefresh;
        private System.Windows.Forms.ComboBox comboBox_COMPort;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox_Overwrite;
        private System.Windows.Forms.Button button_BrowseSaveDirectory;
        private System.Windows.Forms.Button button_Retract;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.Button button1;
    }
}

