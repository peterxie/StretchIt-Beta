namespace StretchIt
{
    partial class Setup_t
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_t));
            this.backLabel = new System.Windows.Forms.Label();
            this.setupLabel = new System.Windows.Forms.Label();
            this.kinectPictureBox = new System.Windows.Forms.PictureBox();
            this.calibrateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kinectPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // backLabel
            // 
            this.backLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backLabel.AutoSize = true;
            this.backLabel.BackColor = System.Drawing.Color.Transparent;
            this.backLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backLabel.ForeColor = System.Drawing.Color.White;
            this.backLabel.Location = new System.Drawing.Point(15, 649);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(96, 32);
            this.backLabel.TabIndex = 45;
            this.backLabel.Text = "Back";
            this.backLabel.Click += new System.EventHandler(this.backLabel_Click);
            // 
            // setupLabel
            // 
            this.setupLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.setupLabel.AutoSize = true;
            this.setupLabel.BackColor = System.Drawing.Color.Transparent;
            this.setupLabel.Font = new System.Drawing.Font("Action Jackson", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.setupLabel.Location = new System.Drawing.Point(287, 20);
            this.setupLabel.Name = "setupLabel";
            this.setupLabel.Size = new System.Drawing.Size(226, 65);
            this.setupLabel.TabIndex = 46;
            this.setupLabel.Text = "Setup";
            // 
            // kinectPictureBox
            // 
            this.kinectPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kinectPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.kinectPictureBox.Location = new System.Drawing.Point(80, 112);
            this.kinectPictureBox.Name = "kinectPictureBox";
            this.kinectPictureBox.Size = new System.Drawing.Size(640, 480);
            this.kinectPictureBox.TabIndex = 47;
            this.kinectPictureBox.TabStop = false;
            // 
            // calibrateLabel
            // 
            this.calibrateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calibrateLabel.AutoSize = true;
            this.calibrateLabel.BackColor = System.Drawing.Color.Transparent;
            this.calibrateLabel.Font = new System.Drawing.Font("Action Jackson", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrateLabel.ForeColor = System.Drawing.Color.White;
            this.calibrateLabel.Location = new System.Drawing.Point(301, 649);
            this.calibrateLabel.Name = "calibrateLabel";
            this.calibrateLabel.Size = new System.Drawing.Size(198, 32);
            this.calibrateLabel.TabIndex = 48;
            this.calibrateLabel.Text = "Calibrate";
            this.calibrateLabel.Click += new System.EventHandler(this.calibrateLabel_Click);
            // 
            // Setup_t
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.calibrateLabel);
            this.Controls.Add(this.kinectPictureBox);
            this.Controls.Add(this.setupLabel);
            this.Controls.Add(this.backLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Setup_t";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.kinectPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.Label setupLabel;
        private System.Windows.Forms.PictureBox kinectPictureBox;
        private System.Windows.Forms.Label calibrateLabel;
    }
}