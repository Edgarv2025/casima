using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima
{
    public partial class Fcliente : Form
    {
        // Usamos la clase Class1 para la cadena de conexión
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);

        public Fcliente()
        {
            InitializeComponent();
        }

        // Evento click del PictureBox "pcliente"
        private void pcliente_Click(object sender, EventArgs e)
        {
            // Obtener el valor ingresado en el TextBox "tcliente"
            string clienteID = tcliente.Text.Trim();

            // Validar que el campo no esté vacío
            if (string.IsNullOrEmpty(clienteID))
            {
                MessageBox.Show("Por favor, ingrese el ID del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insertar el cliente en la base de datos
            RegistrarCliente(clienteID);
        }

        // Método para insertar el cliente en la base de datos
        private void RegistrarCliente(string clienteID)
        {
            try
            {
                // Abrir la conexión a la base de datos
                conection.Open();

                // Consulta SQL para insertar el cliente en la tabla Clientes
                string query = "INSERT INTO Clientes (idcliente) VALUES (@idcliente)";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    // Pasar el parámetro a la consulta
                    command.Parameters.AddWithValue("@idcliente", clienteID);

                    // Ejecutar la consulta
                    int resultado = command.ExecuteNonQuery();

                    // Verificar si se insertó el registro correctamente
                    if (resultado > 0)
                    {
                        MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Cerrar el formulario Fcliente
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conection.Close();
            }
            this.Close();
        }
    }
}

