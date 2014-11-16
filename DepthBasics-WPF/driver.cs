using System;
using System.Collections.Generic.Dictionary;
using System.IO;

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
        Gesture_t processor;

        public driver()
        {
            kinect_record = true;
            mode = Game_mode_e.Menu_Mode;
            enabled_menu_pages = new Dictionary<string,Gesture_t>();
            reference_frames = new Dictionary<string,Gesture_t>();
            loadReferenceFrames();

        }
        private void loadReferenceFrames()
        {
            string[] filePaths = Directory.GetFiles(@"c:\MyDir\");
            for (int i = 0; i < filePaths.Length; ++i)
            {
                StreamREader inFile = new StreamReader(filename);
                String gesture_name = inFile.ReadLine();
                Frame_t ref_frame = new Frame_t(filename);
                reference_frames.add(gesture_name, ref_frame);
                inFile.close();
            }
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
        private void process_menu()
        {
        }
        private void play_game()
        {
            Game_State_e state_gesture;
            while (mode != Game_mode_e.Menu_Mode)
            {
                update_current_kinect_frame();
                state_gesture = processor.processGesture(current_kinect_frame());
                switch (state_gesture)
                {
                    case Game_State_e.Correct:
                        break;
                    case Game_State_e.Incorrect:
                        break;
                    case Game_State_e.Back_Button:
                        mode = Game_mode_e.Menu_Mode;
                        break;
                    case Game_State_e.No_Input:
                        break;
                }
            }
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
