using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StretchIt
{
    public partial class Settings_t : Form
    {
        private List<string> selected_gestures;
        private Dictionary<string, int> configuration;
        private string path;

        public Settings_t()
        {
            InitializeComponent();

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
            catch (FileNotFoundException e)
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
            using(StreamWriter sw = new StreamWriter(path))
            {
                foreach(KeyValuePair<string, int> option in configuration)
                {
                    sw.WriteLine(option.Key);
                    sw.WriteLine(option.Value);
                }
            }
        }

        /********** Numeric UpDown ***********************/
        private void pushUpDown_ValueChanged(object sender, EventArgs e)
        {
            upDownBound(this.pushUpDown);
        }
        private void pullUpDown_ValueChanged(object sender, EventArgs e)
        {
            upDownBound(this.pullUpDown);
        }
        private void swipeUpDown_ValueChanged(object sender, EventArgs e)
        {
            upDownBound(this.swipeUpDown);
        }
        private void highFiveUpDown_ValueChanged(object sender, EventArgs e)
        {
            upDownBound(this.highFiveUpDown);
        }
        // aka fistBumpUpDown
        private void firstBumpUpDown_ValueChanged(object sender, EventArgs e)
        {
            upDownBound(this.fistBumpUpDown);
        }
        private void pushHardUpDown_ValueChanged(object sender, EventArgs e)
        {
            upDownBound(this.pushHardUpDown);
        }
        private void pullHardUpDown_ValueChanged(object sender, EventArgs e)
        {
            upDownBound(this.pullHardUpDown);
        }
        private void upDownBound(NumericUpDown up_down)
        {
            if (up_down.Value < 0)
                up_down.Value = 0;
            else if (up_down.Value > 5)
                up_down.Value = 5;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            save();
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            save();
            this.Visible = false;
        }
        /******************end Numeric UpDowns **************************/
    }
}
