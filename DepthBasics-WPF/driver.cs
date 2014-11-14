using System;
using System.Collections.Generic.Dictionary;

namespace StretchIt
{
    enum Game_mode_e
    {
        Play,
        Menu_Mode,
        Exit_Game
    }
    public class driver
    {

        Frame_t current_kinect_frame;
        bool kinect_record;
        Game_mode_e mode;
        Dictionary<string, Gesture_t> enabled_menu_pages;
        Dictionary<string,Frame_t> reference_frames;

        public driver()
        {
            kinect_record = true;
            mode = Game_mode_e.Menu_Mode;
            enabled_menu_pages = new Dictionary<string,Gesture_t>();
            reference_frames = new Dictionary<string,Gesture_t>();

        }
        public void run_system()
        {
            while(mode != Game_mode_e.Exit_Game)
            {
                switch (mode)
                {
                    case Game_mode_e.Play:
                        play_game();
                        break;
                    case Game_mode_e.Menu_Mode:
                        process_menu();
                        break;
                }
            }
        }
        public void process_menu()
        {
        }
        public void play_game()
        {
        }
        private void update_current_kinect_frame()
        {
            current_kinect_frame.num_pixels = global_kinect_frame.num_pixels;
            current_kinect_frame.error_threshold = global_kinect_frame.error_threshold;
            current_kinect_frame = global_kinect_frame;
            current_kinect_frame = global_kinect_frame;
            Buffer.BlockCopy(global_kinect_frame.depth_pixels, 0, current_kinect_frame.depth_pixels, 0, num_pixels);
        }
    }
}
