using casima.roles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace casima.autenticacion
{
    public partial class Fverrol : Form
    {
        private SqlConnection _connection = new SqlConnection(Class1.ConnectionString);
        private List<Classrooles> _roles;

        public Fverrol()
        {
            InitializeComponent();
        }

        private void Fverrol_Load(object sender, EventArgs e)
        {
            CargarRoles(); // Cargar la lista de roles al iniciar el formulario
        }

        // Método para cargar todos los roles
        private void CargarRoles()
        {
            _roles = new List<Classrooles>();
            string query = "SELECT id_rol, nombre, ventas, inventario, informes, cierre, config FROM roles";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _roles.Add(new Classrooles
                        {
                            Id_rol = (int)reader["id_rol"],
                            Nombre = reader["nombre"].ToString(),
                            Ventas = reader["ventas"].ToString(),
                            Inventario = reader["inventario"].ToString(),
                            Informes = reader["informes"].ToString(),
                            Cierre = reader["cierre"].ToString(),
                            Config = reader["config"].ToString()
                        });
                    }
                    datalistarol.DataSource = _roles; // Cargar todos los roles
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar roles: " + ex.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        // Método para buscar un rol por Id_rol
        private void BuscarRolPorId(int idRol)
        {
            string query = "SELECT id_rol, nombre, ventas, inventario, informes, cierre, config FROM roles WHERE id_rol = @Id_rol";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Id_rol", idRol);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtid.Text = reader["id_rol"].ToString();
                        txtrol.Text = reader["nombre"].ToString();
                        txtventas.Text = reader["ventas"].ToString();
                        txtinventario.Text = reader["inventario"].ToString();
                        txtinformes.Text = reader["informes"].ToString();
                        txtcierre.Text = reader["cierre"].ToString();
                        txtconfig.Text = reader["config"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún rol con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar rol: " + ex.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        private void bbuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtid.Text.Trim(), out int idRol))
            {
                BuscarRolPorId(idRol);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de rol válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bmtodos_Click(object sender, EventArgs e)
        {
            CargarRoles(); // Cargar todos los roles
        }

        private void bmid_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtid.Text.Trim(), out int idRol))
            {
                BuscarRolPorId(idRol); // Buscar rol por ID

                // Filtrar el DataGridView para mostrar solo el rol seleccionado
                var rolFiltrado = _roles.Where(r => r.Id_rol == idRol).ToList();
                datalistarol.DataSource = rolFiltrado; // Actualizar el DataGridView con el rol filtrado
            }
        }

        private void beditar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtid.Text.Trim(), out int idRol))
            {
                string nombre = txtrol.Text.Trim();
                string ventas = txtventas.Text.Trim();
                string inventario = txtinventario.Text.Trim();
                string informes = txtinformes.Text.Trim();
                string cierre = txtcierre.Text.Trim();
                string config = txtconfig.Text.Trim();

                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string updateQuery = "UPDATE roles SET nombre = @nombre, ventas = @ventas, inventario = @inventario, informes = @informes, cierre = @cierre, config = @config WHERE id_rol = @Id_rol";

                using (SqlCommand command = new SqlCommand(updateQuery, _connection))
                {
                    command.Parameters.AddWithValue("@Id_rol", idRol);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@ventas", ventas);
                    command.Parameters.AddWithValue("@inventario", inventario);
                    command.Parameters.AddWithValue("@informes", informes);
                    command.Parameters.AddWithValue("@cierre", cierre);
                    command.Parameters.AddWithValue("@config", config);

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Rol actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRoles(); // Recargar la lista de roles
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar rol: " + ex.Message);
                    }
                    finally
                    {
                        _connection.Close();
                    }
                }
            }
        }

        private void beliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtid.Text.Trim(), out int idRol))
            {
                string deleteQuery = "DELETE FROM roles WHERE id_rol = @Id_rol";

                using (SqlCommand command = new SqlCommand(deleteQuery, _connection))
                {
                    command.Parameters.AddWithValue("@Id_rol", idRol);

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Rol eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRoles(); // Recargar la lista de roles
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar rol: " + ex.Message);
                    }
                    finally
                    {
                        _connection.Close();
                    }
                }
            }
        }
    }
}


