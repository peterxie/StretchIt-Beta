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
            this.ImageHolder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageHolder
            // 
            this.ImageHolder.Location = new System.Drawing.Point(12, 12);
            this.ImageHolder.Name = "ImageHolder";
            this.ImageHolder.Size = new System.Drawing.Size(410, 373);
            this.ImageHolder.TabIndex = 0;
            this.ImageHolder.TabStop = false;
            // 
            // DisplayWindow
            // 
            this.ClientSize = new System.Drawing.Size(434, 412);
            this.Controls.Add(this.ImageHolder);
            this.Name = "DisplayWindow";
            ((System.ComponentModel.ISupportInitialize)(this.ImageHolder)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox ImageHolder;
    }
}