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

namespace Microsoft.Samples.Kinect.DepthBasics
{
    public partial class DisplayWindow : Form
    {
        SoundPlayer player;
        Thread t;
        
        
        public DisplayWindow()
        {
            InitializeComponent();

            player = new SoundPlayer();
            t = new Thread(player.PlaySync);
        }

        public void loadOutput(string audio_file, string image_file)
        {
            ImageHolder.ImageLocation = image_file;
            player.SoundLocation = audio_file;

            t.Start();
        }

       
 
    }
}
