using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class ConcurrentImageFilter
    {
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

        //brigth **
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
                       Console.WriteLine("Proceso " + index + " iniciado.");
                       Tuple<int, int, int> pixel = FilterMonitor.getNext();
                       Color nextPixel;
                       while (pixel != null)
                       {
                           nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                           Tuple<int, int> dim = FilterMonitor.getDimentions(pixel.Item3);
                           int xLimit = pixel.Item1 + radious < dim.Item1 ? pixel.Item1 + radious : dim.Item1 - 1;
                           int yLimit = pixel.Item2 + radious < dim.Item2 ? pixel.Item2 + radious : dim.Item2 - 1;
                           int r = 0; int g = 0; int b = 0;
                           Color aux;
                           int c = 0;
                           for (int w = (Math.Abs(pixel.Item1 - radious) + (pixel.Item1 - radious)) / 2; w < xLimit; w++)
                               for (int h = (Math.Abs(pixel.Item2 - radious) + (pixel.Item2 - radious)) / 2; h < yLimit; h++)
                               {
                                   aux = FilterMonitor.getPixel(w, h,pixel.Item3);
                                   r += aux.R;
                                   g += aux.G;
                                   b += aux.B;
                                   c++;
                               }
                           Color newPixel = Color.FromArgb(r / c, g / c, b / c);
                           FilterMonitor.setPixel(
                                   pixel.Item3,
                                   newPixel,
                                   new Tuple<int, int>(pixel.Item1, pixel.Item2));
                           pixel = FilterMonitor.getNext();
                       }
                       Console.WriteLine("Proceso " + index + " terminado.");
                   });
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
