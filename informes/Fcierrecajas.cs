using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima.informes
{
    public partial class Fcierrecajas : Form
    {
        public Fcierrecajas(string userId)
        {
            InitializeComponent();

            txtusercierre.Text = userId; // mostrar el userId
            txtusercierre.ReadOnly = true; // Hacer el TextBox solo lectura
            datalistacierre.ReadOnly = true; // Hacer el DataGridView solo lectura
            datacierre.Value = DateTime.Now; // Configurar la fecha actual

            // Limitar los TextBox para aceptar solo números
            txtusercaja.KeyPress += OnlyNumbers_KeyPress;
            txtncaja.KeyPress += OnlyNumbers_KeyPress;
            txtvalor.KeyPress += OnlyNumbers_KeyPress;

            CargarCajaActiva(); // Cargar el id de la caja activa
            CargarTotalVentasDelDia(); // Calcular y mostrar el total de ventas del día
            CargarDatosCierreCaja(); // Cargar los datos al iniciar el formulario
        }

        private void grabar_Click(object sender, EventArgs e)
        {
            GuardarCierreCaja();
        }

        private void GuardarCierreCaja()
        {
            if (string.IsNullOrWhiteSpace(txtusercierre.Text) ||
                string.IsNullOrWhiteSpace(txtusercaja.Text) ||
                string.IsNullOrWhiteSpace(txtncaja.Text) ||
                string.IsNullOrWhiteSpace(txtvalor.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Verificar si el usuario existe en la tabla usuarios
            if (!UsuarioExiste(txtusercaja.Text))
            {
                MessageBox.Show("El usuario ingresado no existe. Verifique el ID de usuario.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(casima.Class1.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Insertar datos en la tabla cierre_caja
                        string insertQuery = @"INSERT INTO cierre_caja (idusuariocierre, idusuariocaja, idcaja, valorcierre, fecha) 
                                               VALUES (@userCierre, @userCaja, @idCaja, @valorCierre, @fecha)";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userCierre", txtusercierre.Text);
                            command.Parameters.AddWithValue("@userCaja", txtusercaja.Text);
                            command.Parameters.AddWithValue("@idCaja", txtncaja.Text);
                            command.Parameters.AddWithValue("@valorCierre", txtvalor.Text);
                            command.Parameters.AddWithValue("@fecha", datacierre.Value);
                            command.ExecuteNonQuery();
                        }

                        // Actualizar la fecha de cierre en la tabla cajas
                        string updateQuery = @"UPDATE cajas SET fecha_cierre = @fecha WHERE idcaja = @idCaja";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@fecha", datacierre.Value);
                            updateCommand.Parameters.AddWithValue("@idCaja", txtncaja.Text);
                            updateCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Cierre de caja registrado con éxito.");

                        CargarDatosCierreCaja(); // Cargar los datos actualizados en el DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el cierre de caja: " + ex.Message);
                }
            }
        }

        private bool UsuarioExiste(string userId)
        {
            using (SqlConnection connection = new SqlConnection(casima.Class1.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM usuarios WHERE id_usuario = @id_usuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_usuario", userId);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el usuario: " + ex.Message);
                    return false;
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un registro seleccionado en el DataGridView
            if (datalistacierre.SelectedRows.Count > 0)
            {
                // Confirmar la eliminación con el usuario
                DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar el registro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Obtener el ID del registro seleccionado (ajusta esto según la estructura de tus datos)
                    int idCierre = Convert.ToInt32(datalistacierre.SelectedRows[0].Cells["idCierre"].Value);

                    using (SqlConnection connection = new SqlConnection(casima.Class1.ConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {
                                // Actualizar la fecha de cierre en la tabla cajas a la fecha actual menos un día
                                string updateFechaCajaQuery = "UPDATE cajas SET fecha_cierre = @fechaCierre WHERE idcaja = @idCaja";
                                using (SqlCommand updateCommand = new SqlCommand(updateFechaCajaQuery, connection, transaction))
                                {
                                    updateCommand.Parameters.AddWithValue("@fechaCierre", DateTime.Now.AddDays(-1));
                                    updateCommand.Parameters.AddWithValue("@idCaja", txtncaja.Text);
                                    updateCommand.ExecuteNonQuery();
                                }

                                // Eliminar el registro de cierre_caja
                                string deleteQuery = "DELETE FROM cierre_caja WHERE idCierre = @idCierre";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                                {
                                    deleteCommand.Parameters.AddWithValue("@idCierre", idCierre);
                                    deleteCommand.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Registro eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Recargar los datos del DataGridView para reflejar la eliminación
                                CargarDatosCierreCaja();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDatosCierreCaja()
        {
            using (SqlConnection connection = new SqlConnection(casima.Class1.ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Seleccionar solo los últimos 10 registros ordenados por fecha descendente
                    string query = "SELECT TOP 10 * FROM cierre_caja ORDER BY fecha DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        datalistacierre.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos de cierre de caja: " + ex.Message);
                }
            }
        }

        private void CargarCajaActiva()
        {
            using (SqlConnection connection = new SqlConnection(casima.Class1.ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Obtener el ID de la caja activa asociada al equipo actual
                    string query = @"SELECT idcaja FROM cajas WHERE nombreequipo = @nombreequipo ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreequipo", Environment.MachineName); // Nombre del equipo actual
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            txtncaja.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró una caja activa para este equipo.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la caja activa: " + ex.Message);
                }
            }
        }

        private void CargarTotalVentasDelDia()
        {
            using (SqlConnection connection = new SqlConnection(casima.Class1.ConnectionString))
            {
                try
                {
                    connection.Open();
                    DateTime fechaInicio = datacierre.Value.Date; // Fecha desde 00:00
                    DateTime fechaFin = fechaInicio.AddDays(1).AddSeconds(-1); // Fecha hasta 23:59:59

                    // Calcular el total de ventas activas del día de la caja activa
                    string query = @"SELECT SUM(totalventa) 
                                     FROM cab_venta 
                                     WHERE idcaja = @idCaja 
                                     AND fechaventa BETWEEN @fechaInicio AND @fechaFin 
                                     AND estado = 'activo'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCaja", txtncaja.Text);
                        command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        command.Parameters.AddWithValue("@fechaFin", fechaFin);

                        object result = command.ExecuteScalar();
                        txtvalor.Text = result != DBNull.Value ? result.ToString() : "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular el total de ventas del día: " + ex.Message);
                }
            }
        }

        // Método para permitir solo números en los TextBox
        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
