using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
                    pixel = FilterMonitor.getNext(); // devuelve x, y, index de la imagen en la lista de imagenes
                    Color nextPixel;
                    while (pixel != null)
                    {
                        nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);  //obteniendo el pixel
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

        public static void distortionFilter(int level)
        {
            Byte rojo, azul, verde, alpha;            
            Random rndm = new Random();
            int numRandom;
            Parallel.For(0, Environment.ProcessorCount,
                index =>
                {
                    Tuple<int, int, int> pixel;
                    pixel = FilterMonitor.getNext(); // devuelve x, y, index de la imagen en la lista de imagenes
                    Tuple<int, int> dimeniones = FilterMonitor.getDimentions(pixel.Item3);
                    Color nextPixel;
                    while (pixel != null)
                    {
                        numRandom = rndm.Next(level + 1);
                        if(pixel.Item1 < dimeniones.Item1 - level & pixel.Item2 < dimeniones.Item2 - level)
                        {
                            nextPixel = FilterMonitor.getPixel(pixel.Item1 + numRandom, pixel.Item2 + numRandom, pixel.Item3);
                        }
                        else
                        {
                            nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                        }
                        FilterMonitor.setPixel(
                                pixel.Item3,
                                nextPixel,
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

        public static void compressionFilter(float compressionPorcentage, string[] imagesList)
        {
            string num = compressionPorcentage.ToString();
            long numero = Convert.ToInt64(num);
            Parallel.ForEach(imagesList, imagen =>
            {
                using (Bitmap bmp = new Bitmap(imagen))
                {
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, numero);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    bmp.Save(@"OutputImages\\" + Path.GetFileName(imagen),
                        PixelFilters.GetEncoder(PixelFilters.ParseImageFormat(imagen.Split('.')[imagen.Split('.').Length - 1])),
                        myEncoderParameters
                    );
                }
            });
        }

        /*public static void distortionFilter(int level, string[] imagesList)
        {
            Color color;
            Byte rojo, azul, verde, alpha;
            Random rndm = new Random();
            int numRandom;

            Parallel.ForEach(imagesList, imagen =>
            {
                using (Bitmap bmp = new Bitmap(imagen))
                {

                }
            });

            for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        numRandom = rndm.Next(level + 1);
                        if (y < bitmap.Height - level & x < bitmap.Width - level)
                        {
                            rojo = bitmap.GetPixel(x + numRandom, y + numRandom).R;
                            verde = bitmap.GetPixel(x + numRandom, y + numRandom).G;
                            azul = bitmap.GetPixel(x + numRandom, y + numRandom).B;
                            alpha = bitmap.GetPixel(x + numRandom, y + numRandom).A;
                        }
                        else
                        {
                            rojo = bitmap.GetPixel(x, y).R;
                            verde = bitmap.GetPixel(x, y).G;
                            azul = bitmap.GetPixel(x, y).B;
                            alpha = bitmap.GetPixel(x, y).A;
                        }
                        bitmap.SetPixel(x, y, Color.FromArgb(alpha, rojo, verde, azul));
                    }
                }
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            
        }*/
        public static void wrinkledTexture()
        {
            Bitmap textureBitmap = new Bitmap(@"texture.jpg");
            Parallel.For(0, Environment.ProcessorCount,
                index =>
                {
                    Tuple<int, int, int> pixel;
                    pixel = FilterMonitor.getNext();
                    Color nextPixel;
                    while (pixel != null)
                    {
                        nextPixel = FilterMonitor.getPixel(pixel.Item1, pixel.Item2, pixel.Item3);
                        Color newPixel;
                        lock (textureBitmap)
                            newPixel = PixelFilters.wrinkledTextureFilter(nextPixel, textureBitmap.GetPixel(pixel.Item1 % textureBitmap.Width, pixel.Item2 % textureBitmap.Height));
                        FilterMonitor.setPixel(
                                pixel.Item3,
                                newPixel,
                                new Tuple<int, int>(pixel.Item1, pixel.Item2));
                        pixel = FilterMonitor.getNext();
                    }
                }
            );
        }
    }
}
