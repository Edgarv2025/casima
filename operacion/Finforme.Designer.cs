namespace casima.operacion
{
    partial class Finforme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finforme));
            this.buttonventas = new System.Windows.Forms.Button();
            this.buttoninv = new System.Windows.Forms.Button();
            this.bttingreso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonventas
            // 
            this.buttonventas.Location = new System.Drawing.Point(35, 23);
            this.buttonventas.Name = "buttonventas";
            this.buttonventas.Size = new System.Drawing.Size(129, 49);
            this.buttonventas.TabIndex = 0;
            this.buttonventas.Text = "ventas";
            this.buttonventas.UseVisualStyleBackColor = true;
            this.buttonventas.Click += new System.EventHandler(this.buttonventas_Click);
            // 
            // buttoninv
            // 
            this.buttoninv.Location = new System.Drawing.Point(35, 78);
            this.buttoninv.Name = "buttoninv";
            this.buttoninv.Size = new System.Drawing.Size(129, 49);
            this.buttoninv.TabIndex = 1;
            this.buttoninv.Text = "Inventarios";
            this.buttoninv.UseVisualStyleBackColor = true;
            this.buttoninv.Click += new System.EventHandler(this.buttoninv_Click);
            // 
            // bttingreso
            // 
            this.bttingreso.Location = new System.Drawing.Point(35, 133);
            this.bttingreso.Name = "bttingreso";
            this.bttingreso.Size = new System.Drawing.Size(129, 49);
            this.bttingreso.TabIndex = 2;
            this.bttingreso.Text = "Ingresos";
            this.bttingreso.UseVisualStyleBackColor = true;
            this.bttingreso.Click += new System.EventHandler(this.bttingreso_Click);
            // 
            // Finforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(194, 206);
            this.Controls.Add(this.bttingreso);
            this.Controls.Add(this.buttoninv);
            this.Controls.Add(this.buttonventas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Finforme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonventas;
        private System.Windows.Forms.Button buttoninv;
        private System.Windows.Forms.Button bttingreso;
    }
}