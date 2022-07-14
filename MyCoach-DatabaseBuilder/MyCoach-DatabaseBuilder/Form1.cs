using System;
using System.Windows.Forms;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Threading;
using Microsoft.Office.Interop.Excel;

namespace MyCoach_DatabaseBuilder
{
    public partial class Form1 : Form
    {
        private int lastExcelRow = 0;
        private int lastFrameNo = 0;
        private int currentPracticeNo = 0;
        private long currentSessionId = 0;

        private String currentExcelPath = "";
        private String currentUserName = "";
        private String currentExcerciseName = "";

        Microsoft.Office.Interop.Excel.Application oXL = null;
        _Workbook oWB = null;
        _Worksheet oSheet = null;

        private Boolean isSessionRunning = false;
        private Boolean isRecording = false;

        private KinectSensor sensor = null;
        private ColorImageFormat lastImageFormat;
        private byte[] pixelData;
        private Bitmap bitmapImage;

        private JointType[] jointsArray = {
            JointType.Head,
            JointType.Spine,
            JointType.HipCenter,
            JointType.HipRight,
            JointType.HipLeft,
            JointType.ShoulderCenter,
            JointType.ShoulderRight,
            JointType.ShoulderLeft,
            JointType.ElbowRight,
            JointType.ElbowLeft,
            JointType.WristRight,
            JointType.WristLeft,
            JointType.HandRight,
            JointType.HandLeft,
            JointType.KneeRight,
            JointType.KneeLeft,
            JointType.AnkleRight,
            JointType.AnkleLeft,
            JointType.FootRight,
            JointType.FootLeft
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitKinect();
        }

        private void InitKinect()
        {
            KinectSensorChooser sensorStatus = new KinectSensorChooser();
            sensorStatus.KinectChanged += KinectSensorChooserKinectChanged;
            sensorStatus.Start();
        }

        private void KinectSensorChooserKinectChanged(object sender, KinectChangedEventArgs e)
        {
            if (sensor != null)
            {
                sensor.SkeletonFrameReady -= KinectSkeletonFrameReady;
                sensor.ColorFrameReady -= kinectColorFrameReady;
            }

            sensor = e.NewSensor;

            if (sensor == null)
            {
                isSessionRunning = false;
                this.tvKinectStatus.Text = "Disconnected";
                this.tvKinectSensorName.Text = "---";
                return;
            }

            this.tvKinectStatus.Text = Convert.ToString(sensor.Status);
            this.tvKinectSensorName.Text = sensor.UniqueKinectId.ToString();

            sensor.SkeletonStream.Enable();
            sensor.ColorStream.Enable();
            sensor.SkeletonFrameReady += KinectSkeletonFrameReady;
            sensor.ColorFrameReady += kinectColorFrameReady;
            sensor.Stop();
        }

        private void KinectSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            var skeletons = new Skeleton[0];

            using (var skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            if (skeletons.Length == 0) return;

            Skeleton skel = null;
            for (int i = 0; i < skeletons.Length; i++)
                if (skeletons[i].TrackingState == SkeletonTrackingState.Tracked)
                    skel = skeletons[i];

            writeSkelotonFrameDataToExcel(skel);
        }

