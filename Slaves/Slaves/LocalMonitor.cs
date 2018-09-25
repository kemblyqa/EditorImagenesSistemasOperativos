using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Slaves
{
    class LocalMonitor
    {
        static List<Int16[]> buffer;
        static List<Int16[]> sendBuffer;
        public static void init()
        {
            buffer = new List<Int16[]>();
            sendBuffer = new List<short[]>();
        }
        static void request()
        {
            try
            {

                byte[] objectBytes = Form1.sendMsg(new Int16[1] { -2 });
                var mStream = new MemoryStream();
                var binFormatter = new BinaryFormatter();

                // Where 'objectBytes' is your byte array.
                mStream.Write(objectBytes, 0, objectBytes.Length);
                mStream.Position = 0;

                Int16[] response = binFormatter.Deserialize(mStream) as Int16[];
                if (response[0] != -1)
                    for (int x = 0; x * 7 < response.Length; x++)
                    {
                        short[] aux = new short[7];
                        for (int y = 0; y < 7; y++)
                            aux[y] = response[(x * 7) + y];
                        lock (buffer)
                            buffer.Add(aux);
                    }
            }
            catch
            {

            }
        }
        public static Int16[] getNext()
        {
            lock (buffer)
            {
                if (buffer.Count == 0)
                    request();
                if (buffer.Count == 0)
                    return new Int16[1] { -2 };
                else
                {
                    Int16[] aux = buffer[0];
                    buffer.RemoveAt(0);
                    return aux;
                }
            }
        }
        public static void addBuffer(Int16[] pixel)
        {
            bool empty = false;

            Monitor.Enter(buffer);
            try
            {
                empty = buffer.Count == 0;
            }
            finally
            {
                Monitor.Exit(buffer);
            }
            
            Int16[] msg = new short[1] { -1 };
            sendBuffer.Add(pixel);
            lock (sendBuffer)
                if (sendBuffer.Count == 20 || empty)
                {
                    msg = new short[sendBuffer.Count * 7];
                    for (int x = 0; x < sendBuffer.Count; x++)
                    {
                        for (int y = 0; y < 7; y++)
                            msg[(x * 7) + y] = sendBuffer[x][y];
                    }
                    sendBuffer = new List<short[]>();
                }
            Form1.sendMsg(msg);
            request();
        }
    }
}
