using System;
using System.Collections.Generic;

namespace StretchIt
{
    public class Settings_t : MenuPage_t
    {
        private List<string> selected_gestures;
        private Dictionary<string, string> configuration;
        private string path;    //design doc has settings_file_name and default_file_name
                                //seems like we would only have one though

        //can't retrieve last settings until we agree on a format
        public Settings_t()
        {
            path = "files/settings.txt";
        }

        public Settings_t(string _path)
        {
            path = _path;
        }

        public override void back()
        {

        }

        public void setOption(string option_name, string option_value)
        {
            configuration[option_name] = option_value;
            return;
        }

        /*
        //Can't do this until we know what options we want so that we can format file properly
        public void setDefault
        {

        }*/

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

