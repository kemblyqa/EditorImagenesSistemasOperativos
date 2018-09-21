using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void btnGenerateImg_Click(object sender, EventArgs e)
        {
            btnGenerateImg.Enabled = false;

            // images files
            string[] imagesList = Directory.GetFiles(@"InputImages\\");
            switch (cmbFilters.SelectedIndex)
            {
                case 0:
                    SequentialImageFilter.grayScale(imagesList);
                    break;
                case 1:
                    SequentialImageFilter.sepia(imagesList);
                    break;
                case 2:
                    SequentialImageFilter.opacityFilter(imagesList, (float)(slider.Value + 10) / (float)20);
                    break;
                case 5:
                    SequentialImageFilter.brigthness(imagesList, slider.Value);
                    break;
                case 7:
                    SequentialImageFilter.segmentationFilter(imagesList, 21-(slider.Value + 10));
                    break;
                case 8:
                    SequentialImageFilter.texture(imagesList);
                    break;
                default:
                    //
                    break;
            }
            btnGenerateImg.Enabled = true;
        }
    }    
}
