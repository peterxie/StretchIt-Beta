using System;
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
                GlobalVar.ALL_POSSIBLE_GESTURES_C.Add(gesture_name);

                Gesture_t ref_gesture = new Gesture_t(gesture_name, 
                    filePathsGestures[i],filePathsAudio[i],filePathsVideo[i], 
                    GlobalVar.AUDIO_DIRECTORY_C+"celebration.wav",GlobalVar.IMAGE_DIRECTORY_C+"celebration.jpg");
                
                reference_gestures.Add(gesture_name, ref_gesture);
                
                inFile.Close();
            }
        }

        public void run_system()
        {
            while(GlobalVar.MODE != Game_mode_e.Exit_Game)
            {
                switch (GlobalVar.MODE)
                {
                    case Game_mode_e.Play:
                        play_game();
                        break;

                    case Game_mode_e.Record:
                        createGesture();
                        break;
                    //default: maybe put a pause here
                }
            }
            
            GlobalVar.MAIN_MENU.Stats.saveStatistics();
        }

        private void play_game()
        {
            while (GlobalVar.MODE != Game_mode_e.Menu_Mode)
            {
                Gesture_t nextGesture = select_next_gesture();
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

        private Gesture_t select_next_gesture()
        {
            Random r = new Random();
            
            int selected_index = r.Next(GlobalVar.MAIN_MENU.Settings.getGestures().Count);
            
            return reference_gestures[GlobalVar.MAIN_MENU.Settings.getGestures()[selected_index]];
        }

        private void createGesture()
        {
            string gesture_name = GlobalVar.MAIN_MENU.Settings.record_gesture_name;
            
            kinect.recordGesture(GlobalVar.NUM_FRAMES_RECORD_C);

            Frame_t f = kinect.getFrame();

            f.write(GlobalVar.REFERENCE_GESTURE_DIRECTORY_C + gesture_name + ".txt", gesture_name);

            //Append Settings file with new gesture and default frequency
            StreamWriter outFile = new StreamWriter(GlobalVar.SETTINGS_PATH_C, true);
            
            outFile.WriteLine(gesture_name);
            outFile.WriteLine(1);
            
            outFile.Close();
            
            GlobalVar.ALL_POSSIBLE_GESTURES_C.Add(gesture_name);

            Thread t = new Thread(createGestureImage);
            t.Start();

            GlobalVar.MODE = Game_mode_e.Menu_Mode;
        }

        public void createGestureImage()
        {
            GestureImage g = new GestureImage(GlobalVar.REFERENCE_GESTURE_DIRECTORY_C + "gesture.txt");

            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();

            while (s.ElapsedMilliseconds < 5000) { }
        }
    }
}
