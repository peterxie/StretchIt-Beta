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

        public Play_t()
        {
            
            InitializeComponent();
            mainPicture.Visible = true;

            player = new SoundPlayer();
        }

        public void loadOutput(string audio_file, string image_file)
        {
            this.Visible = true;
            
            mainPicture.Image = Image.FromFile(image_file);
            Update();

            player.SoundLocation = audio_file;
            player.Play();
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
