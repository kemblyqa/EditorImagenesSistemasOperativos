using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorImagenes_Proyecto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbFilters.SelectedIndex = 0;
            panelCompress.Visible = false;
            
        }
        
        private void btnGenerateImg_Click(object sender, EventArgs e)
        {
            // images files
            string[] imagesList = Directory.GetFiles(@"InputImages\\");
            FilterMonitor.refresh();
            switch (cmbFilters.SelectedIndex)
            {
                case 0:
                    SequentialImageFilter.grayScale(imagesList);
                    break;
                case 1:
                    if (rdbSequential.Checked)
                        SequentialImageFilter.sepia(imagesList);
                    else
                        Console.WriteLine("Llamar funcion con threads");
                    break;
                case 2:
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.opacity((float)(5) / (float)20);
                    }
                    else
                        SequentialImageFilter.opacityFilter(imagesList, (float)(5) / (float)20);
                    break;
                case 3:
                    if (rdbSequential.Checked)
                        SequentialImageFilter.investColorsFunction(imagesList);
                    else
                        Console.WriteLine("Llamar funcion con threads");
                    break;
                case 4:
                    if (rdbSequential.Checked)
                        Console.WriteLine("Llamar funcion secuencial");
                    else
                        Console.WriteLine("Llamar funcion con threads");
                    break;
                case 5:
                    SequentialImageFilter.brigthness(imagesList, slider.Value);
                    break;
                case 6:
                    // Compresión
                    break;
                case 7:
                    SequentialImageFilter.segmentationFilter(imagesList, 21-(slider.Value + 10));
                    break;
                case 8:
                    SequentialImageFilter.texture(imagesList);
                    break;
                case 9:
                    SequentialImageFilter.gammaFilter(imagesList, slider.Value);
                    break;
                case 10:
                    SequentialImageFilter.contrastFilter(imagesList, slider.Value);
                    break;
                default:
                    Console.WriteLine("Error detectado");
                    break;
            }
        }

        private void slider_ValueChanged(object sender, EventArgs e)
        {
            lblPorcentajeCompresion.Text = slider.Value + "%";
            
        }

        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFilters.SelectedIndex == 6 || cmbFilters.SelectedIndex == 9 || cmbFilters.SelectedIndex == 10)
            {
                panelCompress.Visible = true;
            }
            else
            {
                panelCompress.Visible = false;
            }
        }
    }    
}