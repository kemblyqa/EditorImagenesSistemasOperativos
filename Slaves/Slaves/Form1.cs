using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slaves
{
    public partial class Form1 : Form
    {
        bool connected, validIP, validPORT;
        IPAddress ipAddress;
        int port;
        long c;
        Socket socketCon;
        BackgroundWorker worker;
        Tuple<int, int> selectedFilter;
        public Form1()
        {
            connected = false;
            ipAddress = null;
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(connectionWork);
            worker.WorkerSupportsCancellation = true;
            selectedFilter = new Tuple<int, int>(-1, 0);
            validIP = false;
            validPORT = false;
            c = 0;
            InitializeComponent();
            SliderValue.Text = selectedFilter.Item2.ToString();
            Connection.Enabled = false;
        }

        private void portChanged(object sender, EventArgs e)
        {
            Int32.TryParse(PORT.Text, out port);
            validPORT = port > 1 && port < 65535;
            Connection.Enabled = validIP && validPORT;
        }
        private byte[] sendMsg(Int16[] msg)
        {
            socketCon = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            byte[] bytes;
            try
            {
                socketCon.Connect(new IPEndPoint(ipAddress, port));

                BinaryFormatter binFormatter = new BinaryFormatter();
                MemoryStream mStream = new MemoryStream();

                binFormatter.Serialize(mStream, msg);

                socketCon.Send(mStream.ToArray());
                bytes = new byte[1024];
                socketCon.Receive(bytes);
            }
            catch (Exception e)
            {
                socketCon.Shutdown(SocketShutdown.Both);
                socketCon.Close();
                return null;
            }

            return bytes;
        }
        private void connectionWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                if (selectedFilter.Item1 == -1)
                {
                    byte[] objectBytes = sendMsg(new Int16[7] { -1, -1, -1, 255, 0, 0, 0 });
                    if (objectBytes == null)
                        continue;
                    var mStream = new MemoryStream();
                    var binFormatter = new BinaryFormatter();

                    // Where 'objectBytes' is your byte array.
                    mStream.Write(objectBytes, 0, objectBytes.Length);
                    mStream.Position = 0;
                    selectedFilter = binFormatter.Deserialize(mStream) as Tuple<int, int>;
                    SliderValue.Text = selectedFilter.Item2.ToString();
                }
                else
                {
                    Object connection = new object();
                    Object counter = new object();
                    Parallel.For(0, Environment.ProcessorCount, index => {
                        Int16[] task = new Int16[7] { -2, -2, -2, 255, 255, 255, 255 };
                        while (true)
                        {
                            byte[] objectBytes;
                            Color newPixel = Color.FromArgb(255, 255, 255);
                            if (task[0] != -2)
                            {
                                Random r = new Random();
                                Color oldPixel = Color.FromArgb(task[3], task[4], task[5], task[6]);
                                switch (selectedFilter.Item1)
                                {
                                    case 0:
                                        newPixel = PixelFilters.grayScaleFilter(oldPixel);
                                        break;
                                    case 1: // sepia
                                        newPixel = PixelFilters.sepiaFilter(oldPixel);
                                        break;
                                    case 2:
                                        newPixel = PixelFilters.opacityFilter(oldPixel, 1f - (selectedFilter.Item2 + 64) / 128f);
                                        break;
                                    case 3: // invest colors
                                        newPixel = PixelFilters.investColorFilter(oldPixel);
                                        break;
                                    case 5:
                                        newPixel = PixelFilters.brightnessFilter(oldPixel, selectedFilter.Item2);
                                        break;
                                    case 7:
                                        int segments = (int)(((selectedFilter.Item2 + 64) * 7) / 128f);
                                        newPixel = PixelFilters.segmentationFilter(oldPixel, (int)Math.Pow(2, segments));
                                        break;
                                    case 8:
                                        newPixel = PixelFilters.gammaFilter(oldPixel, selectedFilter.Item2);
                                        break;
                                    case 9:
                                        newPixel = PixelFilters.contrastFilter(oldPixel, selectedFilter.Item2);
                                        break;
                                    case 10:
                                        int chaosLvl = (selectedFilter.Item2 + 64) * 2;
                                        newPixel = PixelFilters.sumFilter(oldPixel, 0, r.Next(-chaosLvl, chaosLvl), r.Next(-chaosLvl, chaosLvl), r.Next(-chaosLvl, chaosLvl));
                                        break;
                                    case 13:
                                        newPixel = PixelFilters.redFilter(oldPixel);
                                        break;
                                }
                            }
                            task[3] = newPixel.A;
                            task[4] = newPixel.R;
                            task[5] = newPixel.G;
                            task[6] = newPixel.B;
                            lock (connection)
                                objectBytes = sendMsg(task);
                            if (objectBytes == null)
                                continue;
                            var mStream = new MemoryStream();
                            var binFormatter = new BinaryFormatter();

                            // Where 'objectBytes' is your byte array.
                            mStream.Write(objectBytes, 0, objectBytes.Length);
                            mStream.Position = 0;

                            task = binFormatter.Deserialize(mStream) as Int16[];
                            if (task[0] == -2)
                            {
                                lock (selectedFilter)
                                    selectedFilter = new Tuple<int, int>(-1, 0);
                                break;
                            }
                            else
                                lock (counter)
                                {
                                    c++;
                                    if (c % 1000 == 0)
                                        pixels.Text = c + " Pixeles en este esclavo";
                                }
                        }
                        Console.WriteLine("Proceso " + index + " terminado");
                    });
                }
            }
        }
        private void connection(object sender, EventArgs e)
        {
            if (!connected)
                try
                {
                    LINE.Text = "Online";
                    Connection.Text = "Disconenct";
                    connected = true;
                    worker.RunWorkerAsync();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Unexpected exception : {0}", exc.ToString());
                }
            else
            {
                worker.CancelAsync();
                LINE.Text = "Offline";
                Connection.Text = "Connect";
                connected = false;
            }
        }
        
        private void checkValid(object sender, EventArgs e)
        {
            validIP = IPAddress.TryParse($"{IP1.Text}.{IP2.Text}.{IP3.Text}.{IP4.Text}", out ipAddress);
            Connection.Enabled = validIP && validPORT;
        }
    }
}
