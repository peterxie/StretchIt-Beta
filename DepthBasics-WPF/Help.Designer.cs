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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.Title = new System.Windows.Forms.Label();
            this.HelpTextBox = new System.Windows.Forms.RichTextBox();
            this.backLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Action Jackson", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(203, 18);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(193, 65);
            this.Title.TabIndex = 1;
            this.Title.Text = "Help";
            // 
            // HelpTextBox
            // 
            this.HelpTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HelpTextBox.Location = new System.Drawing.Point(129, 109);
            this.HelpTextBox.Name = "HelpTextBox";
            this.HelpTextBox.Size = new System.Drawing.Size(338, 191);
            this.HelpTextBox.TabIndex = 3;
            this.HelpTextBox.Text = "";
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
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(599, 399);
            this.Controls.Add(this.backLabel);
            this.Controls.Add(this.HelpTextBox);
            this.Controls.Add(this.Title);
            this.Name = "Help";
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.RichTextBox HelpTextBox;
        private System.Windows.Forms.Label backLabel;
    }
}