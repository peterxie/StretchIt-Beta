﻿using System;
using System.Collections.Generic;
using System.IO;

namespace StretchIt
{
    public class driver
    {
        Game_mode_e mode;
        Dictionary<string,Gesture_t> reference_gestures;
        Settings settings;
        StatisticsForm statistics;
        Kinect_t kinect;

        public driver()
        {
            mode = Game_mode_e.Menu_Mode;
            reference_gestures = new Dictionary<string,Gesture_t>();
            settings = new Settings();
            statistics = new StatisticsForm();
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
            statistics.saveStatistics();
        }
        private void process_menu()
        {
        }
        private void play_game()
        {
            Gesture_rc_e state_gesture;
            while (mode != Game_mode_e.Menu_Mode)
            {
                kinect.recordGesture(GlobalVar.NUM_FRAMES_RECORD_C);
                Gesture_t nextGesture = select_next_gesture();
                state_gesture = nextGesture.processGesture(kinect.getFrame());
                switch (state_gesture)
                {
                    case Gesture_rc_e.Correct:
                        statistics.recordResult(true);
                        break;
                    case Gesture_rc_e.Incorrect:
                        statistics.recordResult(false);
                        break;
                    case Gesture_rc_e.Back_Button:
                        mode = Game_mode_e.Menu_Mode;
                        break;
                    case Gesture_rc_e.No_Input:
                        break;
                }
            }
        }
        private Gesture_t select_next_gesture()
        {
            Random r = new Random();
            int selected_index = r.Next(settings.getGestures().Count);
            return reference_gestures[settings.getGestures()[selected_index]];
        }
    }
}
