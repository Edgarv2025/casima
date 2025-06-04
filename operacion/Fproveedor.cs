using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima
{
    public partial class Fproveedor : Form
    {
        // Usamos la clase Class1 para la cadena de conexión
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);

        public Fproveedor()
        {
            InitializeComponent();
            dataproveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleccionar filas completas en el DataGridView
            dataproveedores.ReadOnly = true; // Establecer el DataGridView en solo lectura
            dataproveedores.SelectionChanged += Dataproveedores_SelectionChanged; // Manejar el evento de selección de fila
        }

        // Evento click del PictureBox "pproveedor" para registrar un proveedor
        private void pproveedor_Click(object sender, EventArgs e)
        {
            string proveedorNIT = tnitpr.Text.Trim();
            string proveedorRazon = trazonpr.Text.Trim();

            if (string.IsNullOrEmpty(proveedorNIT) || string.IsNullOrEmpty(proveedorRazon))
            {
                MessageBox.Show("Por favor, ingrese tanto el NIT como la razón social del proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegistrarProveedor(proveedorNIT, proveedorRazon);
        }

        // Método para insertar el proveedor en la base de datos
        private void RegistrarProveedor(string proveedorNIT, string proveedorRazon)
        {
            try
            {
                conection.Open();
                string query = "INSERT INTO Proveedores (idproveedor, nombre) VALUES (@idproveedor, @nombre)";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@idproveedor", proveedorNIT);
                    command.Parameters.AddWithValue("@nombre", proveedorRazon);

                    int resultado = command.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Proveedor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosProveedores(); // Recargar datos en el DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conection.Close();
            }
        }

        // Evento click del botón "bver" para cargar los datos de proveedores en el DataGridView
        private void bver_Click(object sender, EventArgs e)
        {
            CargarDatosProveedores();
        }

        // Método para cargar los datos de proveedores en el DataGridView
        private void CargarDatosProveedores()
        {
            try
            {
                string query = "SELECT idproveedor, nombre FROM Proveedores";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                dataproveedores.DataSource = dataTable;
                dataproveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para mostrar los datos de la fila seleccionada en los TextBox
        private void Dataproveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dataproveedores.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataproveedores.SelectedRows[0];
                tnitpr.Text = row.Cells["idproveedor"].Value.ToString();
                trazonpr.Text = row.Cells["nombre"].Value.ToString();
            }
        }

        // Evento click del botón "editar" para actualizar un proveedor
        private void editar_Click(object sender, EventArgs e)
        {
            string proveedorNIT = tnitpr.Text.Trim();
            string proveedorRazon = trazonpr.Text.Trim();

            if (string.IsNullOrEmpty(proveedorNIT) || string.IsNullOrEmpty(proveedorRazon))
            {
                MessageBox.Show("Por favor, ingrese tanto el NIT como la razón social del proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ActualizarProveedor(proveedorNIT, proveedorRazon);
        }

        // Método para actualizar un proveedor en la base de datos
        private void ActualizarProveedor(string proveedorNIT, string proveedorRazon)
        {
            try
            {
                conection.Open();
                string query = "UPDATE Proveedores SET nombre = @nombre WHERE idproveedor = @idproveedor";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@idproveedor", proveedorNIT);
                    command.Parameters.AddWithValue("@nombre", proveedorRazon);

                    int resultado = command.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosProveedores(); // Recargar datos en el DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conection.Close();
            }
        }

        // Evento click del botón "eliminar" para eliminar un proveedor
        private void eliminar_Click(object sender, EventArgs e)
        {
            if (dataproveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un proveedor para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string proveedorNIT = tnitpr.Text.Trim();

            if (MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EliminarProveedor(proveedorNIT);
            }
        }

        // Método para eliminar un proveedor de la base de datos
        private void EliminarProveedor(string proveedorNIT)
        {
            try
            {
                conection.Open();
                string query = "DELETE FROM Proveedores WHERE idproveedor = @idproveedor";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@idproveedor", proveedorNIT);

                    int resultado = command.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatosProveedores(); // Recargar datos en el DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conection.Close();
            }
        }
    }
}
