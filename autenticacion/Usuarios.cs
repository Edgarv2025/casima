using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima.autenticacion
{
    public partial class Usuarios : Form
    {
        private SqlConnection _connection = new SqlConnection(Class1.ConnectionString);
        private List<classUsuario> _usuarios;

        public Usuarios()
        {
            InitializeComponent();
            txtDocumento.KeyPress += TxtDocumento_KeyPress;
            datalistausuarios.ReadOnly = true; // Hacer que el DataGridView sea solo de lectura
            datalistausuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleccionar filas completas
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios(); // Carga inicial con todos los usuarios
        }

        private void TxtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Rechaza cualquier carácter que no sea dígito
            }
        }

        private void CargarUsuarios()
        {
            _usuarios = new List<classUsuario>();
            string query = "SELECT Id_usuario, Nombre, Apellidos, Cargo, id_rol FROM Usuarios";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _usuarios.Add(new classUsuario
                        {
                            Id_usuario = (int)reader["Id_usuario"],
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellidos"].ToString(),
                            Cargo = reader["Cargo"].ToString(),
                            Id_rol = (int)reader["id_rol"]
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                }
                finally
                {
                    if (_connection.State == System.Data.ConnectionState.Open)
                    {
                        _connection.Close(); // Asegurar que la conexión se cierre
                    }
                }
            }

            datalistausuarios.DataSource = null;
            datalistausuarios.DataSource = _usuarios;
        }

        private void CargarUsuarioPorId(int idUsuario)
        {
            string query = "SELECT Id_usuario, Nombre, Apellidos, Cargo, id_rol FROM Usuarios WHERE Id_usuario = @Id_usuario";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id_usuario", idUsuario);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        txtApellido.Text = reader["Apellidos"].ToString();
                        txtCargo.Text = reader["Cargo"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún usuario con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimpiarCampos();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el usuario: " + ex.Message);
                }
                finally
                {
                    if (_connection.State == System.Data.ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }
            }
        }

        private void bmtodos_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void bmid_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDocumento.Text.Trim(), out int idUsuario))
            {
                CargarUsuarioPorId(idUsuario);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtDocumento.Text.Trim(), out int idUsuario))
            {
                CargarUsuarioPorId(idUsuario);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que muestra el usuario seleccionado en los TextBoxes cuando se hace clic en el DataGridView
        private void datalistausuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datalistausuarios.CurrentRow != null)
            {
                classUsuario usuarioSeleccionado = (classUsuario)datalistausuarios.CurrentRow.DataBoundItem;
                txtDocumento.Text = usuarioSeleccionado.Id_usuario.ToString();
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtApellido.Text = usuarioSeleccionado.Apellido;
                txtCargo.Text = usuarioSeleccionado.Cargo;
            }
        }

        private void LimpiarCampos()
        {
            txtDocumento.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCargo.Clear();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (datalistausuarios.CurrentRow != null)
            {
                classUsuario usuarioSeleccionado = (classUsuario)datalistausuarios.CurrentRow.DataBoundItem;
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string cargo = txtCargo.Text.Trim();

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(cargo))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string updateQuery = "UPDATE Usuarios SET Nombre = @Nombre, Apellidos = @Apellidos, Cargo = @Cargo WHERE Id_usuario = @Id_usuario";

                using (SqlCommand command = new SqlCommand(updateQuery, _connection))
                {
                    command.Parameters.AddWithValue("@Id_usuario", usuarioSeleccionado.Id_usuario);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellido);
                    command.Parameters.AddWithValue("@Cargo", cargo);

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
                    }
                    finally
                    {
                        if (_connection.State == System.Data.ConnectionState.Open)
                        {
                            _connection.Close();
                        }
                    }
                }

                CargarUsuarios();
                LimpiarCampos();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (datalistausuarios.CurrentRow != null)
            {
                classUsuario usuarioSeleccionado = (classUsuario)datalistausuarios.CurrentRow.DataBoundItem;

                string deleteQuery = "DELETE FROM Usuarios WHERE Id_usuario = @Id_usuario";

                using (SqlCommand command = new SqlCommand(deleteQuery, _connection))
                {
                    command.Parameters.AddWithValue("@Id_usuario", usuarioSeleccionado.Id_usuario);

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                    }
                    finally
                    {
                        if (_connection.State == System.Data.ConnectionState.Open)
                        {
                            _connection.Close();
                        }
                    }
                }

                CargarUsuarios();
                LimpiarCampos();
            }
        }
    }
}

