namespace StretchIt
{
    partial class Settings
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
            this.title = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.pushLabel = new System.Windows.Forms.Label();
            this.pullLabel = new System.Windows.Forms.Label();
            this.pullUpDown = new System.Windows.Forms.NumericUpDown();
            this.swipeLabel = new System.Windows.Forms.Label();
            this.swipeUpDown = new System.Windows.Forms.NumericUpDown();
            this.pushHardLabel = new System.Windows.Forms.Label();
            this.pushHardUpDown = new System.Windows.Forms.NumericUpDown();
            this.fistBumpLabel = new System.Windows.Forms.Label();
            this.fistBumpUpDown = new System.Windows.Forms.NumericUpDown();
            this.highFiveLabel = new System.Windows.Forms.Label();
            this.highFiveUpDown = new System.Windows.Forms.NumericUpDown();
            this.pullHardLabel = new System.Windows.Forms.Label();
            this.pullHardUpDown = new System.Windows.Forms.NumericUpDown();
            this.pushUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pullUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swipeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushHardUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fistBumpUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highFiveUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullHardUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Action Jackson", 47.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(135, 38);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(348, 65);
            this.title.TabIndex = 0;
            this.title.Text = "Settings";
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(12, 327);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 2;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // pushLabel
            // 
            this.pushLabel.AutoSize = true;
            this.pushLabel.Location = new System.Drawing.Point(178, 139);
            this.pushLabel.Name = "pushLabel";
            this.pushLabel.Size = new System.Drawing.Size(31, 13);
            this.pushLabel.TabIndex = 4;
            this.pushLabel.Text = "Push";
            // 
            // pullLabel
            // 
            this.pullLabel.AutoSize = true;
            this.pullLabel.Location = new System.Drawing.Point(178, 165);
            this.pullLabel.Name = "pullLabel";
            this.pullLabel.Size = new System.Drawing.Size(24, 13);
            this.pullLabel.TabIndex = 6;
            this.pullLabel.Text = "Pull";
            // 
            // pullUpDown
            // 
            this.pullUpDown.Location = new System.Drawing.Point(316, 159);
            this.pullUpDown.Name = "pullUpDown";
            this.pullUpDown.Size = new System.Drawing.Size(120, 20);
            this.pullUpDown.TabIndex = 5;
            this.pullUpDown.ValueChanged += new System.EventHandler(this.pullUpDown_ValueChanged);
            // 
            // swipeLabel
            // 
            this.swipeLabel.AutoSize = true;
            this.swipeLabel.Location = new System.Drawing.Point(178, 191);
            this.swipeLabel.Name = "swipeLabel";
            this.swipeLabel.Size = new System.Drawing.Size(36, 13);
            this.swipeLabel.TabIndex = 8;
            this.swipeLabel.Text = "Swipe";
            // 
            // swipeUpDown
            // 
            this.swipeUpDown.Location = new System.Drawing.Point(316, 185);
            this.swipeUpDown.Name = "swipeUpDown";
            this.swipeUpDown.Size = new System.Drawing.Size(120, 20);
            this.swipeUpDown.TabIndex = 7;
            this.swipeUpDown.ValueChanged += new System.EventHandler(this.swipeUpDown_ValueChanged);
            // 
            // pushHardLabel
            // 
            this.pushHardLabel.AutoSize = true;
            this.pushHardLabel.Location = new System.Drawing.Point(178, 269);
            this.pushHardLabel.Name = "pushHardLabel";
            this.pushHardLabel.Size = new System.Drawing.Size(57, 13);
            this.pushHardLabel.TabIndex = 14;
            this.pushHardLabel.Text = "Push Hard";
            // 
            // pushHardUpDown
            // 
            this.pushHardUpDown.Location = new System.Drawing.Point(316, 263);
            this.pushHardUpDown.Name = "pushHardUpDown";
            this.pushHardUpDown.Size = new System.Drawing.Size(120, 20);
            this.pushHardUpDown.TabIndex = 13;
            this.pushHardUpDown.ValueChanged += new System.EventHandler(this.pushHardUpDown_ValueChanged);
            // 
            // fistBumpLabel
            // 
            this.fistBumpLabel.AutoSize = true;
            this.fistBumpLabel.Location = new System.Drawing.Point(178, 243);
            this.fistBumpLabel.Name = "fistBumpLabel";
            this.fistBumpLabel.Size = new System.Drawing.Size(53, 13);
            this.fistBumpLabel.TabIndex = 12;
            this.fistBumpLabel.Text = "Fist Bump";
            // 
            // fistBumpUpDown
            // 
            this.fistBumpUpDown.Location = new System.Drawing.Point(316, 237);
            this.fistBumpUpDown.Name = "fistBumpUpDown";
            this.fistBumpUpDown.Size = new System.Drawing.Size(120, 20);
            this.fistBumpUpDown.TabIndex = 11;
            this.fistBumpUpDown.ValueChanged += new System.EventHandler(this.firstBumpUpDown_ValueChanged);
            // 
            // highFiveLabel
            // 
            this.highFiveLabel.AutoSize = true;
            this.highFiveLabel.Location = new System.Drawing.Point(178, 217);
            this.highFiveLabel.Name = "highFiveLabel";
            this.highFiveLabel.Size = new System.Drawing.Size(52, 13);
            this.highFiveLabel.TabIndex = 10;
            this.highFiveLabel.Text = "High Five";
            // 
            // highFiveUpDown
            // 
            this.highFiveUpDown.Location = new System.Drawing.Point(316, 211);
            this.highFiveUpDown.Name = "highFiveUpDown";
            this.highFiveUpDown.Size = new System.Drawing.Size(120, 20);
            this.highFiveUpDown.TabIndex = 9;
            this.highFiveUpDown.ValueChanged += new System.EventHandler(this.highFiveUpDown_ValueChanged);
            // 
            // pullHardLabel
            // 
            this.pullHardLabel.AutoSize = true;
            this.pullHardLabel.Location = new System.Drawing.Point(178, 296);
            this.pullHardLabel.Name = "pullHardLabel";
            this.pullHardLabel.Size = new System.Drawing.Size(50, 13);
            this.pullHardLabel.TabIndex = 16;
            this.pullHardLabel.Text = "Pull Hard";
            // 
            // pullHardUpDown
            // 
            this.pullHardUpDown.Location = new System.Drawing.Point(316, 290);
            this.pullHardUpDown.Name = "pullHardUpDown";
            this.pullHardUpDown.Size = new System.Drawing.Size(120, 20);
            this.pullHardUpDown.TabIndex = 15;
            this.pullHardUpDown.ValueChanged += new System.EventHandler(this.pullHardUpDown_ValueChanged);
            // 
            // pushUpDown
            // 
            this.pushUpDown.Location = new System.Drawing.Point(316, 132);
            this.pushUpDown.Name = "pushUpDown";
            this.pushUpDown.Size = new System.Drawing.Size(120, 20);
            this.pushUpDown.TabIndex = 17;
            this.pushUpDown.ValueChanged += new System.EventHandler(this.pushUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.pushUpDown);
            this.Controls.Add(this.pullHardLabel);
            this.Controls.Add(this.pullHardUpDown);
            this.Controls.Add(this.pushHardLabel);
            this.Controls.Add(this.pushHardUpDown);
            this.Controls.Add(this.fistBumpLabel);
            this.Controls.Add(this.fistBumpUpDown);
            this.Controls.Add(this.highFiveLabel);
            this.Controls.Add(this.highFiveUpDown);
            this.Controls.Add(this.swipeLabel);
            this.Controls.Add(this.swipeUpDown);
            this.Controls.Add(this.pullLabel);
            this.Controls.Add(this.pullUpDown);
            this.Controls.Add(this.pushLabel);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pullUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swipeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushHardUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fistBumpUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highFiveUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pullHardUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label pushLabel;
        private System.Windows.Forms.Label pullLabel;
        private System.Windows.Forms.NumericUpDown pullUpDown;
        private System.Windows.Forms.Label swipeLabel;
        private System.Windows.Forms.NumericUpDown swipeUpDown;
        private System.Windows.Forms.Label pushHardLabel;
        private System.Windows.Forms.NumericUpDown pushHardUpDown;
        private System.Windows.Forms.Label fistBumpLabel;
        private System.Windows.Forms.NumericUpDown fistBumpUpDown;
        private System.Windows.Forms.Label highFiveLabel;
        private System.Windows.Forms.NumericUpDown highFiveUpDown;
        private System.Windows.Forms.Label pullHardLabel;
        private System.Windows.Forms.NumericUpDown pullHardUpDown;
        private System.Windows.Forms.NumericUpDown pushUpDown;
    }
}