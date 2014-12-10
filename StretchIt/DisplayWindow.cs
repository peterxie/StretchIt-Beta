using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace StretchIt
{
    public partial class Play_t : Form
    {
        SoundPlayer player;
        //int timeLeft;

        public Play_t()
        {
            InitializeComponent();
            showOnMonitor(1);
            //timeLeft = GlobalVar.TIME_TO_COMPLETE_GESTURE_C;
            player = new SoundPlayer();
        }

        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        public void loadOutput(string audio_file, string image_file)
        {
            this.Visible = true;
            
            this.BackgroundImage = Image.FromFile(image_file);
            //Thread t = new Thread(timer1.Start);
            //t.Start();
            Update();

             player.SoundLocation = audio_file;
            player.Play();
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            GlobalVar.MAIN_MENU.Visible = true;
            GlobalVar.MAIN_MENU.Activate();
            this.Visible = false;
            Cursor.Show();

            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Menu_Mode;
                Monitor.Pulse(GlobalVar.key);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
/*
            if (timeLeft > 0)
            {
                // Display the new time left 
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " sec";
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                timeLeft = GlobalVar.TIME_TO_COMPLETE_GESTURE_C;
            }
 */       }

        private void Play_t_Activated(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

 
    }
}
