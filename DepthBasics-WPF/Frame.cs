using System;
using System.IO;
using Microsoft.Kinect;
//not finished

namespace StretchIt
{
    public class Frame_t
    {
        private int num_pixels;
        private double error_threshold;
        private short[] depth_pixels;
        private static short[] default_frame;
        private static short[] back_frame;
        
        private const int default_pixels_c = 307200;

        public Frame_t(int num_pixels_ = default_pixels_c)
        {
            num_pixels = num_pixels_;
            depth_pixels = new short[num_pixels];
        }

        public Frame_t(DepthImageFrame depthFrame)
        {
            if (depthFrame == null)
            {
                num_pixels = default_pixels_c;
            }
            else
            {
                num_pixels = depthFrame.PixelDataLength;
            }
            depth_pixels = new short[num_pixels];
        }

        public Frame_t(short[] pixels)
        {
            if (pixels == null)
            {
                num_pixels = default_pixels_c;
                depth_pixels = new short[num_pixels];
            }
            else
            {
                num_pixels = pixels.Length;
                depth_pixels = new short[num_pixels];
                pixels.CopyTo(depth_pixels, 0);
            }

        }

        public void write(string fileName,string gestureName)
        {
            StreamWriter file = new StreamWriter(fileName);
            file.WriteLine(gestureName);
            file.WriteLine(num_pixels.ToString());
            for (int i = 0; i < num_pixels; ++i)
            {
                file.WriteLine(depth_pixels[i].ToString());
            }
            file.Close();
        }

        public void read(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string gestureName = file.ReadLine();
            string pixelNum = file.ReadLine();
            int size = Convert.ToInt32(pixelNum);
            this.num_pixels = size;
            if (depth_pixels == null || depth_pixels.Length != num_pixels)
            {
                depth_pixels = new short[num_pixels];
            }
            for (int i = 0; i < num_pixels; ++i)
            {
                int val = Convert.ToInt32(file.ReadLine());
                depth_pixels[i] = (short)val;
            }
            file.Close();
        }

        public void reset(int _num_pixels = 307200)
        {
            num_pixels = _num_pixels;
            depth_pixels = new short[num_pixels];
        }

        public Frame_t(string filename)
        {
            StreamReader inFile = new StreamReader(filename);

            inFile.ReadLine(); //Eat the gesture name

            num_pixels = int.Parse(inFile.ReadLine());
            depth_pixels = new short[num_pixels];

            for (int i = 0; i < num_pixels; ++i)
            {
                depth_pixels[i] = short.Parse(inFile.ReadLine());
            }

            inFile.Close();            
        }
        
        static public void setDefault(short[] frame)
        {
            default_frame = new short[frame.Length];
            for (int i = 0; i < frame.Length; ++i)
            {
                default_frame[i] = (short)(frame[i] >> DepthImageFrame.PlayerIndexBitmaskWidth);
            }
        }

        static public void setBack(short[] frame)
        {
            back_frame = new short[frame.Length];
            for (int i = 0; i < frame.Length; ++i)
            {
                back_frame[i] = (short)(frame[i] >> DepthImageFrame.PlayerIndexBitmaskWidth);
            }
        }

        public short[] getPixels()
        {
            return this.depth_pixels;
        }

        public short this[int index]
        {
            get
            {
                return depth_pixels[index];
            }
        }

        public int getNumPixels()
        {
            return this.num_pixels;
        }

        // Need to discuss whether these should be absolute values
        public void adjustFrame(short[] raw_depth_pixels)
        {
            for (int i = 0; i < num_pixels; ++i)
            {
                short input_diff = (short) ((raw_depth_pixels[i] >> DepthImageFrame.PlayerIndexBitmaskWidth) - default_frame[i]);

                if (Math.Abs(input_diff) > Math.Abs(depth_pixels[i]))
                {
                    depth_pixels[i] = input_diff;
                }
            }
        }

        public Gesture_rc_e computeDeviation(Frame_t input_frame)
        {
            double input_gesture_error = 0;
            double def_gesture_error = 0;
            double back_gesture_error = 0;

            for (int i = 0; i < num_pixels; ++i)
            {
                input_gesture_error += Math.Abs(depth_pixels[i] - input_frame.depth_pixels[i]);
                def_gesture_error += Math.Abs(default_frame[i] - input_frame.depth_pixels[i]);
                back_gesture_error += Math.Abs(back_frame[i] - input_frame.depth_pixels[i]);
            }

            if(input_gesture_error / num_pixels < error_threshold)
            {
                return Gesture_rc_e.Correct;
            }

            else if(def_gesture_error / num_pixels < error_threshold)
            {
                return Gesture_rc_e.No_Input;
            }

            else if(back_gesture_error / num_pixels < error_threshold)
            {
                return Gesture_rc_e.Back_Button;
            }

            return Gesture_rc_e.Incorrect;
        }

        //finish this (yeah its not an empty function)
        public void aggregate(Frame_t frame)
        {

        }

        /*public Frame_t(Frame_t frame_one, Frame_t frame_two)
        {
            num_pixels = frame_one.num_pixels;
            //Not sure which array to copy from either one
            Buffer.BlockCopy(frame_one.depth_pixels, 0, depth_pixels, 0, num_pixels);
            Buffer.BlockCopy(default_frame, 0, default_frame, 0, num_pixels);
        }*/
    }
}
