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
        Thread t;
        
        
        public DisplayWindow()
        {
            InitializeComponent();

            player = new SoundPlayer();
        }

        public void loadOutput(string audio_file, string image_file)
        {
            t = new Thread(player.PlaySync);
            //initializePicture();

            ImageHolder.Image = Image.FromFile(image_file);

            player.SoundLocation = audio_file;

            t.Start();
        }

 
    }
}
