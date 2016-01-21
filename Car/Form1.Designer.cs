namespace Car
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblV = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongtitude = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblMagnetometerZ = new System.Windows.Forms.Label();
            this.lblMagnetometerY = new System.Windows.Forms.Label();
            this.lblMagnetometerX = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblGyroscopeZ = new System.Windows.Forms.Label();
            this.lblGyroscopeY = new System.Windows.Forms.Label();
            this.lblGyroscopeX = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAccelerometerZ = new System.Windows.Forms.Label();
            this.lblAccelerometerY = new System.Windows.Forms.Label();
            this.lblAccelerometerX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 452);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "當前讀取資料";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblV);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.lblLatitude);
            this.groupBox5.Controls.Add(this.lblLongtitude);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(6, 344);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(234, 100);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GPS";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(178, 62);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(16, 16);
            this.lblV.TabIndex = 14;
            this.lblV.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "v";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(92, 62);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(16, 16);
            this.lblLatitude.TabIndex = 11;
            this.lblLatitude.Text = "0";
            // 
            // lblLongtitude
            // 
            this.lblLongtitude.AutoSize = true;
            this.lblLongtitude.Location = new System.Drawing.Point(6, 62);
            this.lblLongtitude.Name = "lblLongtitude";
            this.lblLongtitude.Size = new System.Drawing.Size(16, 16);
            this.lblLongtitude.TabIndex = 12;
            this.lblLongtitude.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "latitude";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "longitude";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblMagnetometerZ);
            this.groupBox4.Controls.Add(this.lblMagnetometerY);
            this.groupBox4.Controls.Add(this.lblMagnetometerX);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(6, 238);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(234, 100);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "磁力計";
            // 
            // lblMagnetometerZ
            // 
            this.lblMagnetometerZ.AutoSize = true;
            this.lblMagnetometerZ.Location = new System.Drawing.Point(178, 60);
            this.lblMagnetometerZ.Name = "lblMagnetometerZ";
            this.lblMagnetometerZ.Size = new System.Drawing.Size(16, 16);
            this.lblMagnetometerZ.TabIndex = 10;
            this.lblMagnetometerZ.Text = "0";
            // 
            // lblMagnetometerY
            // 
            this.lblMagnetometerY.AutoSize = true;
            this.lblMagnetometerY.Location = new System.Drawing.Point(92, 60);
            this.lblMagnetometerY.Name = "lblMagnetometerY";
            this.lblMagnetometerY.Size = new System.Drawing.Size(16, 16);
            this.lblMagnetometerY.TabIndex = 9;
            this.lblMagnetometerY.Text = "0";
            // 
            // lblMagnetometerX
            // 
            this.lblMagnetometerX.AutoSize = true;
            this.lblMagnetometerX.Location = new System.Drawing.Point(6, 60);
            this.lblMagnetometerX.Name = "lblMagnetometerX";
            this.lblMagnetometerX.Size = new System.Drawing.Size(16, 16);
            this.lblMagnetometerX.TabIndex = 9;
            this.lblMagnetometerX.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "x";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblGyroscopeZ);
            this.groupBox3.Controls.Add(this.lblGyroscopeY);
            this.groupBox3.Controls.Add(this.lblGyroscopeX);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "陀螺儀";
            // 
            // lblGyroscopeZ
            // 
            this.lblGyroscopeZ.AutoSize = true;
            this.lblGyroscopeZ.Location = new System.Drawing.Point(178, 61);
            this.lblGyroscopeZ.Name = "lblGyroscopeZ";
            this.lblGyroscopeZ.Size = new System.Drawing.Size(16, 16);
            this.lblGyroscopeZ.TabIndex = 8;
            this.lblGyroscopeZ.Text = "0";
            // 
            // lblGyroscopeY
            // 
            this.lblGyroscopeY.AutoSize = true;
            this.lblGyroscopeY.Location = new System.Drawing.Point(92, 61);
            this.lblGyroscopeY.Name = "lblGyroscopeY";
            this.lblGyroscopeY.Size = new System.Drawing.Size(16, 16);
            this.lblGyroscopeY.TabIndex = 7;
            this.lblGyroscopeY.Text = "0";
            // 
            // lblGyroscopeX
            // 
            this.lblGyroscopeX.AutoSize = true;
            this.lblGyroscopeX.Location = new System.Drawing.Point(6, 61);
            this.lblGyroscopeX.Name = "lblGyroscopeX";
            this.lblGyroscopeX.Size = new System.Drawing.Size(16, 16);
            this.lblGyroscopeX.TabIndex = 6;
            this.lblGyroscopeX.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "x";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAccelerometerZ);
            this.groupBox2.Controls.Add(this.lblAccelerometerY);
            this.groupBox2.Controls.Add(this.lblAccelerometerX);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "加速度";
            // 
            // lblAccelerometerZ
            // 
            this.lblAccelerometerZ.AutoSize = true;
            this.lblAccelerometerZ.Location = new System.Drawing.Point(178, 61);
            this.lblAccelerometerZ.Name = "lblAccelerometerZ";
            this.lblAccelerometerZ.Size = new System.Drawing.Size(16, 16);
            this.lblAccelerometerZ.TabIndex = 5;
            this.lblAccelerometerZ.Text = "0";
            // 
            // lblAccelerometerY
            // 
            this.lblAccelerometerY.AutoSize = true;
            this.lblAccelerometerY.Location = new System.Drawing.Point(92, 61);
            this.lblAccelerometerY.Name = "lblAccelerometerY";
            this.lblAccelerometerY.Size = new System.Drawing.Size(16, 16);
            this.lblAccelerometerY.TabIndex = 4;
            this.lblAccelerometerY.Text = "0";
            // 
            // lblAccelerometerX
            // 
            this.lblAccelerometerX.AutoSize = true;
            this.lblAccelerometerX.Location = new System.Drawing.Point(6, 61);
            this.lblAccelerometerX.Name = "lblAccelerometerX";
            this.lblAccelerometerX.Size = new System.Drawing.Size(16, 16);
            this.lblAccelerometerX.TabIndex = 3;
            this.lblAccelerometerX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "x";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbInfo);
            this.groupBox6.Font = new System.Drawing.Font("新細明體", 12F);
            this.groupBox6.Location = new System.Drawing.Point(264, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(426, 452);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "結果";
            // 
            // lbInfo
            // 
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 16;
            this.lbInfo.Location = new System.Drawing.Point(6, 26);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(414, 420);
            this.lbInfo.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnStart.Location = new System.Drawing.Point(841, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 81);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnStop.Location = new System.Drawing.Point(841, 99);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 81);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 475);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "車載計畫Demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongtitude;
        private System.Windows.Forms.Label lblMagnetometerZ;
        private System.Windows.Forms.Label lblMagnetometerY;
        private System.Windows.Forms.Label lblMagnetometerX;
        private System.Windows.Forms.Label lblGyroscopeZ;
        private System.Windows.Forms.Label lblGyroscopeY;
        private System.Windows.Forms.Label lblGyroscopeX;
        private System.Windows.Forms.Label lblAccelerometerZ;
        private System.Windows.Forms.Label lblAccelerometerY;
        private System.Windows.Forms.Label lblAccelerometerX;
        private System.Windows.Forms.Label lblV;
    }
}

