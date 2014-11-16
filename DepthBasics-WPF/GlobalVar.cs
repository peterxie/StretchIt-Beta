using System;
using System.Collections.Generic;
using System.IO;

namespace StretchIt
{
    public static class GlobalVar
    {
        public static string REFERENCE_GESTURE_DIRECTORY_C;
        public static string AV_DIRECTORY_C;
        public static List<string> ALL_POSSIBLE_GESTURES_C;
        public static int NUM_PIXELS_C;
        public static int NUM_FRAMES_RECORD_C;
        public static Frame_t GLOBAL_KINECT_FRAME;
        public static Kinect_t KINECT;
        public GlobalVar()
        {
            REFERENCE_GESTURE_DIRECTORY_C = @"c:.\Reference_Gestures\";
            AV_DIRECTORY_C = @"c:.\AudioVideo\";
            NUM_PIXELS_C = 307200;
            NUM_FRAMES_RECORD_C = 100;

            ALL_POSSIBLE_GESTURES_C = new List<string>();
            GLOBAL_KINECT_FRAME = new Frame_t(NUM_PIXELS_C);
            KINECT = new Kinect_t();

            string[] filePaths = Directory.GetFiles(REFERENCE_GESTURE_DIRECTORY_C);
            for (int i = 0; i < filePaths.Length; ++i)
            {
                StreamReader inFile = new StreamReader(filePaths[i]);
                ALL_POSSIBLE_GESTURES_C.Add(inFile.ReadLine());
                inFile.Close();
            }
        }
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