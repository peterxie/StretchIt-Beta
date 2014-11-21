﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StretchIt
{
    public class driver
    {
        Dictionary<string, Gesture_t> reference_gestures;
        Kinect_t kinect;
        public MessageBox gesture_valid_prompt;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainMenu_t m = new MainMenu_t();
            GlobalVar.MAIN_MENU = m;

            driver d = new driver();
            Thread t = new Thread(d.run_system);
            t.Start();

            Application.Run(m);

            t.Abort();
        }
        
        public driver()
        {
            reference_gestures = new Dictionary<string,Gesture_t>();
            kinect = new Kinect_t();

            loadReferenceGestures();
        }

        private void loadReferenceGestures()
        {
            string[] filePathsGestures = Directory.GetFiles(GlobalVar.REFERENCE_GESTURE_DIRECTORY_C);
            string[] filePathsAudio = Directory.GetFiles(GlobalVar.AUDIO_DIRECTORY_C);
            string[] filePathsVideo = Directory.GetFiles(GlobalVar.IMAGE_DIRECTORY_C);
            Array.Sort<string>(filePathsGestures);
            Array.Sort<string>(filePathsAudio);
            Array.Sort<string>(filePathsVideo);
            
            for (int i = 0; i < filePathsGestures.Length; ++i)
            {
                StreamReader inFile = new StreamReader(filePathsGestures[i]);
                
                String gesture_name = inFile.ReadLine();

                Gesture_t ref_gesture = new Gesture_t(gesture_name, 
                    filePathsGestures[i],filePathsAudio[i],filePathsVideo[i], 
                    GlobalVar.AUDIO_DIRECTORY_C+"celebration.wav",GlobalVar.IMAGE_DIRECTORY_C+"celebration.jpg");
                
                reference_gestures.Add(gesture_name, ref_gesture);
                
                inFile.Close();
            }
        }

        public void run_system()
        {
            while(GlobalVar.MODE != Game_mode_e.Exit_Game) {
                lock (GlobalVar.key)
                {
                    while (GlobalVar.MODE != Game_mode_e.Play && GlobalVar.MODE != Game_mode_e.Record)
                        Monitor.Wait(GlobalVar.key);
                    switch (GlobalVar.MODE)
                    {
                        case Game_mode_e.Play:
                            play_game();
                            break;

                        case Game_mode_e.Record:
                            createGesture();
                            Monitor.Wait(GlobalVar.key);
                            break;

                        case Game_mode_e.Add_Gesture:
                            addGesture();
                            GlobalVar.MODE = Game_mode_e.Menu_Mode;
                            break;

                        //default: maybe put a pause here
                    }
                }
            }
            
            GlobalVar.MAIN_MENU.Stats.saveStatistics();
        }

        private void play_game()
        {
            while (GlobalVar.MODE == Game_mode_e.Play)
            {
                Gesture_t nextGesture = reference_gestures[GlobalVar.MAIN_MENU.Settings.getGestureName()];
                nextGesture.sendPrompt();

                kinect.recordGesture(GlobalVar.NUM_FRAMES_RECORD_C);

                Gesture_rc_e state_gesture = Gesture_rc_e.No_Input;

                while (state_gesture == Gesture_rc_e.No_Input)
                {
                    state_gesture = nextGesture.processGesture(kinect.getFrame());
                    
                    switch (state_gesture)
                    {
                        case Gesture_rc_e.Correct:
                            GlobalVar.MAIN_MENU.Stats.recordResult(true);
                            break;
                        case Gesture_rc_e.Incorrect:
                            GlobalVar.MAIN_MENU.Stats.recordResult(false);
                            break;
                    }
                }
            }
        }

        /*private Gesture_t select_next_gesture()
        {
            Random r = new Random();
            
            int selected_index = r.Next(GlobalVar.MAIN_MENU.Settings.getGestures().Count);
            
            return reference_gestures[GlobalVar.MAIN_MENU.Settings.getGestures()[selected_index]];
        }*/

        private void createGesture()
        {
            string gesture_name = GlobalVar.MAIN_MENU.Settings.record_gesture_name;
            
            kinect.recordGesture(GlobalVar.NUM_FRAMES_RECORD_C);

            Frame_t f = kinect.getFrame();
            f.write(@"../../GestureImages/gesture.txt", gesture_name);
        }

        private void addGesture()
        {
            string gesture_name = GlobalVar.MAIN_MENU.Settings.record_gesture_name;

            Gesture_t ref_gesture = new Gesture_t(gesture_name,
                GlobalVar.REFERENCE_GESTURE_DIRECTORY_C + gesture_name, 
                GlobalVar.AUDIO_DIRECTORY_C + gesture_name, 
                GlobalVar.IMAGE_DIRECTORY_C + gesture_name,
                GlobalVar.AUDIO_DIRECTORY_C + "celebration.wav", 
                GlobalVar.IMAGE_DIRECTORY_C + "celebration.jpg");

            reference_gestures.Add(gesture_name, ref_gesture);
        }
    }
}
