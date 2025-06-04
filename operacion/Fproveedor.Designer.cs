namespace casima
{
    partial class Fproveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fproveedor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tnitpr = new System.Windows.Forms.TextBox();
            this.trazonpr = new System.Windows.Forms.TextBox();
            this.pproveedor = new System.Windows.Forms.PictureBox();
            this.bver = new System.Windows.Forms.Button();
            this.dataproveedores = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pproveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataproveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Identificacion proveedor";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre / Razon social";
            // 
            // tnitpr
            // 
            this.tnitpr.Location = new System.Drawing.Point(211, 27);
            this.tnitpr.Name = "tnitpr";
            this.tnitpr.Size = new System.Drawing.Size(163, 20);
            this.tnitpr.TabIndex = 6;
            // 
            // trazonpr
            // 
            this.trazonpr.Location = new System.Drawing.Point(211, 66);
            this.trazonpr.Name = "trazonpr";
            this.trazonpr.Size = new System.Drawing.Size(323, 20);
            this.trazonpr.TabIndex = 7;
            // 
            // pproveedor
            // 
            this.pproveedor.Image = ((System.Drawing.Image)(resources.GetObject("pproveedor.Image")));
            this.pproveedor.Location = new System.Drawing.Point(568, 12);
            this.pproveedor.Name = "pproveedor";
            this.pproveedor.Size = new System.Drawing.Size(113, 85);
            this.pproveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pproveedor.TabIndex = 11;
            this.pproveedor.TabStop = false;
            this.pproveedor.Click += new System.EventHandler(this.pproveedor_Click);
            // 
            // bver
            // 
            this.bver.Location = new System.Drawing.Point(574, 107);
            this.bver.Name = "bver";
            this.bver.Size = new System.Drawing.Size(95, 26);
            this.bver.TabIndex = 12;
            this.bver.Text = "ver proveedores";
            this.bver.UseVisualStyleBackColor = true;
            this.bver.Click += new System.EventHandler(this.bver_Click);
            // 
            // dataproveedores
            // 
            this.dataproveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataproveedores.Location = new System.Drawing.Point(12, 121);
            this.dataproveedores.Name = "dataproveedores";
            this.dataproveedores.Size = new System.Drawing.Size(544, 208);
            this.dataproveedores.TabIndex = 13;
            // 
            // Editar
            // 
            this.Editar.Location = new System.Drawing.Point(574, 139);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(95, 26);
            this.Editar.TabIndex = 14;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            this.Editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(574, 171);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(95, 26);
            this.Eliminar.TabIndex = 15;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // Fproveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(694, 348);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.dataproveedores);
            this.Controls.Add(this.bver);
            this.Controls.Add(this.pproveedor);
            this.Controls.Add(this.trazonpr);
            this.Controls.Add(this.tnitpr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fproveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.pproveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataproveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tnitpr;
        private System.Windows.Forms.TextBox trazonpr;
        private System.Windows.Forms.PictureBox pproveedor;
        private System.Windows.Forms.Button bver;
        private System.Windows.Forms.DataGridView dataproveedores;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.Button Eliminar;
    }
}