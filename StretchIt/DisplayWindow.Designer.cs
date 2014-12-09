namespace StretchIt
{
    partial class Play_t
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Play_t));
            this.backLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backLabel
            // 
            this.backLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backLabel.AutoSize = true;
            this.backLabel.BackColor = System.Drawing.Color.Transparent;
            this.backLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backLabel.ForeColor = System.Drawing.Color.White;
            this.backLabel.Location = new System.Drawing.Point(12, 371);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(96, 32);
            this.backLabel.TabIndex = 1;
            this.backLabel.Text = "Back";
            this.backLabel.Visible = false;
            this.backLabel.Click += new System.EventHandler(this.backLabel_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timeLabel.Location = new System.Drawing.Point(144, 353);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(150, 30);
            this.timeLabel.TabIndex = 2;
            // 
            // Play_t
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 412);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.backLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Play_t";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Play_t_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeLabel;

    }
}