        private void kinectColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame != null)
                {
                    bool haveNewFormat = this.lastImageFormat != colorFrame.Format;
                    if (haveNewFormat)
                    {
                        this.pixelData = new byte[colorFrame.PixelDataLength];
                        unsafe
                        {
                            fixed (void* p = this.pixelData)
                            {
                                IntPtr ptr = new IntPtr(p);
                                PixelFormat format = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
                                bitmapImage = new Bitmap(colorFrame.Width, colorFrame.Height, (4 * colorFrame.Width), format, ptr);
                            }
                        }
                    }

                    colorFrame.CopyPixelDataTo(this.pixelData);

                    this.videoPlayback.Image = bitmapImage;

                    this.lastImageFormat = colorFrame.Format;
                }
            }
        }

        // Button Clicks

        private void onBtnStartSessionClicked(object sender, EventArgs e)
        {
            if (currentExcelPath == null || currentExcelPath.Length == 0)
            {
                showInvalidCommandMessage("Excel file path cannot be null or empty");
                return;
            }
            if (sensor == null)
            {
                showInvalidCommandMessage("Kinect not connected");
                return;
            }
            if (sensor.IsRunning)
            {
                showInvalidCommandMessage("Session is already running");
                return;
            }

            currentSessionId = DateTimeOffset.Now.ToUnixTimeSeconds();
            currentPracticeNo = 0;
            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oWB = oXL.Workbooks.Open(currentExcelPath);
                oSheet = String.IsNullOrEmpty("Sheet1") ? (_Worksheet)oWB.ActiveSheet : (_Worksheet)oWB.Worksheets["Sheet1"];
                lastExcelRow = oSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing).Row;

            }
            catch (Exception ex)
            {
                showInvalidCommandMessage("Can't open the exel file: " + ex.Message);
                return;
            }

            sensor.Start();
            isSessionRunning = true;
        }

        private void onBtnEndSessionClicked(object sender, EventArgs e)
        {
            if (!isSessionRunning)
            {
                showInvalidCommandMessage("Session is already not running");
                return;
            }
            sensor.Stop();
            isSessionRunning = false;
            oWB.Close();
        }

        private void onBtnStartEndRecordingClicked(object sender, EventArgs e)
        {
            if (this.ivRecordingStatus.BackColor == System.Drawing.Color.Red)
                onBtnStartRecordingClicked(sender, e);
            else
                onBtnEndRecordingClicked(sender, e);

        }

        private void onBtnStartRecordingClicked(object sender, EventArgs e)
        {
            if (!isSessionRunning)
            {
                showInvalidCommandMessage("Session is not running, so recording is unavailable");
                return;
            }
            if (isRecording)
            {
                showInvalidCommandMessage("The Session is already being recorded");
                return;
            }
            if (currentUserName == null || currentUserName.Length == 0)
            {
                showInvalidCommandMessage("User name cannot be null or empty");
                return;
            }
            if (currentExcerciseName == null || currentExcerciseName.Length == 0)
            {
                showInvalidCommandMessage("Exercise name cannot be null or empty");
                return;
            }
            isRecording = true;
            this.ivRecordingStatus.BackColor = System.Drawing.Color.Green;
        }

        private void onBtnEndRecordingClicked(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                showInvalidCommandMessage("The Session is already not being recorded");
                return;
            }
            isRecording = false;
            oWB.Save();
            currentPracticeNo++;
            this.ivRecordingStatus.BackColor = System.Drawing.Color.Red;
            lastFrameNo = 0;
        }

        private void etExcelPath_TextChanged(object sender, EventArgs e)
        {
            currentExcelPath = this.etExcelPath.Text.Trim();
        }

        private void etUserName_TextChanged(object sender, EventArgs e)
        {
            currentUserName = this.etUserName.Text.Trim();
        }

        private void etExerciseName_TextChanged(object sender, EventArgs e)
        {
            currentExcerciseName = this.etExerciseName.Text.Trim();
        }

        // Private own functions

        private void showInvalidCommandMessage(String message)
        {
            MessageBox.Show(message, "Invalid Command", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void writeSkelotonFrameDataToExcel(Skeleton skel)
        {
            if (skel == null || !isRecording) return;

            Dispatcher.CurrentDispatcher.BeginInvoke((System.Action)delegate {
                int frameNo = ++lastFrameNo;
                int row = ++lastExcelRow;
                String JointsText = "";
                for (int i = 0; i < jointsArray.Length; i++)
                {
                    Joint joint = skel.Joints[jointsArray[i]];
                    if (joint != null)
                    {
                        String X = joint.Position.X.ToString(CultureInfo.InvariantCulture);
                        String Y = joint.Position.Y.ToString(CultureInfo.InvariantCulture);
                        String Z = joint.Position.Z.ToString(CultureInfo.InvariantCulture);

                        JointsText += X + "," + Y + "," + Z + ";";
                    }
                }
                oSheet.Cells[row, 1] = currentUserName;
                oSheet.Cells[row, 2] = currentSessionId;
                oSheet.Cells[row, 3] = currentExcerciseName;
                oSheet.Cells[row, 4] = currentPracticeNo;
                oSheet.Cells[row, 5] = frameNo;
                oSheet.Cells[row, 6] = JointsText;
            });
        }
    }
}
