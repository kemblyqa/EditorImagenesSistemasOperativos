using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class ConcurrentImageFilter
    {
        public static Bitmap grayScale(string imagePath)
        {
            //read image
            Bitmap bitmap = new Bitmap(imagePath);
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

            //write the grayscale image
            bitmap.Save("D:\\Image\\Grayscale.png");
            return bitmap;
        }

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
    }
}
