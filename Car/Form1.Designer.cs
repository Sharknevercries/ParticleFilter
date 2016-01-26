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
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblGPSY = new System.Windows.Forms.Label();
            this.lblGPSX = new System.Windows.Forms.Label();
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
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblEstimatedY = new System.Windows.Forms.Label();
            this.lblEstimatedX = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblCurvatureDf = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblCarCurvature = new System.Windows.Forms.Label();
            this.lblRoadCurvature = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblAzimuth = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblEarthAccelerationZ = new System.Windows.Forms.Label();
            this.lblEarthAccelerationY = new System.Windows.Forms.Label();
            this.lblEarthAccelerationX = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.lblEclipseTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(246, 513);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "當前讀取資料";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.lblGPSY);
            this.groupBox5.Controls.Add(this.lblGPSX);
            this.groupBox5.Controls.Add(this.lblV);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.lblLatitude);
            this.groupBox5.Controls.Add(this.lblLongtitude);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(6, 344);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(234, 162);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GPS";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 123);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(19, 16);
            this.label29.TabIndex = 20;
            this.label29.Text = "Y";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 98);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 16);
            this.label26.TabIndex = 19;
            this.label26.Text = "X";
            // 
            // lblGPSY
            // 
            this.lblGPSY.AutoSize = true;
            this.lblGPSY.Location = new System.Drawing.Point(79, 123);
            this.lblGPSY.Name = "lblGPSY";
            this.lblGPSY.Size = new System.Drawing.Size(16, 16);
            this.lblGPSY.TabIndex = 18;
            this.lblGPSY.Text = "0";
            // 
            // lblGPSX
            // 
            this.lblGPSX.AutoSize = true;
            this.lblGPSX.Location = new System.Drawing.Point(79, 98);
            this.lblGPSX.Name = "lblGPSX";
            this.lblGPSX.Size = new System.Drawing.Size(16, 16);
            this.lblGPSX.TabIndex = 17;
            this.lblGPSX.Text = "0";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(79, 73);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(16, 16);
            this.lblV.TabIndex = 14;
            this.lblV.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "v(位置差)";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(79, 48);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(16, 16);
            this.lblLatitude.TabIndex = 11;
            this.lblLatitude.Text = "0";
            // 
            // lblLongtitude
            // 
            this.lblLongtitude.AutoSize = true;
            this.lblLongtitude.Location = new System.Drawing.Point(79, 23);
            this.lblLongtitude.Name = "lblLongtitude";
            this.lblLongtitude.Size = new System.Drawing.Size(16, 16);
            this.lblLongtitude.TabIndex = 12;
            this.lblLongtitude.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 48);
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
            this.lblMagnetometerZ.Location = new System.Drawing.Point(28, 73);
            this.lblMagnetometerZ.Name = "lblMagnetometerZ";
            this.lblMagnetometerZ.Size = new System.Drawing.Size(16, 16);
            this.lblMagnetometerZ.TabIndex = 10;
            this.lblMagnetometerZ.Text = "0";
            // 
            // lblMagnetometerY
            // 
            this.lblMagnetometerY.AutoSize = true;
            this.lblMagnetometerY.Location = new System.Drawing.Point(28, 48);
            this.lblMagnetometerY.Name = "lblMagnetometerY";
            this.lblMagnetometerY.Size = new System.Drawing.Size(16, 16);
            this.lblMagnetometerY.TabIndex = 9;
            this.lblMagnetometerY.Text = "0";
            // 
            // lblMagnetometerX
            // 
            this.lblMagnetometerX.AutoSize = true;
            this.lblMagnetometerX.Location = new System.Drawing.Point(28, 23);
            this.lblMagnetometerX.Name = "lblMagnetometerX";
            this.lblMagnetometerX.Size = new System.Drawing.Size(16, 16);
            this.lblMagnetometerX.TabIndex = 9;
            this.lblMagnetometerX.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
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
            this.lblGyroscopeZ.Location = new System.Drawing.Point(28, 73);
            this.lblGyroscopeZ.Name = "lblGyroscopeZ";
            this.lblGyroscopeZ.Size = new System.Drawing.Size(16, 16);
            this.lblGyroscopeZ.TabIndex = 8;
            this.lblGyroscopeZ.Text = "0";
            // 
            // lblGyroscopeY
            // 
            this.lblGyroscopeY.AutoSize = true;
            this.lblGyroscopeY.Location = new System.Drawing.Point(28, 48);
            this.lblGyroscopeY.Name = "lblGyroscopeY";
            this.lblGyroscopeY.Size = new System.Drawing.Size(16, 16);
            this.lblGyroscopeY.TabIndex = 7;
            this.lblGyroscopeY.Text = "0";
            // 
            // lblGyroscopeX
            // 
            this.lblGyroscopeX.AutoSize = true;
            this.lblGyroscopeX.Location = new System.Drawing.Point(28, 23);
            this.lblGyroscopeX.Name = "lblGyroscopeX";
            this.lblGyroscopeX.Size = new System.Drawing.Size(16, 16);
            this.lblGyroscopeX.TabIndex = 6;
            this.lblGyroscopeX.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
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
            this.lblAccelerometerZ.Location = new System.Drawing.Point(28, 73);
            this.lblAccelerometerZ.Name = "lblAccelerometerZ";
            this.lblAccelerometerZ.Size = new System.Drawing.Size(16, 16);
            this.lblAccelerometerZ.TabIndex = 5;
            this.lblAccelerometerZ.Text = "0";
            // 
            // lblAccelerometerY
            // 
            this.lblAccelerometerY.AutoSize = true;
            this.lblAccelerometerY.Location = new System.Drawing.Point(28, 48);
            this.lblAccelerometerY.Name = "lblAccelerometerY";
            this.lblAccelerometerY.Size = new System.Drawing.Size(16, 16);
            this.lblAccelerometerY.TabIndex = 4;
            this.lblAccelerometerY.Text = "0";
            // 
            // lblAccelerometerX
            // 
            this.lblAccelerometerX.AutoSize = true;
            this.lblAccelerometerX.Location = new System.Drawing.Point(28, 23);
            this.lblAccelerometerX.Name = "lblAccelerometerX";
            this.lblAccelerometerX.Size = new System.Drawing.Size(16, 16);
            this.lblAccelerometerX.TabIndex = 3;
            this.lblAccelerometerX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
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
            this.groupBox6.Controls.Add(this.groupBox10);
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Font = new System.Drawing.Font("新細明體", 12F);
            this.groupBox6.Location = new System.Drawing.Point(264, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 513);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "結果";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lblResult);
            this.groupBox10.Location = new System.Drawing.Point(8, 392);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(234, 114);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "預測轉彎結果";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("新細明體", 30F);
            this.lblResult.Location = new System.Drawing.Point(48, 40);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(128, 40);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "label20";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblEstimatedY);
            this.groupBox9.Controls.Add(this.lblEstimatedX);
            this.groupBox9.Controls.Add(this.label27);
            this.groupBox9.Controls.Add(this.label28);
            this.groupBox9.Location = new System.Drawing.Point(6, 155);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(234, 100);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "預估位置";
            // 
            // lblEstimatedY
            // 
            this.lblEstimatedY.AutoSize = true;
            this.lblEstimatedY.Location = new System.Drawing.Point(28, 60);
            this.lblEstimatedY.Name = "lblEstimatedY";
            this.lblEstimatedY.Size = new System.Drawing.Size(16, 16);
            this.lblEstimatedY.TabIndex = 4;
            this.lblEstimatedY.Text = "0";
            // 
            // lblEstimatedX
            // 
            this.lblEstimatedX.AutoSize = true;
            this.lblEstimatedX.Location = new System.Drawing.Point(28, 23);
            this.lblEstimatedX.Name = "lblEstimatedX";
            this.lblEstimatedX.Size = new System.Drawing.Size(16, 16);
            this.lblEstimatedX.TabIndex = 3;
            this.lblEstimatedX.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(16, 16);
            this.label27.TabIndex = 1;
            this.label27.Text = "y";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 23);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(16, 16);
            this.label28.TabIndex = 0;
            this.label28.Text = "x";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblCurvatureDf);
            this.groupBox8.Controls.Add(this.label22);
            this.groupBox8.Controls.Add(this.lblCarCurvature);
            this.groupBox8.Controls.Add(this.lblRoadCurvature);
            this.groupBox8.Controls.Add(this.label23);
            this.groupBox8.Controls.Add(this.label24);
            this.groupBox8.Location = new System.Drawing.Point(8, 261);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(234, 122);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "曲率";
            // 
            // lblCurvatureDf
            // 
            this.lblCurvatureDf.AutoSize = true;
            this.lblCurvatureDf.Location = new System.Drawing.Point(68, 83);
            this.lblCurvatureDf.Name = "lblCurvatureDf";
            this.lblCurvatureDf.Size = new System.Drawing.Size(16, 16);
            this.lblCurvatureDf.TabIndex = 8;
            this.lblCurvatureDf.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 83);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 16);
            this.label22.TabIndex = 2;
            this.label22.Text = "曲率差";
            // 
            // lblCarCurvature
            // 
            this.lblCarCurvature.AutoSize = true;
            this.lblCarCurvature.Location = new System.Drawing.Point(52, 50);
            this.lblCarCurvature.Name = "lblCarCurvature";
            this.lblCarCurvature.Size = new System.Drawing.Size(16, 16);
            this.lblCarCurvature.TabIndex = 7;
            this.lblCarCurvature.Text = "0";
            // 
            // lblRoadCurvature
            // 
            this.lblRoadCurvature.AutoSize = true;
            this.lblRoadCurvature.Location = new System.Drawing.Point(52, 25);
            this.lblRoadCurvature.Name = "lblRoadCurvature";
            this.lblRoadCurvature.Size = new System.Drawing.Size(16, 16);
            this.lblRoadCurvature.TabIndex = 6;
            this.lblRoadCurvature.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 16);
            this.label23.TabIndex = 1;
            this.label23.Text = "車子";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 16);
            this.label24.TabIndex = 0;
            this.label24.Text = "道路";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblAzimuth);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.lblEarthAccelerationZ);
            this.groupBox7.Controls.Add(this.lblEarthAccelerationY);
            this.groupBox7.Controls.Add(this.lblEarthAccelerationX);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Location = new System.Drawing.Point(6, 26);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(234, 123);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "地球座標加速度";
            // 
            // lblAzimuth
            // 
            this.lblAzimuth.AutoSize = true;
            this.lblAzimuth.Location = new System.Drawing.Point(74, 93);
            this.lblAzimuth.Name = "lblAzimuth";
            this.lblAzimuth.Size = new System.Drawing.Size(16, 16);
            this.lblAzimuth.TabIndex = 7;
            this.lblAzimuth.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 16);
            this.label15.TabIndex = 6;
            this.label15.Text = "Azimuth";
            // 
            // lblEarthAccelerationZ
            // 
            this.lblEarthAccelerationZ.AutoSize = true;
            this.lblEarthAccelerationZ.Location = new System.Drawing.Point(28, 73);
            this.lblEarthAccelerationZ.Name = "lblEarthAccelerationZ";
            this.lblEarthAccelerationZ.Size = new System.Drawing.Size(16, 16);
            this.lblEarthAccelerationZ.TabIndex = 5;
            this.lblEarthAccelerationZ.Text = "0";
            // 
            // lblEarthAccelerationY
            // 
            this.lblEarthAccelerationY.AutoSize = true;
            this.lblEarthAccelerationY.Location = new System.Drawing.Point(28, 48);
            this.lblEarthAccelerationY.Name = "lblEarthAccelerationY";
            this.lblEarthAccelerationY.Size = new System.Drawing.Size(16, 16);
            this.lblEarthAccelerationY.TabIndex = 4;
            this.lblEarthAccelerationY.Text = "0";
            // 
            // lblEarthAccelerationX
            // 
            this.lblEarthAccelerationX.AutoSize = true;
            this.lblEarthAccelerationX.Location = new System.Drawing.Point(28, 23);
            this.lblEarthAccelerationX.Name = "lblEarthAccelerationX";
            this.lblEarthAccelerationX.Size = new System.Drawing.Size(16, 16);
            this.lblEarthAccelerationX.TabIndex = 3;
            this.lblEarthAccelerationX.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "z";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 16);
            this.label17.TabIndex = 1;
            this.label17.Text = "y";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 16);
            this.label18.TabIndex = 0;
            this.label18.Text = "x";
            // 
            // lbInfo
            // 
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.ItemHeight = 12;
            this.lbInfo.Location = new System.Drawing.Point(518, 12);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(267, 412);
            this.lbInfo.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnStart.Location = new System.Drawing.Point(791, 12);
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
            this.btnStop.Location = new System.Drawing.Point(791, 99);
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
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("新細明體", 12F);
            this.label21.Location = new System.Drawing.Point(854, 479);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 16);
            this.label21.TabIndex = 21;
            this.label21.Text = "EclipseTime";
            // 
            // lblEclipseTime
            // 
            this.lblEclipseTime.AutoSize = true;
            this.lblEclipseTime.Font = new System.Drawing.Font("新細明體", 12F);
            this.lblEclipseTime.Location = new System.Drawing.Point(854, 502);
            this.lblEclipseTime.Name = "lblEclipseTime";
            this.lblEclipseTime.Size = new System.Drawing.Size(16, 16);
            this.lblEclipseTime.TabIndex = 21;
            this.lblEclipseTime.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 534);
            this.Controls.Add(this.lblEclipseTime);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lbInfo);
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
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblEarthAccelerationZ;
        private System.Windows.Forms.Label lblEarthAccelerationY;
        private System.Windows.Forms.Label lblEarthAccelerationX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lblEstimatedY;
        private System.Windows.Forms.Label lblEstimatedX;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblCurvatureDf;
        private System.Windows.Forms.Label lblCarCurvature;
        private System.Windows.Forms.Label lblRoadCurvature;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblAzimuth;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblGPSY;
        private System.Windows.Forms.Label lblGPSX;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblEclipseTime;
    }
}

