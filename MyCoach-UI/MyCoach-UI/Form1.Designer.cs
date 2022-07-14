namespace MyCoach_UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.ivRecordingStatus = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.etServerPort = new System.Windows.Forms.TextBox();
            this.tvKinectSensorName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.videoPlayback = new System.Windows.Forms.PictureBox();
            this.btnStartEndRecording = new System.Windows.Forms.Button();
            this.tvKinectStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEndSession = new System.Windows.Forms.Button();
            this.btnStartSession = new System.Windows.Forms.Button();
            this.radioButtonDeadLift = new System.Windows.Forms.RadioButton();
            this.radioButtonLateralRaise = new System.Windows.Forms.RadioButton();
            this.radioButtonTwist = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tvRightCounter = new System.Windows.Forms.Label();
            this.tvWrongCounter = new System.Windows.Forms.Label();
            this.excercisesGifView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ivRecordingStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.excercisesGifView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ivRecordingStatus
            // 
            this.ivRecordingStatus.BackColor = System.Drawing.Color.Red;
            this.ivRecordingStatus.Location = new System.Drawing.Point(666, 379);
            this.ivRecordingStatus.Name = "ivRecordingStatus";
            this.ivRecordingStatus.Size = new System.Drawing.Size(30, 17);
            this.ivRecordingStatus.TabIndex = 35;
            this.ivRecordingStatus.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(563, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 32;
            this.label2.Text = "Socket Server Port";
            // 
            // etServerPort
            // 
            this.etServerPort.Location = new System.Drawing.Point(706, 227);
            this.etServerPort.Name = "etServerPort";
            this.etServerPort.Size = new System.Drawing.Size(73, 20);
            this.etServerPort.TabIndex = 31;
            this.etServerPort.TextChanged += new System.EventHandler(this.etServerPort_TextChanged);
            // 
            // tvKinectSensorName
            // 
            this.tvKinectSensorName.AutoSize = true;
            this.tvKinectSensorName.ForeColor = System.Drawing.Color.ForestGreen;
            this.tvKinectSensorName.Location = new System.Drawing.Point(658, 162);
            this.tvKinectSensorName.Name = "tvKinectSensorName";
            this.tvKinectSensorName.Size = new System.Drawing.Size(16, 13);
            this.tvKinectSensorName.TabIndex = 30;
            this.tvKinectSensorName.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(567, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 19);
            this.label7.TabIndex = 29;
            this.label7.Text = "Kinect Sensor:";
            // 
            // videoPlayback
            // 
            this.videoPlayback.Location = new System.Drawing.Point(12, 44);
            this.videoPlayback.Name = "videoPlayback";
            this.videoPlayback.Size = new System.Drawing.Size(549, 416);
            this.videoPlayback.TabIndex = 28;
            this.videoPlayback.TabStop = false;
            // 
            // btnStartEndRecording
            // 
            this.btnStartEndRecording.Location = new System.Drawing.Point(567, 409);
            this.btnStartEndRecording.Name = "btnStartEndRecording";
            this.btnStartEndRecording.Size = new System.Drawing.Size(230, 48);
            this.btnStartEndRecording.TabIndex = 25;
            this.btnStartEndRecording.Text = "Start / End Recording";
            this.btnStartEndRecording.UseVisualStyleBackColor = true;
            this.btnStartEndRecording.Click += new System.EventHandler(this.btnStartEndRecording_Click);
            // 
            // tvKinectStatus
            // 
            this.tvKinectStatus.AutoSize = true;
            this.tvKinectStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.tvKinectStatus.Location = new System.Drawing.Point(659, 193);
            this.tvKinectStatus.Name = "tvKinectStatus";
            this.tvKinectStatus.Size = new System.Drawing.Size(16, 13);
            this.tvKinectStatus.TabIndex = 24;
            this.tvKinectStatus.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(568, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "Kinect Status:";
            // 
            // btnEndSession
            // 
            this.btnEndSession.Location = new System.Drawing.Point(567, 314);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(230, 48);
            this.btnEndSession.TabIndex = 22;
            this.btnEndSession.Text = "End Session";
            this.btnEndSession.UseVisualStyleBackColor = true;
            this.btnEndSession.Click += new System.EventHandler(this.btnEndSession_Click);
            // 
            // btnStartSession
            // 
            this.btnStartSession.Location = new System.Drawing.Point(567, 260);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(230, 48);
            this.btnStartSession.TabIndex = 21;
            this.btnStartSession.Text = "Start Session";
            this.btnStartSession.UseVisualStyleBackColor = true;
            this.btnStartSession.Click += new System.EventHandler(this.btnStartSession_Click);
            // 
            // radioButtonDeadLift
            // 
            this.radioButtonDeadLift.AutoSize = true;
            this.radioButtonDeadLift.Checked = true;
            this.radioButtonDeadLift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDeadLift.Location = new System.Drawing.Point(17, 12);
            this.radioButtonDeadLift.Name = "radioButtonDeadLift";
            this.radioButtonDeadLift.Size = new System.Drawing.Size(101, 24);
            this.radioButtonDeadLift.TabIndex = 36;
            this.radioButtonDeadLift.TabStop = true;
            this.radioButtonDeadLift.Text = "Dead Lift";
            this.radioButtonDeadLift.UseVisualStyleBackColor = true;
            this.radioButtonDeadLift.CheckedChanged += new System.EventHandler(this.radioButtonDeadLift_CheckedChanged);
            // 
            // radioButtonLateralRaise
            // 
            this.radioButtonLateralRaise.AutoSize = true;
            this.radioButtonLateralRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLateralRaise.Location = new System.Drawing.Point(271, 12);
            this.radioButtonLateralRaise.Name = "radioButtonLateralRaise";
            this.radioButtonLateralRaise.Size = new System.Drawing.Size(134, 24);
            this.radioButtonLateralRaise.TabIndex = 37;
            this.radioButtonLateralRaise.Text = "Lateral Raise";
            this.radioButtonLateralRaise.UseVisualStyleBackColor = true;
            this.radioButtonLateralRaise.CheckedChanged += new System.EventHandler(this.radioButtonLateralRaise_CheckedChanged);
            // 
            // radioButtonTwist
            // 
            this.radioButtonTwist.AutoSize = true;
            this.radioButtonTwist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTwist.Location = new System.Drawing.Point(156, 12);
            this.radioButtonTwist.Name = "radioButtonTwist";
            this.radioButtonTwist.Size = new System.Drawing.Size(68, 24);
            this.radioButtonTwist.TabIndex = 38;
            this.radioButtonTwist.Text = "Twist";
            this.radioButtonTwist.UseVisualStyleBackColor = true;
            this.radioButtonTwist.CheckedChanged += new System.EventHandler(this.radioButtonTwist_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "___________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(571, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 40;
            this.label4.Text = "Right";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(714, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 41;
            this.label6.Text = "Wrong";
            // 
            // tvRightCounter
            // 
            this.tvRightCounter.AutoSize = true;
            this.tvRightCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvRightCounter.ForeColor = System.Drawing.Color.Green;
            this.tvRightCounter.Location = new System.Drawing.Point(590, 89);
            this.tvRightCounter.Name = "tvRightCounter";
            this.tvRightCounter.Size = new System.Drawing.Size(21, 24);
            this.tvRightCounter.TabIndex = 42;
            this.tvRightCounter.Text = "0";
            // 
            // tvWrongCounter
            // 
            this.tvWrongCounter.AutoSize = true;
            this.tvWrongCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvWrongCounter.ForeColor = System.Drawing.Color.Red;
            this.tvWrongCounter.Location = new System.Drawing.Point(738, 89);
            this.tvWrongCounter.Name = "tvWrongCounter";
            this.tvWrongCounter.Size = new System.Drawing.Size(21, 24);
            this.tvWrongCounter.TabIndex = 43;
            this.tvWrongCounter.Text = "0";
            // 
            // excercisesGifView
            // 
            this.excercisesGifView.BackColor = System.Drawing.Color.Transparent;
            this.excercisesGifView.Image = ((System.Drawing.Image)(resources.GetObject("excercisesGifView.Image")));
            this.excercisesGifView.Location = new System.Drawing.Point(364, 232);
            this.excercisesGifView.Name = "excercisesGifView";
            this.excercisesGifView.Size = new System.Drawing.Size(185, 185);
            this.excercisesGifView.TabIndex = 44;
            this.excercisesGifView.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.excercisesGifView);
            this.Controls.Add(this.tvWrongCounter);
            this.Controls.Add(this.tvRightCounter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonTwist);
            this.Controls.Add(this.radioButtonLateralRaise);
            this.Controls.Add(this.radioButtonDeadLift);
            this.Controls.Add(this.ivRecordingStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.etServerPort);
            this.Controls.Add(this.tvKinectSensorName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.videoPlayback);
            this.Controls.Add(this.btnStartEndRecording);
            this.Controls.Add(this.tvKinectStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEndSession);
            this.Controls.Add(this.btnStartSession);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ivRecordingStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.excercisesGifView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ivRecordingStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox etServerPort;
        private System.Windows.Forms.Label tvKinectSensorName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox videoPlayback;
        private System.Windows.Forms.Button btnStartEndRecording;
        private System.Windows.Forms.Label tvKinectStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEndSession;
        private System.Windows.Forms.Button btnStartSession;
        private System.Windows.Forms.RadioButton radioButtonDeadLift;
        private System.Windows.Forms.RadioButton radioButtonLateralRaise;
        private System.Windows.Forms.RadioButton radioButtonTwist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tvRightCounter;
        private System.Windows.Forms.Label tvWrongCounter;
        private System.Windows.Forms.PictureBox excercisesGifView;
    }
}

