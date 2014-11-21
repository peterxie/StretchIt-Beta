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

        private List<NumericUpDown> default_up_downs;
        private List<Label> default_labels;
        
        private List<NumericUpDown> custom_up_downs;
        private List<Label> custom_labels;
        private int num_custom;

        public string record_gesture_name { get; set; }
        public string record_gesture_image { get; set; }
        public string record_gesture_audio { get; set; }

        public Settings_t()
        {
            InitializeComponent();
            this.Visible = false;
            inputText.Visible = false;
            retrieveInput.Visible = false;

            selected_gestures = new List<string>();
            configuration = new Dictionary<string, int>();
            record_gesture_name = "";

            default_up_downs = new List<NumericUpDown>();
            default_up_downs.Add(pushUpDown);
            default_up_downs.Add(pullUpDown);
            default_up_downs.Add(swipeUpDown);
            default_up_downs.Add(highFiveUpDown);
            default_up_downs.Add(pushHardUpDown);
            default_up_downs.Add(pullHardUpDown);

            default_labels = new List<Label>();
            default_labels.Add(pushLabel);
            default_labels.Add(pullLabel);
            default_labels.Add(swipeLabel);
            default_labels.Add(highFiveLabel);
            default_labels.Add(pushHardLabel);
            default_labels.Add(pullHardLabel);

            custom_up_downs = new List<NumericUpDown>();
            custom_up_downs.Add(customUpDown1);
            custom_up_downs.Add(customUpDown2);
            custom_up_downs.Add(customUpDown3);
            custom_up_downs.Add(customUpDown4);
            custom_up_downs.Add(customUpDown5);
            custom_up_downs.Add(customUpDown6);
            custom_up_downs.Add(customUpDown7);
            custom_up_downs.Add(customUpDown8);

            foreach(NumericUpDown n in custom_up_downs)
                n.Visible = false;

            custom_labels = new List<Label>();
            custom_labels.Add(customLabel1);
            custom_labels.Add(customLabel2);
            custom_labels.Add(customLabel3);
            custom_labels.Add(customLabel4);
            custom_labels.Add(customLabel5);
            custom_labels.Add(customLabel6);
            custom_labels.Add(customLabel7);
            custom_labels.Add(customLabel8);

            num_custom = 0;

            try
            {
                using (StreamReader sr = new StreamReader(GlobalVar.SETTINGS_PATH_C))
                {
                    string line;
                    int count = 0;

                    //each loop reads one pair of (name, frequency) values
                    while ((line = sr.ReadLine()) != null)
                    {
                        string name = line;

                        //read frequency name, if not found use defaults
                        if ((line = sr.ReadLine()) == null)
                        {
                            useDefaults();
                        }

                        int frequency = int.Parse(line);
                        //configuration[name] = frequency;

                        //if more gestures than default, add custom
                        if (count >= default_labels.Count)
                        {
                            custom_labels[num_custom].Text = name;
                            custom_up_downs[num_custom].Value = frequency;
                            custom_up_downs[num_custom].Visible = true;
                            ++num_custom;
                        }
                        else
                        {
                            default_up_downs[count].Value = frequency;
                        }

                        ++count;

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
        }

        private void useDefaults()
        {
            selected_gestures.Clear();
            
            for(int i = 0; i < default_labels.Count; ++i)
            {
                selected_gestures.Add(default_labels[i].Text);
                default_up_downs[i].Value = 1;
            }

        }

        public string getGestureName()
        {
            Random r = new Random();
            
            return selected_gestures[r.Next(selected_gestures.Count)];
        }

        private void save()
        {
            using(StreamWriter sw = new StreamWriter(GlobalVar.SETTINGS_PATH_C))
            {
                for (int i = 0; i < default_labels.Count; ++i)
                {
                    sw.WriteLine(default_labels[i].Text);
                    sw.WriteLine(default_up_downs[i].Value);
                }

                for (int i = 0; i < num_custom; ++i)
                {
                    sw.WriteLine(custom_labels[i].Text);
                    sw.WriteLine(custom_up_downs[i].Value);
                }

                    /*foreach (KeyValuePair<string, int> option in configuration)
                    {
                        sw.WriteLine(option.Key);
                        sw.WriteLine(option.Value);
                    }*/
            }
        }

        private void setSelectedGestures()
        {
            selected_gestures.Clear();
            
            for (int i = 0; i < default_up_downs.Count; ++i)
            {
                for (int j = 0; j < default_up_downs[i].Value; ++j)
                    selected_gestures.Add(default_labels[i].Text);
            }

            for (int i = 0; i < num_custom; ++i)
            {
                for (int j = 0; j < custom_up_downs[i].Value; ++j)
                    selected_gestures.Add(custom_labels[i].Text);
            }
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            save();

            setSelectedGestures();

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
            if (num_custom >= custom_labels.Count)
            {
                MessageBox.Show("You have created the maximum number of gestures!");
                return;
            }
            
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
            // Ensure that this gesture name does not already exist
            for (int i = 0; i < default_labels.Count; ++i)
            {
                if (default_labels[i].Text == inputText.Text)
                {
                    MessageBox.Show("Looks like that name is already taken!", "Whoops!", MessageBoxButtons.OK);
                    return;
                }
            }

            for (int i = 0; i < num_custom; ++i)
            {
                if (custom_labels[i].Text == inputText.Text)
                {
                    MessageBox.Show("Looks like that name is already taken!", "Whoops!", MessageBoxButtons.OK);
                    return;
                }
            }

            record_gesture_name = this.inputText.Text;

            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Record;
                Monitor.Pulse(GlobalVar.key);
            }

            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
            s.Start();
            while (s.ElapsedMilliseconds < 7000) { }
            s.Stop();

            GestureImage g = new GestureImage();

            if (MessageBox.Show("Do you want to save this gesture?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DialogResult img_result = imageFileDialog.ShowDialog();

                if (img_result == DialogResult.OK)
                {
                    record_gesture_image = imageFileDialog.FileName;

                    DialogResult audio_result = audioFileDialog.ShowDialog();

                    if (audio_result == DialogResult.OK)
                    {
                        record_gesture_audio = audioFileDialog.FileName;

                        //Send files to local directories with correct names
                        File.Copy(record_gesture_image, GlobalVar.IMAGE_DIRECTORY_C + record_gesture_name + ".jpg");
                        File.Copy(record_gesture_audio, GlobalVar.AUDIO_DIRECTORY_C + record_gesture_name + ".wav");
                        File.Copy(GlobalVar.TEMP_GESTURE_FILE, GlobalVar.REFERENCE_GESTURE_DIRECTORY_C + record_gesture_name + ".txt");


                        //Append Settings file with new gesture and default frequency
                        StreamWriter outFile = new StreamWriter(GlobalVar.SETTINGS_PATH_C, true);

                        outFile.WriteLine(record_gesture_name);
                        outFile.WriteLine(1);

                        outFile.Close();
                        drawGesture(record_gesture_name);
                        lock (GlobalVar.key)
                        {
                            GlobalVar.MODE = Game_mode_e.Add_Gesture;
                            Monitor.Pulse(GlobalVar.key);
                        }
                        backLabel_Click(sender, e);
                    }
                }
            }
            else
            {
                lock (GlobalVar.key)
                {
                    GlobalVar.MODE = Game_mode_e.Menu_Mode;
                    Monitor.Pulse(GlobalVar.key);
                }
            }

            g.Close();



        }

        public void drawGesture(string gesture_name)
        {
            custom_labels[num_custom].Text = gesture_name;
            custom_up_downs[num_custom].Value = 1;
            custom_up_downs[num_custom].Visible = true;
            
            ++num_custom;
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
