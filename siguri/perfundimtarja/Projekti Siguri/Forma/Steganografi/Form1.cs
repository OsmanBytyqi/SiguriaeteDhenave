using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganografi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button_OpenFile_Click(object sender, EventArgs e)
        {
           OpenFileDialog openfileDialog = new OpenFileDialog();
            openfileDialog.Filter = "Image Files (*.png,*.jpg)|*png;*.jpg";
            openfileDialog.InitialDirectory = @"C:\Users\jd\Desktop";

            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFileTextBox.Text = openfileDialog.FileName.ToString();
                pictureBox1.ImageLocation = OpenFileTextBox.Text;
            }
        }
 
        private void button_encode_Click(object sender, EventArgs e)
        {
           

        }

        private void button_decode_Click(object sender, EventArgs e)
        {
          
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}