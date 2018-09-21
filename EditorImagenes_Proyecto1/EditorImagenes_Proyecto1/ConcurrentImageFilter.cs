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
        static Object set = new object();
        static Object get = new object();
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
                       Monitor.Enter(get);
                       try
                       {
                           pixel = FilterMonitor.getNext();
                       }
                       finally
                       {
                           Monitor.Exit(get);
                       }
                       Color nextPixel;
                       while (pixel != null)
                       {
                           Monitor.Enter(get);
                           try
                           {
                               nextPixel = FilterMonitor.imageList[pixel.Item3].GetPixel(pixel.Item1, pixel.Item2);
                           }
                           finally
                           {
                               Monitor.Exit(get);
                           }
                           Color newPixel = PixelFilters.opacityFilter(
                               nextPixel,
                               opacity);
                           Monitor.Enter(set);
                           try
                           {
                               FilterMonitor.setPixel(
                                       pixel.Item3,
                                       newPixel,
                                       new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           }
                           finally
                           {
                               Monitor.Exit(set);
                           }

                           Monitor.Enter(get);
                           try
                           {
                               pixel = FilterMonitor.getNext();
                           }
                           finally
                           {
                               Monitor.Exit(get);
                           }
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }
    }
}
