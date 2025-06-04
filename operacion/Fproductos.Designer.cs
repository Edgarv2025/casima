namespace casima
{
    partial class Fproductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fproductos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tdesproducto = new System.Windows.Forms.TextBox();
            this.tvaloruntp = new System.Windows.Forms.TextBox();
            this.ctipo = new System.Windows.Forms.ComboBox();
            this.pproductos = new System.Windows.Forms.PictureBox();
            this.bveredit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pproductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion producto";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor unt venta";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de producto";
            // 
            // tdesproducto
            // 
            this.tdesproducto.Location = new System.Drawing.Point(238, 76);
            this.tdesproducto.Name = "tdesproducto";
            this.tdesproducto.Size = new System.Drawing.Size(406, 20);
            this.tdesproducto.TabIndex = 5;
            // 
            // tvaloruntp
            // 
            this.tvaloruntp.Location = new System.Drawing.Point(238, 119);
            this.tvaloruntp.Name = "tvaloruntp";
            this.tvaloruntp.Size = new System.Drawing.Size(179, 20);
            this.tvaloruntp.TabIndex = 6;
            // 
            // ctipo
            // 
            this.ctipo.FormattingEnabled = true;
            this.ctipo.Items.AddRange(new object[] {
            "Preparado",
            "Inventario"});
            this.ctipo.Location = new System.Drawing.Point(238, 160);
            this.ctipo.Name = "ctipo";
            this.ctipo.Size = new System.Drawing.Size(178, 21);
            this.ctipo.TabIndex = 8;
            // 
            // pproductos
            // 
            this.pproductos.Image = ((System.Drawing.Image)(resources.GetObject("pproductos.Image")));
            this.pproductos.Location = new System.Drawing.Point(476, 113);
            this.pproductos.Name = "pproductos";
            this.pproductos.Size = new System.Drawing.Size(70, 62);
            this.pproductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pproductos.TabIndex = 10;
            this.pproductos.TabStop = false;
            this.pproductos.Click += new System.EventHandler(this.pproductos_Click);
            // 
            // bveredit
            // 
            this.bveredit.Location = new System.Drawing.Point(366, 12);
            this.bveredit.Name = "bveredit";
            this.bveredit.Size = new System.Drawing.Size(137, 32);
            this.bveredit.TabIndex = 11;
            this.bveredit.Text = "Ver o Editar Productos";
            this.bveredit.UseVisualStyleBackColor = true;
            this.bveredit.Click += new System.EventHandler(this.bveredit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Fproductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(718, 192);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bveredit);
            this.Controls.Add(this.pproductos);
            this.Controls.Add(this.ctipo);
            this.Controls.Add(this.tvaloruntp);
            this.Controls.Add(this.tdesproducto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fproductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos ";
            this.Load += new System.EventHandler(this.Fproductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pproductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tdesproducto;
        private System.Windows.Forms.TextBox tvaloruntp;
        private System.Windows.Forms.ComboBox ctipo;
        private System.Windows.Forms.PictureBox pproductos;
        private System.Windows.Forms.Button bveredit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}