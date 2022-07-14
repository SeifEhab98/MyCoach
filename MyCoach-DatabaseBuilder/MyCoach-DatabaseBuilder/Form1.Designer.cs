namespace MyCoach_DatabaseBuilder
{
    using System.Windows.Forms;
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartSession = new System.Windows.Forms.Button();
            this.btnEndSession = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tvKinectStatus = new System.Windows.Forms.Label();
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.etExerciseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.videoPlayback = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tvKinectSensorName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.etExcelPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.etUserName = new System.Windows.Forms.TextBox();
            this.ivRecordingStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivRecordingStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartSession
            // 
            this.btnStartSession.Location = new System.Drawing.Point(591, 121);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(230, 48);
            this.btnStartSession.TabIndex = 0;
            this.btnStartSession.Text = "Start Session";
            this.btnStartSession.UseVisualStyleBackColor = true;
            this.btnStartSession.Click += new System.EventHandler(this.onBtnStartSessionClicked);
            // 
            // btnEndSession
            // 
            this.btnEndSession.Location = new System.Drawing.Point(591, 175);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(230, 48);
            this.btnEndSession.TabIndex = 1;
            this.btnEndSession.Text = "End Session";
            this.btnEndSession.UseVisualStyleBackColor = true;
            this.btnEndSession.Click += new System.EventHandler(this.onBtnEndSessionClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(585, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kinect Status:";
            // 
            // tvKinectStatus
            // 
            this.tvKinectStatus.AutoSize = true;
            this.tvKinectStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.tvKinectStatus.Location = new System.Drawing.Point(676, 45);
            this.tvKinectStatus.Name = "tvKinectStatus";
            this.tvKinectStatus.Size = new System.Drawing.Size(16, 13);
            this.tvKinectStatus.TabIndex = 3;
            this.tvKinectStatus.Text = "---";
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Location = new System.Drawing.Point(591, 344);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(230, 48);
            this.btnStartRecording.TabIndex = 7;
            this.btnStartRecording.Text = "Start / End Recording";
            this.btnStartRecording.UseVisualStyleBackColor = true;
            this.btnStartRecording.Click += new System.EventHandler(this.onBtnStartEndRecordingClicked);
            // 
            // etExerciseName
            // 
            this.etExerciseName.Location = new System.Drawing.Point(699, 273);
            this.etExerciseName.Name = "etExerciseName";
            this.etExerciseName.Size = new System.Drawing.Size(122, 20);
            this.etExerciseName.TabIndex = 8;
            this.etExerciseName.TextChanged += new System.EventHandler(this.etExerciseName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(587, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Exercise Name";
            // 
            // videoPlayback
            // 
            this.videoPlayback.Location = new System.Drawing.Point(10, 10);
            this.videoPlayback.Name = "videoPlayback";
            this.videoPlayback.Size = new System.Drawing.Size(549, 416);
            this.videoPlayback.TabIndex = 13;
            this.videoPlayback.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(584, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kinect Sensor:";
            // 
            // tvKinectSensorName
            // 
            this.tvKinectSensorName.AutoSize = true;
            this.tvKinectSensorName.ForeColor = System.Drawing.Color.ForestGreen;
            this.tvKinectSensorName.Location = new System.Drawing.Point(675, 14);
            this.tvKinectSensorName.Name = "tvKinectSensorName";
            this.tvKinectSensorName.Size = new System.Drawing.Size(16, 13);
            this.tvKinectSensorName.TabIndex = 15;
            this.tvKinectSensorName.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(587, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Excel Path";
            // 
            // etExcelPath
            // 
            this.etExcelPath.Location = new System.Drawing.Point(671, 88);
            this.etExcelPath.Name = "etExcelPath";
            this.etExcelPath.Size = new System.Drawing.Size(150, 20);
            this.etExcelPath.TabIndex = 16;
            this.etExcelPath.TextChanged += new System.EventHandler(this.etExcelPath_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(587, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "Trainee Name";
            // 
            // etUserName
            // 
            this.etUserName.Location = new System.Drawing.Point(699, 247);
            this.etUserName.Name = "etUserName";
            this.etUserName.Size = new System.Drawing.Size(122, 20);
            this.etUserName.TabIndex = 18;
            this.etUserName.TextChanged += new System.EventHandler(this.etUserName_TextChanged);
            // 
            // ivRecordingStatus
            // 
            this.ivRecordingStatus.BackColor = System.Drawing.Color.Red;
            this.ivRecordingStatus.Location = new System.Drawing.Point(690, 314);
            this.ivRecordingStatus.Name = "ivRecordingStatus";
            this.ivRecordingStatus.Size = new System.Drawing.Size(30, 17);
            this.ivRecordingStatus.TabIndex = 20;
            this.ivRecordingStatus.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 442);
            this.Controls.Add(this.ivRecordingStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.etUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.etExcelPath);
            this.Controls.Add(this.tvKinectSensorName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.videoPlayback);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.etExerciseName);
            this.Controls.Add(this.btnStartRecording);
            this.Controls.Add(this.tvKinectStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEndSession);
            this.Controls.Add(this.btnStartSession);
            this.Name = "Form1";
            this.Text = "MyCoach-SkeletonTracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ivRecordingStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartSession;
        private Button btnEndSession;
        private Label label1;
        private Label tvKinectStatus;
        private Button btnStartRecording;
        private TextBox etExerciseName;
        private Label label3;
        private PictureBox videoPlayback;
        private Label label7;
        private Label tvKinectSensorName;
        private Label label2;
        private TextBox etExcelPath;
        private Label label4;
        private TextBox etUserName;
        private PictureBox ivRecordingStatus;
    }
}

