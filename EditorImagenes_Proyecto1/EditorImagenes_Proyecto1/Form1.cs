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
                case 1:
                    if (rdbSequential.Checked)
                        SequentialImageFilter.sepia(imagesList);
                    else
                        Console.WriteLine("Llamar funcion con threads");
                    break;
                case 2:
                    percent = (slider.Value + 64) / 128f;
                    if (rdbParallelism.Checked)
                    {
                        FilterMonitor.addBuffer(imagesList);
                        ConcurrentImageFilter.opacity(percent);
                    }
                    else
                        SequentialImageFilter.opacityFilter(imagesList, percent);
                    break;
                case 3:
                    if (rdbSequential.Checked)
                        SequentialImageFilter.investColorsFunction(imagesList);
                    else
                        Console.WriteLine("Llamar funcion con threads");
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
                    SequentialImageFilter.VaryQualityLevel(imagesList, compressionLevel);
                    // Compresión
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
                default:
                    Console.WriteLine("Error detectado");
                    break;
            }
            btnGenerateImg.Enabled = true;
        }

        private void slider_ValueChanged(object sender, EventArgs e)
        {
            lblPorcentajeCompresion.Text = slider.Value + "%";
            
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
        }
    }    
}