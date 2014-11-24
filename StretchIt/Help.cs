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
        private string statistics_help_text = "The Statistics screen allows " +
            "you to track your best all time streak versus your most recent score. " +
            "You can also similarly examine the percent of correct gestures.";
        private string settings_help_text = "The Settings screen is where " +
            "you may select the frequency that each gesture appears in the game. " +
            "Setting a frequency of 0 disables the gesture. You can also record " +
            "new gestures from this panel.";
        private string howTo_help_text = "When PLAY is selected, the left side of" +
            " the textile will depict a visual cue of the type of gesture. The " +
            "zone where the textile should be manipulated will glow. After " + 
            "interacting, the game will return feedback indicating correctness.";
        private bool is_nested = false;

        public Help_t()
        {
            this.DoubleBuffered = true;

            InitializeComponent();
            this.Visible = false;
            // help sub-menu fields should not be visible
            this.headerLabel.Visible = false;
            this.helpText.Visible = false;

            foreach (Control c in this.Controls)
            {
                c.Anchor = AnchorStyles.None;
            }
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            if (is_nested == false)
            {
                GlobalVar.MAIN_MENU.Activate();
                GlobalVar.MAIN_MENU.Visible = true;
                this.Visible = false;
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
