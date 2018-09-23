using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class PixelFilters
    {
        //Applies a sum over the pixel
        public static Color sumFilter(Color pixel, int A, int R, int G, int B)
        {
            return Color.FromArgb(
                A + pixel.A > 255 ? 255 : A + pixel.A < 0 ? 0 : A + pixel.A,
                R + pixel.R > 255 ? 255 : R + pixel.R < 0 ? 0 : R + pixel.R,
                G + pixel.G > 255 ? 255 : G + pixel.G < 0 ? 0 : G + pixel.G,
                B + pixel.B > 255 ? 255 : B + pixel.B < 0 ? 0 : B + pixel.B
                );
        }

        //Multiplies all values of the pixel by a float, values between 0 and 1 are recommended for percentage reasons
        public static Color mulFilter(Color pixel, float A, float R, float G, float B)
        {
            return Color.FromArgb(
                Convert.ToInt32(A * pixel.A > 255 ? 255 : A * pixel.A < 0 ? 0 : A * pixel.A),
                Convert.ToInt32(R * pixel.R > 255 ? 255 : R * pixel.R < 0 ? 0 : R * pixel.R),
                Convert.ToInt32(G * pixel.G > 255 ? 255 : G * pixel.G < 0 ? 0 : G * pixel.G),
                Convert.ToInt32(B * pixel.B > 255 ? 255 : B * pixel.B < 0 ? 0 : B * pixel.B)
                );
        }

        //Replace the channels of a filter for the ones in the function, values outside (0,255) omits the channel replacement
        public static Color replaceFilter(Color pixel, int A, int R, int G, int B)
        {
            return Color.FromArgb(
                A > 255 || A < 0 ? pixel.A : A,
                R > 255 || R < 0 ? pixel.R : R,
                G > 255 || G < 0 ? pixel.G : G,
                B > 255 || B < 0 ? pixel.B : B
                );
        }
        //Applies an opacity Filter over a pixel
        public static Color opacityFilter(Color pixel, float opacity)
        {
            return Color.FromArgb(
                Convert.ToInt32(opacity * pixel.A > 255 ? 255 : opacity * pixel.A < 1 ? 1 : opacity * pixel.A),
                pixel.R, pixel.G, pixel.B);
        }

        //Applies an opacity Filter over a pixel
        public static Color segmentationFilter(Color pixel, int segmentation)
        {
            int factor = segmentation == 1 ? 1 : segmentation-1;

            return Color.FromArgb(
                pixel.A,
                pixel.R % factor <= factor / 2 ? pixel.R - pixel.R % factor : Math.Min(pixel.R + factor - (pixel.R % factor), 255),
                pixel.G % factor <= factor / 2 ? pixel.G - pixel.G % factor : Math.Min(pixel.G + factor - (pixel.G % factor), 255),
                pixel.B % factor <= factor / 2 ? pixel.B - pixel.B % factor : Math.Min(pixel.B + factor - (pixel.B % factor), 255)
                );
        }
        //Gauss
        public static Color Gauss(ref Bitmap img, int x, int y, int radious)
        {
            int xLimit = x + radious < img.Width ? x + radious : img.Width - 1;
            int yLimit = y + radious < img.Height ? y + radious : img.Height - 1;
            int r = 0;int g = 0;int b = 0;
            Color aux;
            int c = 0;
            for (int w = (Math.Abs(x - radious) + (x - radious)) / 2; w < xLimit; w++)
                for(int h = (Math.Abs(y-radious) + (y-radious))/2; h < yLimit; h++)
                {
                    aux = img.GetPixel(w, h);
                    r += aux.R;
                    g += aux.G;
                    b += aux.B;
                    c++;
                }
            return Color.FromArgb(r/c, g/c, b/c);
        }

        /// <summary>
        /// average color from pixel
        /// </summary>
        /// <param name="pixel">pixel color</param>
        /// <returns>pixel modified</returns>
        public static int averageColorFilter(Color pixel)
        {
            return (pixel.R + pixel.G + pixel.B) / 3;
        }

        /// <summary>
        /// set graysacale color to pixel
        /// </summary>
        /// <param name="pixel">pixel to modify</param>
        /// <returns>pixel modified</returns>
        public static Color grayScaleFilter(Color pixel)
        {
            //set new pixel value
            int avg = averageColorFilter(pixel);
            return Color.FromArgb(pixel.A, avg, avg, avg);
        }

        /// <summary>
        /// set brightness to pixel
        /// </summary>
        /// <param name="pixel">pixel to modify</param>
        /// <param name="brightPercentage">brightness percentage</param>
        /// <returns>pixel modified</returns>
        public static Color brightnessFilter(Color pixel, float brightPercentage)
        {
            return brightPercentage < 0 ?
                Color.FromArgb(
                pixel.A,
                (int)((1 + brightPercentage) * pixel.R),
                (int)((1 + brightPercentage) * pixel.G),
                (int)((1 + brightPercentage) * pixel.B))
                :
                Color.FromArgb(
                pixel.A, 
                (int)((255 - pixel.R) * brightPercentage + pixel.R),
                (int)((255 - pixel.G) * brightPercentage + pixel.G),
                (int)((255 - pixel.B) * brightPercentage + pixel.B)
           );
        }

        /// <summary>
        /// set gamma color to pixel
        /// </summary>
        /// <param name="pixel">pixel to modify</param>
        /// <param name="gammaPercentage">gamma percentage</param>
        /// <returns>pixel modified</returns>
        public static Color gammaFilter(Color pixel, float gammaPercentage)
        {    
            byte[] redGamma = createGammaArray(gammaPercentage);
            byte[] greenGamma = createGammaArray(gammaPercentage);
            byte[] blueGamma = createGammaArray(gammaPercentage);

            return Color.FromArgb(
                pixel.A,
                redGamma[pixel.R],
                greenGamma[pixel.G],
                blueGamma[pixel.B]
                );
        }

        /// <summary>
        /// set array of bytes where applies the gamma balance
        /// </summary>
        /// <param name="color">pixel color to modify</param>
        /// <returns>pixel modified</returns>
        public static byte[] createGammaArray(float color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte) Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }

        /// <summary>
        /// set contrast adjustment to a pixel
        /// </summary>
        /// <param name="pixelItem">pixel color to modify</param>
        /// <param name="contrastPercentage">contrast percentage</param>
        /// <returns>pixel modified</returns>
        public static int adjustConstrast(float pixelItem, float contrastPercentage)
        {
            float pI = pixelItem / 255f;
            pI -= 0.5f;
            pI *= contrastPercentage;
            pI += 0.5f;
            pI *= 255;
            if (pI < 0) pI = 0;
            if (pI > 255) pI = 255;
            return (int) pI;
        }

        /// <summary>
        /// set contrast balance to a pixel
        /// </summary>
        /// <param name="pixel">pixel to modify</param>
        /// <param name="contrastPercentage">contrast percentage</param>
        /// <returns>pixel modified</returns>
        public static Color contrastFilter(Color pixel, float contrastPercentage)
        {
            return Color.FromArgb(
                pixel.A,
                adjustConstrast(pixel.R, contrastPercentage),
                adjustConstrast(pixel.G, contrastPercentage),
                adjustConstrast(pixel.B, contrastPercentage)
            );
        }

        public static Color investColorFilter(Color pixel)
        {
            return Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
        }

        public static Color sepiaFilter(Color p)
        {
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
            return Color.FromArgb(a, r, g, b);
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
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

        public static ImageFormat ParseImageFormat(string formato)
        {
            ImageFormat formatoFinal = ImageFormat.Jpeg;
            switch (formato.ToString().ToLower())
            {                
                case "png":
                    formatoFinal = ImageFormat.Png;
                    break;
                case "jpeg":
                    formatoFinal = ImageFormat.Jpeg;
                    break;

                case "bmp":
                    formatoFinal = ImageFormat.Bmp;
                    break;

                case "icon":
                    formatoFinal = ImageFormat.Icon;
                    break;
                case "emf":
                    formatoFinal = ImageFormat.Emf;
                    break;
            }
            return formatoFinal;
        }
        
    }
}
