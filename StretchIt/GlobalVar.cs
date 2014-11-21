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
        Add_Gesture
        Exit_Game,
    }

    public static class GlobalVar
    {
        public static readonly object   key = new object();
        public const string             REFERENCE_GESTURE_DIRECTORY_C = @"..\..\Gestures\";
        public const string             AUDIO_DIRECTORY_C = @"..\..\Audio\";
        public const string             IMAGE_DIRECTORY_C = @"..\..\Images\";
        public const string             STATS_PATH_C = @"..\..\statistics.txt";
        public const string             SETTINGS_PATH_C = @"..\..\settings.txt";
        public const int                NUM_PIXELS_C = 307200;
        public const int                NUM_FRAMES_RECORD_C = 100;


        public static Game_mode_e       MODE = Game_mode_e.Menu_Mode;
        public static MainMenu_t        MAIN_MENU;// = new MainMenu_t();
    }

}