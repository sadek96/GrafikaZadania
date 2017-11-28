namespace GrafikaZadania
{
    partial class UserControl9
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.operationButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bTBox = new System.Windows.Forms.TextBox();
            this.thresholdTBox = new System.Windows.Forms.TextBox();
            this.gTBox = new System.Windows.Forms.TextBox();
            this.rTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 496);
            this.panel1.TabIndex = 2;
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(768, 494);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rTBox);
            this.panel2.Controls.Add(this.gTBox);
            this.panel2.Controls.Add(this.thresholdTBox);
            this.panel2.Controls.Add(this.bTBox);
            this.panel2.Controls.Add(this.operationButton);
            this.panel2.Controls.Add(this.loadImageButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 33);
            this.panel2.TabIndex = 3;
            // 
            // operationButton
            // 
            this.operationButton.Location = new System.Drawing.Point(692, 7);
            this.operationButton.Name = "operationButton";
            this.operationButton.Size = new System.Drawing.Size(75, 23);
            this.operationButton.TabIndex = 2;
            this.operationButton.Text = "Aplikuj";
            this.operationButton.UseVisualStyleBackColor = true;
            this.operationButton.Click += new System.EventHandler(this.operationButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.AutoSize = true;
            this.loadImageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadImageButton.Location = new System.Drawing.Point(0, 7);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(84, 23);
            this.loadImageButton.TabIndex = 0;
            this.loadImageButton.Text = "Wczytaj obraz";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bTBox
            // 
            this.bTBox.Location = new System.Drawing.Point(538, 9);
            this.bTBox.Name = "bTBox";
            this.bTBox.Size = new System.Drawing.Size(41, 20);
            this.bTBox.TabIndex = 3;
            // 
            // thresholdTBox
            // 
            this.thresholdTBox.Location = new System.Drawing.Point(636, 9);
            this.thresholdTBox.Name = "thresholdTBox";
            this.thresholdTBox.Size = new System.Drawing.Size(41, 20);
            this.thresholdTBox.TabIndex = 4;
            // 
            // gTBox
            // 
            this.gTBox.Location = new System.Drawing.Point(472, 9);
            this.gTBox.Name = "gTBox";
            this.gTBox.Size = new System.Drawing.Size(41, 20);
            this.gTBox.TabIndex = 5;
            // 
            // rTBox
            // 
            this.rTBox.Location = new System.Drawing.Point(408, 9);
            this.rTBox.Name = "rTBox";
            this.rTBox.Size = new System.Drawing.Size(41, 20);
            this.rTBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(590, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Thresh";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Oryginalny obraz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserControl9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UserControl9";
            this.Size = new System.Drawing.Size(770, 529);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button operationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rTBox;
        private System.Windows.Forms.TextBox gTBox;
        private System.Windows.Forms.TextBox thresholdTBox;
        private System.Windows.Forms.TextBox bTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
