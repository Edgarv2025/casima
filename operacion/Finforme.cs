using casima.informes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace casima.operacion
{
    public partial class Finforme : Form
    {
        public Finforme()
        {
            InitializeComponent();
        }

        private void buttonventas_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Finformesventas)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Finformesventas FinformesventasForm = new Finformesventas();
                FinformesventasForm.Show();
                this.Close();
            }
        }

        private void buttoninv_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is eliminar)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                eliminar FinventarioForm = new eliminar();
                FinventarioForm.Show();
                this.Close();
            }
        }

        private void bttingreso_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Finformeingresos)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Finformeingresos FinformeingresosForm = new Finformeingresos();
                FinformeingresosForm.Show();
                this.Close();
            }
        }
    }
}
