using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class SequentialImageFilter
    {
        public static void compressionFilter(string[] imagesList, float compressionPorcentage)
        {
            string num = compressionPorcentage.ToString();
            long numero = Convert.ToInt64(num);
            for (int i = 0; i < imagesList.Length; i++)
            {
                // Get a bitmap. The using statement ensures objects  
                // are automatically disposed from memory after use.  
                using (Bitmap bmp = new Bitmap(imagesList[i]))
                {
                    ImageCodecInfo jpgEncoder = PixelFilters.GetEncoder(ImageFormat.Jpeg);//jpeg

                    // Create an Encoder object based on the GUID  
                    // for the Quality parameter category.  
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                    // Create an EncoderParameters object.  
                    // An EncoderParameters object has an array of EncoderParameter  
                    // objects. In this case, there is only one  
                    // EncoderParameter object in the array.  
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, numero);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bmp.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]), jpgEncoder, myEncoderParameters);
                }
            }
        }


        /// <summary>
        /// Function where we will apply the invert color filter to the loaded image
        /// </summary>
        public static void investColorsFunction(string[] imagesList)
        {
            for (int imagen = 0; imagen < imagesList.Length; imagen++)
            {
                //read image
                Bitmap bmap = new Bitmap(imagesList[imagen]);

                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        bmap.SetPixel(i, j, PixelFilters.investColorFilter(bmap.GetPixel(i, j)));
                    }
                }
                bmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[imagen]));
            }
        }

        /// <summary>
        /// grayscale filter
        /// </summary>
        public static void grayScale(string[] imagesList)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        bitmap.SetPixel(x, y, PixelFilters.grayScaleFilter(bitmap.GetPixel(x, y)));
                    }
                }
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

        /// <summary>
        /// brightness filter
        /// </summary>
        /// <param name="brightPercentage"> need the bright percentage </param>
        public static void brigthness(string[] imagesList, float brightPercentage)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        bitmap.SetPixel(x, y, PixelFilters.brightnessFilter(bitmap.GetPixel(x, y), brightPercentage / 100));
                    }
                }
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }
        
        /// <summary>
        /// Function where we will apply the sepia filter to the loaded image
        /// </summary>
        public static void sepia(string[] imagesList)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Console.WriteLine(imagesList[i]);

                Bitmap bmp = new Bitmap(imagesList[i]);
                //get image dimension
                int width = bmp.Width;
                int height = bmp.Height;

                //sepia
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        bmp.SetPixel(x, y, PixelFilters.sepiaFilter(bmp.GetPixel(x, y)));
                    }
                }
                bmp.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }


        public static void opacityFilter(string[] imagesList, float opacity)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap img = new Bitmap(imagesList[i]);
                Bitmap product = new Bitmap(img.Width, img.Height);
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        product.SetPixel(x, y, PixelFilters.opacityFilter(img.GetPixel(x, y), opacity));
                    }
                product.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }


        public static void segmentationFilter(string[] imagesList, int segmentSize)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap img = new Bitmap(imagesList[i]);
                Bitmap product = new Bitmap(img.Width, img.Height);
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        product.SetPixel(x, y, PixelFilters.segmentationFilter(img.GetPixel(x, y), segmentSize));
                    }
                product.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

        public static void gaussianFilter(string[] imagesList, int radious)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap img = new Bitmap(imagesList[i]);
                Bitmap product = new Bitmap(img.Width, img.Height);
                for (int x = 0; x < img.Width; x++)
                    for (int y = 0; y < img.Height; y++)
                    {
                        product.SetPixel(x, y, PixelFilters.Gauss(ref img, x, y, radious));
                    }
                product.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

        /// <summary>
        /// gamma filter
        /// </summary>
        /// <param name="gammaPercentage"> gamma percentage </param>
        public static void gammaFilter(string[] imagesList, float gammaPercentage)
        {
            gammaPercentage = ((gammaPercentage + 64f) / 127f) * 5;
            //Console.WriteLine(((gammaPercentage + 64f) / 127f) * 5);
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        bitmap.SetPixel(x, y, PixelFilters.gammaFilter(bitmap.GetPixel(x, y), gammaPercentage));
                    }
                }
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

        /// <summary>
        /// contrast filter
        /// </summary>
        /// <param name="contrastPercentage"> contrast percentage </param>
        public static void contrastFilter(string[] imagesList, float contrastPercentage)
        {
            contrastPercentage = ((contrastPercentage + 64f) / 127f) * 4;
            //Console.WriteLine(((contrastPercentage + 64f) / 127f) * 4);
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        bitmap.SetPixel(x, y, PixelFilters.contrastFilter(bitmap.GetPixel(x, y), contrastPercentage));
                    }
                }
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }
        public static void chaosFilter(string[] imagesList, int chaosLvl)
        {
            Random r = new Random();
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        bitmap.SetPixel(x, y, PixelFilters.sumFilter(bitmap.GetPixel(x, y), 0, r.Next(-chaosLvl, chaosLvl), r.Next(-chaosLvl, chaosLvl), r.Next(-chaosLvl, chaosLvl)));
                    }
                }
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

        public static void distortionFilter(string[] imagesList, int level)
        {
            Random rndm = new Random();
            int numRandom;
            Byte rojo, azul, verde, alpha;
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);

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
            }
        }
        /// <summary>
        /// set a texture like is a wrinkled image
        /// </summary>
        /// <param name="imagesList"></param>
        public static void wrinkledTexture(string[] imagesList)
        {
            for (int i = 0; i < imagesList.Length; i++)
            {
                Bitmap bitmap = new Bitmap(imagesList[i]);
                Bitmap textureBitmap = new Bitmap(@"texture.jpg");
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        bitmap.SetPixel(x, y, PixelFilters.wrinkledTextureFilter(
                            bitmap.GetPixel(x, y),
                            textureBitmap.GetPixel(x % textureBitmap.Width, y % textureBitmap.Height)
                            ));
                    }
                }
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }
    }
}
