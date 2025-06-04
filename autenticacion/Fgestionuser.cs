using casima.configuracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace casima.autenticacion
{
    public partial class Fgestionuser : Form
    {
        public Fgestionuser()
        {
            InitializeComponent();
        }

        private void bcrearuser_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario ya está abierto
            bool isOpen = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FRegistro) // Comprueba si el formulario abierto es FmrRegistro
                {
                    isOpen = true;
                    form.BringToFront(); // Lleva el formulario al frente
                    break;
                }
            }

            // Si el formulario no está abierto, se crea una nueva instancia
            if (!isOpen)
            {
                FRegistro registroForm = new FRegistro();
                registroForm.Show();
            }
            this.Close();
        }

        private void bcrearrol_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario ya está abierto
            bool isOpen = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is Frol) // Comprueba si el formulario abierto es Frol
                {
                    isOpen = true;
                    form.BringToFront(); // Lleva el formulario al frente
                    break;
                }
            }

            // Si el formulario no está abierto, se crea una nueva instancia
            if (!isOpen)
            {
                Frol rolForm = new Frol();
                rolForm.Show();
            }
            this.Close();
        }

        private void bedituser_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario ya está abierto
            bool isOpen = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is Frol) // Comprueba si el formulario abierto es Frol
                {
                    isOpen = true;
                    form.BringToFront(); // Lleva el formulario al frente
                    break;
                }
            }

            // Si el formulario no está abierto, se crea una nueva instancia
            if (!isOpen)
            {
                Usuarios usuariosForm = new Usuarios();
                usuariosForm.Show();
            }
            this.Close();
        }

        private void beditrol_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario ya está abierto
            bool isOpen = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is Frol) // Comprueba si el formulario abierto es Frol
                {
                    isOpen = true;
                    form.BringToFront(); // Lleva el formulario al frente
                    break;
                }
            }

            // Si el formulario no está abierto, se crea una nueva instancia
            if (!isOpen)
            {
                Fverrol FverrolForm = new Fverrol();
                FverrolForm.Show();
            }
            this.Close();
        }
    }
}
