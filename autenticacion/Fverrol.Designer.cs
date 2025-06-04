namespace casima.autenticacion
{
    partial class Fverrol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fverrol));
            this.txtrol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ncaja = new System.Windows.Forms.Label();
            this.bbuscar = new System.Windows.Forms.Button();
            this.bmid = new System.Windows.Forms.Button();
            this.bmtodos = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.datalistarol = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtventas = new System.Windows.Forms.TextBox();
            this.txtconfig = new System.Windows.Forms.TextBox();
            this.txtcierre = new System.Windows.Forms.TextBox();
            this.txtinformes = new System.Windows.Forms.TextBox();
            this.txtinventario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datalistarol)).BeginInit();
            this.SuspendLayout();
            // 
            // txtrol
            // 
            this.txtrol.Location = new System.Drawing.Point(121, 44);
            this.txtrol.Name = "txtrol";
            this.txtrol.Size = new System.Drawing.Size(146, 20);
            this.txtrol.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Permisos";
            // 
            // Ncaja
            // 
            this.Ncaja.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Ncaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Ncaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ncaja.Location = new System.Drawing.Point(121, 15);
            this.Ncaja.Name = "Ncaja";
            this.Ncaja.Size = new System.Drawing.Size(80, 22);
            this.Ncaja.TabIndex = 1;
            this.Ncaja.Text = "Nombre roll";
            // 
            // bbuscar
            // 
            this.bbuscar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bbuscar.Location = new System.Drawing.Point(310, 12);
            this.bbuscar.Name = "bbuscar";
            this.bbuscar.Size = new System.Drawing.Size(153, 23);
            this.bbuscar.TabIndex = 3;
            this.bbuscar.Text = "Buscar";
            this.bbuscar.UseVisualStyleBackColor = false;
            this.bbuscar.Click += new System.EventHandler(this.bbuscar_Click);
            // 
            // bmid
            // 
            this.bmid.Location = new System.Drawing.Point(265, 335);
            this.bmid.Name = "bmid";
            this.bmid.Size = new System.Drawing.Size(153, 23);
            this.bmid.TabIndex = 6;
            this.bmid.Text = "mostrar id";
            this.bmid.UseVisualStyleBackColor = true;
            this.bmid.Click += new System.EventHandler(this.bmid_Click);
            // 
            // bmtodos
            // 
            this.bmtodos.Location = new System.Drawing.Point(265, 309);
            this.bmtodos.Name = "bmtodos";
            this.bmtodos.Size = new System.Drawing.Size(153, 23);
            this.bmtodos.TabIndex = 5;
            this.bmtodos.Text = "mostrar todos";
            this.bmtodos.UseVisualStyleBackColor = true;
            this.bmtodos.Click += new System.EventHandler(this.bmtodos_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(449, 335);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(153, 23);
            this.Eliminar.TabIndex = 8;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.beliminar_Click);
            // 
            // Editar
            // 
            this.Editar.Location = new System.Drawing.Point(449, 309);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(153, 23);
            this.Editar.TabIndex = 7;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            this.Editar.Click += new System.EventHandler(this.beditar_Click);
            // 
            // datalistarol
            // 
            this.datalistarol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistarol.Location = new System.Drawing.Point(54, 86);
            this.datalistarol.Name = "datalistarol";
            this.datalistarol.Size = new System.Drawing.Size(739, 139);
            this.datalistarol.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(338, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "LISTADO DE ROLES";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(35, 40);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(61, 20);
            this.txtid.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 31;
            this.label2.Text = "Id Roll";
            // 
            // txtventas
            // 
            this.txtventas.Location = new System.Drawing.Point(121, 269);
            this.txtventas.Name = "txtventas";
            this.txtventas.Size = new System.Drawing.Size(40, 20);
            this.txtventas.TabIndex = 9;
            // 
            // txtconfig
            // 
            this.txtconfig.Location = new System.Drawing.Point(122, 357);
            this.txtconfig.Name = "txtconfig";
            this.txtconfig.Size = new System.Drawing.Size(40, 20);
            this.txtconfig.TabIndex = 13;
            // 
            // txtcierre
            // 
            this.txtcierre.Location = new System.Drawing.Point(121, 335);
            this.txtcierre.Name = "txtcierre";
            this.txtcierre.Size = new System.Drawing.Size(40, 20);
            this.txtcierre.TabIndex = 12;
            // 
            // txtinformes
            // 
            this.txtinformes.Location = new System.Drawing.Point(121, 313);
            this.txtinformes.Name = "txtinformes";
            this.txtinformes.Size = new System.Drawing.Size(40, 20);
            this.txtinformes.TabIndex = 11;
            // 
            // txtinventario
            // 
            this.txtinventario.Location = new System.Drawing.Point(121, 292);
            this.txtinventario.Name = "txtinventario";
            this.txtinventario.Size = new System.Drawing.Size(40, 20);
            this.txtinventario.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 39;
            this.label3.Text = "Ventas";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 40;
            this.label4.Text = "Config";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 41;
            this.label5.Text = "Cierre";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 22);
            this.label7.TabIndex = 42;
            this.label7.Text = "Informes";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 22);
            this.label8.TabIndex = 43;
            this.label8.Text = "Inventario";
            // 
            // Fverrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(821, 386);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtinventario);
            this.Controls.Add(this.txtinformes);
            this.Controls.Add(this.txtcierre);
            this.Controls.Add(this.txtconfig);
            this.Controls.Add(this.txtventas);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datalistarol);
            this.Controls.Add(this.bbuscar);
            this.Controls.Add(this.bmid);
            this.Controls.Add(this.bmtodos);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.txtrol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ncaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fverrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Roles";
            ((System.ComponentModel.ISupportInitialize)(this.datalistarol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtrol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ncaja;
        private System.Windows.Forms.Button bbuscar;
        private System.Windows.Forms.Button bmid;
        private System.Windows.Forms.Button bmtodos;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.DataGridView datalistarol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtventas;
        private System.Windows.Forms.TextBox txtconfig;
        private System.Windows.Forms.TextBox txtcierre;
        private System.Windows.Forms.TextBox txtinformes;
        private System.Windows.Forms.TextBox txtinventario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}