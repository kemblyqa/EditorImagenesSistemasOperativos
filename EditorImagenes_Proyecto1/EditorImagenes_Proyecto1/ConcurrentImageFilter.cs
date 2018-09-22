using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class ConcurrentImageFilter
    {
        //public static Bitmap grayScale(string imagePath)
        //{
            
        //    //write the grayscale image
        //    bitmap.Save("D:\\Image\\Grayscale.png");
        //    return bitmap;
        //}

        //brigth **
        public static Bitmap brigthness(string imagePath)
        {
            //read image
            Bitmap bitmap = new Bitmap(imagePath);
            return bitmap;
        }
        //texture **
        public static Bitmap texture(string imagePath)
        {
            //read image
            Bitmap bitmap = new Bitmap(imagePath);
            return bitmap;
        }

        public static void sepia(string[] imagesList)
        {
            Parallel.ForEach(imagesList, imagen =>
            {
                Console.WriteLine(imagen);
                Bitmap bmp = new Bitmap(imagen);
                //get image dimension
                int width = bmp.Width;
                int height = bmp.Height;

                //color of pixel
                Color p;//

                //sepia
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < width; y++)
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
                //save (write) sepia image
                bmp.Save(@"OutputImages\\" + Path.GetFileName(imagen));
            });
        }

    }
}
