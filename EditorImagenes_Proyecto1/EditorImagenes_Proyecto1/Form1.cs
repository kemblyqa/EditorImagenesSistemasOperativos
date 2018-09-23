using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorImagenes_Proyecto1
{
    public partial class Form1 : Form
    {
        static BackgroundWorker worker;
        static string data;
        static Socket handler;
        public Form1()
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(StartListening);
            worker.WorkerSupportsCancellation = true;
            data = null;
            InitializeComponent();
            cmbFilters.SelectedIndex = 0;
            panelCompress.Visible = false;
            
        }
        
        private void btnGenerateImg_Click(object sender, EventArgs e)
        {
            // images files
            btnGenerateImg.Enabled = false;
            string[] imagesList = Directory.GetFiles(@"InputImages\\");            
            FilterMonitor.refresh();
            float percent = 0;
            switch (cmbFilters.SelectedIndex)
            {
                case 0:
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.grayScale();
                    }
                    else
                        SequentialImageFilter.grayScale(imagesList);
                    break;
                case 1: // sepia
                    if (rdbSequential.Checked)
                        SequentialImageFilter.sepia(imagesList);
                    else
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.sepiaFilter();
                    }
                    break;
                case 2:
                    percent = 1f - (slider.Value + 64) / 128f;
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.opacity(percent);
                    }
                    else
                        SequentialImageFilter.opacityFilter(imagesList, percent);
                    break;
                case 3: // invest colors
                    if (rdbSequential.Checked)
                        SequentialImageFilter.investColorsFunction(imagesList);
                    else
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.investColorFilter();
                    }
                    break;
                case 4:
                    percent = (slider.Value + 64) / 128f;
                    if (rdbSequential.Checked)
                        SequentialImageFilter.gaussianFilter(imagesList, (int)percent * 5 + 1);
                    else
                        SequentialImageFilter.gaussianFilter(imagesList, (int)percent * 5 + 1);
                    break;
                case 5:
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.brigthness(slider.Value);
                    }
                    else
                        SequentialImageFilter.brigthness(imagesList, slider.Value);
                    break;
                case 6:
                    int compressionLevel = (int)(((slider.Value + 64) * 95) / 128f);
                    if (rdbSequential.Checked)
                        SequentialImageFilter.compressionFilter(imagesList, compressionLevel);
                    else
                    {
                        ConcurrentImageFilter.compressionFilter(compressionLevel, imagesList);
                    }
                    break;
                case 7:
                    int segments = (int)(((slider.Value+64)*7)/128f);
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.segmentation((int)Math.Pow(2, segments));
                    }
                    else
                        SequentialImageFilter.segmentationFilter(imagesList, (int)Math.Pow(2, segments));
                    break;
                case 8:
                    SequentialImageFilter.texture(imagesList);
                    break;
                case 9:
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.gammaFilter(slider.Value);
                    }
                    else
                        SequentialImageFilter.gammaFilter(imagesList, slider.Value);
                    break;
                case 10:
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.contrastFilter(slider.Value);
                    }
                    else
                        SequentialImageFilter.contrastFilter(imagesList, slider.Value);
                    break;
                case 11:
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        //ConcurrentImageFilter.chaosFilter(slider.Value);
                    }
                    else
                        SequentialImageFilter.chaosFilter(imagesList, (slider.Value + 64) * 2);
                    break;
                case 12:
                    int level = (int)(((slider.Value + 64) * 19) / 128f);
                    if (rdbSequential.Checked)
                        SequentialImageFilter.distortionFilter(imagesList, level);
                    break;
                default:
                    Console.WriteLine("Error detectado");
                    break;
            }
            btnGenerateImg.Enabled = true;
        }        

        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFilters.SelectedIndex == 0 || cmbFilters.SelectedIndex == 1 || cmbFilters.SelectedIndex == 3)
            {
                panelCompress.Visible = false;
            }
            else
            {
                panelCompress.Visible = true;
            }

            if(cmbFilters.SelectedIndex == 6 | cmbFilters.SelectedIndex == 12)
            {
                lblMin.Text = "Maximo";
                lblMax.Text = "Minimo";
            }
            else
            {
                lblMax.Text = "Maximo";
                lblMin.Text = "Minimo";
            }
        }
        public static void StartListening(object sender, DoWorkEventArgs e)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = null;
            foreach (var ip in ipHostInfo.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip;
                    break;
                }
            }
            Console.WriteLine(ipAddress.ToString());
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (!worker.CancellationPending)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    // Show the data on the console.  
                    Console.WriteLine("Text received : {0}", data);

                    // Echo the data back to the client.  
                    byte[] msg = Encoding.ASCII.GetBytes("Recibido<EOF>");

                    handler.Send(msg);
                }
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        private void ServeButton_Click(object sender, EventArgs e)
        {
            if(ServeButton.Text == "Serve")
            {
                worker.RunWorkerAsync();
                ServeButton.Text = "Shutdown";
            }
            else
            {
                worker.CancelAsync();
                ServeButton.Text = "Serve";
            }
        }
    }    
}