//------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.DepthBasics
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Diagnostics;
    using Microsoft.Kinect;
    using StretchIt;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        /// <summary>
        /// Bitmap that will hold color information
        /// </summary>
        private WriteableBitmap colorBitmap;

        /// <summary>
        /// Intermediate storage for the depth data converted to color
        /// </summary>
        private byte[] colorPixels;
        short[] firstDepthData;

        private int frame_num;

        private Frame_t ref_frame;

        public bool kinect_record;


        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AVTest(){
            AV_Output_t av1 = new AV_Output_t(@"../../verne.bmp", @"../../audio.wav");
            av1.load();

            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.ElapsedMilliseconds < 5000) { }
            s.Stop();

            AV_Output_t av2 = new AV_Output_t(@"../../Block M.gif", @"../../audio.wav");

            av2.load();
        }

        /// <summary>
        /// Execute startup tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (null != this.sensor)
            {
                //System.Console.WriteLine("HEY");

                // Turn on the depth stream to receive depth frames
                this.sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);

                // Turn on the color stream to receive color frames
                this.sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

                // Allocate space to put the color pixels we'll create
                this.colorPixels = new byte[this.sensor.ColorStream.FramePixelDataLength];


                // This is the bitmap we'll display on-screen
                this.colorBitmap = new WriteableBitmap(this.sensor.DepthStream.FrameWidth, this.sensor.DepthStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

                // Set the image we display to point to the bitmap where we'll put the image data
                this.Image.Source = this.colorBitmap;

                // Add an event handler to be called whenever there is new depth frame data
                this.sensor.DepthFrameReady += this.SensorDepthFrameReady;

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.ColorFrameReady += this.SensorColorFrameReady;

                this.frame_num = 0;
                this.firstDepthData = null;
                this.kinect_record = false;
                // Start the sensor!
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                this.statusBarText.Text = Properties.Resources.NoKinectReady;
                return;
            }
            this.sensor.DepthStream.Range = DepthRange.Near;

        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }


        private void GenerateColoredBytes(DepthImageFrame depthImageFrame)
        {
            //if (this.frame_num%5 != 0) return;
            if (!this.kinect_record) return;
            short[] rawDepthData = new short[depthImageFrame.PixelDataLength];
            depthImageFrame.CopyPixelDataTo(rawDepthData);

            this.ref_frame.adjustFrame(rawDepthData);
            //for (int depthIndex = 0; depthIndex < rawDepthData.Length; depthIndex++)
            //{
            //    int depth = rawDepthData[depthIndex] >> DepthImageFrame.PlayerIndexBitmaskWidth;
            //    int first_depth = firstDepthData[depthIndex] >> DepthImageFrame.PlayerIndexBitmaskWidth;
            //  //  Debug.WriteLine(depth.ToString());
            //    //Debug.WriteLine(first_depth.ToString());
            //    int delta = depth - first_depth;

            //    if ( Math.Abs(delta) > Math.Abs(this.depthMap[depthIndex]))
            //    {
            //        this.depthMap[depthIndex] = (short)delta;
            //    }
            //}
            return;
        }

        /// <summary>
        /// Event handler for Kinect sensor's DepthFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            //System.Console.WriteLine("HEY");
            using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
            {
                if (depthFrame != null)
                {

                    //if this is the first frame, save it
                    if (this.frame_num == 0)
                    {
                        this.firstDepthData = new short[depthFrame.PixelDataLength];
                        //this.depthMap = new short[depthFrame.PixelDataLength];
                        depthFrame.CopyPixelDataTo(firstDepthData);

                        Frame_t.setDefault(firstDepthData);
                        this.ref_frame = new Frame_t();

                        for (int i = 0; i < this.colorPixels.Length; ++i)
                        {
                            this.colorPixels[i] = 255;
                        }
                    }
                    else
                    {
                        // Copy the pixel data from the image to a temporary array
                        GenerateColoredBytes(depthFrame);

                    }
                    if (this.colorPixels != null)
                    {
                        // Copy the pixel data from the image to a temporary array
                        //colorFrame.CopyPixelDataTo(this.colorPixels);
                        makeColor();
                        // Write the pixel data into our bitmap
                        this.colorBitmap.WritePixels(
                            new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
                            this.colorPixels,
                            this.colorBitmap.PixelWidth * sizeof(int),
                            0);
                    }
                    this.frame_num++;

                }
            }
        }



        /// <summary>
        /// Event handler for Kinect sensor's ColorFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            /*using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (this.colorPixels != null && this.depthMap != null)
                {
                    // Copy the pixel data from the image to a temporary array
                    //colorFrame.CopyPixelDataTo(this.colorPixels);
                    makeColor();
                    // Write the pixel data into our bitmap
                    this.colorBitmap.WritePixels(
                        new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
                        this.colorPixels,
                        this.colorBitmap.PixelWidth * sizeof(int),
                        0);
                }
            }*/
        }

        private void makeColor()
        {
            const int BlueIndex = 0;
            const int GreenIndex = 1;
            const int RedIndex = 2;

            short[] depth_pixels = this.ref_frame.getPixels();

            for (int depthIndex = 0, colorIndex = 0;
                depthIndex < depth_pixels.Length && colorIndex < this.colorPixels.Length;
                depthIndex++, colorIndex += 4)
            {
                if (depth_pixels[depthIndex] > 100)
                {
                    this.colorPixels[colorIndex + BlueIndex] = 255;
                    this.colorPixels[colorIndex + GreenIndex] = 0;
                    this.colorPixels[colorIndex + RedIndex] = 0;
                }
                else if (depth_pixels[depthIndex] < -100)
                {
                    this.colorPixels[colorIndex + BlueIndex] = 0;
                    this.colorPixels[colorIndex + GreenIndex] = 255;
                    this.colorPixels[colorIndex + RedIndex] = 0;
                }
                else
                {
                    this.colorPixels[colorIndex + BlueIndex] = 255;
                    this.colorPixels[colorIndex + GreenIndex] = 255;
                    this.colorPixels[colorIndex + RedIndex] = 255;
                }
            }
            return;
        }

        /// <summary>
        /// Handles the user clicking on the screenshot button
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void ButtonScreenshotClick(object sender, RoutedEventArgs e)
        {
            if (null == this.sensor)
            {
                this.statusBarText.Text = Properties.Resources.ConnectDeviceFirst;
                return;
            }

            // create a png bitmap encoder which knows how to save a .png file
            BitmapEncoder encoder = new PngBitmapEncoder();

            // create frame from the writable bitmap and add to encoder
            encoder.Frames.Add(BitmapFrame.Create(this.colorBitmap));

            string time = System.DateTime.Now.ToString("hh'-'mm'-'ss", CultureInfo.CurrentUICulture.DateTimeFormat);

            string myPhotos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            string path = Path.Combine(myPhotos, "KinectSnapshot-" + time + ".png");

            // write the new file to disk
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    encoder.Save(fs);
                }

                this.statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteSuccess, path);
            }
            catch (IOException)
            {
                this.statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteFailed, path);
            }
        }

        /// <summary>
        /// Handles the checking or unchecking of the near mode combo box
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxNearModeChanged(object sender, RoutedEventArgs e)
        {
            if (this.sensor != null)
            {
                // will not function on non-Kinect for Windows devices
                try
                {
                    if (this.checkBoxNearMode.IsChecked.GetValueOrDefault())
                    {
                        this.sensor.DepthStream.Range = DepthRange.Near;
                    }
                    else
                    {
                        this.sensor.DepthStream.Range = DepthRange.Default;
                    }
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        private void captureButton_Click(object sender, RoutedEventArgs e)
        {
            this.frame_num = 0;
<<<<<<< HEAD
            if (this.kinect_record)
            {
                this.kinect_record = false;
                captureButton.Content = "Calibrate/Record";
                this.ref_frame.write("frame_out.txt");

                // create a png bitmap encoder which knows how to save a .png file
                BitmapEncoder encoder = new PngBitmapEncoder();

                // create frame from the writable bitmap and add to encoder
                encoder.Frames.Add(BitmapFrame.Create(this.colorBitmap));

                string time = System.DateTime.Now.ToString("hh'-'mm'-'ss", CultureInfo.CurrentUICulture.DateTimeFormat);

                string myPhotos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                string path = Path.Combine(myPhotos, "KinectSnapshot-" + time + ".png");

                // write the new file to disk
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        encoder.Save(fs);
                    }

                    this.statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteSuccess, path);
                }
                catch (IOException)
                {
                    this.statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteFailed, path);
                }
            }
            else
            {
                this.kinect_record = true;
                captureButton.Content = "Calibrate/Stop";
            }

            return;
        }
    }
}