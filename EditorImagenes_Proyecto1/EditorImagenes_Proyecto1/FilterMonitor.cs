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
        //Añade una cola de imagenes al buffer de pixeles
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
        //Retorna el siguiente pixel a en cola de tratamiento, los valores son X, Y y el numero de imagen de la cola
        public static Tuple<int, int, int> getNext()
        {
            Monitor.Enter(imageList);
            try
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
            finally
            {
                Monitor.Exit(imageList);
            }
        }
        //Asigna un nuevo pixel en la lista de imagenes procesadas, recibe el numero de imagen, el pixel modificado y las coordenadas en forma de Tupla doble
        public static void setPixel(int imgTarget, Color pixel, Tuple<int, int> coord)
        {
            Monitor.Enter(imageOut);

            try{
                imageOut[imgTarget].SetPixel(coord.Item1, coord.Item2, pixel);
                imageCounter[imgTarget]--;
                if (imageCounter[imgTarget] == 0)
                {
                    imageOut[imgTarget].Save(@"OutputImages\\" + Path.GetFileName(imageStr[imgTarget]));
                    Console.WriteLine("Guardado " + imgTarget);
                }
            }
            finally
            {
                Monitor.Exit(imageOut);
            }
        }
        //Obtiene un pixel
        public static Color getPixel(int x, int y, int img)
        {
            return imageList[img].GetPixel(x, y);
        }
        //Obtiene el ancho y alto de una imagen objetivo
        public static Tuple<int,int> getDimentions(int imgTarget)
        {
            lock (imageList)
                return new Tuple<int, int>(imageList[imgTarget].Width, imageList[imgTarget].Height);
        }
    }
}
