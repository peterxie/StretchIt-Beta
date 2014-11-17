using System;
using System.Collections.Generic;
using System.IO;

namespace StretchIt
{
    public static class GlobalVar
    {
        public static string REFERENCE_GESTURE_DIRECTORY_C = @"c:.\Reference_Gestures\";
        public static string AV_DIRECTORY_C = @"c:.\AudioVideo\";
        public static List<string> ALL_POSSIBLE_GESTURES_C = new List<string>();
        public static int NUM_PIXELS_C = 307200;
        public static int NUM_FRAMES_RECORD_C = 100;
        public static Frame_t GLOBAL_KINECT_FRAME = new Frame_t(NUM_PIXELS_C);
        public static Kinect_t KINECT = new Kinect_t();

        public static MainMenu_t MAIN_MENU = new MainMenu_t();
        public static Statistics_t STATS_MENU = new Statistics_t();
        public static Settings_t SETTINGS_MENU = new Settings_t();
        public static Help_t HELP_MENU = new Help_t();

        public static string STATS_PATH_C = "statistics.txt";
    }

    public enum Gesture_rc_e
    {
        Correct,
        No_Input,
        Back_Button,
        Incorrect
    }
    public enum Game_mode_e
    {
        Play,
        Menu_Mode,
        Exit_Game
    }
}