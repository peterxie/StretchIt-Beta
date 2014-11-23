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
    public partial class DisplayWindow : Form
    {
        SoundPlayer player;
        //Thread t;
        
        
        public DisplayWindow()
        {
            
            InitializeComponent();
            mainPicture.Visible = true;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            player = new SoundPlayer();
        }

        public void loadOutput(string audio_file, string image_file)
        {
            //t = new Thread(player.PlaySync);

            mainPicture.Image = Image.FromFile(image_file);
            Update();
            this.Visible = true;

            player.SoundLocation = audio_file;
            player.Play();

            //t.Start();

            //should be able to remove thread and use player.Play()
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            GlobalVar.MAIN_MENU.Activate();
            GlobalVar.MAIN_MENU.Visible = true;
            this.Visible = false;

            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Menu_Mode;
                Monitor.Pulse(GlobalVar.key);
            }
        }

 
    }
}
