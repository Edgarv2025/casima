namespace casima.configuracion
{
    partial class Fcajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fcajas));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tnombrecaja = new System.Windows.Forms.TextBox();
            this.datacierre = new System.Windows.Forms.DateTimePicker();
            this.pcrearcaja = new System.Windows.Forms.PictureBox();
            this.bvercajas = new System.Windows.Forms.Button();
            this.datavercajas = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.Button();
            this.btseguridad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcrearcaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datavercajas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Equipo";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de Cierre";
            // 
            // tnombrecaja
            // 
            this.tnombrecaja.Location = new System.Drawing.Point(150, 24);
            this.tnombrecaja.Name = "tnombrecaja";
            this.tnombrecaja.Size = new System.Drawing.Size(172, 20);
            this.tnombrecaja.TabIndex = 1;
            // 
            // datacierre
            // 
            this.datacierre.Location = new System.Drawing.Point(152, 52);
            this.datacierre.Name = "datacierre";
            this.datacierre.Size = new System.Drawing.Size(169, 20);
            this.datacierre.TabIndex = 3;
            // 
            // pcrearcaja
            // 
            this.pcrearcaja.Image = ((System.Drawing.Image)(resources.GetObject("pcrearcaja.Image")));
            this.pcrearcaja.Location = new System.Drawing.Point(328, 4);
            this.pcrearcaja.Name = "pcrearcaja";
            this.pcrearcaja.Size = new System.Drawing.Size(113, 85);
            this.pcrearcaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcrearcaja.TabIndex = 11;
            this.pcrearcaja.TabStop = false;
            this.pcrearcaja.Click += new System.EventHandler(this.pcrearcaja_Click);
            // 
            // bvercajas
            // 
            this.bvercajas.Location = new System.Drawing.Point(82, 98);
            this.bvercajas.Name = "bvercajas";
            this.bvercajas.Size = new System.Drawing.Size(99, 28);
            this.bvercajas.TabIndex = 12;
            this.bvercajas.Text = "ver cajas";
            this.bvercajas.UseVisualStyleBackColor = true;
            this.bvercajas.Click += new System.EventHandler(this.bvercajas_Click);
            // 
            // datavercajas
            // 
            this.datavercajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datavercajas.Location = new System.Drawing.Point(40, 132);
            this.datavercajas.Name = "datavercajas";
            this.datavercajas.Size = new System.Drawing.Size(379, 117);
            this.datavercajas.TabIndex = 13;
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(210, 98);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(99, 28);
            this.Eliminar.TabIndex = 14;
            this.Eliminar.Text = "Eliminar caja";
            this.Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.beliminar_Click);
            // 
            // btseguridad
            // 
            this.btseguridad.Location = new System.Drawing.Point(12, 255);
            this.btseguridad.Name = "btseguridad";
            this.btseguridad.Size = new System.Drawing.Size(69, 23);
            this.btseguridad.TabIndex = 15;
            this.btseguridad.Text = "Cscaja";
            this.btseguridad.UseVisualStyleBackColor = true;
            this.btseguridad.Click += new System.EventHandler(this.btseguridad_Click);
            // 
            // Fcajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(456, 287);
            this.Controls.Add(this.btseguridad);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.datavercajas);
            this.Controls.Add(this.bvercajas);
            this.Controls.Add(this.pcrearcaja);
            this.Controls.Add(this.datacierre);
            this.Controls.Add(this.tnombrecaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fcajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cajas ";
            ((System.ComponentModel.ISupportInitialize)(this.pcrearcaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datavercajas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tnombrecaja;
        private System.Windows.Forms.DateTimePicker datacierre;
        private System.Windows.Forms.PictureBox pcrearcaja;
        private System.Windows.Forms.Button bvercajas;
        private System.Windows.Forms.DataGridView datavercajas;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button btseguridad;
    }
}