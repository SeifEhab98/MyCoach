using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyCoach_UI
{
    public partial class Form1 : Form
    {

        private enum Exercise : int
        {
            NOISE = 0,
            DEAD_LIFT = 1,
            TWIST = 2,
            LATERAL_RAISE = 3
        }

        private Exercise currentExercise = Exercise.DEAD_LIFT;
        private String currentServerPort;
        private String currentPracticeText = "";
        private int rightPracticesCount = 0;
        private int wrongPracticesCount = 0;

        private Boolean isSessionRunning = false;
        private Boolean isRecording = false;

        private KinectSensor sensor = null;
        private ColorImageFormat lastImageFormat;
        private byte[] pixelData;
        private Bitmap bitmapImage;

        private Socket socket = null;

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
            //AllocConsole();
            InitKinect();
            this.excercisesGifView.Parent = this.videoPlayback;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

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

            addSkelotonFrameDataToPracticeText(skel);
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

        private void radioButtonDeadLift_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButtonDeadLift.Checked)
                return;
            this.currentExercise = Exercise.DEAD_LIFT;
            this.excercisesGifView.Image = global::MyCoach_UI.Properties.Resources.deadLift;
            this.radioButtonTwist.Checked = false;
            this.radioButtonLateralRaise.Checked = false;
        }

        private void radioButtonTwist_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButtonTwist.Checked)
                return;
            this.currentExercise = Exercise.TWIST;
            this.excercisesGifView.Image = global::MyCoach_UI.Properties.Resources.twist;
            this.radioButtonDeadLift.Checked = false;
            this.radioButtonLateralRaise.Checked = false;
        }

        private void radioButtonLateralRaise_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButtonLateralRaise.Checked)
                return;
            this.currentExercise = Exercise.LATERAL_RAISE;
            this.excercisesGifView.Image = global::MyCoach_UI.Properties.Resources.lateralRaise;
            this.radioButtonDeadLift.Checked = false;
            this.radioButtonTwist.Checked = false;
        }

        private void btnStartSession_Click(object sender, EventArgs e)
        {
            if (currentServerPort == null || currentServerPort.Length == 0)
            {
                showInvalidCommandMessage("Server port be null or empty");
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

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, Int32.Parse(currentServerPort));
                socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remoteEP);
            }
            catch (Exception ex)
            {
                showInvalidCommandMessage("Can't connect to server: " + ex.Message);
                return;
            }

            sensor.Start();
            isSessionRunning = true;
            rightPracticesCount = wrongPracticesCount = 0;
            refreshRightWrongPracticesCount();
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            if (!isSessionRunning)
            {
                showInvalidCommandMessage("Session is already not running");
                return;
            }
            sensor.Stop();
            isSessionRunning = false;
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        private void btnStartEndRecording_Click(object sender, EventArgs e)
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
            currentPracticeText = "";
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
            this.ivRecordingStatus.BackColor = System.Drawing.Color.Red;
            sendPracticeToServer();
        }

        private void etServerPort_TextChanged(object sender, EventArgs e)
        {
            currentServerPort = this.etServerPort.Text.Trim();
        }

        // Private own functions

        private void showInvalidCommandMessage(String message)
        {
            MessageBox.Show(message, "Invalid Command", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void addSkelotonFrameDataToPracticeText(Skeleton skel)
        {
            if (skel == null || !isRecording) return;

            Dispatcher.CurrentDispatcher.BeginInvoke((System.Action)delegate {
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
                currentPracticeText += JointsText;
                currentPracticeText += "/";
            });
        }

        private void sendPracticeToServer() 
        {
            if (currentPracticeText.Length == 0) {
                wrongPracticesCount++;
                refreshRightWrongPracticesCount();
                return;
            }
            Dispatcher.CurrentDispatcher.BeginInvoke((System.Action)delegate {
                try
                {
                    byte[] msg = Encoding.UTF8.GetBytes(currentPracticeText);
                    socket.Send(msg);

                    byte[] bytes = new byte[1024];
                    int bytesRec = socket.Receive(bytes);
                    String response = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    JObject jObject = JObject.Parse(response);
                    String detectedExcercise = (String)jObject["predicted_class"];
                    Console.WriteLine(detectedExcercise);

                    Exercise exercise;
                    Enum.TryParse(detectedExcercise, out exercise);

                    if (exercise.Equals(currentExercise))
                    {
                        rightPracticesCount++;
                        refreshRightWrongPracticesCount();
                    }
                    else {
                        wrongPracticesCount++;
                        refreshRightWrongPracticesCount();
                    }
                }
                catch (Exception ex)
                {
                    showInvalidCommandMessage("Error happened while communicating with the server: " + ex.Message);
                    btnEndSession_Click(null, null);
                }
            });
        }

        private void refreshRightWrongPracticesCount() { 
            this.tvRightCounter.Text = rightPracticesCount.ToString();
            this.tvWrongCounter.Text = wrongPracticesCount.ToString();
        }

    }
}
