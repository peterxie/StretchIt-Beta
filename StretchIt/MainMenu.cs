using System;
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
    public partial class MainMenu_t : Form
    {
        private Statistics_t stats_menu;
        private Settings_t settings_menu;
        private Help_t help_menu;
        public static Point projector_location;

        public MainMenu_t()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            stats_menu = new Statistics_t();
            settings_menu = new Settings_t();
            help_menu = new Help_t();

            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }

            screenTest();
            this.Visible = true;
        }

        private void screenTest()
        {
            MainMenu_t.projector_location = System.Windows.Forms.Screen.AllScreens[1].Bounds.Location;

        }

        /* Accessor Properties */

        public Statistics_t Stats
        {
            get
            {
                return this.stats_menu;
            }
        }

        public Settings_t Settings
        {
            get
            {
                return this.settings_menu;
            }
        }

        public Help_t Help
        {
            get
            {
                return this.help_menu;
            }
        }

        /* Event Handling */

        private void playLabel_Click(object sender, EventArgs e)
        {
            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Play;
                Monitor.Pulse(GlobalVar.key);
            }
        }

        private void statsLabel_Click(object sender, EventArgs e)
        {
            stats_menu.Activate();
            stats_menu.Visible = true;
            this.Visible = false;
        }

        private void settingsLabel_Click(object sender, EventArgs e)
        {
            settings_menu.Activate();
            settings_menu.Visible = true;
            this.Visible = false;
        }

        private void helpLabel_Click(object sender, EventArgs e)
        {
            help_menu.Activate();
            help_menu.Visible = true;
            this.Visible = false;
        }

        private void MainMenu_t_FormClosing(object sender, FormClosingEventArgs e)
        {
            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Exit_Game;
                Monitor.Pulse(GlobalVar.key);
            }
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            lock (GlobalVar.key)
            {
                GlobalVar.MODE = Game_mode_e.Exit_Game;
                Monitor.Pulse(GlobalVar.key);
            }
            Close();
        }
    }
}
