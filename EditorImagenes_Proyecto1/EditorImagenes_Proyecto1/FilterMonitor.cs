using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorImagenes_Proyecto1
{
    class FilterMonitor
    {
        static int nextx;
        static int nexty;
        static int nextImg;
        public static List<Bitmap> imageList { get; private set; }
        static List<Bitmap> imageOut;
        static List<String> imageStr;
        public static List<int> imageCounter { get; private set; }

        public static void refresh()
        {
            nextx = 0;
            nexty = 0;
            nextImg = 0;
            imageList = new List<Bitmap>();
            imageOut = new List<Bitmap>();
            imageStr = new List<String>();
            imageCounter = new List<int>();
        }
        //Adds new images to the buffer
        public static void addBuffer(String[] imgList)
        {
            foreach(String img in imgList)
            {
                Bitmap aux = new Bitmap(img);
                imageList.Add(aux);
                imageOut.Add(new Bitmap(aux.Width, aux.Height));
                imageStr.Add(img);
                imageCounter.Add(aux.Width * aux.Height);
            }
        }
        public class getter
        {
            //X,Y and image number
            public Tuple<int, int, int> getNext()
            {
                if (nextImg >= imageList.Count)
                    return null;
                Tuple<int, int, int> value = new Tuple<int, int, int>(nextx, nexty, nextImg);
                nextx++;
                if (nextx == imageList[nextImg].Width)
                {
                    nextx = 0;
                    nexty++;
                }
                if (nexty == imageList[nextImg].Height)
                {
                    nexty = 0;
                    nextImg++;
                }
                return value;
            }
        }
        public class setter
        {
            public void setPixel(int imgTarget, Color pixel, Tuple<int, int> coord)
            {
                imageOut[imgTarget].SetPixel(coord.Item1, coord.Item2, pixel);
                imageCounter[imgTarget]--;
                if (imageCounter[imgTarget] == 0)
                {
                    imageOut[imgTarget].Save(@"OutputImages\\" + Path.GetFileName(imageStr[imgTarget]));
                    Console.WriteLine("Guardando " + imgTarget);
                }
            }
        }
    }
}
