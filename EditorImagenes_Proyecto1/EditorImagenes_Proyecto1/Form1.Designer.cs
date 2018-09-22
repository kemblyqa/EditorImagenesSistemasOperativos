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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbFilters = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateImg = new System.Windows.Forms.Button();
            this.rdbSequential = new System.Windows.Forms.RadioButton();
            this.rdbParallelism = new System.Windows.Forms.RadioButton();
            this.panelCompress = new System.Windows.Forms.Panel();
            this.slider = new System.Windows.Forms.TrackBar();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblPorcentajeCompresion = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.panelCompress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
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
            "Textura",
            "Gamma",
            "Contraste",
            "Chaos"});
            this.cmbFilters.Location = new System.Drawing.Point(102, 59);
            this.cmbFilters.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFilters.Name = "cmbFilters";
            this.cmbFilters.Size = new System.Drawing.Size(172, 27);
            this.cmbFilters.TabIndex = 2;
            this.cmbFilters.SelectedIndexChanged += new System.EventHandler(this.cmbFilters_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filters to apply";
            // 
            // btnGenerateImg
            // 
            this.btnGenerateImg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateImg.Location = new System.Drawing.Point(125, 213);
            this.btnGenerateImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateImg.Name = "btnGenerateImg";
            this.btnGenerateImg.Size = new System.Drawing.Size(148, 30);
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
            this.rdbSequential.Location = new System.Drawing.Point(100, 173);
            this.rdbSequential.Margin = new System.Windows.Forms.Padding(2);
            this.rdbSequential.Name = "rdbSequential";
            this.rdbSequential.Size = new System.Drawing.Size(89, 23);
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
            this.rdbParallelism.Location = new System.Drawing.Point(201, 173);
            this.rdbParallelism.Margin = new System.Windows.Forms.Padding(2);
            this.rdbParallelism.Name = "rdbParallelism";
            this.rdbParallelism.Size = new System.Drawing.Size(91, 23);
            this.rdbParallelism.TabIndex = 5;
            this.rdbParallelism.Text = "Parallelism";
            this.rdbParallelism.UseVisualStyleBackColor = false;
            // 
            // panelCompress
            // 
            this.panelCompress.BackColor = System.Drawing.Color.Transparent;
            this.panelCompress.Controls.Add(this.slider);
            this.panelCompress.Controls.Add(this.lblMax);
            this.panelCompress.Controls.Add(this.lblPorcentajeCompresion);
            this.panelCompress.Controls.Add(this.lblMin);
            this.panelCompress.Location = new System.Drawing.Point(10, 104);
            this.panelCompress.Name = "panelCompress";
            this.panelCompress.Size = new System.Drawing.Size(366, 54);
            this.panelCompress.TabIndex = 15;
            this.panelCompress.Visible = false;
            // 
            // slider
            // 
            this.slider.BackColor = System.Drawing.Color.Linen;
            this.slider.Location = new System.Drawing.Point(58, 3);
            this.slider.Maximum = 64;
            this.slider.Minimum = -64;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(243, 45);
            this.slider.SmallChange = 10;
            this.slider.TabIndex = 15;
            this.slider.TickFrequency = 0;
            this.slider.ValueChanged += new System.EventHandler(this.slider_ValueChanged);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.BackColor = System.Drawing.Color.Transparent;
            this.lblMax.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(306, 20);
            this.lblMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(59, 19);
            this.lblMax.TabIndex = 14;
            this.lblMax.Text = "Maximo";
            // 
            // lblPorcentajeCompresion
            // 
            this.lblPorcentajeCompresion.AutoSize = true;
            this.lblPorcentajeCompresion.BackColor = System.Drawing.Color.Linen;
            this.lblPorcentajeCompresion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeCompresion.Location = new System.Drawing.Point(162, 25);
            this.lblPorcentajeCompresion.Name = "lblPorcentajeCompresion";
            this.lblPorcentajeCompresion.Size = new System.Drawing.Size(30, 19);
            this.lblPorcentajeCompresion.TabIndex = 18;
            this.lblPorcentajeCompresion.Text = "1%";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(2, 20);
            this.lblMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(55, 19);
            this.lblMin.TabIndex = 16;
            this.lblMin.Text = "Minimo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(463, 343);
            this.Controls.Add(this.rdbParallelism);
            this.Controls.Add(this.rdbSequential);
            this.Controls.Add(this.btnGenerateImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFilters);
            this.Controls.Add(this.panelCompress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image filters OS";
            this.panelCompress.ResumeLayout(false);
            this.panelCompress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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

