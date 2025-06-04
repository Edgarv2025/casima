namespace casima.autenticacion
{
    partial class Fgestionuser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fgestionuser));
            this.bcrearuser = new System.Windows.Forms.Button();
            this.bcrearrol = new System.Windows.Forms.Button();
            this.bedituser = new System.Windows.Forms.Button();
            this.beditrol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bcrearuser
            // 
            this.bcrearuser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bcrearuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcrearuser.Location = new System.Drawing.Point(12, 12);
            this.bcrearuser.Name = "bcrearuser";
            this.bcrearuser.Size = new System.Drawing.Size(154, 41);
            this.bcrearuser.TabIndex = 2;
            this.bcrearuser.Text = "Crear Usuario";
            this.bcrearuser.UseVisualStyleBackColor = false;
            this.bcrearuser.Click += new System.EventHandler(this.bcrearuser_Click);
            // 
            // bcrearrol
            // 
            this.bcrearrol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bcrearrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bcrearrol.Location = new System.Drawing.Point(185, 12);
            this.bcrearrol.Name = "bcrearrol";
            this.bcrearrol.Size = new System.Drawing.Size(154, 41);
            this.bcrearrol.TabIndex = 3;
            this.bcrearrol.Text = "Crear Rol";
            this.bcrearrol.UseVisualStyleBackColor = false;
            this.bcrearrol.Click += new System.EventHandler(this.bcrearrol_Click);
            // 
            // bedituser
            // 
            this.bedituser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bedituser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bedituser.Location = new System.Drawing.Point(12, 69);
            this.bedituser.Name = "bedituser";
            this.bedituser.Size = new System.Drawing.Size(154, 41);
            this.bedituser.TabIndex = 4;
            this.bedituser.Text = "Editar Usuario";
            this.bedituser.UseVisualStyleBackColor = false;
            this.bedituser.Click += new System.EventHandler(this.bedituser_Click);
            // 
            // beditrol
            // 
            this.beditrol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.beditrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beditrol.Location = new System.Drawing.Point(185, 69);
            this.beditrol.Name = "beditrol";
            this.beditrol.Size = new System.Drawing.Size(154, 41);
            this.beditrol.TabIndex = 5;
            this.beditrol.Text = "Editar Permisos";
            this.beditrol.UseVisualStyleBackColor = false;
            this.beditrol.Click += new System.EventHandler(this.beditrol_Click);
            // 
            // Fgestionuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(349, 134);
            this.Controls.Add(this.beditrol);
            this.Controls.Add(this.bedituser);
            this.Controls.Add(this.bcrearrol);
            this.Controls.Add(this.bcrearuser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fgestionuser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gestion Usuarios";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bcrearuser;
        private System.Windows.Forms.Button bcrearrol;
        private System.Windows.Forms.Button bedituser;
        private System.Windows.Forms.Button beditrol;
    }
}