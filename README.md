<p align="center">
  <img src="stego.png"  style="width:330px">
</p>

<!-- ## Steganografia është teknikë e fshehjes së të dhënave sekrete brenda një file apo mesazhi të zakonshëm, jo ​​sekret, në mënyrë që të shmanget zbulimi; të dhënat sekrete nxirren më pas në destinacionin e tyre. Përdorimi i steganografisë mund të kombinohet me kriptimin si një hap shtesë për fshehjen ose mbrojtjen e të dhënave. -->
<br/>

[![GitHub contributors](https://img.shields.io/github/contributors/OsmanBytyqi/SiguriaeteDhenave?color=&logo=github&style=for)](https://github.com/OsmanBytyqi/SiguriaeteDhenave/graphs/contributors)
![Discord](https://img.shields.io/discord/834805264048848946?logo=discord&logoColor=green&style=for)
![GitHub last commit](https://img.shields.io/github/last-commit/OsmanBytyqi/SiguriaeteDhenave?color=blue&logo=github&style=for)
![GitHub commit merge status](https://img.shields.io/github/commit-status/OsmanBytyqi/Siguriaetedhenave/master/74b2f7ce17a6b95f2a4ea2a923e205ce8e42587d?logo=github)

### Steganografia është teknikë e fshehjes së të dhënave sekrete brenda një file apo mesazhi të zakonshëm, jo ​​sekret, në mënyrë që të shmanget zbulimi; të dhënat sekrete nxirren më pas në destinacionin e tyre. Përdorimi i steganografisë mund të kombinohet me kriptimin si një hap shtesë për fshehjen ose mbrojtjen e të dhënave.

---


 > ### Fshehja e informates ne fotografi duke ndryshuar 3 bita ne pixel.


---
### Permes klasave te `.NET` kemi krijuar programin per enkriptim dhe dekriptim te informates ne fotografi dmth duke i ndryshuar nga 3 bita per pixel
---




### Funksioni i cili na mundeson qe ta hapim nje file

```java
//funksioni i cili na mundeson ta hapim nje file ne kete ras si nje .png .jpg

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
```
---
### Funksioni i cili e   `Enkripton` textin ne fotografi

```C#

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
```
---
### Funksioni i cili `Dekripton` textin ne fotografi
```C#

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
```


---
<br/>

##  License & CopyRigh

 
 © Osman Bytyqi 2021
 
Licensed under the [MIT License](https://github.com/OsmanBytyqi/SiguriaeteDhenave/blob/master/LICENSE)




