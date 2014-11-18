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
    public partial class Help_t : Form
    {
        private string statistics_help_text = "The statistics screen allows " +
            "you to track your all time score and see the difference " +
        "between all of your scores and your current score.";
        private string settings_help_text = "Settings help text";
        private string howTo_help_text = "This is how to play";
        private bool is_nested = false;

        public Help_t()
        {
            InitializeComponent();
            this.Visible = false;
            // help sub-menu fields should not be visible
            this.headerLabel.Visible = false;
            this.helpText.Visible = false;
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            if (is_nested == false)
            {
                this.Visible = false;
                GlobalVar.MAIN_MENU.Visible = true;
                GlobalVar.MAIN_MENU.Activate();
            } else
            {
                toggle_help_menu();
            }
        }

        private void toggle_help_menu()
        {
            is_nested = !is_nested;
            // help sub-menu fields
            this.headerLabel.Visible = !this.headerLabel.Visible;
            this.helpText.Visible = !this.helpText.Visible;
            // help header labels
            this.statisticsLabel.Visible = !this.statisticsLabel.Visible;
            this.settingsLabel.Visible = !this.settingsLabel.Visible;
            this.howToLabel.Visible = !this.howToLabel.Visible;

        }

        private void Help_t_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("You must exit via the Back button.");
        }

        private void statisticsLabel_Click(object sender, EventArgs e)
        {
            headerLabel.Text = "Statistics";
            helpText.Text = statistics_help_text;
            toggle_help_menu();
        }

        private void settingsLabel_Click(object sender, EventArgs e)
        {
            headerLabel.Text = "Settings";
            helpText.Text = settings_help_text;
            toggle_help_menu();
        }

        private void howToLabel_Click(object sender, EventArgs e)
        {
            headerLabel.Text = "How to play";
            helpText.Text = howTo_help_text;
            toggle_help_menu();

        }


    }
}
