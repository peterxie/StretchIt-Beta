﻿using System;
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
        public MainMenu_t()
        {
            InitializeComponent();
        }

        private void playLabel_Click(object sender, EventArgs e)
        {

        }

        private void statsLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GlobalVar.STATS_MENU.Visible = true;
        }

        private void settingsLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GlobalVar.SETTINGS_MENU.Visible = true;
        }

        private void helpLabel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GlobalVar.HELP_MENU.Visible = true;
        }
    }
}
