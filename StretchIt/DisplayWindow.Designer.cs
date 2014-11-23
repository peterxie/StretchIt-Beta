namespace StretchIt
{
    partial class DisplayWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayWindow));
            this.mainPicture = new System.Windows.Forms.PictureBox();
            this.backLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicture
            // 
            this.mainPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainPicture.BackColor = System.Drawing.Color.Transparent;
            this.mainPicture.Location = new System.Drawing.Point(67, 45);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(305, 281);
            this.mainPicture.TabIndex = 0;
            this.mainPicture.TabStop = false;
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
            this.backLabel.Click += new System.EventHandler(this.backLabel_Click);
            // 
            // DisplayWindow
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 412);
            this.Controls.Add(this.backLabel);
            this.Controls.Add(this.mainPicture);
            this.Name = "DisplayWindow";
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPicture;
        private System.Windows.Forms.Label backLabel;

    }
}