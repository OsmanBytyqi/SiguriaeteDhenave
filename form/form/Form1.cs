using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form
{
    public partial class steganografia : Form
    {
        private object textBox2FilePath;

        public steganografia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
            openFileDialog.InitialDirectory = @"C:\Users\njomza\Desktop";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName.ToString();
                pictureBox1.ImageLocation = textBoxFilePath.Text;
            }
        }

        private void steganografia_Load(object sender, EventArgs e)
        {

        }
    }
}
