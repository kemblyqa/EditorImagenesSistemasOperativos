using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorImagenes_Proyecto1
{
    public partial class Form1 : Form
    {
        static BackgroundWorker worker;
        static int selectedFilter, selectedValue;
        static Socket handler;
        public static bool serving;
        Stopwatch sw;
        int fixedTimeSeconds;
        List<int> netBannedFilters = new List<int>() { 4, 6, 11, 12 };
        public Form1()
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(StartListening);
            worker.WorkerSupportsCancellation = true;
            selectedFilter = 0;
            selectedValue = -64;
            serving = false;
            InitializeComponent();
            cmbFilters.SelectedIndex = 0;
            panelCompress.Visible = false;
            
        }

        private void btnGenerateImg_Click(object sender, EventArgs e)
        {
            txtTime.Text = "";
            btnGenerateImg.Enabled = false;
            string[] imagesList = Directory.GetFiles(@"InputImages\\");
            cmbFilters.Enabled = false;
            FilterMonitor.refresh();
            float percent = 0;
            sw = Stopwatch.StartNew();
            if (serving)
            {
                FilterMonitor.addBuffer(imagesList);
                while (serving)
                {
                    //Do nothing
                }
            }
            else
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
                        {
                            FilterMonitor.addBuffer(imagesList);
                            ConcurrentImageFilter.gauss((int)percent * 5 + 1);
                        }
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
                        int segments = (int)(((slider.Value + 64) * 7) / 128f);
                        if (rdbParallelism.Checked)
                        {
                            FilterMonitor.addBuffer(imagesList);
                            ConcurrentImageFilter.segmentation((int)Math.Pow(2, segments));
                        }
                        else
                            SequentialImageFilter.segmentationFilter(imagesList, (int)Math.Pow(2, segments));
                        break;
                    case 8:
                        if (rdbParallelism.Checked)
                        {
                            FilterMonitor.addBuffer(imagesList);
                            ConcurrentImageFilter.gammaFilter(slider.Value);
                        }
                        else
                            SequentialImageFilter.gammaFilter(imagesList, slider.Value);
                        break;
                    case 9:
                        if (rdbParallelism.Checked)
                        {
                            FilterMonitor.addBuffer(imagesList);
                            ConcurrentImageFilter.contrastFilter(slider.Value);
                        }
                        else
                            SequentialImageFilter.contrastFilter(imagesList, slider.Value);
                        break;
                    case 10:
                        if (rdbParallelism.Checked)
                        {
                            FilterMonitor.addBuffer(imagesList);
                            ConcurrentImageFilter.chaosFilter((slider.Value + 64) * 2);
                        }
                        else
                            SequentialImageFilter.chaosFilter(imagesList, (slider.Value + 64) * 2);
                        break;
                    case 11:
                        if (rdbParallelism.Checked)
                        {
                            FilterMonitor.addBuffer(imagesList);
                            ConcurrentImageFilter.wrinkledTexture();
                        }
                        else
                            SequentialImageFilter.wrinkledTexture(imagesList);
                        break;
                    case 12:
                        int level = (int)(((slider.Value + 64) * 50) / 128f);
                        if (rdbSequential.Checked)
                            SequentialImageFilter.distortionFilter(imagesList, level);
                        else
                        {
                            FilterMonitor.addBuffer(imagesList);
                            ConcurrentImageFilter.distortionFilter(level);
                        }
                        break;
                    case 13:
                        SequentialImageFilter.redFilter(imagesList);
                        break;
                    default:
                        Console.WriteLine("Error detectado");
                        break;
                }
            cmbFilters.Enabled = true;
            serving = !ServeButton.Visible;
            sw.Stop();
            fixedTimeSeconds = (int)(sw.ElapsedMilliseconds / 1000) % 60;
            txtTime.Text =
                (sw.ElapsedMilliseconds / 60000) +
                ":" +
                    ((fixedTimeSeconds > 9) ? 
                    "" + fixedTimeSeconds :
                    "0" + fixedTimeSeconds) + 
                " s";
            btnGenerateImg.Enabled = true;
        }        

        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTime.Text = "";
            if (cmbFilters.SelectedIndex == 0 
                || cmbFilters.SelectedIndex == 1 
                || cmbFilters.SelectedIndex == 3 
                || cmbFilters.SelectedIndex == 11)
            {
                panelCompress.Visible = false;
            }
            else
            {
                panelCompress.Visible = true;
            }

            if(cmbFilters.SelectedIndex == 6)
            {
                lblMin.Text = "Maximo";
                lblMax.Text = "Minimo";
            }
            else
            {
                lblMax.Text = "Maximo";
                lblMin.Text = "Minimo";
            }
            btnGenerateImg.Enabled = !(serving && (netBannedFilters.Contains(cmbFilters.SelectedIndex)));
        }
        public void StartListening(object sender, DoWorkEventArgs e)
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
                    handler = listener.Accept();
                    handler.Receive(bytes);

                    var mStream = new MemoryStream();
                    var binFormatter = new BinaryFormatter();

                    // Where 'objectBytes' is your byte array.
                    mStream.Write(bytes, 0, bytes.Length);
                    mStream.Position = 0;

                    Int16[] data = binFormatter.Deserialize(mStream) as Int16[];
                    if (data[0] == -1)
                    {
                        Tuple<int, int> aux = new Tuple<int, int>(selectedFilter, selectedValue);
                        binFormatter = new BinaryFormatter();
                        mStream = new MemoryStream();
                        binFormatter.Serialize(mStream, aux);
                        handler.Send(mStream.ToArray());
                    }
                    else
                    {
                        if (data[0] != -2)
                            FilterMonitor.setPixel(data[2], Color.FromArgb(data[3], data[4], data[5], data[6]), new Tuple<int, int>(data[0], data[1]));
                        Tuple<int, int, int> nextPixel = FilterMonitor.getNext();
                        Color pixel = Color.FromArgb(0, 0, 0);

                        if (nextPixel != null)
                            pixel = FilterMonitor.getPixel(nextPixel.Item1, nextPixel.Item2, nextPixel.Item3);
                        else
                            nextPixel = new Tuple<int, int, int>(-2, -2, -2);

                        Int16[] aux = new Int16[7] {
                            (Int16)nextPixel.Item1,
                            (Int16)nextPixel.Item2,
                            (Int16)nextPixel.Item3,
                            pixel.A,
                            pixel.R,
                            pixel.G,
                            pixel.B};
                        binFormatter = new BinaryFormatter();
                        mStream = new MemoryStream();
                        binFormatter.Serialize(mStream, aux);
                        handler.Send(mStream.ToArray());
                    }
                }
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void ServeButton_Click(object sender, EventArgs e)
        {
            FilterMonitor.refresh();
            serving = true;
            rdbParallelism.Enabled = false;
            rdbSequential.Enabled = false;
            rdbParallelism.Checked = true;
            ServeButton.Visible = false;
            worker.RunWorkerAsync();
        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            selectedValue = slider.Value;
        }
    }    
}