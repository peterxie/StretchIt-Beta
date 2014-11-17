using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Samples.Kinect.DepthBasics
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            //this.HelpTextBox.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            HelpTextBox.BackColor = System.Drawing.Color.Transparent;
            HelpTextBox.Text = "This is the help text!";
        }

        private void backLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
