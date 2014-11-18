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
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Action Jackson", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Location = new System.Drawing.Point(84, 42);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(441, 65);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Stretch-It!";
            // 
            // playLabel
            // 
            this.playLabel.AutoSize = true;
            this.playLabel.BackColor = System.Drawing.Color.Transparent;
            this.playLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playLabel.Location = new System.Drawing.Point(249, 142);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(114, 38);
            this.playLabel.TabIndex = 1;
            this.playLabel.Text = "play";
            this.playLabel.Click += new System.EventHandler(this.playLabel_Click);
            // 
            // statsLabel
            // 
            this.statsLabel.AutoSize = true;
            this.statsLabel.BackColor = System.Drawing.Color.Transparent;
            this.statsLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsLabel.Location = new System.Drawing.Point(241, 195);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(131, 38);
            this.statsLabel.TabIndex = 2;
            this.statsLabel.Text = "stats";
            this.statsLabel.Click += new System.EventHandler(this.statsLabel_Click);
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.BackColor = System.Drawing.Color.Transparent;
            this.settingsLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.settingsLabel.Location = new System.Drawing.Point(204, 250);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(201, 38);
            this.settingsLabel.TabIndex = 3;
            this.settingsLabel.Text = "settings";
            this.settingsLabel.Click += new System.EventHandler(this.settingsLabel_Click);
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.BackColor = System.Drawing.Color.Transparent;
            this.helpLabel.Font = new System.Drawing.Font("Action Jackson", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.helpLabel.Location = new System.Drawing.Point(255, 303);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(112, 38);
            this.helpLabel.TabIndex = 4;
            this.helpLabel.Text = "help";
            this.helpLabel.Click += new System.EventHandler(this.helpLabel_Click);
            // 
            // MainMenu_t
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(599, 399);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.settingsLabel);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "MainMenu_t";
            this.Text = "Main Menu";
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
    }
}