namespace Slaves
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PORT = new System.Windows.Forms.TextBox();
            this.Connection = new System.Windows.Forms.Button();
            this.IP1 = new System.Windows.Forms.MaskedTextBox();
            this.IP2 = new System.Windows.Forms.MaskedTextBox();
            this.IP3 = new System.Windows.Forms.MaskedTextBox();
            this.IP4 = new System.Windows.Forms.MaskedTextBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.LINE = new System.Windows.Forms.ToolStripStatusLabel();
            this.pixels = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SliderValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PORT";
            // 
            // PORT
            // 
            this.PORT.Location = new System.Drawing.Point(55, 38);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(78, 20);
            this.PORT.TabIndex = 4;
            this.PORT.TextChanged += new System.EventHandler(this.portChanged);
            // 
            // Connection
            // 
            this.Connection.Location = new System.Drawing.Point(139, 38);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(108, 26);
            this.Connection.TabIndex = 5;
            this.Connection.Text = "Connect";
            this.Connection.UseVisualStyleBackColor = true;
            this.Connection.Click += new System.EventHandler(this.connection);
            // 
            // IP1
            // 
            this.IP1.Location = new System.Drawing.Point(55, 8);
            this.IP1.Mask = "###";
            this.IP1.Name = "IP1";
            this.IP1.Size = new System.Drawing.Size(36, 20);
            this.IP1.TabIndex = 0;
            this.IP1.TextChanged += new System.EventHandler(this.checkValid);
            // 
            // IP2
            // 
            this.IP2.Location = new System.Drawing.Point(97, 8);
            this.IP2.Mask = "###";
            this.IP2.Name = "IP2";
            this.IP2.Size = new System.Drawing.Size(36, 20);
            this.IP2.TabIndex = 1;
            this.IP2.TextChanged += new System.EventHandler(this.checkValid);
            // 
            // IP3
            // 
            this.IP3.Location = new System.Drawing.Point(139, 8);
            this.IP3.Mask = "###";
            this.IP3.Name = "IP3";
            this.IP3.Size = new System.Drawing.Size(36, 20);
            this.IP3.TabIndex = 2;
            this.IP3.TextChanged += new System.EventHandler(this.checkValid);
            // 
            // IP4
            // 
            this.IP4.Location = new System.Drawing.Point(181, 8);
            this.IP4.Mask = "###";
            this.IP4.Name = "IP4";
            this.IP4.Size = new System.Drawing.Size(36, 20);
            this.IP4.TabIndex = 3;
            this.IP4.TextChanged += new System.EventHandler(this.checkValid);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LINE,
            this.pixels,
            this.toolStripStatusLabel1,
            this.SliderValue});
            this.status.Location = new System.Drawing.Point(0, 67);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(259, 22);
            this.status.TabIndex = 12;
            this.status.Text = "Status";
            // 
            // LINE
            // 
            this.LINE.Name = "LINE";
            this.LINE.Size = new System.Drawing.Size(43, 17);
            this.LINE.Text = "Offline";
            // 
            // pixels
            // 
            this.pixels.Name = "pixels";
            this.pixels.Size = new System.Drawing.Size(39, 17);
            this.pixels.Text = "Pixels:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "Slider Value";
            // 
            // SliderValue
            // 
            this.SliderValue.Name = "SliderValue";
            this.SliderValue.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 89);
            this.Controls.Add(this.status);
            this.Controls.Add(this.IP4);
            this.Controls.Add(this.IP3);
            this.Controls.Add(this.IP2);
            this.Controls.Add(this.IP1);
            this.Controls.Add(this.Connection);
            this.Controls.Add(this.PORT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Slave Program";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PORT;
        private System.Windows.Forms.Button Connection;
        private System.Windows.Forms.MaskedTextBox IP1;
        private System.Windows.Forms.MaskedTextBox IP2;
        private System.Windows.Forms.MaskedTextBox IP3;
        private System.Windows.Forms.MaskedTextBox IP4;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel LINE;
        private System.Windows.Forms.ToolStripStatusLabel pixels;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel SliderValue;
    }
}

