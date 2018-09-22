using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static void opacity(float opacity)
        {
            Parallel.For(0, Environment.ProcessorCount,
                   index =>
                   {
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel;
                       pixel = FilterMonitor.getNext();
                       Color nextPixel;
                       while (pixel != null)
                       {
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2,pixel.Item3);
                           Color newPixel = PixelFilters.opacityFilter(
                               nextPixel,
                               opacity);
                           FilterMonitor.setPixel(
                                   pixel.Item3,
                                   newPixel,
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           pixel = FilterMonitor.getNext();
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }
    }
}
