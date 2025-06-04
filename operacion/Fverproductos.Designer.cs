namespace casima.productos
{
    partial class Fverproductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fverproductos));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctipo = new System.Windows.Forms.ComboBox();
            this.ckardex = new System.Windows.Forms.CheckBox();
            this.txtvalor = new System.Windows.Forms.TextBox();
            this.txtproducto = new System.Windows.Forms.TextBox();
            this.datalistaproductos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.bmid = new System.Windows.Forms.Button();
            this.bmtodos = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cestado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.bbuscar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datalistaproductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Se registra en kardex";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de producto";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor unt venta";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripcion producto";
            // 
            // ctipo
            // 
            this.ctipo.FormattingEnabled = true;
            this.ctipo.Items.AddRange(new object[] {
            "Preparado",
            "Inventario"});
            this.ctipo.Location = new System.Drawing.Point(195, 147);
            this.ctipo.Name = "ctipo";
            this.ctipo.Size = new System.Drawing.Size(178, 21);
            this.ctipo.TabIndex = 6;
            // 
            // ckardex
            // 
            this.ckardex.AutoSize = true;
            this.ckardex.Location = new System.Drawing.Point(194, 185);
            this.ckardex.Name = "ckardex";
            this.ckardex.Size = new System.Drawing.Size(120, 17);
            this.ckardex.TabIndex = 8;
            this.ckardex.Text = "Selecciona si aplica";
            this.ckardex.UseVisualStyleBackColor = true;
            // 
            // txtvalor
            // 
            this.txtvalor.Location = new System.Drawing.Point(195, 110);
            this.txtvalor.Name = "txtvalor";
            this.txtvalor.Size = new System.Drawing.Size(179, 20);
            this.txtvalor.TabIndex = 4;
            // 
            // txtproducto
            // 
            this.txtproducto.Location = new System.Drawing.Point(194, 77);
            this.txtproducto.Name = "txtproducto";
            this.txtproducto.Size = new System.Drawing.Size(282, 20);
            this.txtproducto.TabIndex = 2;
            // 
            // datalistaproductos
            // 
            this.datalistaproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistaproductos.Location = new System.Drawing.Point(34, 217);
            this.datalistaproductos.Name = "datalistaproductos";
            this.datalistaproductos.Size = new System.Drawing.Size(718, 235);
            this.datalistaproductos.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(267, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(275, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "LISTADO DE PRODUCTOS";
            // 
            // bmid
            // 
            this.bmid.Location = new System.Drawing.Point(495, 95);
            this.bmid.Name = "bmid";
            this.bmid.Size = new System.Drawing.Size(153, 23);
            this.bmid.TabIndex = 20;
            this.bmid.Text = "mostrar id";
            this.bmid.UseVisualStyleBackColor = true;
            this.bmid.Click += new System.EventHandler(this.bmid_Click);
            // 
            // bmtodos
            // 
            this.bmtodos.Location = new System.Drawing.Point(495, 69);
            this.bmtodos.Name = "bmtodos";
            this.bmtodos.Size = new System.Drawing.Size(153, 23);
            this.bmtodos.TabIndex = 19;
            this.bmtodos.Text = "mostrar todos";
            this.bmtodos.UseVisualStyleBackColor = true;
            this.bmtodos.Click += new System.EventHandler(this.bmtodos_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(495, 154);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(153, 23);
            this.Eliminar.TabIndex = 18;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // Editar
            // 
            this.Editar.Location = new System.Drawing.Point(495, 128);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(153, 23);
            this.Editar.TabIndex = 17;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            this.Editar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(390, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Estado del producto";
            // 
            // cestado
            // 
            this.cestado.FormattingEnabled = true;
            this.cestado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cestado.Location = new System.Drawing.Point(549, 185);
            this.cestado.Name = "cestado";
            this.cestado.Size = new System.Drawing.Size(178, 21);
            this.cestado.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 26);
            this.label5.TabIndex = 21;
            this.label5.Text = "codigo producto";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(195, 40);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(75, 20);
            this.txtcodigo.TabIndex = 0;
            // 
            // bbuscar
            // 
            this.bbuscar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bbuscar.Location = new System.Drawing.Point(495, 40);
            this.bbuscar.Name = "bbuscar";
            this.bbuscar.Size = new System.Drawing.Size(153, 23);
            this.bbuscar.TabIndex = 23;
            this.bbuscar.Text = "Buscar";
            this.bbuscar.UseVisualStyleBackColor = false;
            this.bbuscar.Click += new System.EventHandler(this.bbuscar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(665, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // Fverproductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bbuscar);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bmid);
            this.Controls.Add(this.bmtodos);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datalistaproductos);
            this.Controls.Add(this.cestado);
            this.Controls.Add(this.ctipo);
            this.Controls.Add(this.ckardex);
            this.Controls.Add(this.txtvalor);
            this.Controls.Add(this.txtproducto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Fverproductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "listado productos ";
            ((System.ComponentModel.ISupportInitialize)(this.datalistaproductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ctipo;
        private System.Windows.Forms.CheckBox ckardex;
        private System.Windows.Forms.TextBox txtvalor;
        private System.Windows.Forms.TextBox txtproducto;
        private System.Windows.Forms.DataGridView datalistaproductos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bmid;
        private System.Windows.Forms.Button bmtodos;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cestado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Button bbuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}