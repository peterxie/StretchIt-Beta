using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using Microsoft.Kinect;

namespace StretchIt
{
    //Kinect_t class wraps a KinectSensor object and provides functionality for recording a specified number of frames
    // while updating an internal frame_t object with the maximum deviation depth data

    public class Kinect_t
    {
        private KinectSensor    sensor;         //Active Kinect sensor

        private Frame_t         input;          //internal frame object    

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

                this.sensor.DepthStream.Range = DepthRange.Near;
                this.resetReference();
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
        public void resetReference()
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

            //extract the depth information
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = (short)(data[i] >> DepthImageFrame.PlayerIndexBitmaskWidth);
            }

            //set the default reference frame for Frame objects
            Frame_t.setDefault(data);
            Frame_t.setBack(data);

            //throw the frame away to clear memory
            depthFrame.Dispose();
            return;
        }

        //records num_frames number of frames and aggregates them into a gesture input
        public void recordGesture(int num_frames)
        {
            //reset the depth_pixels of the input frame object
            DepthImageFrame depthFrame = null;
            this.input.reset();
            while (num_frames > 0)
            {
                //attempt to read a frame from the kinect
                depthFrame = this.sensor.DepthStream.OpenNextFrame(1000);

                //if the attempt succeeded, aggregate the depth info into the inpur frame object
                if (depthFrame != null)
                {
                    short[] rawDepthData = new short[depthFrame.PixelDataLength];
                    depthFrame.CopyPixelDataTo(rawDepthData);
                    this.input.adjustFrame(rawDepthData);

                    //only decrement num_frames if a frame was read
                    num_frames--;

                    //dispose the frame object
                    depthFrame.Dispose();
                }
            }
            return;
        }

        //accessor for the frame object
        public Frame_t getFrame()
        {
            return this.input;
        }

        //accessor for the KinectSensor object
        public KinectSensor getSensor()
        {
            return this.sensor;
        }

        public void clear()
        {
            this.input.reset();
        }
    }
}
