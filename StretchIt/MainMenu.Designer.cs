namespace StretchIt
{
    partial class MainMenu_t
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu_t));
            this.titleLabel = new System.Windows.Forms.Label();
            this.playLabel = new System.Windows.Forms.Label();
            this.statsLabel = new System.Windows.Forms.Label();
            this.settingsLabel = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Action Jackson", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Location = new System.Drawing.Point(84, 38);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(441, 65);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Stretch-It!";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playLabel
            // 
            this.playLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playLabel.AutoSize = true;
            this.playLabel.BackColor = System.Drawing.Color.Transparent;
            this.playLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playLabel.Location = new System.Drawing.Point(249, 125);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(114, 38);
            this.playLabel.TabIndex = 1;
            this.playLabel.Text = "play";
            this.playLabel.Click += new System.EventHandler(this.playLabel_Click);
            // 
            // statsLabel
            // 
            this.statsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.statsLabel.AutoSize = true;
            this.statsLabel.BackColor = System.Drawing.Color.Transparent;
            this.statsLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsLabel.Location = new System.Drawing.Point(241, 178);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(131, 38);
            this.statsLabel.TabIndex = 2;
            this.statsLabel.Text = "stats";
            this.statsLabel.Click += new System.EventHandler(this.statsLabel_Click);
            // 
            // settingsLabel
            // 
            this.settingsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.settingsLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.settingsLabel.Location = new System.Drawing.Point(204, 233);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(201, 38);
            this.settingsLabel.TabIndex = 3;
            this.settingsLabel.Text = "settings";
            this.settingsLabel.Click += new System.EventHandler(this.settingsLabel_Click);
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.helpLabel.AutoSize = true;
            this.helpLabel.BackColor = System.Drawing.Color.Transparent;
            this.helpLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.helpLabel.Location = new System.Drawing.Point(255, 286);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(112, 38);
            this.helpLabel.TabIndex = 4;
            this.helpLabel.Text = "help";
            this.helpLabel.Click += new System.EventHandler(this.helpLabel_Click);
            // 
            // exitLabel
            // 
            this.exitLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitLabel.AutoSize = true;
            this.exitLabel.BackColor = System.Drawing.Color.Transparent;
            this.exitLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitLabel.Location = new System.Drawing.Point(255, 337);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(115, 38);
            this.exitLabel.TabIndex = 5;
            this.exitLabel.Text = "exit";
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // MainMenu_t
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 399);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenu_t";
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_t_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label exitLabel;
    }
}