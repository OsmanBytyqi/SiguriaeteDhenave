
namespace Steganografi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_encode = new System.Windows.Forms.Button();
            this.button_decode = new System.Windows.Forms.Button();
            this.textEnterBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.OpenFileTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_encode
            // 
            this.button_encode.Location = new System.Drawing.Point(201, 370);
            this.button_encode.Name = "button_encode";
            this.button_encode.Size = new System.Drawing.Size(132, 23);
            this.button_encode.TabIndex = 0;
            this.button_encode.Text = "Encode";
            this.button_encode.UseVisualStyleBackColor = true;
            this.button_encode.Click += new System.EventHandler(this.button_encode_Click);
            // 
            // button_decode
            // 
            this.button_decode.Location = new System.Drawing.Point(405, 370);
            this.button_decode.Name = "button_decode";
            this.button_decode.Size = new System.Drawing.Size(132, 23);
            this.button_decode.TabIndex = 1;
            this.button_decode.Text = "Decode";
            this.button_decode.UseVisualStyleBackColor = true;
            this.button_decode.Click += new System.EventHandler(this.button_decode_Click);
            // 
            // textEnterBox
            // 
            this.textEnterBox.Location = new System.Drawing.Point(270, 310);
            this.textEnterBox.Name = "textEnterBox";
            this.textEnterBox.Size = new System.Drawing.Size(220, 23);
            this.textEnterBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Write your text here:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(201, 260);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(123, 23);
            this.button_OpenFile.TabIndex = 4;
            this.button_OpenFile.Text = "Open File";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // OpenFileTextBox
            // 
            this.OpenFileTextBox.Location = new System.Drawing.Point(387, 260);
            this.OpenFileTextBox.Name = "OpenFileTextBox";
            this.OpenFileTextBox.Size = new System.Drawing.Size(150, 23);
            this.OpenFileTextBox.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(247, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(210)))), ((int)(((byte)(145)))));
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OpenFileTextBox);
            this.Controls.Add(this.button_OpenFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEnterBox);
            this.Controls.Add(this.button_decode);
            this.Controls.Add(this.button_encode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Stegaongraphy";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_encode;
        private System.Windows.Forms.Button button_decode;
        private System.Windows.Forms.TextBox textEnterBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.TextBox OpenFileTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

