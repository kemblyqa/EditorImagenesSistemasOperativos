using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class ConcurrentImageFilter
    {
        /// <summary>
        /// grayscale filter
        /// </summary>
        public static void grayScale()
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
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                           Color newPixel = PixelFilters.grayScaleFilter(nextPixel);
                           FilterMonitor.setPixel(
                                   pixel.Item3,
                                   newPixel,
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           pixel = FilterMonitor.getNext();
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }

        /// <summary>
        /// brightness filter
        /// </summary>
        /// <param name="brightPercentage"> need the bright percentage </param>
        public static void brigthness(float brightPercentage)
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
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                           Color newPixel = PixelFilters.brightnessFilter(
                               nextPixel, 
                               brightPercentage);
                           FilterMonitor.setPixel(
                                   pixel.Item3,
                                   newPixel,
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           pixel = FilterMonitor.getNext();
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }

        public static void opacity(float opacity)
        {
            Parallel.For(0, Environment.ProcessorCount,
                   index =>
                   {
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel = FilterMonitor.getNext();
                       Color nextPixel;
                       while (pixel != null)
                       {
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
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

        /// <summary>
        /// gamma filter
        /// </summary>
        /// <param name="gammaPercentage"> gamma percentage </param>
        public static void gammaFilter(float gammaPercentage)
        {
            gammaPercentage = ((gammaPercentage + 64f) / 127f) * 5;
            Parallel.For(0, Environment.ProcessorCount,
                   index =>
                   {
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel;
                       pixel = FilterMonitor.getNext();
                       Color nextPixel;
                       while (pixel != null)
                       {
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                           Color newPixel = PixelFilters.gammaFilter(
                               nextPixel,
                               gammaPercentage);
                           FilterMonitor.setPixel(
                                   pixel.Item3,
                                   newPixel,
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           pixel = FilterMonitor.getNext();
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }

        /// <summary>
        /// contrast filter
        /// </summary>
        /// <param name="contrastPercentage"> contrast percentage </param>
        public static void contrastFilter(float contrastPercentage)
        {
            contrastPercentage = ((contrastPercentage + 64f) / 127f) * 4;
            Parallel.For(0, Environment.ProcessorCount,
                   index =>
                   {
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel;
                       pixel = FilterMonitor.getNext();
                       Color nextPixel;
                       while (pixel != null)
                       {
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                           Color newPixel = PixelFilters.contrastFilter(
                               nextPixel,
                               contrastPercentage);
                           FilterMonitor.setPixel(
                                   pixel.Item3,
                                   newPixel,
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           pixel = FilterMonitor.getNext();
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }

        public static void segmentation(int segments)
        {
            Parallel.For(0, Environment.ProcessorCount,
                   index =>
                   {
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel = FilterMonitor.getNext();
                       Color nextPixel;
                       while (pixel != null)
                       {
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                           Color newPixel = PixelFilters.segmentationFilter(
                               nextPixel,
                               segments);
                           FilterMonitor.setPixel(
                                   pixel.Item3,
                                   newPixel,
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           pixel = FilterMonitor.getNext();
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }

        public static void gauss(int radious)
        {
            Parallel.For(0, Environment.ProcessorCount,
                   index =>
                   {
                       int currentImage = -1;
                       Bitmap img = null;
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel = FilterMonitor.getNext();
                       Color nextPixel;
                       while (pixel != null)
                       {
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                           if (currentImage != pixel.Item3 || img == null)
                           {
                               currentImage = pixel.Item3;
                               img = FilterMonitor.imageList[pixel.Item3];
                           }
                           else
                           {
                               Color newPixel = PixelFilters.Gauss(ref img, pixel.Item1, pixel.Item2, radious);
                               FilterMonitor.setPixel(
                                       pixel.Item3,
                                       newPixel,
                                       new Tuple<int, int>(pixel.Item1, pixel.Item2));
                               pixel = FilterMonitor.getNext();
                           }
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
        }

        public static void sepiaFilter()
        {
            Parallel.For(0, Environment.ProcessorCount,
                index =>
                {
                    Tuple<int, int, int> pixel;
                    pixel = FilterMonitor.getNext();
                    Color nextPixel;
                    while (pixel != null)
                    {
                        nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                        Color newPixel = PixelFilters.sepiaFilter(nextPixel);
                        FilterMonitor.setPixel(
                                pixel.Item3,
                                newPixel,
                                new Tuple<int, int>(pixel.Item1, pixel.Item2));
                        pixel = FilterMonitor.getNext();
                    }
                }
            );
        }
        
        public static void investColorFilter()
        {
            Parallel.For(0, Environment.ProcessorCount,
                index =>
                {
                    Tuple<int, int, int> pixel;
                    pixel = FilterMonitor.getNext();
                    Color nextPixel;
                    while (pixel != null)
                    {
                        nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                        Color newPixel = PixelFilters.investColorFilter(nextPixel);
                        FilterMonitor.setPixel(
                                pixel.Item3,
                                newPixel,
                                new Tuple<int, int>(pixel.Item1, pixel.Item2));
                        pixel = FilterMonitor.getNext();
                    }
                }
            );
        }
        
        public static void compressionFilter(float compressionPorcentage, string [] imagesList)
        {
            string num = compressionPorcentage.ToString();
            long numero = Convert.ToInt64(num);
            Parallel.ForEach(imagesList, imagen =>
            {
                using (Bitmap bmp1 = new Bitmap(imagen))
                {
                    PixelFilters.GetEncoder(PixelFilters.ParseImageFormat(imagen.Split('.')[imagen.Split('.').Length - 1]));

                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, numero);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    bmp1.Save(@"OutputImages\\" + Path.GetFileName(imagen),
                        PixelFilters.GetEncoder(PixelFilters.ParseImageFormat(imagen.Split('.')[imagen.Split('.').Length - 1])), 
                        myEncoderParameters
                    );
                }
            });
        }
    }
}
