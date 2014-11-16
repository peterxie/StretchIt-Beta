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
        public GlobalVar()
        {
            REFERENCE_GESTURE_DIRECTORY_C = @"c:.\Reference_Gestures\";
            AV_DIRECTORY_C = @"c:.\AudioVideo\";
            NUM_PIXELS_C = 307200;

            string[] filePaths = Directory.GetFiles(REFERENCE_GESTURE_DIRECTORY_C);
            for (int i = 0; i < filePaths.Length; ++i)
            {
                StreamReader inFile = new StreamReader(filePaths[i]);
                ALL_POSSIBLE_GESTURES_C.Add(inFile.ReadLine());
                inFile.Close();
            }
        }
    }
}