using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace StretchIt
{
    public partial class Setup_t : Form
    {
        private KinectSensor kinectSensor;
        private ColorImageFormat imageFormat;
        
        public Setup_t()
        {
            InitializeComponent();
            imageFormat = ColorImageFormat.RgbResolution640x480Fps30;

            foreach(var potentialSensor in KinectSensor.KinectSensors)
            {
                if(potentialSensor.Status == KinectStatus.Connected)
                {
                    this.kinectSensor = potentialSensor;
                    break;
                }
            }
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            GlobalVar.MAIN_MENU.Settings.Activate();
            GlobalVar.MAIN_MENU.Settings.Visible = true;
            this.Visible = false;

            kinectSensor.ColorStream.Disable();
            kinectSensor.ColorFrameReady -= 
                new EventHandler<ColorImageFrameReadyEventArgs> (kinectSensor_ColorFrameReady);
        }

        public void SetupSensorVideoInput()
        {
            if (kinectSensor != null)
            {
                kinectSensor.ColorStream.Enable(imageFormat);


                kinectSensor.ColorFrameReady +=
                new EventHandler<ColorImageFrameReadyEventArgs>(kinectSensor_ColorFrameReady);


                kinectSensor.Start();
            }
        }

        private void kinectSensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            ColorImageFrame colorFrame = e.OpenColorImageFrame();


            if (colorFrame == null)
            {
                return;
            }


            Bitmap bitmapFrame = ColorImageFrameToBitmap(colorFrame);

            kinectPictureBox.Image = bitmapFrame;
        }

        private static Bitmap ColorImageFrameToBitmap(ColorImageFrame colorFrame)
        {
            byte[] pixelBuffer = new byte[colorFrame.PixelDataLength];
            colorFrame.CopyPixelDataTo(pixelBuffer);


            Bitmap bitmapFrame = new Bitmap(colorFrame.Width, colorFrame.Height,
                PixelFormat.Format32bppRgb);


            BitmapData bitmapData = bitmapFrame.LockBits(new Rectangle(0, 0,
                                             colorFrame.Width, colorFrame.Height),
            ImageLockMode.WriteOnly, bitmapFrame.PixelFormat);


            IntPtr intPointer = bitmapData.Scan0;
            Marshal.Copy(pixelBuffer, 0, intPointer, colorFrame.PixelDataLength);


            bitmapFrame.UnlockBits(bitmapData);


            return bitmapFrame;
        }

        private void calibrateLabel_Click(object sender, EventArgs e)
        {
            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Calibrate;
                Monitor.Pulse(GlobalVar.key);
            }
        }
    }
}
