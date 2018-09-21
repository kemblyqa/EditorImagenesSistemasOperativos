using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            panelCompress.Visible = false;
            
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
                case 0: //Escala de grises
                    //
                    break;
                case 1: //Sepia
                    if (rdbSequential.Checked)
                        sepiaSecuentialFunction();
                    else
                        sepiaThreadsFunction();
                    break;
                case 2: //Opacidad
                    //
                    break;
                case 3: //Invertir los colores
                    invertColorFunction();
                    break;
                case 4: //Desenfoque gaussiano
                    //
                    break;
                case 5: //Ajuste de brillo
                    //
                    break;
                case 6: //Compresión
                    compressImg();
                    VaryQualityLevel();
                    break;
                case 7: //Segmentación
                    break;
                case 8: //Textura
                    break;
                default:
                    //
                    break;
            }
        }
        private void quitCompressImg()
        {
            panelCompress.Visible = false;
            rdbParallelism.Location.Offset(712, 200);

            rdbSequential.Location.Offset(577, 200);
            btnGenerateImg.Location.Offset(608, 247);
        }
        private void compressImg()
        {
            panelCompress.Location.Offset(511, 184);
            panelCompress.Visible = true;
            rdbParallelism.Location.Offset(712,277); // 712; 200
            rdbSequential.Location.Offset(577,277); // 577; 200
            btnGenerateImg.Location.Offset(605, 324); // 608; 247
        }

        /// <summary>
        /// Function where we will apply the sepia filter to the loaded image
        /// </summary>
        private void sepiaSecuentialFunction()
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

        private void sepiaThreadsFunction()
        {

        }
        /// <summary>
        /// Function where we will apply the invert color filter to the loaded image
        /// </summary>
        private void invertColorFunction()
        {
            //read image
            Bitmap bmap = new Bitmap(this.pathImg);

            //load original image in picturebox1
            imgLoader1.Image = Image.FromFile(this.pathImg);

            Color col;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    col = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j,
                    Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B));
                }
            }
            imgLoader2.Image = bmap;
            bmap.Save("D:\\Image\\invertirColor.png");
        }

        private Bitmap compresssImageFunction(Bitmap imagen, long calidad)
        {
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, calidad);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, myImageCodecInfo, myEncoderParameters);
            return new Bitmap(ms);
        }

        private void VaryQualityLevel()
        {
            // Get a bitmap. The using statement ensures objects  
            // are automatically disposed from memory after use.  
            using (Bitmap bmp1 = new Bitmap(this.pathImg))
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID  
                // for the Quality parameter category.  
                System.Drawing.Imaging.Encoder myEncoder =
                    System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.  
                // An EncoderParameters object has an array of EncoderParameter  
                // objects. In this case, there is only one  
                // EncoderParameter object in the array.  
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save("D:\\Image\\varyQuality50.png", jpgEncoder, myEncoderParameters);

                myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save("D:\\Image\\varyQuality100.png", jpgEncoder, myEncoderParameters);

                // Save the bitmap as a JPG file with zero quality level compression.  
                myEncoderParameter = new EncoderParameter(myEncoder, 0L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save("D:\\Image\\varyQuality0.png", jpgEncoder, myEncoderParameters);
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private ImageCodecInfo GetEncoderInfo(string v)
        {
            throw new NotImplementedException();
        }

        private void slider_ValueChanged(object sender, EventArgs e)
        {
            this.lblPorcentajeCompresion.Text = this.slider.Value + "%";
        }

        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelCompress.Visible = false;
            quitCompressImg();
            if(this.cmbFilters.SelectedIndex == 6)
            {
                compressImg();
                this.panelCompress.Visible = true;
            }
        }
    }    
}
