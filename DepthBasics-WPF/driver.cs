using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace StretchIt
{
    public class driver
    {
        Dictionary<string,Gesture_t> reference_gestures;
        Kinect_t kinect;

        public driver()
        {
            reference_gestures = new Dictionary<string,Gesture_t>();
            kinect = new Kinect_t();
            loadReferenceFrames();
            string[] filePaths = Directory.GetFiles(GlobalVar.REFERENCE_GESTURE_DIRECTORY_C);
            for (int i = 0; i < filePaths.Length; ++i)
            {
                StreamReader inFile = new StreamReader(filePaths[i]);
                GlobalVar.ALL_POSSIBLE_GESTURES_C.Add(inFile.ReadLine());
                inFile.Close();
            }
        }
        private void loadReferenceFrames()
        {
            string[] filePaths = Directory.GetFiles(GlobalVar.REFERENCE_GESTURE_DIRECTORY_C);
            for (int i = 0; i < filePaths.Length; ++i)
            {
                StreamReader inFile = new StreamReader(filePaths[i]);
                String gesture_name = inFile.ReadLine();
                Frame_t ref_frame = new Frame_t(filePaths[i]);
                Gesture_t ref_gesture = new Gesture_t(gesture_name, filePaths[i], "tmp", "tmp", "tmp", "tmp");
                reference_gestures.Add(gesture_name, ref_gesture);
                inFile.Close();
            }
        }
        public void run_system()
        {
            while(GlobalVar.MODE != Game_mode_e.Exit_Game)
            {
                switch (GlobalVar.MODE)
                {
                    case Game_mode_e.Play:
                        play_game();
                        break;
                    case Game_mode_e.Menu_Mode:
                        process_menu();
                        break;
                }
            }
            GlobalVar.MAIN_MENU.Stats.saveStatistics();
        }
        private void process_menu()
        {
        }
        private void play_game()
        {
            Gesture_rc_e state_gesture;
            while (GlobalVar.MODE != Game_mode_e.Menu_Mode)
            {
                kinect.recordGesture(GlobalVar.NUM_FRAMES_RECORD_C);
                Gesture_t nextGesture = select_next_gesture();
                state_gesture = nextGesture.processGesture(kinect.getFrame());
                switch (state_gesture)
                {
                    case Gesture_rc_e.Correct:
                        GlobalVar.MAIN_MENU.Stats.recordResult(true);
                        break;
                    case Gesture_rc_e.Incorrect:
                        GlobalVar.MAIN_MENU.Stats.recordResult(false);
                        break;
                    case Gesture_rc_e.Back_Button:
                        GlobalVar.MODE = Game_mode_e.Menu_Mode;
                        break;
                    case Gesture_rc_e.No_Input:
                        break;
                }
            }
        }
        private Gesture_t select_next_gesture()
        {
            Random r = new Random();
            int selected_index = r.Next(GlobalVar.MAIN_MENU.Settings.getGestures().Count);
            return reference_gestures[GlobalVar.MAIN_MENU.Settings.getGestures()[selected_index]];
        }
    }
}
