namespace STM
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.numericUpDown_zTravel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_xyTravel = new System.Windows.Forms.NumericUpDown();
            this.label_volts = new System.Windows.Forms.Label();
            this.label_nanoamps = new System.Windows.Forms.Label();
            this.label_nanometers = new System.Windows.Forms.Label();
            this.label_microseconds = new System.Windows.Forms.Label();
            this.lebel_timeStep = new System.Windows.Forms.Label();
            this.label_stepSize = new System.Windows.Forms.Label();
            this.label_bias = new System.Windows.Forms.Label();
            this.label_setpoint = new System.Windows.Forms.Label();
            this.numericUpDown_xyResolution = new System.Windows.Forms.NumericUpDown();
            this.label_pixels = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_zResolution = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_biasRange = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_STMPreampGain = new System.Windows.Forms.NumericUpDown();
            this.label_scanSize = new System.Windows.Forms.Label();
            this.STMSettingsLabel = new System.Windows.Forms.GroupBox();
            this.numericUpDown_setpointResolution = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_ADCRange = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_errorResolution = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_biasResolution = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_zTravel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xyTravel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xyResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_zResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_biasRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_STMPreampGain)).BeginInit();
            this.STMSettingsLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setpointResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ADCRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_errorResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_biasResolution)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_zTravel
            // 
            this.numericUpDown_zTravel.DecimalPlaces = 2;
            this.numericUpDown_zTravel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_zTravel.Location = new System.Drawing.Point(150, 62);
            this.numericUpDown_zTravel.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericUpDown_zTravel.Name = "numericUpDown_zTravel";
            this.numericUpDown_zTravel.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_zTravel.TabIndex = 54;
            this.numericUpDown_zTravel.Value = new decimal(new int[] {
            667,
            0,
            0,
            0});
            // 
            // numericUpDown_xyTravel
            // 
            this.numericUpDown_xyTravel.DecimalPlaces = 2;
            this.numericUpDown_xyTravel.Increment = new decimal(new int[] {
            305175781,
            0,
            0,
            589824});
            this.numericUpDown_xyTravel.Location = new System.Drawing.Point(150, 36);
            this.numericUpDown_xyTravel.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numericUpDown_xyTravel.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_xyTravel.Name = "numericUpDown_xyTravel";
            this.numericUpDown_xyTravel.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_xyTravel.TabIndex = 53;
            this.numericUpDown_xyTravel.Value = new decimal(new int[] {
            1680,
            0,
            0,
            0});
            // 
            // label_volts
            // 
            this.label_volts.AutoSize = true;
            this.label_volts.Location = new System.Drawing.Point(238, 38);
            this.label_volts.Name = "label_volts";
            this.label_volts.Size = new System.Drawing.Size(21, 13);
            this.label_volts.TabIndex = 45;
            this.label_volts.Text = "nm";
            // 
            // label_nanoamps
            // 
            this.label_nanoamps.AutoSize = true;
            this.label_nanoamps.Location = new System.Drawing.Point(238, 64);
            this.label_nanoamps.Name = "label_nanoamps";
            this.label_nanoamps.Size = new System.Drawing.Size(21, 13);
            this.label_nanoamps.TabIndex = 46;
            this.label_nanoamps.Text = "nm";
            // 
            // label_nanometers
            // 
            this.label_nanometers.AutoSize = true;
            this.label_nanometers.Location = new System.Drawing.Point(226, 130);
            this.label_nanometers.Name = "label_nanometers";
            this.label_nanometers.Size = new System.Drawing.Size(23, 13);
            this.label_nanometers.TabIndex = 51;
            this.label_nanometers.Text = "bits";
            // 
            // label_microseconds
            // 
            this.label_microseconds.AutoSize = true;
            this.label_microseconds.Location = new System.Drawing.Point(226, 156);
            this.label_microseconds.Name = "label_microseconds";
            this.label_microseconds.Size = new System.Drawing.Size(23, 13);
            this.label_microseconds.TabIndex = 52;
            this.label_microseconds.Text = "bits";
            // 
            // lebel_timeStep
            // 
            this.lebel_timeStep.AutoSize = true;
            this.lebel_timeStep.Location = new System.Drawing.Point(59, 156);
            this.lebel_timeStep.Name = "lebel_timeStep";
            this.lebel_timeStep.Size = new System.Drawing.Size(70, 13);
            this.lebel_timeStep.TabIndex = 49;
            this.lebel_timeStep.Text = "Z Resolution:";
            // 
            // label_stepSize
            // 
            this.label_stepSize.AutoSize = true;
            this.label_stepSize.Location = new System.Drawing.Point(52, 130);
            this.label_stepSize.Name = "label_stepSize";
            this.label_stepSize.Size = new System.Drawing.Size(77, 13);
            this.label_stepSize.TabIndex = 48;
            this.label_stepSize.Text = "XY Resolution:";
            // 
            // label_bias
            // 
            this.label_bias.AutoSize = true;
            this.label_bias.Location = new System.Drawing.Point(72, 26);
            this.label_bias.Name = "label_bias";
            this.label_bias.Size = new System.Drawing.Size(57, 13);
            this.label_bias.TabIndex = 43;
            this.label_bias.Text = "XY Travel:";
            // 
            // label_setpoint
            // 
            this.label_setpoint.AutoSize = true;
            this.label_setpoint.Location = new System.Drawing.Point(79, 52);
            this.label_setpoint.Name = "label_setpoint";
            this.label_setpoint.Size = new System.Drawing.Size(50, 13);
            this.label_setpoint.TabIndex = 44;
            this.label_setpoint.Text = "Z Travel:";
            // 
            // numericUpDown_xyResolution
            // 
            this.numericUpDown_xyResolution.Increment = new decimal(new int[] {
            168,
            0,
            0,
            327680});
            this.numericUpDown_xyResolution.Location = new System.Drawing.Point(138, 128);
            this.numericUpDown_xyResolution.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_xyResolution.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown_xyResolution.Name = "numericUpDown_xyResolution";
            this.numericUpDown_xyResolution.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_xyResolution.TabIndex = 56;
            this.numericUpDown_xyResolution.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label_pixels
            // 
            this.label_pixels.AutoSize = true;
            this.label_pixels.Location = new System.Drawing.Point(227, 78);
            this.label_pixels.Name = "label_pixels";
            this.label_pixels.Size = new System.Drawing.Size(14, 13);
            this.label_pixels.TabIndex = 50;
            this.label_pixels.Text = "V";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "STM Preamplifier Gain:";
            // 
            // numericUpDown_zResolution
            // 
            this.numericUpDown_zResolution.Location = new System.Drawing.Point(138, 154);
            this.numericUpDown_zResolution.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_zResolution.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown_zResolution.Name = "numericUpDown_zResolution";
            this.numericUpDown_zResolution.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_zResolution.TabIndex = 57;
            this.numericUpDown_zResolution.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDown_biasRange
            // 
            this.numericUpDown_biasRange.DecimalPlaces = 3;
            this.numericUpDown_biasRange.Location = new System.Drawing.Point(138, 76);
            this.numericUpDown_biasRange.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_biasRange.Name = "numericUpDown_biasRange";
            this.numericUpDown_biasRange.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_biasRange.TabIndex = 55;
            this.numericUpDown_biasRange.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "V / nA";
            // 
            // numericUpDown_STMPreampGain
            // 
            this.numericUpDown_STMPreampGain.DecimalPlaces = 4;
            this.numericUpDown_STMPreampGain.Location = new System.Drawing.Point(138, 258);
            this.numericUpDown_STMPreampGain.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_STMPreampGain.Name = "numericUpDown_STMPreampGain";
            this.numericUpDown_STMPreampGain.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_STMPreampGain.TabIndex = 62;
            this.numericUpDown_STMPreampGain.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label_scanSize
            // 
            this.label_scanSize.AutoSize = true;
            this.label_scanSize.Location = new System.Drawing.Point(25, 78);
            this.label_scanSize.Name = "label_scanSize";
            this.label_scanSize.Size = new System.Drawing.Size(104, 13);
            this.label_scanSize.TabIndex = 47;
            this.label_scanSize.Text = "Bias Voltage Range:";
            // 
            // STMSettingsLabel
            // 
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_setpointResolution);
            this.STMSettingsLabel.Controls.Add(this.label9);
            this.STMSettingsLabel.Controls.Add(this.label10);
            this.STMSettingsLabel.Controls.Add(this.label6);
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_ADCRange);
            this.STMSettingsLabel.Controls.Add(this.label8);
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_errorResolution);
            this.STMSettingsLabel.Controls.Add(this.label3);
            this.STMSettingsLabel.Controls.Add(this.label5);
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_biasResolution);
            this.STMSettingsLabel.Controls.Add(this.label1);
            this.STMSettingsLabel.Controls.Add(this.label2);
            this.STMSettingsLabel.Controls.Add(this.label_scanSize);
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_STMPreampGain);
            this.STMSettingsLabel.Controls.Add(this.label7);
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_zResolution);
            this.STMSettingsLabel.Controls.Add(this.label4);
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_biasRange);
            this.STMSettingsLabel.Controls.Add(this.label_pixels);
            this.STMSettingsLabel.Controls.Add(this.numericUpDown_xyResolution);
            this.STMSettingsLabel.Controls.Add(this.label_setpoint);
            this.STMSettingsLabel.Controls.Add(this.label_bias);
            this.STMSettingsLabel.Controls.Add(this.label_stepSize);
            this.STMSettingsLabel.Controls.Add(this.lebel_timeStep);
            this.STMSettingsLabel.Controls.Add(this.label_microseconds);
            this.STMSettingsLabel.Controls.Add(this.label_nanometers);
            this.STMSettingsLabel.Location = new System.Drawing.Point(12, 12);
            this.STMSettingsLabel.Name = "STMSettingsLabel";
            this.STMSettingsLabel.Size = new System.Drawing.Size(267, 293);
            this.STMSettingsLabel.TabIndex = 66;
            this.STMSettingsLabel.TabStop = false;
            this.STMSettingsLabel.Text = "STM Settings";
            this.STMSettingsLabel.Enter += new System.EventHandler(this.ScanControlsGroupBox_Enter);
            // 
            // numericUpDown_setpointResolution
            // 
            this.numericUpDown_setpointResolution.Location = new System.Drawing.Point(138, 232);
            this.numericUpDown_setpointResolution.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_setpointResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_setpointResolution.Name = "numericUpDown_setpointResolution";
            this.numericUpDown_setpointResolution.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_setpointResolution.TabIndex = 79;
            this.numericUpDown_setpointResolution.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 77;
            this.label9.Text = "Setpoint Resolution:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 78;
            this.label10.Text = "bits";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "ADC Range:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericUpDown_ADCRange
            // 
            this.numericUpDown_ADCRange.DecimalPlaces = 3;
            this.numericUpDown_ADCRange.Location = new System.Drawing.Point(138, 102);
            this.numericUpDown_ADCRange.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_ADCRange.Name = "numericUpDown_ADCRange";
            this.numericUpDown_ADCRange.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_ADCRange.TabIndex = 76;
            this.numericUpDown_ADCRange.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "V";
            // 
            // numericUpDown_errorResolution
            // 
            this.numericUpDown_errorResolution.Location = new System.Drawing.Point(138, 180);
            this.numericUpDown_errorResolution.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_errorResolution.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown_errorResolution.Name = "numericUpDown_errorResolution";
            this.numericUpDown_errorResolution.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_errorResolution.TabIndex = 73;
            this.numericUpDown_errorResolution.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Error Signal Resolution:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "bits";
            // 
            // numericUpDown_biasResolution
            // 
            this.numericUpDown_biasResolution.Location = new System.Drawing.Point(138, 206);
            this.numericUpDown_biasResolution.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown_biasResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_biasResolution.Name = "numericUpDown_biasResolution";
            this.numericUpDown_biasResolution.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown_biasResolution.TabIndex = 70;
            this.numericUpDown_biasResolution.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Bias Voltage Resolution:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "bits";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(204, 311);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 67;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 344);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.numericUpDown_zTravel);
            this.Controls.Add(this.numericUpDown_xyTravel);
            this.Controls.Add(this.label_nanoamps);
            this.Controls.Add(this.label_volts);
            this.Controls.Add(this.STMSettingsLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "STM Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_zTravel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xyTravel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_xyResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_zResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_biasRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_STMPreampGain)).EndInit();
            this.STMSettingsLabel.ResumeLayout(false);
            this.STMSettingsLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setpointResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ADCRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_errorResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_biasResolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_zTravel;
        private System.Windows.Forms.NumericUpDown numericUpDown_xyTravel;
        private System.Windows.Forms.Label label_volts;
        private System.Windows.Forms.Label label_nanoamps;
        private System.Windows.Forms.Label label_nanometers;
        private System.Windows.Forms.Label label_microseconds;
        private System.Windows.Forms.Label lebel_timeStep;
        private System.Windows.Forms.Label label_stepSize;
        private System.Windows.Forms.Label label_bias;
        private System.Windows.Forms.Label label_setpoint;
        private System.Windows.Forms.NumericUpDown numericUpDown_xyResolution;
        private System.Windows.Forms.Label label_pixels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_zResolution;
        private System.Windows.Forms.NumericUpDown numericUpDown_biasRange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_STMPreampGain;
        private System.Windows.Forms.Label label_scanSize;
        private System.Windows.Forms.GroupBox STMSettingsLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown numericUpDown_biasResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_ADCRange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_errorResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_setpointResolution;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

    }
}