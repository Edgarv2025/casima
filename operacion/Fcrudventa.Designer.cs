namespace casima.operacion
{
    partial class Fcrudventa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fcrudventa));
            this.label1 = new System.Windows.Forms.Label();
            this.Encabezado = new System.Windows.Forms.DataGridView();
            this.detalleventa = new System.Windows.Forms.DataGridView();
            this.txtidventa = new System.Windows.Forms.TextBox();
            this.Editar = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.BtnCargarTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Encabezado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleventa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Venta";
            // 
            // Encabezado
            // 
            this.Encabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Encabezado.Location = new System.Drawing.Point(21, 70);
            this.Encabezado.Name = "Encabezado";
            this.Encabezado.Size = new System.Drawing.Size(808, 132);
            this.Encabezado.TabIndex = 1;
            // 
            // detalleventa
            // 
            this.detalleventa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detalleventa.Location = new System.Drawing.Point(21, 208);
            this.detalleventa.Name = "detalleventa";
            this.detalleventa.Size = new System.Drawing.Size(808, 132);
            this.detalleventa.TabIndex = 2;
            // 
            // txtidventa
            // 
            this.txtidventa.Location = new System.Drawing.Point(112, 26);
            this.txtidventa.Name = "txtidventa";
            this.txtidventa.Size = new System.Drawing.Size(72, 20);
            this.txtidventa.TabIndex = 3;
            // 
            // Editar
            // 
            this.Editar.Location = new System.Drawing.Point(300, 21);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(89, 29);
            this.Editar.TabIndex = 4;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            this.Editar.Click += new System.EventHandler(this.Editar_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(205, 21);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(89, 29);
            this.buscar.TabIndex = 5;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(395, 21);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(89, 29);
            this.Eliminar.TabIndex = 6;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // BtnCargarTodos
            // 
            this.BtnCargarTodos.Location = new System.Drawing.Point(490, 21);
            this.BtnCargarTodos.Name = "BtnCargarTodos";
            this.BtnCargarTodos.Size = new System.Drawing.Size(89, 29);
            this.BtnCargarTodos.TabIndex = 13;
            this.BtnCargarTodos.Text = "Todos";
            this.BtnCargarTodos.UseVisualStyleBackColor = true;
            this.BtnCargarTodos.Click += new System.EventHandler(this.BtnCargarTodos_Click);
            // 
            // Fcrudventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(844, 383);
            this.Controls.Add(this.BtnCargarTodos);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.txtidventa);
            this.Controls.Add(this.detalleventa);
            this.Controls.Add(this.Encabezado);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fcrudventa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ediar venta";
            ((System.ComponentModel.ISupportInitialize)(this.Encabezado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleventa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Encabezado;
        private System.Windows.Forms.DataGridView detalleventa;
        private System.Windows.Forms.TextBox txtidventa;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button BtnCargarTodos;
    }
}