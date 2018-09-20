using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class SequentialImageFilter
    {
        //grayscale **
        public static void grayScale(string[] imagesList)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);
                //get image dimension
                int width = bitmap.Width;
                int height = bitmap.Height;

                //color of pixel
                Color p;

                //grayscale
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        //get pixel value
                        p = bitmap.GetPixel(x, y);

                        //extract pixel component ARGB
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;

                        //find average
                        int avg = (r + g + b) / 3;

                        //set new pixel value
                        bitmap.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                    }
                }
                //save (write) sepia image
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

        //brigth **
        public static void brigthness(string[] imagesList)
        {
        }
        //texture **
        public static void texture(string[] imagesList)
        {
        }

        /// <summary>
        /// Function where we will apply the sepia filter to the loaded image
        /// </summary>
        public static void sepiaFunction(string[] imagesList)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Console.WriteLine(imagesList[i]);
                Bitmap bmp = new Bitmap(imagesList[i]);
                //get image dimension
                int width = bmp.Width;
                int height = bmp.Height;

                //color of pixel
                Color p;//

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
                    //save (write) sepia image
                    bmp.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
                }
            }
        }
    }
}
