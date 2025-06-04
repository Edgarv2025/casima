namespace casima.configuracion
{
    partial class Frol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frol));
            this.Ncaja = new System.Windows.Forms.Label();
            this.checkpermisos = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.registroroll = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.registroroll)).BeginInit();
            this.SuspendLayout();
            // 
            // Ncaja
            // 
            this.Ncaja.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Ncaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Ncaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ncaja.Location = new System.Drawing.Point(24, 20);
            this.Ncaja.Name = "Ncaja";
            this.Ncaja.Size = new System.Drawing.Size(80, 22);
            this.Ncaja.TabIndex = 2;
            this.Ncaja.Text = "Nombre roll";
            // 
            // checkpermisos
            // 
            this.checkpermisos.CheckOnClick = true;
            this.checkpermisos.FormattingEnabled = true;
            this.checkpermisos.Items.AddRange(new object[] {
            "Ventas",
            "Inventario",
            "Informes",
            "Cierre",
            "Config"});
            this.checkpermisos.Location = new System.Drawing.Point(24, 93);
            this.checkpermisos.Name = "checkpermisos";
            this.checkpermisos.Size = new System.Drawing.Size(77, 79);
            this.checkpermisos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Permisos";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(24, 45);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(146, 20);
            this.txtRol.TabIndex = 0;
            // 
            // registroroll
            // 
            this.registroroll.Image = ((System.Drawing.Image)(resources.GetObject("registroroll.Image")));
            this.registroroll.Location = new System.Drawing.Point(121, 87);
            this.registroroll.Name = "registroroll";
            this.registroroll.Size = new System.Drawing.Size(113, 85);
            this.registroroll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.registroroll.TabIndex = 13;
            this.registroroll.TabStop = false;
            // 
            // Frol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(250, 189);
            this.Controls.Add(this.registroroll);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkpermisos);
            this.Controls.Add(this.Ncaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roles";
            ((System.ComponentModel.ISupportInitialize)(this.registroroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ncaja;
        private System.Windows.Forms.CheckedListBox checkpermisos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.PictureBox registroroll;
    }
}