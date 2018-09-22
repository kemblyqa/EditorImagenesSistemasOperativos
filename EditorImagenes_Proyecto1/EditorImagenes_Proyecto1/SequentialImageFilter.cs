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
        /*
        private Bitmap compresssImageFunction(Bitmap imagen, long calidad)
        {
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, calidad);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, myImageCodecInfo, myEncoderParameters);
            return new Bitmap(ms);
        }

        private ImageCodecInfo GetEncoderInfo(string v)
        {
            throw new NotImplementedException();
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void VaryQualityLevel(string[]  imagesList, float compressionPorcentage)
        {
            for(int i = 0; i < imagesList.Length; i++)
            {
                // Get a bitmap. The using statement ensures objects  
                // are automatically disposed from memory after use.  
                using (Bitmap bmp1 = new Bitmap(imagesList[i]))
                {
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                    // Create an Encoder object based on the GUID  
                    // for the Quality parameter category.  
                    System.Drawing.Imaging.Encoder myEncoder =
                        System.Drawing.Imaging.Encoder.Quality;

                    // Create an EncoderParameters object.  
                    // An EncoderParameters object has an array of EncoderParameter  
                    // objects. In this case, there is only one  
                    // EncoderParameter object in the array.  
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, Convert.ToInt64(compressionPorcentage.ToString() + "L"));
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bmp1.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]), jpgEncoder, myEncoderParameters);
                }
            }
            
        }
        */
        
        /// <summary>
        /// Function where we will apply the invert color filter to the loaded image
        /// </summary>
        public static void investColorsFunction(string[] imagesList)
        {
            Color col;
            for (int imagen = 0; imagen < imagesList.Length; imagen++)
            {
                //read image
                Bitmap bmap = new Bitmap(imagesList[imagen]);
                
                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        col = bmap.GetPixel(i, j);
                        bmap.SetPixel(i, j, Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B));
                    }
                }
                bmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[imagen]));
            }
        }

        //grayscale
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
                //save (write) sepia image
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

        //brigth **
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
                //save (write) sepia image
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }
        
        //texture **
        public static void texture(string[] imagesList)
        {
            
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

                //color of pixel
                Color p;//

                //sepia
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
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
                //save (write) sepia image, i mean, opacity image
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
                //save (write) segmented image
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
                //save (write) gaussian image
                product.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }
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
                //save (write) sepia image
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }

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
                //save (write) sepia image
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
                        bitmap.SetPixel(x, y, PixelFilters.sumFilter(bitmap.GetPixel(x, y), 0, r.Next(0, chaosLvl), r.Next(0, chaosLvl), r.Next(0, chaosLvl)));
                    }
                }
                //save (write) sepia image
                bitmap.Save(@"OutputImages\\" + Path.GetFileName(imagesList[i]));
            }
        }
    }
}
