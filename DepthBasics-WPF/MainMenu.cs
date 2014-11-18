using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StretchIt
{
    public partial class MainMenu_t : Form
    {
        private Statistics_t stats_menu;
        private Settings_t settings_menu;
        private Help_t help_menu;

        public MainMenu_t()
        {
            InitializeComponent();
            stats_menu = new Statistics_t();
            settings_menu = new Settings_t();
            help_menu = new Help_t();
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
            GlobalVar.MODE = Game_mode_e.Play;
        }

        private void statsLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            stats_menu.Visible = true;
            stats_menu.Activate();
        }

        private void settingsLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            settings_menu.Visible = true;
            settings_menu.Activate();
        }

        private void helpLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            help_menu.Visible = true;
            help_menu.Activate();
        }

        private void MainMenu_t_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalVar.MODE = Game_mode_e.Exit_Game;
        }
    }
}
