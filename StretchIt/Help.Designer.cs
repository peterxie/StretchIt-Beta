namespace StretchIt
{
    partial class Help_t
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help_t));
            this.Title = new System.Windows.Forms.Label();
            this.backLabel = new System.Windows.Forms.Label();
            this.helpText = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.statisticsLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.howToLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Action Jackson", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(95, 53);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(413, 41);
            this.Title.TabIndex = 1;
            this.Title.Text = "Get help with...";
            // 
            // backLabel
            // 
            this.backLabel.AutoSize = true;
            this.backLabel.BackColor = System.Drawing.Color.Transparent;
            this.backLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backLabel.ForeColor = System.Drawing.Color.White;
            this.backLabel.Location = new System.Drawing.Point(13, 355);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(96, 32);
            this.backLabel.TabIndex = 4;
            this.backLabel.Text = "Back";
            this.backLabel.Click += new System.EventHandler(this.backLabel_Click);
            // 
            // helpText
            // 
            this.helpText.BackColor = System.Drawing.Color.Transparent;
            this.helpText.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpText.ForeColor = System.Drawing.Color.White;
            this.helpText.Location = new System.Drawing.Point(54, 206);
            this.helpText.Name = "helpText";
            this.helpText.Size = new System.Drawing.Size(488, 149);
            this.helpText.TabIndex = 5;
            this.helpText.Text = "This is a user\'s manual! It explains the functionality of each of the menus and h" +
    "ow to play the game. This text will be altered before the beta release!";
            this.helpText.Visible = false;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(51, 134);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(238, 32);
            this.headerLabel.TabIndex = 6;
            this.headerLabel.Text = "Menu title";
            // 
            // statisticsLabel
            // 
            this.statisticsLabel.AutoSize = true;
            this.statisticsLabel.BackColor = System.Drawing.Color.Transparent;
            this.statisticsLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsLabel.ForeColor = System.Drawing.Color.White;
            this.statisticsLabel.Location = new System.Drawing.Point(188, 209);
            this.statisticsLabel.Name = "statisticsLabel";
            this.statisticsLabel.Size = new System.Drawing.Size(213, 32);
            this.statisticsLabel.TabIndex = 7;
            this.statisticsLabel.Text = "Statistics";
            this.statisticsLabel.Click += new System.EventHandler(this.statisticsLabel_Click);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.settingsLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.ForeColor = System.Drawing.Color.White;
            this.settingsLabel.Location = new System.Drawing.Point(202, 274);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(177, 32);
            this.settingsLabel.TabIndex = 8;
            this.settingsLabel.Text = "Settings";
            this.settingsLabel.Click += new System.EventHandler(this.settingsLabel_Click);
            // 
            // howToLabel
            // 
            this.howToLabel.AutoSize = true;
            this.howToLabel.BackColor = System.Drawing.Color.Transparent;
            this.howToLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToLabel.ForeColor = System.Drawing.Color.White;
            this.howToLabel.Location = new System.Drawing.Point(172, 151);
            this.howToLabel.Name = "howToLabel";
            this.howToLabel.Size = new System.Drawing.Size(259, 32);
            this.howToLabel.TabIndex = 9;
            this.howToLabel.Text = "How to play";
            this.howToLabel.Click += new System.EventHandler(this.howToLabel_Click);
            // 
            // Help_t
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 399);
            this.Controls.Add(this.howToLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.statisticsLabel);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.helpText);
            this.Controls.Add(this.backLabel);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Help_t";
            this.Text = "Help";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Help_t_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.Label helpText;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label statisticsLabel;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label howToLabel;
    }
}