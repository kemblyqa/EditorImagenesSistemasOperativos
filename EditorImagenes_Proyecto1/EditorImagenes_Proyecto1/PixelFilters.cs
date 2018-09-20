using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                Convert.ToInt32(opacity * pixel.A > 255 ? 255 : opacity * pixel.A < 0 ? 0 : opacity * pixel.A),
                pixel.R, pixel.G, pixel.B);
        }
    }
}
