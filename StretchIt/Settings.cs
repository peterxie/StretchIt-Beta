using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace StretchIt
{
    public partial class Settings_t : Form
    {
        private List<string> selected_gestures;
        private Dictionary<string, int> configuration;
        public string record_gesture_name { get; set; }
        public string record_gesture_image { get; set; }
        //public string record_gesture_audio { get; set; }

        public Settings_t()
        {
            InitializeComponent();
            this.Visible = false;
            inputText.Visible = false;
            retrieveInput.Visible = false;

            selected_gestures = new List<string>();
            configuration = new Dictionary<string, int>();
            record_gesture_name = "";

            try
            {
                using (StreamReader sr = new StreamReader(GlobalVar.SETTINGS_PATH_C))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string name = line;
                        if ((line = sr.ReadLine()) == null)
                        {
                            useDefaults();
                        }

                        int frequency = int.Parse(line);
                        configuration[name] = frequency;

                        for (int i = 0; i < frequency; ++i)
                        {
                            selected_gestures.Add(name);
                        }
                    }
                    if (selected_gestures.Count == 0)
                    {
                        useDefaults();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                useDefaults();
            }

            if (configuration.ContainsKey("push"))
                this.pushUpDown.Value = configuration["push"];
            if (configuration.ContainsKey("pull"))
                this.pullUpDown.Value = configuration["pull"];
            if (configuration.ContainsKey("swipe"))
                this.swipeUpDown.Value = configuration["swipe"];
            if (configuration.ContainsKey("high_five"))
                this.highFiveUpDown.Value = configuration["high_five"];
            if (configuration.ContainsKey("fist_bump"))
                this.fistBumpUpDown.Value = configuration["fist_bump"];
            if (configuration.ContainsKey("push_hard"))
                this.pushHardUpDown.Value = configuration["push_hard"];
            if (configuration.ContainsKey("pull_hard"))
                this.pullHardUpDown.Value = configuration["pull_hard"];
        }

        private void useDefaults()
        {
            foreach (string name in GlobalVar.ALL_POSSIBLE_GESTURES_C)
            {
                selected_gestures.Add(name);
                configuration[name] = 1;
            }
        }

        public List<string> getGestures()
        {
            return selected_gestures;
        }

        private void save()
        {
            using(StreamWriter sw = new StreamWriter(GlobalVar.SETTINGS_PATH_C))
            {
                foreach(KeyValuePair<string, int> option in configuration)
                {
                    sw.WriteLine(option.Key);
                    sw.WriteLine(option.Value);
                }
            }
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            save();
            this.Visible = false;
            inputText.Visible = false;
            retrieveInput.Visible = false;
            GlobalVar.MAIN_MENU.Visible = true;
            GlobalVar.MAIN_MENU.Activate();
        }

        private void Settings_t_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("You must exit via the Back button.");
        }

        private void recordLabel_Click(object sender, EventArgs e)
        {
            retrieveInput.Visible = true;
            inputText.Visible = true;
        }

        private void Settings_t_Activated(object sender, EventArgs e)
        {
            //will we be reloading the settings file after a new gesture is written to it?
            //dependent on how we handle a new gesture

            //Refresh();
        }

        private void upDownBound(object sender, EventArgs e)
        {
            NumericUpDown updown = (NumericUpDown)sender;
            if (updown.Value < 0)
                updown.Value = 0;
            else if (updown.Value > 5)
                updown.Value = 5;
        }

        private void retrieveInput_Click(object sender, EventArgs e)
        {
            save(); //in case any settings were changed before recording
            record_gesture_name = this.inputText.Text;

            /*DialogResult result = openFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                record_gesture_image = openFileDialog1.FileName;
            }*/

            backLabel_Click(sender, e);

            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Record;
                Monitor.Pulse(GlobalVar.key);
            }
        }

        private void inputText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                retrieveInput_Click(sender, e);
            }
        }



    }
}
