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
            FilterMonitor.getter getter = new FilterMonitor.getter();
            FilterMonitor.setter setter = new FilterMonitor.setter();
            Parallel.For(0, Environment.ProcessorCount,
                   index =>
                   {
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel;
                       Monitor.Enter(getter);
                       try
                       {
                           pixel = getter.getNext();
                       }
                       finally
                       {
                           Monitor.Exit(getter);
                       }
                       while (pixel != null)
                       {
                           Monitor.Enter(setter);
                           try {
                               setter.setPixel(
                                   pixel.Item3,
                                   PixelFilters.opacityFilter(
                                       FilterMonitor.imageList[pixel.Item3].GetPixel(
                                           pixel.Item1,
                                           pixel.Item2),
                                       opacity),
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           }
                           finally
                           {
                               Monitor.Exit(setter);
                           }
                           Monitor.Enter(getter);
                           try
                           {
                               pixel = getter.getNext();
                           }
                           finally
                           {
                               Monitor.Exit(getter);
                           }
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }
    }
}
