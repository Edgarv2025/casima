namespace casima
{
    partial class Finicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finicio));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Casima = new System.Windows.Forms.Label();
            this.bproductos = new System.Windows.Forms.Button();
            this.bclientes = new System.Windows.Forms.Button();
            this.bproveed = new System.Windows.Forms.Button();
            this.bcierre = new System.Windows.Forms.Button();
            this.binfor = new System.Windows.Forms.Button();
            this.bventas = new System.Windows.Forms.Button();
            this.bingresos = new System.Windows.Forms.Button();
            this.bdatosemp = new System.Windows.Forms.Button();
            this.bgestcajas = new System.Windows.Forms.Button();
            this.bgestUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(292, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Casima
            // 
            this.Casima.AutoSize = true;
            this.Casima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Casima.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Casima.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Casima.Location = new System.Drawing.Point(382, 344);
            this.Casima.Name = "Casima";
            this.Casima.Size = new System.Drawing.Size(68, 21);
            this.Casima.TabIndex = 1;
            this.Casima.Text = "Casima";
            // 
            // bproductos
            // 
            this.bproductos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bproductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bproductos.Location = new System.Drawing.Point(50, 70);
            this.bproductos.Name = "bproductos";
            this.bproductos.Size = new System.Drawing.Size(155, 53);
            this.bproductos.TabIndex = 0;
            this.bproductos.Text = "Productos";
            this.bproductos.UseVisualStyleBackColor = false;
            this.bproductos.Click += new System.EventHandler(this.bproductos_Click);
            // 
            // bclientes
            // 
            this.bclientes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bclientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bclientes.Location = new System.Drawing.Point(50, 188);
            this.bclientes.Name = "bclientes";
            this.bclientes.Size = new System.Drawing.Size(155, 53);
            this.bclientes.TabIndex = 1;
            this.bclientes.Text = "Clientes";
            this.bclientes.UseVisualStyleBackColor = false;
            this.bclientes.Click += new System.EventHandler(this.bclientes_Click);
            // 
            // bproveed
            // 
            this.bproveed.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bproveed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bproveed.Location = new System.Drawing.Point(50, 129);
            this.bproveed.Name = "bproveed";
            this.bproveed.Size = new System.Drawing.Size(155, 53);
            this.bproveed.TabIndex = 2;
            this.bproveed.Text = "Proveedores";
            this.bproveed.UseVisualStyleBackColor = false;
            this.bproveed.Click += new System.EventHandler(this.bproveed_Click);
            // 
            // bcierre
            // 
            this.bcierre.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bcierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcierre.Location = new System.Drawing.Point(621, 82);
            this.bcierre.Name = "bcierre";
            this.bcierre.Size = new System.Drawing.Size(122, 41);
            this.bcierre.TabIndex = 3;
            this.bcierre.Text = "Cierres";
            this.bcierre.UseVisualStyleBackColor = false;
            this.bcierre.Click += new System.EventHandler(this.bcierre_Click);
            // 
            // binfor
            // 
            this.binfor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.binfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binfor.Location = new System.Drawing.Point(621, 150);
            this.binfor.Name = "binfor";
            this.binfor.Size = new System.Drawing.Size(122, 41);
            this.binfor.TabIndex = 4;
            this.binfor.Text = "Informes";
            this.binfor.UseVisualStyleBackColor = false;
            this.binfor.Click += new System.EventHandler(this.binfor_Click);
            // 
            // bventas
            // 
            this.bventas.BackColor = System.Drawing.Color.DarkTurquoise;
            this.bventas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bventas.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bventas.Location = new System.Drawing.Point(242, 260);
            this.bventas.Name = "bventas";
            this.bventas.Size = new System.Drawing.Size(155, 53);
            this.bventas.TabIndex = 5;
            this.bventas.Text = "Ventas";
            this.bventas.UseVisualStyleBackColor = false;
            this.bventas.Click += new System.EventHandler(this.bventas_Click);
            // 
            // bingresos
            // 
            this.bingresos.BackColor = System.Drawing.Color.DarkTurquoise;
            this.bingresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bingresos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bingresos.Location = new System.Drawing.Point(427, 260);
            this.bingresos.Name = "bingresos";
            this.bingresos.Size = new System.Drawing.Size(155, 53);
            this.bingresos.TabIndex = 6;
            this.bingresos.Text = "Ingresos";
            this.bingresos.UseVisualStyleBackColor = false;
            this.bingresos.Click += new System.EventHandler(this.bingresos_Click);
            // 
            // bdatosemp
            // 
            this.bdatosemp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bdatosemp.Location = new System.Drawing.Point(180, 12);
            this.bdatosemp.Name = "bdatosemp";
            this.bdatosemp.Size = new System.Drawing.Size(132, 29);
            this.bdatosemp.TabIndex = 7;
            this.bdatosemp.Text = "Datos Empresa";
            this.bdatosemp.UseVisualStyleBackColor = false;
            this.bdatosemp.Click += new System.EventHandler(this.bdatosemp_Click);
            // 
            // bgestcajas
            // 
            this.bgestcajas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgestcajas.Location = new System.Drawing.Point(319, 12);
            this.bgestcajas.Name = "bgestcajas";
            this.bgestcajas.Size = new System.Drawing.Size(132, 29);
            this.bgestcajas.TabIndex = 8;
            this.bgestcajas.Text = "Gestion Cajas ";
            this.bgestcajas.UseVisualStyleBackColor = false;
            this.bgestcajas.Click += new System.EventHandler(this.bcajas_Click);
            // 
            // bgestUser
            // 
            this.bgestUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bgestUser.Location = new System.Drawing.Point(457, 12);
            this.bgestUser.Name = "bgestUser";
            this.bgestUser.Size = new System.Drawing.Size(132, 29);
            this.bgestUser.TabIndex = 9;
            this.bgestUser.Text = "Gestion Usuarios ";
            this.bgestUser.UseVisualStyleBackColor = false;
            this.bgestUser.Click += new System.EventHandler(this.bgestUser_Click);
            // 
            // Finicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(766, 369);
            this.Controls.Add(this.bgestUser);
            this.Controls.Add(this.bgestcajas);
            this.Controls.Add(this.bdatosemp);
            this.Controls.Add(this.bingresos);
            this.Controls.Add(this.bventas);
            this.Controls.Add(this.binfor);
            this.Controls.Add(this.bcierre);
            this.Controls.Add(this.bproveed);
            this.Controls.Add(this.bclientes);
            this.Controls.Add(this.bproductos);
            this.Controls.Add(this.Casima);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Finicio";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Finicio_FormClosing);
            this.Load += new System.EventHandler(this.Frmmenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Casima;
        private System.Windows.Forms.Button bproductos;
        private System.Windows.Forms.Button binfor;
        private System.Windows.Forms.Button bcierre;
        private System.Windows.Forms.Button bproveed;
        private System.Windows.Forms.Button bclientes;
        private System.Windows.Forms.Button bventas;
        private System.Windows.Forms.Button bingresos;
        private System.Windows.Forms.Button bdatosemp;
        private System.Windows.Forms.Button bgestcajas;
        private System.Windows.Forms.Button bgestUser;
    }
}