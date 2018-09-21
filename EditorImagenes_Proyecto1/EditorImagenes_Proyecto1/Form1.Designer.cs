namespace EditorImagenes_Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgLoader1 = new System.Windows.Forms.PictureBox();
            this.imgLoader2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbFilters = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateImg = new System.Windows.Forms.Button();
            this.rdbSequential = new System.Windows.Forms.RadioButton();
            this.rdbParallelism = new System.Windows.Forms.RadioButton();
            this.panelCompress = new System.Windows.Forms.Panel();
            this.lblPorcentajeCompresion = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.slider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader2)).BeginInit();
            this.panelCompress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLoader1
            // 
            this.imgLoader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgLoader1.Location = new System.Drawing.Point(15, 38);
            this.imgLoader1.Name = "imgLoader1";
            this.imgLoader1.Size = new System.Drawing.Size(495, 328);
            this.imgLoader1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader1.TabIndex = 0;
            this.imgLoader1.TabStop = false;
            // 
            // imgLoader2
            // 
            this.imgLoader2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgLoader2.Location = new System.Drawing.Point(909, 38);
            this.imgLoader2.Name = "imgLoader2";
            this.imgLoader2.Size = new System.Drawing.Size(495, 328);
            this.imgLoader2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoader2.TabIndex = 1;
            this.imgLoader2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(905, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result of image 1";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.Location = new System.Drawing.Point(632, 61);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(143, 37);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Load image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Imagen";
            // 
            // cmbFilters
            // 
            this.cmbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilters.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilters.FormattingEnabled = true;
            this.cmbFilters.Items.AddRange(new object[] {
            "Escala de grises",
            "Sepia",
            "Opacidad",
            "Invertir los colores",
            "Desenfoque gaussiano",
            "Ajuste de brillo",
            "Compresión",
            "Segmentación",
            "Textura"});
            this.cmbFilters.Location = new System.Drawing.Point(591, 144);
            this.cmbFilters.Name = "cmbFilters";
            this.cmbFilters.Size = new System.Drawing.Size(228, 30);
            this.cmbFilters.TabIndex = 2;
            this.cmbFilters.SelectedIndexChanged += new System.EventHandler(this.cmbFilters_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(639, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filters to apply";
            // 
            // btnGenerateImg
            // 
            this.btnGenerateImg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateImg.Location = new System.Drawing.Point(608, 247);
            this.btnGenerateImg.Name = "btnGenerateImg";
            this.btnGenerateImg.Size = new System.Drawing.Size(198, 37);
            this.btnGenerateImg.TabIndex = 6;
            this.btnGenerateImg.Text = "Generate image";
            this.btnGenerateImg.UseVisualStyleBackColor = true;
            this.btnGenerateImg.Click += new System.EventHandler(this.btnGenerateImg_Click);
            // 
            // rdbSequential
            // 
            this.rdbSequential.AutoSize = true;
            this.rdbSequential.BackColor = System.Drawing.Color.Transparent;
            this.rdbSequential.Checked = true;
            this.rdbSequential.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSequential.Location = new System.Drawing.Point(577, 200);
            this.rdbSequential.Name = "rdbSequential";
            this.rdbSequential.Size = new System.Drawing.Size(114, 26);
            this.rdbSequential.TabIndex = 4;
            this.rdbSequential.TabStop = true;
            this.rdbSequential.Text = "Sequential";
            this.rdbSequential.UseVisualStyleBackColor = false;
            // 
            // rdbParallelism
            // 
            this.rdbParallelism.AutoSize = true;
            this.rdbParallelism.BackColor = System.Drawing.Color.Transparent;
            this.rdbParallelism.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbParallelism.Location = new System.Drawing.Point(712, 200);
            this.rdbParallelism.Name = "rdbParallelism";
            this.rdbParallelism.Size = new System.Drawing.Size(122, 26);
            this.rdbParallelism.TabIndex = 5;
            this.rdbParallelism.Text = "Parallelism";
            this.rdbParallelism.UseVisualStyleBackColor = false;
            // 
            // panelCompress
            // 
            this.panelCompress.BackColor = System.Drawing.Color.Transparent;
            this.panelCompress.Controls.Add(this.lblPorcentajeCompresion);
            this.panelCompress.Controls.Add(this.lblMax);
            this.panelCompress.Controls.Add(this.lblMin);
            this.panelCompress.Controls.Add(this.slider);
            this.panelCompress.Location = new System.Drawing.Point(514, 382);
            this.panelCompress.Name = "panelCompress";
            this.panelCompress.Size = new System.Drawing.Size(397, 72);
            this.panelCompress.TabIndex = 15;
            this.panelCompress.Visible = false;
            // 
            // lblPorcentajeCompresion
            // 
            this.lblPorcentajeCompresion.AutoSize = true;
            this.lblPorcentajeCompresion.BackColor = System.Drawing.Color.Linen;
            this.lblPorcentajeCompresion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeCompresion.Location = new System.Drawing.Point(159, 33);
            this.lblPorcentajeCompresion.Name = "lblPorcentajeCompresion";
            this.lblPorcentajeCompresion.Size = new System.Drawing.Size(37, 22);
            this.lblPorcentajeCompresion.TabIndex = 18;
            this.lblPorcentajeCompresion.Text = "1%";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.BackColor = System.Drawing.Color.Transparent;
            this.lblMax.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(317, 18);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(75, 22);
            this.lblMax.TabIndex = 17;
            this.lblMax.Text = "Maximo";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(2, 18);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(72, 22);
            this.lblMin.TabIndex = 16;
            this.lblMin.Text = "Minimo";
            // 
            // slider
            // 
            this.slider.BackColor = System.Drawing.Color.Linen;
            this.slider.Location = new System.Drawing.Point(74, 7);
            this.slider.Maximum = 100;
            this.slider.Minimum = 1;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(243, 56);
            this.slider.TabIndex = 15;
            this.slider.TickFrequency = 0;
            this.slider.Value = 1;
            this.slider.ValueChanged += new System.EventHandler(this.slider_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1418, 681);
            this.Controls.Add(this.rdbParallelism);
            this.Controls.Add(this.rdbSequential);
            this.Controls.Add(this.btnGenerateImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFilters);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgLoader2);
            this.Controls.Add(this.imgLoader1);
            this.Controls.Add(this.panelCompress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image filters OS";
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader2)).EndInit();
            this.panelCompress.ResumeLayout(false);
            this.panelCompress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLoader1;
        private System.Windows.Forms.PictureBox imgLoader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbFilters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateImg;
        private System.Windows.Forms.RadioButton rdbSequential;
        private System.Windows.Forms.RadioButton rdbParallelism;
        private System.Windows.Forms.Panel panelCompress;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Label lblPorcentajeCompresion;
    }
}

