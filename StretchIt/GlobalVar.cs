﻿using System;
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
        Calibrate,
        Add_Gesture,
        Remove_Gesture,
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
        public const string             TEMP_GESTURE_FILE = @"..\..\GestureImages\gesture.txt";
        public const string             TEMP_GESTURE_IMAGE_FILE = @"..\..\GestureImages\gesture.png";
        public static string[]                 CELEB_AUDIO_FILES = Directory.GetFiles(@"..\..\Celebrations", "celebration*.wav");
        public const string             CELEB_IMAGE_FILE = @"..\..\Celebrations\celebration1.jpg";
        public const int                NUM_PIXELS_C = 307200;
        public const int                NUM_FRAMES_RECORD_C = 100;
        public const int                NUM_GESTURES_IN_GAME_C = 15;


        public static Game_mode_e       MODE = Game_mode_e.Menu_Mode;
        public static MainMenu_t        MAIN_MENU;// = new MainMenu_t();
        public static void sleep(int numMilli)
        {
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();
            while (s.ElapsedMilliseconds < numMilli) { }
            s.Stop();
        }

    }

}