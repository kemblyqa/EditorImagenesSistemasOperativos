using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        Socket socketCon;
        BackgroundWorker worker;
        public Form1()
        {
            connected = false;
            ipAddress = null;
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(connectionWork);
            worker.WorkerSupportsCancellation = true;
            validIP = false;
            validPORT = false;
            InitializeComponent();
            Connection.Enabled = false;
        }

        private void portChanged(object sender, EventArgs e)
        {
            Int32.TryParse(PORT.Text, out port);
            validPORT = port > 1 && port < 65535;
            Connection.Enabled = validIP && validPORT;
        }
        private void connectionWork(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                byte[] bytes = new byte[1024];
                socketCon = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                socketCon.Connect(new IPEndPoint(ipAddress, port));

                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes("Enviado<EOF>");

                // Send the data through the socket.  
                int bytesSent = socketCon.Send(msg);

                // Receive the response from the remote device.  
                int bytesRec = socketCon.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
                // Release the socket.  
                socketCon.Shutdown(SocketShutdown.Both);
                socketCon.Close();
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
