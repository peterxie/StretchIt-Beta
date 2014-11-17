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