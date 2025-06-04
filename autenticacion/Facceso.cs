using casima.informes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace casima
{
    public partial class Facceso : Form
    {
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);
        private static HashSet<string> usuariosEnSesion = new HashSet<string>(); // Almacena usuarios en sesión
        private bool isClosing = false; // Indicador para evitar cierre recursivo

        public Facceso()
        {
            InitializeComponent();

            // Asignar manejadores de eventos para detectar Enter en los controles
            Idocumento.KeyDown += new KeyEventHandler(Control_KeyDown);
            Ipassword.KeyDown += new KeyEventHandler(Control_KeyDown);
            buttonIngresar.KeyDown += new KeyEventHandler(Control_KeyDown);
            pictureBox1.KeyDown += new KeyEventHandler(Control_KeyDown);  // pictureBox1 es el nombre del PictureBox

            // Asignar manejador de eventos para permitir solo números en Idocumento
            Idocumento.KeyPress += new KeyPressEventHandler(Idocumento_KeyPress);
        }

        // Método para manejar el evento KeyPress y permitir solo números
        private void Idocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla de control como retroceso
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es número ni tecla de control, cancelar el evento
                e.Handled = true;
                // Mostrar mensaje de advertencia
                MessageBox.Show("Solo se admiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Evento para mostrar/ocultar la contraseña
        private void mostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            Ipassword.UseSystemPasswordChar = !mostrarContraseña.Checked;
        }

        // Evento click del botón Ingresar
        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            string documento = Idocumento.Text.Trim();
            string contraseña = Ipassword.Text.Trim();

            if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese su documento y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el usuario ya está en sesión
            if (usuariosEnSesion.Contains(documento))
            {
                MessageBox.Show("El usuario ya está en sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contraseñaEncriptada = EncriptarContraseña(contraseña);
            ValidarUsuario(documento, contraseñaEncriptada);
        }

        // Método para encriptar la contraseña
        private string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Método para validar el usuario en la base de datos
        private void ValidarUsuario(string documento, string contraseñaEncriptada)
        {
            try
            {
                conection.Open();

                string query = "SELECT id_rol FROM Usuarios WHERE Id_usuario = @Id_usuario AND CONVERT(NVARCHAR(MAX), contraseña) = @contraseña";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@Id_usuario", documento);
                    command.Parameters.AddWithValue("@contraseña", contraseñaEncriptada);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int id_rol = Convert.ToInt32(reader["id_rol"]);
                        reader.Close();
                        conection.Close();

                        // Añadir usuario a la sesión
                        usuariosEnSesion.Add(documento);

                        AbrirFinicio(id_rol, documento);
                    }
                    else
                    {
                        MessageBox.Show("Documento o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar el usuario: " + ex.Message);
            }
            finally
            {
                if (conection.State == System.Data.ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }

        // Método para abrir el formulario Finicio y pasar el id_rol y userId
        private void AbrirFinicio(int id_rol, string userId)
        {
            // Crear y mostrar el formulario Finicio
            Finicio menu = new Finicio(id_rol, Convert.ToInt32(userId));
            menu.FormClosed += (s, e) => usuariosEnSesion.Remove(userId); // Eliminar usuario de la sesión al cerrar el formulario

            menu.Show();
            this.Hide();  // Ocultar el formulario actual
        }


        // Evento para pasar de un control a otro con Enter
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;  // Evitar el sonido de Enter

                if (sender is TextBox || sender is Button)
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else if (sender is PictureBox)
                {
                    // Ejecutar acción del PictureBox con Enter (simular clic)
                    buttonIngresar_Click(sender, e);
                }
            }
        }

         }
}






