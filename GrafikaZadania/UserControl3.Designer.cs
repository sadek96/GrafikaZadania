namespace GrafikaZadania
{
    partial class UserControl3
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.cmykToRgbButton = new System.Windows.Forms.Button();
            this.rgbToCmykButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showFromRGBButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bTextBox = new System.Windows.Forms.MaskedTextBox();
            this.gTrack = new System.Windows.Forms.TrackBar();
            this.rTrack = new System.Windows.Forms.TrackBar();
            this.bTrack = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.showFromCMYKButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kTextBox = new System.Windows.Forms.MaskedTextBox();
            this.cTrack = new System.Windows.Forms.TrackBar();
            this.kTrack = new System.Windows.Forms.TrackBar();
            this.yTrack = new System.Windows.Forms.TrackBar();
            this.mTrack = new System.Windows.Forms.TrackBar();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bTrack)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.colorPanel);
            this.panel3.Controls.Add(this.cmykToRgbButton);
            this.panel3.Controls.Add(this.rgbToCmykButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 529);
            this.panel3.TabIndex = 2;
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.Black;
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorPanel.Location = new System.Drawing.Point(6, 4);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(357, 320);
            this.colorPanel.TabIndex = 2;
            // 
            // cmykToRgbButton
            // 
            this.cmykToRgbButton.AutoSize = true;
            this.cmykToRgbButton.Location = new System.Drawing.Point(143, 388);
            this.cmykToRgbButton.Name = "cmykToRgbButton";
            this.cmykToRgbButton.Size = new System.Drawing.Size(88, 23);
            this.cmykToRgbButton.TabIndex = 1;
            this.cmykToRgbButton.Text = "CMYK na RGB";
            this.cmykToRgbButton.UseVisualStyleBackColor = true;
            this.cmykToRgbButton.Click += new System.EventHandler(this.cmykToRgbButton_Click);
            // 
            // rgbToCmykButton
            // 
            this.rgbToCmykButton.AutoSize = true;
            this.rgbToCmykButton.Location = new System.Drawing.Point(143, 346);
            this.rgbToCmykButton.Name = "rgbToCmykButton";
            this.rgbToCmykButton.Size = new System.Drawing.Size(88, 23);
            this.rgbToCmykButton.TabIndex = 0;
            this.rgbToCmykButton.Text = "RGB na CMYK";
            this.rgbToCmykButton.UseVisualStyleBackColor = true;
            this.rgbToCmykButton.Click += new System.EventHandler(this.rgbToCmykButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.showFromRGBButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bTextBox);
            this.panel1.Controls.Add(this.gTrack);
            this.panel1.Controls.Add(this.rTrack);
            this.panel1.Controls.Add(this.bTrack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 529);
            this.panel1.TabIndex = 0;
            // 
            // showFromRGBButton
            // 
            this.showFromRGBButton.Location = new System.Drawing.Point(61, 201);
            this.showFromRGBButton.Name = "showFromRGBButton";
            this.showFromRGBButton.Size = new System.Drawing.Size(88, 24);
            this.showFromRGBButton.TabIndex = 3;
            this.showFromRGBButton.Text = "Pokaż kolor";
            this.showFromRGBButton.UseVisualStyleBackColor = true;
            this.showFromRGBButton.Click += new System.EventHandler(this.showFromRGBButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Red";
            // 
            // rTextBox
            // 
            this.rTextBox.Location = new System.Drawing.Point(100, 325);
            this.rTextBox.Mask = "000";
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.Size = new System.Drawing.Size(100, 20);
            this.rTextBox.TabIndex = 7;
            this.rTextBox.TextChanged += new System.EventHandler(this.rgbTextBox_TextChanged);
            this.rTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Green";
            // 
            // gTextBox
            // 
            this.gTextBox.Location = new System.Drawing.Point(100, 392);
            this.gTextBox.Mask = "000";
            this.gTextBox.Name = "gTextBox";
            this.gTextBox.Size = new System.Drawing.Size(100, 20);
            this.gTextBox.TabIndex = 5;
            this.gTextBox.TextChanged += new System.EventHandler(this.rgbTextBox_TextChanged);
            this.gTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Blue";
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(100, 459);
            this.bTextBox.Mask = "000";
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(100, 20);
            this.bTextBox.TabIndex = 3;
            this.bTextBox.TextChanged += new System.EventHandler(this.rgbTextBox_TextChanged);
            this.bTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTextBox_KeyPress);
            // 
            // gTrack
            // 
            this.gTrack.Location = new System.Drawing.Point(0, 414);
            this.gTrack.Maximum = 255;
            this.gTrack.Name = "gTrack";
            this.gTrack.Size = new System.Drawing.Size(200, 45);
            this.gTrack.TabIndex = 2;
            this.gTrack.ValueChanged += new System.EventHandler(this.rgbTrackBar_ValueChanged);
            // 
            // rTrack
            // 
            this.rTrack.Location = new System.Drawing.Point(0, 347);
            this.rTrack.Maximum = 255;
            this.rTrack.Name = "rTrack";
            this.rTrack.Size = new System.Drawing.Size(200, 45);
            this.rTrack.TabIndex = 1;
            this.rTrack.ValueChanged += new System.EventHandler(this.rgbTrackBar_ValueChanged);
            // 
            // bTrack
            // 
            this.bTrack.Location = new System.Drawing.Point(0, 481);
            this.bTrack.Maximum = 255;
            this.bTrack.Name = "bTrack";
            this.bTrack.Size = new System.Drawing.Size(200, 45);
            this.bTrack.TabIndex = 0;
            this.bTrack.ValueChanged += new System.EventHandler(this.rgbTrackBar_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.showFromCMYKButton);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.mTextBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.yTextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.kTextBox);
            this.panel2.Controls.Add(this.cTrack);
            this.panel2.Controls.Add(this.kTrack);
            this.panel2.Controls.Add(this.yTrack);
            this.panel2.Controls.Add(this.mTrack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(570, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 529);
            this.panel2.TabIndex = 1;
            // 
            // showFromCMYKButton
            // 
            this.showFromCMYKButton.Location = new System.Drawing.Point(59, 201);
            this.showFromCMYKButton.Name = "showFromCMYKButton";
            this.showFromCMYKButton.Size = new System.Drawing.Size(88, 24);
            this.showFromCMYKButton.TabIndex = 14;
            this.showFromCMYKButton.Text = "Pokaż kolor";
            this.showFromCMYKButton.UseVisualStyleBackColor = true;
            this.showFromCMYKButton.Click += new System.EventHandler(this.showFromCMYKButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cyan";
            // 
            // cTextBox
            // 
            this.cTextBox.Location = new System.Drawing.Point(100, 257);
            this.cTextBox.Mask = "000";
            this.cTextBox.Name = "cTextBox";
            this.cTextBox.Size = new System.Drawing.Size(100, 20);
            this.cTextBox.TabIndex = 12;
            this.cTextBox.TextChanged += new System.EventHandler(this.rgbTextBox_TextChanged);
            this.cTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Magenta";
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(100, 325);
            this.mTextBox.Mask = "000";
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(100, 20);
            this.mTextBox.TabIndex = 10;
            this.mTextBox.TextChanged += new System.EventHandler(this.rgbTextBox_TextChanged);
            this.mTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Yellow";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(100, 392);
            this.yTextBox.Mask = "000";
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 20);
            this.yTextBox.TabIndex = 8;
            this.yTextBox.TextChanged += new System.EventHandler(this.rgbTextBox_TextChanged);
            this.yTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Black";
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point(100, 459);
            this.kTextBox.Mask = "000";
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(100, 20);
            this.kTextBox.TabIndex = 6;
            this.kTextBox.TextChanged += new System.EventHandler(this.rgbTextBox_TextChanged);
            this.kTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rgbTextBox_KeyPress);
            // 
            // cTrack
            // 
            this.cTrack.Location = new System.Drawing.Point(0, 280);
            this.cTrack.Maximum = 100;
            this.cTrack.Name = "cTrack";
            this.cTrack.Size = new System.Drawing.Size(200, 45);
            this.cTrack.TabIndex = 5;
            this.cTrack.ValueChanged += new System.EventHandler(this.rgbTrackBar_ValueChanged);
            // 
            // kTrack
            // 
            this.kTrack.Location = new System.Drawing.Point(0, 481);
            this.kTrack.Maximum = 100;
            this.kTrack.Name = "kTrack";
            this.kTrack.Size = new System.Drawing.Size(200, 45);
            this.kTrack.TabIndex = 4;
            this.kTrack.ValueChanged += new System.EventHandler(this.rgbTrackBar_ValueChanged);
            // 
            // yTrack
            // 
            this.yTrack.Location = new System.Drawing.Point(0, 414);
            this.yTrack.Maximum = 100;
            this.yTrack.Name = "yTrack";
            this.yTrack.Size = new System.Drawing.Size(200, 45);
            this.yTrack.TabIndex = 3;
            this.yTrack.ValueChanged += new System.EventHandler(this.rgbTrackBar_ValueChanged);
            // 
            // mTrack
            // 
            this.mTrack.Location = new System.Drawing.Point(0, 347);
            this.mTrack.Maximum = 100;
            this.mTrack.Name = "mTrack";
            this.mTrack.Size = new System.Drawing.Size(200, 45);
            this.mTrack.TabIndex = 1;
            this.mTrack.ValueChanged += new System.EventHandler(this.rgbTrackBar_ValueChanged);
            // 
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(770, 529);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bTrack)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTrack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox gTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox bTextBox;
        private System.Windows.Forms.TrackBar gTrack;
        private System.Windows.Forms.TrackBar rTrack;
        private System.Windows.Forms.TrackBar bTrack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox rTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox cTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox yTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox kTextBox;
        private System.Windows.Forms.TrackBar cTrack;
        private System.Windows.Forms.TrackBar kTrack;
        private System.Windows.Forms.TrackBar yTrack;
        private System.Windows.Forms.TrackBar mTrack;
        private System.Windows.Forms.Button cmykToRgbButton;
        private System.Windows.Forms.Button rgbToCmykButton;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button showFromRGBButton;
        private System.Windows.Forms.Button showFromCMYKButton;
    }
}
