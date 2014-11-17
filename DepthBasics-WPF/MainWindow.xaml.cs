﻿//------------------------------------------------------------------------------
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
       // private KinectSensor sensor;

        /// <summary>
        /// Bitmap that will hold color information
        /// </summary>
        private WriteableBitmap colorBitmap;

        /// <summary>
        /// Intermediate storage for the depth data converted to color
        /// </summary>
        private byte[] colorPixels;
       // short[] firstDepthData;

       // private int frame_num;

       // private Frame_t ref_frame;

      //  public bool kinect_record;
        public Kinect_t kinect_t;

        private Frame_t ref_frame;

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
            /*foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.kinect_t.getSensor() = potentialSensor;
                    break;
                }
            }

            if (null != this.kinect_t.getSensor())
            {*/
                //System.Console.WriteLine("HEY");

                // Turn on the depth stream to receive depth frames
                // this.kinect_t.getSensor().DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);

                // Turn on the color stream to receive color frames
                //  this.kinect_t.getSensor().ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

                // Allocate space to put the color pixels we'll create
                this.kinect_t = new Kinect_t();

                this.colorPixels = new byte[this.kinect_t.getSensor().ColorStream.FramePixelDataLength];


                // This is the bitmap we'll display on-screen
                this.colorBitmap = new WriteableBitmap(this.kinect_t.getSensor().DepthStream.FrameWidth, this.kinect_t.getSensor().DepthStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

                // Set the image we display to point to the bitmap where we'll put the image data
                this.Image.Source = this.colorBitmap;

                this.kinect_t.resetReference();

                /* // Add an event handler to be called whenever there is new depth frame data
                 this.kinect_t.getSensor().DepthFrameReady += this.kinect_t.getSensor()DepthFrameReady;

                 // Add an event handler to be called whenever there is new color frame data
                 this.kinect_t.getSensor().ColorFrameReady += this.kinect_t.getSensor()ColorFrameReady;*/

                /*     this.frame_num = 0;
                     this.firstDepthData = null;
                     this.kinect_record = false;
                     // Start the sensor!
                     try
                     {
                         this.kinect_t.getSensor().Start();
                     }
                     catch (IOException)
                     {
                         this.kinect_t.getSensor() = null;
                     }
                 }

                 if (null == this.kinect_t.getSensor())
                 {
                     this.statusBarText.Text = Properties.Resources.NoKinectReady;
                     return;
                 }*/
            
            //this.kinect_t.getSensor().DepthStream.Range = DepthRange.Near;

        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != this.kinect_t.getSensor())
            {
                this.kinect_t.getSensor().Stop();
            }
        }


       /* private void GenerateColoredBytes(DepthImageFrame depthImageFrame)
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
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
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
            }
        }*/

        private void makeColor()
        {
            const int BlueIndex = 0;
            const int GreenIndex = 1;
            const int RedIndex = 2;

            short[] depth_pixels = this.kinect_t.getFrame().getPixels();

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
            this.ref_frame = new Frame_t(this.kinect_t.getFrame());
            /*if (null == this.kinect_t.getSensor())
            {
                this.statusBarText.Text = Properties.Resources.ConnectDeviceFirst;
                return;
            }*/

            // create a png bitmap encoder which knows how to save a .png file
            /*BitmapEncoder encoder = new PngBitmapEncoder();

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
            }*/
        }

        /// <summary>
        /// Handles the checking or unchecking of the near mode combo box
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxNearModeChanged(object sender, RoutedEventArgs e)
        {
            /*if (this.kinect_t.getSensor() != null)
            {
                // will not function on non-Kinect for Windows devices
                try
                {
                    if (this.checkBoxNearMode.IsChecked.GetValueOrDefault())
                    {
                        this.kinect_t.getSensor().DepthStream.Range = DepthRange.Near;
                    }
                    else
                    {
                        this.kinect_t.getSensor().DepthStream.Range = DepthRange.Default;
                    }
                }
                catch (InvalidOperationException)
                {
                }
            }*/
        }

        private void captureButton_Click(object sender, RoutedEventArgs e)
        {
            this.kinect_t.resetReference();
            this.kinect_t.clear();
            this.kinect_t.recordGesture(50);
            if (ref_frame != null)
            {
                Gesture_rc_e output = this.ref_frame.computeDeviation(this.kinect_t.getFrame());
                switch (output)
                {
                    case Gesture_rc_e.Correct: this.textBox1.Text = "Correct!"; break;
                    case Gesture_rc_e.Incorrect: this.textBox1.Text = "Incorrect!"; break;
                    case Gesture_rc_e.No_Input: this.textBox1.Text = "No Input!"; break;
                    default: break;
                }
            }
            makeColor();
            this.colorBitmap.WritePixels(
                new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
                this.colorPixels,
                this.colorBitmap.PixelWidth * sizeof(int),
                0);
            return;
        }
    }
}