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
           Bitmap img = new Bitmap(OpenFileTextBox.Text);
            //looping pixels of img
            for(int i = 0; i < img.Width; i++)
            {
                for(int j = 0; j < img.Height; j++)
                {
                    //each pixel consist RGB value
                    Color pixel = img.GetPixel(i, j);
                    if (i < 1 && j < textEnterBox.TextLength)
                    {

                        char letter = Convert.ToChar(textEnterBox.Text.Substring(j, 1));
                        int value = Convert.ToInt32(letter);
                        Console.WriteLine("letter:"+letter+"value:" + value);

                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, value));

                    }

                    if (i == img.Width - 1 && j == img.Height - 1)
                    {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, textEnterBox.TextLength));
                    }
                }
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
            saveFile.InitialDirectory = @"C:\Users\Jd\Desktop";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                OpenFileTextBox.Text = saveFile.FileName.ToString();
                pictureBox1.ImageLocation = OpenFileTextBox.Text;

                img.Save(OpenFileTextBox.Text);
            }

        }

        private void button_decode_Click(object sender, EventArgs e)
        
        
        {
        
         Bitmap img = new Bitmap(OpenFileTextBox.Text);
            string message = "";

            Color lastpixel = img.GetPixel(img.Width - 1, img.Height - 1);
            
            int msgLength = lastpixel.B;

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (i < 1 && j < msgLength)
                    {
                        int value = pixel.B;
                        
                        char c = Convert.ToChar(value);
                        string letter = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                        

                        message = message + letter;
                    }
                }
            }

            textEnterBox.Text = message;
        
        
        
          
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
