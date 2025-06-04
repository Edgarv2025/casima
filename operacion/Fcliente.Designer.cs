namespace casima
{
    partial class Fcliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fcliente));
            this.tcliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcliente = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcliente)).BeginInit();
            this.SuspendLayout();
            // 
            // tcliente
            // 
            this.tcliente.Location = new System.Drawing.Point(211, 52);
            this.tcliente.Name = "tcliente";
            this.tcliente.Size = new System.Drawing.Size(205, 20);
            this.tcliente.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Identificacion Cliente";
            // 
            // pcliente
            // 
            this.pcliente.Image = ((System.Drawing.Image)(resources.GetObject("pcliente.Image")));
            this.pcliente.Location = new System.Drawing.Point(432, 12);
            this.pcliente.Name = "pcliente";
            this.pcliente.Size = new System.Drawing.Size(77, 60);
            this.pcliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcliente.TabIndex = 11;
            this.pcliente.TabStop = false;
            this.pcliente.Click += new System.EventHandler(this.pcliente_Click);
            // 
            // Fcliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(524, 85);
            this.Controls.Add(this.pcliente);
            this.Controls.Add(this.tcliente);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fcliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.pcliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tcliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pcliente;
    }
}