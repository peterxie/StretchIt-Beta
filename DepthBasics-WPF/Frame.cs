using System;
using System.IO;
using Microsoft.Kinect;
//not finished

namespace StretchIt
{
    //The Frame_t class represents a motion in 3D space by keeping an array of shorts representing the deviation from its
    // default_frame static member. It can also evaluate the correctness of an input motion using its error_threshold as a cutoff
    // for correctness
    public class Frame_t
    {
        private int                 num_pixels;         //size of the short[] members                
        private double              error_threshold;    //average deviation/pixel threshold for determining correctness
        private short[]             depth_pixels;       //stores the depth "image" for a motion
        private static short[]      default_frame;      //stores the depth "image" reference across all Frame_t objects
        private static short[]      back_frame;         //stores the depth "image" for a back motion across all Frame_t objects
        
        private const int           default_pixels_c = 307200;    // constant for the default size of arrays
        private const double        default_threshold_c = 100.0;

        //default constructor which takes the number of pixels as an argument
        public Frame_t(int num_pixels_ = default_pixels_c, double threshold_ = default_threshold_c)
        {
            num_pixels = num_pixels_;
            depth_pixels = new short[num_pixels];
        }

        //copy constructor
        public Frame_t(Frame_t copyFrame)
        {
            this.num_pixels = copyFrame.num_pixels;
            error_threshold = copyFrame.error_threshold;

            //perform a deep copy
            depth_pixels = new short[num_pixels];

            Buffer.BlockCopy(copyFrame.depth_pixels, 0, this.depth_pixels, 0, this.num_pixels);
        }

        //constructor given a DepthImage Frame (may be removed later if unused)
        public Frame_t(DepthImageFrame depthFrame)
        {
            if (depthFrame == null)
            {
                num_pixels = default_pixels_c;
                depth_pixels = new short[num_pixels];
            }
            else
            {
                num_pixels = depthFrame.PixelDataLength;
                depth_pixels = new short[num_pixels];
                depthFrame.CopyPixelDataTo(depth_pixels);

                //shift the info for the depth data
                for (int i = 0; i < num_pixels; ++i)
                {
                    depth_pixels[i] = (short) (depth_pixels[i] >> DepthImageFrame.PlayerIndexBitmaskWidth);
                }
            }
            this.error_threshold = default_threshold_c;
        }

        //constructor given an array of depth information
        //this assumes that the depth information has already been bit shifted
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
            error_threshold = default_threshold_c;
        }

        //saves the depth_pixels to a text file in the following format
        // <gestureName>
        // <num_pixels>
        // <error_threshold>
        // <depth_pixels[0]
        // <depth_pixels[1]
        // ...
        public void write(string fileName,string gestureName)
        {
            StreamWriter file = new StreamWriter(fileName);
            file.WriteLine(gestureName);
            file.WriteLine(num_pixels.ToString());
            file.WriteLine(error_threshold.ToString());

            for (int i = 0; i < num_pixels; ++i)
            {
                file.WriteLine(depth_pixels[i].ToString());
            }
            file.Close();
        }

        //reads information from a file determined by fileName to assign the values of members
        //format is described by write()
        public void read(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string gestureName = file.ReadLine();   //not used

            num_pixels = Int32.Parse(file.ReadLine());
            error_threshold = Double.Parse(file.ReadLine());

            //if the file specifies a different size, create a new array
            if (depth_pixels == null || depth_pixels.Length != num_pixels)
            {
                depth_pixels = new short[num_pixels];
            }
            for (int i = 0; i < num_pixels; ++i)
            {
                depth_pixels[i] = short.Parse(file.ReadLine());
            }
            file.Close();
        }

        //reset the depth information and size
        public void reset(int num_pixels_ = 307200)
        {
            num_pixels = num_pixels_;
            depth_pixels = new short[num_pixels];
        }

        //constructor taking a file as the input data
        public Frame_t(string fileName)
        {
            read(fileName);
        }
        
        //set the static default_frame variable
        static public void setDefault(short[] frame)
        {
            default_frame = new short[frame.Length];
            frame.CopyTo(default_frame, 0);
        }

        //set the static back_frame variable
        static public void setBack(short[] frame)
        {
            back_frame = new short[frame.Length];
            frame.CopyTo(back_frame, 0);
        }

        //accessor for the depth_pixels
        public short[] getPixels()
        {
            return this.depth_pixels;
        }

        //accessor for individual indices of depth_pixels
        public short this[int index]
        {
            get
            {
                return depth_pixels[index];
            }
        }

        //accessor for num_pixels
        public int getNumPixels()
        {
            return this.num_pixels;
        }

        //adds the raw_depth_pixels depth information to this.depth_pixels
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

        //returns an enum denoting whether the Frame_t object matches any of the stored depth arrays
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
