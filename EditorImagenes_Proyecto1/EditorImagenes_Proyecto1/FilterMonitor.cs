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
                if (imageCounter.Sum() == 0)
                {
                    Form1.serving = false;
                }
            }
            finally
            {
                Monitor.Exit(imageOut);
            }
        }
        public static void setPixels(short[] data)
        {
            for (int x = 0; x * 7 < data.Length; x++)
                setPixel(
                    data[(x * 7) + 2],
                    Color.FromArgb(
                        data[(x * 7) + 3],
                        data[(x * 7) + 4],
                        data[(x * 7) + 5],
                        data[(x * 7) + 6]),
                    new Tuple<int, int>(
                        data[x * 7],
                        data[(x * 7) + 1]));
        }
        //Obtiene un pixel
        public static Color getPixel(int x, int y, int img)
        {
            lock(imageList)
                return imageList[img].GetPixel(x, y);
        }
        public static short[] getNexts()
        {
            List<short[]> buffer = new List<short[]>();
            while (buffer.Count < 20)
            {
                Tuple<int, int, int> aux = getNext();
                if (aux == null)
                    break;
                Color pixel = getPixel(aux.Item1, aux.Item2, aux.Item3);
                buffer.Add(new Int16[7] {
                    (short)aux.Item1,
                    (short)aux.Item2,
                    (short)aux.Item3,
                    pixel.A,
                    pixel.R,
                    pixel.G,
                    pixel.B });
            }
            short[] msg = new short[7 * buffer.Count];
            for (int x = 0; x < buffer.Count; x++)
                for (int y = 0; y < 7; y++)
                    msg[x * 7 + y] = buffer[x][y];
            if (msg.Length == 0)
                return new short[1] { -1 };
            return msg;
        }
        //Obtiene el ancho y alto de una imagen objetivo
        public static Tuple<int,int> getDimentions(int imgTarget)
        {
            lock (imageList)
                return new Tuple<int, int>(imageList[imgTarget].Width, imageList[imgTarget].Height);
        }        
    }
}
