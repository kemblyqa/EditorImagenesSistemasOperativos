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
    }
}
