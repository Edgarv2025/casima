namespace casima.operacion
{
    partial class Finformesventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finformesventas));
            this.label1 = new System.Windows.Forms.Label();
            this.dateinicio = new System.Windows.Forms.DateTimePicker();
            this.datefinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bventag = new System.Windows.Forms.Button();
            this.bventad = new System.Windows.Forms.Button();
            this.dinfoventas = new System.Windows.Forms.DataGridView();
            this.ppdf = new System.Windows.Forms.PictureBox();
            this.pecxel = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttotalinforme = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtncaja = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dinfoventas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pecxel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informes De ventas ";
            // 
            // dateinicio
            // 
            this.dateinicio.Location = new System.Drawing.Point(48, 94);
            this.dateinicio.Name = "dateinicio";
            this.dateinicio.Size = new System.Drawing.Size(150, 20);
            this.dateinicio.TabIndex = 1;
            // 
            // datefinal
            // 
            this.datefinal.Location = new System.Drawing.Point(216, 94);
            this.datefinal.Name = "datefinal";
            this.datefinal.Size = new System.Drawing.Size(150, 20);
            this.datefinal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(212, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Final";
            // 
            // bventag
            // 
            this.bventag.Location = new System.Drawing.Point(295, 121);
            this.bventag.Name = "bventag";
            this.bventag.Size = new System.Drawing.Size(119, 29);
            this.bventag.TabIndex = 5;
            this.bventag.Text = "Venta General";
            this.bventag.UseVisualStyleBackColor = true;
            this.bventag.Click += new System.EventHandler(this.bventag_Click);
            // 
            // bventad
            // 
            this.bventad.Location = new System.Drawing.Point(423, 121);
            this.bventad.Name = "bventad";
            this.bventad.Size = new System.Drawing.Size(119, 29);
            this.bventad.TabIndex = 6;
            this.bventad.Text = "Detalle Venta";
            this.bventad.UseVisualStyleBackColor = true;
            this.bventad.Click += new System.EventHandler(this.bventad_Click);
            // 
            // dinfoventas
            // 
            this.dinfoventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dinfoventas.Location = new System.Drawing.Point(48, 156);
            this.dinfoventas.Name = "dinfoventas";
            this.dinfoventas.Size = new System.Drawing.Size(650, 241);
            this.dinfoventas.TabIndex = 7;
            // 
            // ppdf
            // 
            this.ppdf.Image = ((System.Drawing.Image)(resources.GetObject("ppdf.Image")));
            this.ppdf.Location = new System.Drawing.Point(725, 139);
            this.ppdf.Name = "ppdf";
            this.ppdf.Size = new System.Drawing.Size(35, 43);
            this.ppdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ppdf.TabIndex = 8;
            this.ppdf.TabStop = false;
            this.ppdf.Click += new System.EventHandler(this.ppdf_Click);
            // 
            // pecxel
            // 
            this.pecxel.Image = ((System.Drawing.Image)(resources.GetObject("pecxel.Image")));
            this.pecxel.Location = new System.Drawing.Point(725, 188);
            this.pecxel.Name = "pecxel";
            this.pecxel.Size = new System.Drawing.Size(35, 43);
            this.pecxel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pecxel.TabIndex = 9;
            this.pecxel.TabStop = false;
            this.pecxel.Click += new System.EventHandler(this.pecxel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(412, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total Informe";
            // 
            // txttotalinforme
            // 
            this.txttotalinforme.Location = new System.Drawing.Point(555, 406);
            this.txttotalinforme.Name = "txttotalinforme";
            this.txttotalinforme.Size = new System.Drawing.Size(142, 20);
            this.txttotalinforme.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(595, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(422, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Numero de caja";
            // 
            // txtncaja
            // 
            this.txtncaja.Location = new System.Drawing.Point(426, 94);
            this.txtncaja.Name = "txtncaja";
            this.txtncaja.Size = new System.Drawing.Size(79, 20);
            this.txtncaja.TabIndex = 14;
            // 
            // Finformesventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(775, 458);
            this.Controls.Add(this.txtncaja);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txttotalinforme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pecxel);
            this.Controls.Add(this.ppdf);
            this.Controls.Add(this.dinfoventas);
            this.Controls.Add(this.bventad);
            this.Controls.Add(this.bventag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datefinal);
            this.Controls.Add(this.dateinicio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Finformesventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes Ventas ";
            ((System.ComponentModel.ISupportInitialize)(this.dinfoventas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pecxel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateinicio;
        private System.Windows.Forms.DateTimePicker datefinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bventag;
        private System.Windows.Forms.Button bventad;
        private System.Windows.Forms.DataGridView dinfoventas;
        private System.Windows.Forms.PictureBox ppdf;
        private System.Windows.Forms.PictureBox pecxel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttotalinforme;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtncaja;
    }
}