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
        private byte[] sendMsg(Tuple<int, int, int, Color> msg)
        {
            socketCon = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socketCon.Connect(new IPEndPoint(ipAddress, port));
            byte[] bytes = new byte[1024];

            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();

            binFormatter.Serialize(mStream, msg);

            socketCon.Send(mStream.ToArray());
            socketCon.Receive(bytes);

            socketCon.Shutdown(SocketShutdown.Both);
            socketCon.Close();
            return bytes;
        }
        private void connectionWork(object sender, DoWorkEventArgs e)
        {
            Tuple<int, int, int, Color> task = new Tuple<int, int, int, Color>(-2, -2, -2, Color.FromArgb(0, 255, 0));
            while (!worker.CancellationPending)
            {
                if (selectedFilter.Item1 == -1)
                {
                    byte[] objectBytes = sendMsg(new Tuple<int, int, int, Color>(-1, -1, -1, Color.FromArgb(0, 0, 0)));
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
                    byte[] objectBytes = sendMsg(task);
                    var mStream = new MemoryStream();
                    var binFormatter = new BinaryFormatter();

                    // Where 'objectBytes' is your byte array.
                    mStream.Write(objectBytes, 0, objectBytes.Length);
                    mStream.Position = 0;

                    task = binFormatter.Deserialize(mStream) as Tuple<int, int, int, Color>;
                    if (task.Item1 == -2)
                        selectedFilter = new Tuple<int, int>(-1, 0);
                    else
                    {
                        c++;
                        if(c%1000==0)
                            pixels.Text = c + "Pixeles en este esclavo";
                    }
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
