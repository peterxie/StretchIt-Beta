using System;
using System.Collections.Generic;
using System.IO;

namespace StretchIt
{
    public enum Gesture_rc_e
    {
        Correct,
        No_Input,
        Incorrect
    }
    public enum Game_mode_e
    {
        Play,
        Menu_Mode,
        Record,
        Exit_Game
    }

    public static class GlobalVar
    {
        public static const string REFERENCE_GESTURE_DIRECTORY_C = @"..\..\Gestures\";
        public static const string AUDIO_DIRECTORY_C = @"..\..\Audio\";
        public static const string IMAGE_DIRECTORY_C = @"..\..\Images\";
        public static const string STATS_PATH_C = @"..\..\statistics.txt";
        public static const string SETTINGS_PATH_C = @"..\..\settings.txt";
        public static const int NUM_PIXELS_C = 307200;
        public static const int NUM_FRAMES_RECORD_C = 100;

        public static List<string> ALL_POSSIBLE_GESTURES_C = new List<string>();
        public static Game_mode_e MODE = Game_mode_e.Menu_Mode;
        public static MainMenu_t MAIN_MENU;// = new MainMenu_t();

        //do we need this?
        //public static Frame_t GLOBAL_KINECT_FRAME = new Frame_t(NUM_PIXELS_C);
    }

}