using casima.operacion;
using System;
using System.Windows.Forms;

namespace casima.configuracion
{
    public partial class Fseguridad : Form
    {
        private string CodigoSeguridad = "1234"; // Cambia este valor al código de seguridad que prefieras

        public Fseguridad()
        {
            InitializeComponent();
            // Suscribirse a los eventos KeyPress de los TextBox
            txtactual.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
            txtcodigo.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y limitar a 4 caracteres
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignorar la tecla presionada si no es un dígito
            }

            // Limitar la entrada a 4 caracteres
            TextBox txt = sender as TextBox;
            if (txt.Text.Length >= 4 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignorar la tecla presionada si ya hay 4 caracteres
            }

            // Mostrar mensaje al ingresar
            if (txt.Text.Length < 4)
            {
                this.Text = "4 caracteres numéricos"; // Mostrar mensaje en la parte superior de la ventana
            }
            else
            {
                this.Text = ""; // Limpiar el mensaje
            }
        }

        private void confirmar_Click(object sender, EventArgs e)
        {
            // Verificar si el código ingresado en txtactual coincide con el código de seguridad
            if (txtactual.Text == CodigoSeguridad)
            {
                // Validar que el nuevo código no esté vacío y tenga 4 caracteres
                if (txtcodigo.Text.Length == 4)
                {
                    // Actualizar el código de seguridad
                    CodigoSeguridad = txtcodigo.Text; // Guardar el nuevo código

                    // Puedes cerrar el formulario o hacer algo más aquí
                    MessageBox.Show("Código de seguridad actualizado."); // Mostrar mensaje de éxito
                    this.Close(); // Cerrar el formulario de seguridad
                }
                else
                {
                    MessageBox.Show("El nuevo código debe tener exactamente 4 caracteres numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcodigo.Focus(); // Enfocar en el campo del nuevo código
                }
            }
            else
            {
                MessageBox.Show("Código de seguridad actual incorrecto. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtactual.Clear(); // Limpiar el campo de texto para intentar nuevamente
                txtcodigo.Clear(); // Limpiar el campo del nuevo código
                txtactual.Focus(); // Focar en el campo de texto actual
            }
        }
    }
}

