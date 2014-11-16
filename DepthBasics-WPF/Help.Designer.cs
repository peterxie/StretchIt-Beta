namespace Microsoft.Samples.Kinect.DepthBasics
{
    partial class Help
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
            this.HelpListBox = new System.Windows.Forms.ListBox();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelpListBox
            // 
            this.HelpListBox.BackColor = System.Drawing.SystemColors.Control;
            this.HelpListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HelpListBox.FormattingEnabled = true;
            this.HelpListBox.Location = new System.Drawing.Point(87, 86);
            this.HelpListBox.Name = "HelpListBox";
            this.HelpListBox.Size = new System.Drawing.Size(400, 195);
            this.HelpListBox.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Action Jackson", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Location = new System.Drawing.Point(203, 18);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(193, 65);
            this.Title.TabIndex = 1;
            this.Title.Text = "Help";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.HelpListBox);
            this.Name = "Help";
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox HelpListBox;
        private System.Windows.Forms.Label Title;
    }
}