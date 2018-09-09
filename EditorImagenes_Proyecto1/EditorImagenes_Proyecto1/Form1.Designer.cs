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
            this.button1 = new System.Windows.Forms.Button();
            this.rdbSequential = new System.Windows.Forms.RadioButton();
            this.rdbParallelism = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader2)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLoader1
            // 
            this.imgLoader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgLoader1.Location = new System.Drawing.Point(16, 38);
            this.imgLoader1.Name = "imgLoader1";
            this.imgLoader1.Size = new System.Drawing.Size(463, 328);
            this.imgLoader1.TabIndex = 0;
            this.imgLoader1.TabStop = false;
            // 
            // imgLoader2
            // 
            this.imgLoader2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgLoader2.Location = new System.Drawing.Point(738, 38);
            this.imgLoader2.Name = "imgLoader2";
            this.imgLoader2.Size = new System.Drawing.Size(463, 328);
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
            this.label2.Location = new System.Drawing.Point(734, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result of image 1";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.Location = new System.Drawing.Point(540, 87);
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
            this.cmbFilters.Location = new System.Drawing.Point(504, 168);
            this.cmbFilters.Name = "cmbFilters";
            this.cmbFilters.Size = new System.Drawing.Size(228, 30);
            this.cmbFilters.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(500, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filters to apply";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(514, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Generate image";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // rdbSequential
            // 
            this.rdbSequential.AutoSize = true;
            this.rdbSequential.BackColor = System.Drawing.Color.Transparent;
            this.rdbSequential.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSequential.Location = new System.Drawing.Point(522, 224);
            this.rdbSequential.Name = "rdbSequential";
            this.rdbSequential.Size = new System.Drawing.Size(114, 26);
            this.rdbSequential.TabIndex = 10;
            this.rdbSequential.TabStop = true;
            this.rdbSequential.Text = "Sequential";
            this.rdbSequential.UseVisualStyleBackColor = false;
            // 
            // rdbParallelism
            // 
            this.rdbParallelism.AutoSize = true;
            this.rdbParallelism.BackColor = System.Drawing.Color.Transparent;
            this.rdbParallelism.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbParallelism.Location = new System.Drawing.Point(522, 251);
            this.rdbParallelism.Name = "rdbParallelism";
            this.rdbParallelism.Size = new System.Drawing.Size(122, 26);
            this.rdbParallelism.TabIndex = 11;
            this.rdbParallelism.TabStop = true;
            this.rdbParallelism.Text = "Parallelism";
            this.rdbParallelism.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1217, 681);
            this.Controls.Add(this.rdbParallelism);
            this.Controls.Add(this.rdbSequential);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFilters);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgLoader2);
            this.Controls.Add(this.imgLoader1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Image filters OS";
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoader2)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdbSequential;
        private System.Windows.Forms.RadioButton rdbParallelism;
    }
}

