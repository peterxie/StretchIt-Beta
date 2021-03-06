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

                String gesture_name = filePathsGestures[i].Substring(15, filePathsGestures[i].Length - 19);
                inFile.ReadLine();

                Gesture_t ref_gesture = new Gesture_t(gesture_name, 
                    filePathsGestures[i],filePathsAudio[i],filePathsVideo[i]);
                
                reference_gestures.Add(gesture_name, ref_gesture);
                
                inFile.Close();
            }
        }

        public void run_system()
        {
            while(GlobalVar.MODE != Game_mode_e.Exit_Game) {
                lock (GlobalVar.key)
                {
                    while (GlobalVar.MODE == Game_mode_e.Menu_Mode)
                        Monitor.Wait(GlobalVar.key);
                    switch (GlobalVar.MODE)
                    {
                        case Game_mode_e.Play:
                            play_game();
                            GlobalVar.MODE = Game_mode_e.Menu_Mode;
                            break;

                        case Game_mode_e.Record:
                            createGesture();
                            Monitor.Wait(GlobalVar.key);
                            break;

                        case Game_mode_e.Add_Gesture:
                            addGesture();
                            GlobalVar.MODE = Game_mode_e.Menu_Mode;
                            break;

                        case Game_mode_e.Remove_Gesture:
                            removeGesture();
                            GlobalVar.MODE = Game_mode_e.Menu_Mode;
                            break;

                        case Game_mode_e.Calibrate:
                            kinect.resetReference();
                            GlobalVar.MODE = Game_mode_e.Menu_Mode;
                            break;

                        default:
                            break;
                    }
                }
            }
            
            GlobalVar.MAIN_MENU.Stats.saveStatistics();
        }

        private void play_game()
        {
            int num_rounds_completed = 0;
            //bool get_new_gesture = true;
            Gesture_t nextGesture = reference_gestures[GlobalVar.MAIN_MENU.Settings.getGestureName()];
            while (GlobalVar.MODE == Game_mode_e.Play && 
                    num_rounds_completed < GlobalVar.NUM_GESTURES_IN_GAME_C)
            {
                ++num_rounds_completed;
                //if (get_new_gesture)
                //{
                    nextGesture = reference_gestures[GlobalVar.MAIN_MENU.Settings.getGestureName()];
                    nextGesture.sendPrompt();
                //}

                Gesture_rc_e state_gesture = Gesture_rc_e.No_Input;

                while (state_gesture == Gesture_rc_e.No_Input)
                {
                    kinect.recordGesture(GlobalVar.NUM_FRAMES_RECORD_C);
                    state_gesture = nextGesture.processGesture(kinect.getFrame());
                    
                    switch (state_gesture)
                    {
                        case Gesture_rc_e.Correct:
                            GlobalVar.MAIN_MENU.Stats.recordResult(true);
                            nextGesture.sendFeedback();
                            //get_new_gesture = true;
                            GlobalVar.sleep(3000); 
                            break;
                        case Gesture_rc_e.Incorrect:
                            GlobalVar.MAIN_MENU.Stats.recordResult(false);
                            //get_new_gesture = true;
                            GlobalVar.sleep(1500);
                            break;
                    }
                }
            }

            nextGesture.closeWindow();
        }

        private void createGesture()
        {
            string gesture_name = GlobalVar.MAIN_MENU.Settings.gesture_name_in_focus;
            
            kinect.recordGesture(GlobalVar.NUM_FRAMES_RECORD_C);

            Frame_t f = kinect.getFrame();

            f.write(GlobalVar.TEMP_GESTURE_FILE, gesture_name);
        }

        private void addGesture()
        {
            string gesture_name = GlobalVar.MAIN_MENU.Settings.gesture_name_in_focus;

            Gesture_t ref_gesture = new Gesture_t(gesture_name,
                GlobalVar.REFERENCE_GESTURE_DIRECTORY_C + gesture_name + ".txt", 
                GlobalVar.AUDIO_DIRECTORY_C + gesture_name + ".wav", 
                GlobalVar.IMAGE_DIRECTORY_C + gesture_name + ".jpg");

            reference_gestures.Add(gesture_name, ref_gesture);
        }

        private void removeGesture()
        {
            reference_gestures.Remove(GlobalVar.MAIN_MENU.Settings.gesture_name_in_focus);
        }
    }
}
