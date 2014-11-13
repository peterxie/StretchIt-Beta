using System;

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
    
        public Frame_t(int _num_pixels = 307200)
        {
            num_pixels = _num_pixels;
            depth_pixels = new short[num_pixels];
            default_frame = new short[num_pixels];
            back_frame = new short[num_pixels];
        }

        /*public Frame_t(Frame_t frame_one, Frame_t frame_two)
        {
            num_pixels = frame_one.num_pixels;
            //Not sure which array to copy from either one
            Buffer.BlockCopy(frame_one.depth_pixels, 0, depth_pixels, 0, num_pixels);
            Buffer.BlockCopy(default_frame, 0, default_frame, 0, num_pixels);
        }*/

        // Need to discuss whether these should be absolute values
        public void adjustFrame(short[] raw_depth_pixels)
        {
            for (int i = 0; i < num_pixels; ++i)
            {
                short input_diff = (short) Math.Abs(raw_depth_pixels[i] - depth_pixels[i]);
                short ref_diff = (short) Math.Abs(raw_depth_pixels[i] - default_frame[i]);

                if (input_diff > ref_diff)
                {
                    depth_pixels[i] = input_diff;
                }
            }
        }

        public Game_State_e computeDeviation(Frame_t input_frame)
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
                return Game_State_e.Correct;
            }

            else if(def_gesture_error / num_pixels < error_threshold)
            {
                return Game_State_e.No_Input;
            }

            else if(back_gesture_error / num_pixels < error_threshold)
            {
                return Game_State_e.Back_Button;
            }

            return Game_State_e.Incorrect;
        }

        //finish this (yeah its not an empty function)
        public void aggregate(Frame_t frame)
        {

        }
    }
}
