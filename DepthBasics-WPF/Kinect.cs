using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.DepthBasics
{
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Diagnostics;
    using Microsoft.Kinect;
    using StretchIt;

    class Kinect_t
    {
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        private Frame_t input;

        public Kinect_t()
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
                // Turn on the depth stream to receive depth frames
                this.sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);

                this.input = new Frame_t();

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
        }

        //adds data from stream snapshot to the current tracked frame "input"
        private void aggregateFrame(DepthImageFrame depthImageFrame)
        {
            short[] rawDepthData = new short[depthImageFrame.PixelDataLength];
            depthImageFrame.CopyPixelDataTo(rawDepthData);

            this.input.adjustFrame(rawDepthData);

            return;
        }

        //resets the reference frame of Frame_t to be depthFrame
        public void reset_reference()
        {
            //attempt to read a depth frame until a valid frame is returned
            DepthImageFrame depthFrame = null;
            while (depthFrame == null)
            {
                depthFrame = this.sensor.DepthStream.OpenNextFrame(0);
            }

            //copy the depth data to a temporary buffer
            short[] data = new short[depthFrame.PixelDataLength];
            depthFrame.CopyPixelDataTo(data);

            //set the default reference frame for Frame objects
            Frame_t.setDefault(data);

            //throw the frame away to clear memory
            depthFrame.Dispose();
            return;
        }

        //records num_frames number of frames and aggregates them into a gesture input
        public void record_gesture(int num_frames)
        {
            DepthImageFrame depthFrame = null;
            this.input.reset();
            while (num_frames > 0)
            {
                depthFrame = this.sensor.DepthStream.OpenNextFrame(0);
                if (depthFrame != null)
                {
                    short[] rawDepthData = new short[depthFrame.PixelDataLength];
                    depthFrame.CopyPixelDataTo(rawDepthData);
                    this.input.adjustFrame(rawDepthData);
                    num_frames--;
                    depthFrame.Dispose();
                }
            }
            return;
        }
    }
}
