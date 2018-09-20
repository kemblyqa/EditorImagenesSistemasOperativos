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
        private string pathImg;
        public Form1()
        {
            InitializeComponent();
            cmbFilters.SelectedIndex = 0;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select an image.
            openFileDialog1.Filter = "Png files (*.png)|*.png|Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg";
            openFileDialog1.Title = "Select an imagen file";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a image file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgLoader1.Image = Image.FromFile(openFileDialog1.FileName);
                this.pathImg = openFileDialog1.FileName; // set the img path

            }
        }

        private void btnGenerateImg_Click(object sender, EventArgs e)
        {
            //load original image in picturebox1
            imgLoader1.Image = Image.FromFile(this.pathImg);

            switch (cmbFilters.SelectedIndex)
            {
                case 0:
                    //
                    break;
                case 1:
                    SequentialImageFilter.sepiaFunction(this.pathImg);
                    break;
                default:
                    //
                    break;
            }
            //load sepia image in picturebox2
            //imgLoader2.Image = bmp;

        }
    }    
}
