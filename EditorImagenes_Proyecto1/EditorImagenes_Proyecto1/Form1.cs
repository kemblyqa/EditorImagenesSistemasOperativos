using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorImagenes_Proyecto1
{
    public partial class Form1 : Form
    {
        private string pathImg;
        public Form1()
        {
            InitializeComponent();
            cmbFilters.SelectedIndex = 0;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select an image.
            openFileDialog1.Filter = "Png files (*.png)|*.png|Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg";
            openFileDialog1.Title = "Select an imagen file";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a image file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgLoader1.Image = Image.FromFile(openFileDialog1.FileName);
                this.pathImg = openFileDialog1.FileName; // set the img path

            }
        }

        private void btnGenerateImg_Click(object sender, EventArgs e)
        {
            switch (cmbFilters.SelectedIndex)
            {
                case 0:
                    //
                    break;
                case 1:
                    sepiaFunction();
                    break;
                default:
                    //
                    break;
            }
        }
        /// <summary>
        /// Function where we will apply the sepia filter to the loaded image
        /// </summary>
        private void sepiaFunction()
        {
            //read image
            Bitmap bmp = new Bitmap(this.pathImg);

            //load original image in picturebox1
            imgLoader1.Image = Image.FromFile(this.pathImg);

            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            //load sepia image in picturebox2
            imgLoader2.Image = bmp;

            //save (write) sepia image
            bmp.Save("D:\\Image\\Sepia.png");
        }
    }    
}
