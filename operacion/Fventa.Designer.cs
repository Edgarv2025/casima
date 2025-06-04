namespace casima
{
    partial class Fventa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fventa));
            this.gventa = new System.Windows.Forms.GroupBox();
            this.dfechav = new System.Windows.Forms.DateTimePicker();
            this.tclientev = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalventa = new System.Windows.Forms.TextBox();
            this.tcajan = new System.Windows.Forms.TextBox();
            this.tuserv = new System.Windows.Forms.TextBox();
            this.dataventa = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pventa = new System.Windows.Forms.PictureBox();
            this.txtconf = new System.Windows.Forms.Button();
            this.gventa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataventa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pventa)).BeginInit();
            this.SuspendLayout();
            // 
            // gventa
            // 
            this.gventa.BackColor = System.Drawing.Color.Silver;
            this.gventa.Controls.Add(this.dfechav);
            this.gventa.Controls.Add(this.tclientev);
            this.gventa.Controls.Add(this.label7);
            this.gventa.Controls.Add(this.label6);
            this.gventa.Location = new System.Drawing.Point(380, 63);
            this.gventa.Name = "gventa";
            this.gventa.Size = new System.Drawing.Size(333, 75);
            this.gventa.TabIndex = 2;
            this.gventa.TabStop = false;
            // 
            // dfechav
            // 
            this.dfechav.Location = new System.Drawing.Point(118, 44);
            this.dfechav.Name = "dfechav";
            this.dfechav.Size = new System.Drawing.Size(192, 20);
            this.dfechav.TabIndex = 6;
            // 
            // tclientev
            // 
            this.tclientev.Location = new System.Drawing.Point(118, 16);
            this.tclientev.Name = "tclientev";
            this.tclientev.Size = new System.Drawing.Size(193, 20);
            this.tclientev.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fecha Venta";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(635, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "User";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(503, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Caja N°";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(446, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total venta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalventa
            // 
            this.totalventa.Location = new System.Drawing.Point(574, 409);
            this.totalventa.Name = "totalventa";
            this.totalventa.Size = new System.Drawing.Size(173, 20);
            this.totalventa.TabIndex = 9;
            // 
            // tcajan
            // 
            this.tcajan.Location = new System.Drawing.Point(574, 30);
            this.tcajan.Name = "tcajan";
            this.tcajan.Size = new System.Drawing.Size(41, 20);
            this.tcajan.TabIndex = 0;
            // 
            // tuserv
            // 
            this.tuserv.Location = new System.Drawing.Point(706, 32);
            this.tuserv.Name = "tuserv";
            this.tuserv.Size = new System.Drawing.Size(41, 20);
            this.tuserv.TabIndex = 1;
            // 
            // dataventa
            // 
            this.dataventa.AllowUserToOrderColumns = true;
            this.dataventa.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dataventa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataventa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.producto,
            this.cant,
            this.valor,
            this.Subtotal});
            this.dataventa.Location = new System.Drawing.Point(53, 165);
            this.dataventa.Name = "dataventa";
            this.dataventa.Size = new System.Drawing.Size(694, 215);
            this.dataventa.TabIndex = 7;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Codigo.Width = 50;
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            this.producto.Width = 300;
            // 
            // cant
            // 
            this.cant.HeaderText = "Cantidad";
            this.cant.Name = "cant";
            this.cant.Width = 50;
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor Unitario";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Width = 150;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pventa
            // 
            this.pventa.Image = ((System.Drawing.Image)(resources.GetObject("pventa.Image")));
            this.pventa.Location = new System.Drawing.Point(291, 394);
            this.pventa.Name = "pventa";
            this.pventa.Size = new System.Drawing.Size(57, 46);
            this.pventa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pventa.TabIndex = 11;
            this.pventa.TabStop = false;
            this.pventa.Click += new System.EventHandler(this.pventa_Click);
            // 
            // txtconf
            // 
            this.txtconf.Location = new System.Drawing.Point(13, 411);
            this.txtconf.Name = "txtconf";
            this.txtconf.Size = new System.Drawing.Size(39, 28);
            this.txtconf.TabIndex = 12;
            this.txtconf.Text = "Conf";
            this.txtconf.UseVisualStyleBackColor = true;
            this.txtconf.Click += new System.EventHandler(this.txtconf_Click);
            // 
            // Fventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(771, 451);
            this.Controls.Add(this.txtconf);
            this.Controls.Add(this.pventa);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataventa);
            this.Controls.Add(this.totalventa);
            this.Controls.Add(this.tuserv);
            this.Controls.Add(this.tcajan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gventa);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fventa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta";
            this.gventa.ResumeLayout(false);
            this.gventa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataventa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pventa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gventa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tclientev;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dfechav;
        private System.Windows.Forms.TextBox totalventa;
        private System.Windows.Forms.TextBox tcajan;
        private System.Windows.Forms.TextBox tuserv;
        private System.Windows.Forms.DataGridView dataventa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.PictureBox pventa;
        private System.Windows.Forms.Button txtconf;
    }
}