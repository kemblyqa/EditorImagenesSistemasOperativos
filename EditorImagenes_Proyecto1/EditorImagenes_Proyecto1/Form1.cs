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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            openFileDialog1.Filter = "Png files (*.png)|*.png|Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg";
            openFileDialog1.Title = "Select an imagen file";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgLoader1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            /*if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }*/
            /*try
            {
                Bitmap image1 = (Bitmap)Image.FromFile(@"C:\Documents and Settings\" +
                    @"All Users\Documents\My Music\music.bmp", true);

                TextureBrush texture = new TextureBrush(image1);
                texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.FillEllipse(texture,
                    new RectangleF(90.0F, 110.0F, 100, 100));
                formGraphics.Dispose();

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
            }*/
        }
    }
}
