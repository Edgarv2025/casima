namespace casima.operacion
{
    partial class Finformeingresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finformeingresos));
            this.detalleingreso = new System.Windows.Forms.DataGridView();
            this.Encabezado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.txtidingreso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCargarTodos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.detalleingreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Encabezado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // detalleingreso
            // 
            this.detalleingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detalleingreso.Location = new System.Drawing.Point(12, 226);
            this.detalleingreso.Name = "detalleingreso";
            this.detalleingreso.Size = new System.Drawing.Size(808, 132);
            this.detalleingreso.TabIndex = 4;
            // 
            // Encabezado
            // 
            this.Encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Encabezado.Location = new System.Drawing.Point(12, 88);
            this.Encabezado.Name = "Encabezado";
            this.Encabezado.Size = new System.Drawing.Size(614, 132);
            this.Encabezado.TabIndex = 3;
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(422, 27);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(89, 29);
            this.Eliminar.TabIndex = 11;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(232, 27);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(89, 29);
            this.buscar.TabIndex = 10;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // Editar
            // 
            this.Editar.Location = new System.Drawing.Point(327, 27);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(89, 29);
            this.Editar.TabIndex = 9;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            this.Editar.Click += new System.EventHandler(this.Editar_Click);
            // 
            // txtidingreso
            // 
            this.txtidingreso.Location = new System.Drawing.Point(119, 34);
            this.txtidingreso.Name = "txtidingreso";
            this.txtidingreso.Size = new System.Drawing.Size(72, 20);
            this.txtidingreso.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "No Ingreso";
            // 
            // BtnCargarTodos
            // 
            this.BtnCargarTodos.Location = new System.Drawing.Point(517, 27);
            this.BtnCargarTodos.Name = "BtnCargarTodos";
            this.BtnCargarTodos.Size = new System.Drawing.Size(89, 29);
            this.BtnCargarTodos.TabIndex = 12;
            this.BtnCargarTodos.Text = "Todos";
            this.BtnCargarTodos.UseVisualStyleBackColor = true;
            this.BtnCargarTodos.Click += new System.EventHandler(this.BtnCargarTodos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(652, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Finformeingresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(860, 382);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnCargarTodos);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.txtidingreso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detalleingreso);
            this.Controls.Add(this.Encabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Finformeingresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe ingresos";
            ((System.ComponentModel.ISupportInitialize)(this.detalleingreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Encabezado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView detalleingreso;
        private System.Windows.Forms.DataGridView Encabezado;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.TextBox txtidingreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCargarTodos;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}