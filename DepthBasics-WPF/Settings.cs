using System;
using System.Collections.Generic;
using System.IO;

namespace StretchIt
{
    public class Settings_t : MenuPage_t
    {
        private List<string> selected_gestures;
        private Dictionary<string, int> configuration;
        private string path;

        //can't retrieve last settings until we agree on a format
        public Settings_t()
        {
            selected_gestures = new List<string>();
            configuration = new Dictionary<string, int>();
            path = "settings.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string name = line;
                        if((line = sr.ReadLine()) == null)
                        {
                            useDefaults();
                        }

                        int frequency = int.Parse(line);
                        configuration[name] = frequency;

                        for(int i = 0; i < frequency; ++i)
                        {
                            selected_gestures.Add(name);
                        }
                    }
                    if(selected_gestures.Count == 0)
                    {
                        useDefaults();
                    }
                }
            }
            catch(FileNotFoundException e)
            {
                useDefaults();
            }
        }

        private void useDefaults()
        {
            foreach(string name in GlobalVar.ALL_POSSIBLE_GESTURES_C)
            {
                selected_gestures.Add(name);
                configuration[name] = 1;
            }
        }

        public List<string> getGestures()
        {
            return selected_gestures;
        }

        public override void back()
        {
            save();
        }

        private void save()
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                foreach(KeyValuePair<string, int> option in configuration)
                {
                    sw.WriteLine(option.Key);
                    sw.WriteLine(option.Value);
                }
            }
        }

        public void setOption(string option_name, int option_value)
        {
            configuration[option_name] = option_value;
            return;
        }

        public void addGesture(string gesture_name)
        {
            selected_gestures.Add(gesture_name);
            return;
        }

        public void removeGesture(string gesture_name)
        {
            selected_gestures.Remove(gesture_name);
            return;
        }

        public string getGesture()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, selected_gestures.Count);

            return selected_gestures[index];
        }
    }
}

