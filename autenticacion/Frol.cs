using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima.configuracion
{
    public partial class Frol : Form
    {
        public Frol()
        {
            InitializeComponent();

            // Asignar el evento KeyPress para el TextBox txtRol
            txtRol.KeyPress += new KeyPressEventHandler(OnlyUppercaseLetters_KeyPress);

            // Evento para el PictureBox registroroll
            registroroll.Click += new EventHandler(RegistrarRol);
        }

        // Método para permitir solo letras mayúsculas en txtRol
        private void OnlyUppercaseLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es letra, control o espacio
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convertir a mayúsculas
            }
            else
            {
                e.Handled = true; // Bloquear caracteres no permitidos
                MessageBox.Show("Solo se permiten letras en mayúsculas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RegistrarRol(object sender, EventArgs e)
        {
            // Verificar si la conexión a la base de datos es válida usando la clase Class1
            if (!Class1.TestConnection())
            {
                MessageBox.Show("Error al conectar con la base de datos. Por favor, revise la configuración de la conexión.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convertir a mayúsculas antes de enviar a la base de datos
            string nombreRol = txtRol.Text.Trim().ToUpper();

            // Verificar los permisos seleccionados en el CheckedListBox
            string ventas = checkpermisos.GetItemChecked(0) ? "si" : "no";
            string inventario = checkpermisos.GetItemChecked(1) ? "si" : "no";
            string informes = checkpermisos.GetItemChecked(2) ? "si" : "no";
            string cierre = checkpermisos.GetItemChecked(3) ? "si" : "no";
            string config = checkpermisos.GetItemChecked(4) ? "si" : "no";

            // Validar que el nombre del rol no esté vacío
            if (string.IsNullOrEmpty(nombreRol))
            {
                MessageBox.Show("El campo nombre del rol no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Abrir conexión a la base de datos usando la cadena de conexión de Class1
                using (SqlConnection connection = new SqlConnection(Class1.ConnectionString))
                {
                    connection.Open();

                    // Comprobar si el rol ya existe en la base de datos
                    string checkQuery = "SELECT COUNT(*) FROM Roles WHERE nombre = @nombre";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@nombre", nombreRol);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        // Si el rol ya existe, mostrar un mensaje y cancelar la operación
                        if (count > 0)
                        {
                            MessageBox.Show("El rol ya existe. Por favor, elija otro nombre.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Comando SQL para insertar el nuevo rol
                    string query = "INSERT INTO Roles (nombre, ventas, inventario, informes, cierre, config) VALUES (@nombre, @ventas, @inventario, @informes, @cierre, @config)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parámetros del comando SQL
                        command.Parameters.AddWithValue("@nombre", nombreRol); // Asegura que solo se envíe en mayúsculas
                        command.Parameters.AddWithValue("@ventas", ventas);
                        command.Parameters.AddWithValue("@inventario", inventario);
                        command.Parameters.AddWithValue("@informes", informes);
                        command.Parameters.AddWithValue("@cierre", cierre);
                        command.Parameters.AddWithValue("@config", config);

                        // Ejecutar el comando
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("El rol ha sido registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Cerrar la conexión
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Cerrar el formulario después de registrar la información
            this.Close();
        }
    }
}
