using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima.operacion
{
    public partial class Finformeingresos : Form
    {
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);

        public Finformeingresos()
        {
            InitializeComponent();
            detalleingreso.CellEndEdit += detalleingreso_CellEndEdit;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtidingreso.Text, out int idIngreso))
            {
                CargarDatosIngreso(idIngreso);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de ingreso válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDatosIngreso(int idIngreso)
        {
            try
            {
                if (conection.State == ConnectionState.Closed)
                    conection.Open();

                // Cargar datos de la cabecera
                string queryCabecera = "SELECT * FROM ingresos WHERE idingreso = @idingreso";
                using (SqlCommand commandCab = new SqlCommand(queryCabecera, conection))
                {
                    commandCab.Parameters.AddWithValue("@idingreso", idIngreso);
                    SqlDataAdapter adapterCab = new SqlDataAdapter(commandCab);
                    DataTable dtCabecera = new DataTable();
                    adapterCab.Fill(dtCabecera);
                    Encabezado.DataSource = dtCabecera;
                }

                // Cargar datos de detalle
                string queryDetalle = "SELECT * FROM det_ingreso WHERE idingreso = @idingreso";
                using (SqlCommand commandDet = new SqlCommand(queryDetalle, conection))
                {
                    commandDet.Parameters.AddWithValue("@idingreso", idIngreso);
                    SqlDataAdapter adapterDet = new SqlDataAdapter(commandDet);
                    DataTable dtDetalle = new DataTable();
                    adapterDet.Fill(dtDetalle);
                    detalleingreso.DataSource = dtDetalle;
                }

                // Configurar Encabezado como solo lectura
                foreach (DataGridViewColumn column in Encabezado.Columns)
                {
                    column.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del ingreso: " + ex.Message);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                    conection.Close();
            }
        }

        // Método para cargar toda la información de ambas tablas
        private void CargarTodosLosIngresos()
        {
            try
            {
                if (conection.State == ConnectionState.Closed)
                    conection.Open();

                // Cargar todos los datos de la cabecera
                string queryCabecera = "SELECT * FROM ingresos";
                using (SqlCommand commandCab = new SqlCommand(queryCabecera, conection))
                {
                    SqlDataAdapter adapterCab = new SqlDataAdapter(commandCab);
                    DataTable dtCabecera = new DataTable();
                    adapterCab.Fill(dtCabecera);
                    Encabezado.DataSource = dtCabecera;
                }

                // Cargar todos los datos de detalle
                string queryDetalle = "SELECT * FROM det_ingreso";
                using (SqlCommand commandDet = new SqlCommand(queryDetalle, conection))
                {
                    SqlDataAdapter adapterDet = new SqlDataAdapter(commandDet);
                    DataTable dtDetalle = new DataTable();
                    adapterDet.Fill(dtDetalle);
                    detalleingreso.DataSource = dtDetalle;
                }

                // Configurar Encabezado como solo lectura
                foreach (DataGridViewColumn column in Encabezado.Columns)
                {
                    column.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar todos los ingresos: " + ex.Message);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                    conection.Close();
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            EditarIngreso();
        }

        private void EditarIngreso()
        {
            try
            {
                if (conection.State == ConnectionState.Closed)
                    conection.Open();

                ActualizarTotalIngreso();

                // Actualizar cabecera
                string queryUpdateCab = "UPDATE ingresos SET idproveedor = @idproveedor, fechaingreso = @fechaingreso, valoringreso = @valoringreso, idusuario = @idusuario, docsoporte = @docsoporte WHERE idingreso = @idingreso";
                using (SqlCommand commandCab = new SqlCommand(queryUpdateCab, conection))
                {
                    commandCab.Parameters.AddWithValue("@idingreso", Convert.ToInt32(txtidingreso.Text));
                    commandCab.Parameters.AddWithValue("@idproveedor", Encabezado.Rows[0].Cells["idproveedor"].Value);
                    commandCab.Parameters.AddWithValue("@fechaingreso", Encabezado.Rows[0].Cells["fechaingreso"].Value);
                    commandCab.Parameters.AddWithValue("@valoringreso", Encabezado.Rows[0].Cells["valoringreso"].Value);
                    commandCab.Parameters.AddWithValue("@idusuario", Encabezado.Rows[0].Cells["idusuario"].Value);
                    commandCab.Parameters.AddWithValue("@docsoporte", Encabezado.Rows[0].Cells["docsoporte"].Value);
                    commandCab.ExecuteNonQuery();
                }

                // Actualizar detalle
                foreach (DataGridViewRow row in detalleingreso.Rows)
                {
                    if (row.IsNewRow) continue;
                    string queryUpdateDet = "UPDATE det_ingreso SET cantidad = @cantidad, valorund = @valorund, subtotal = @subtotal, idusuario = @idusuario WHERE idingreso = @idingreso AND idproducto = @idproducto";
                    using (SqlCommand commandDet = new SqlCommand(queryUpdateDet, conection))
                    {
                        commandDet.Parameters.AddWithValue("@idingreso", Convert.ToInt32(txtidingreso.Text));
                        commandDet.Parameters.AddWithValue("@idproducto", row.Cells["idproducto"].Value);
                        commandDet.Parameters.AddWithValue("@cantidad", row.Cells["cantidad"].Value);
                        commandDet.Parameters.AddWithValue("@valorund", row.Cells["valorund"].Value);
                        commandDet.Parameters.AddWithValue("@subtotal", row.Cells["subtotal"].Value);
                        commandDet.Parameters.AddWithValue("@idusuario", row.Cells["idusuario"].Value); 
                        commandDet.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ingreso editado con éxito.");
                CargarDatosIngreso(Convert.ToInt32(txtidingreso.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el ingreso: " + ex.Message);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                    conection.Close();
            }
        }

        private void detalleingreso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (detalleingreso.Columns[e.ColumnIndex].Name == "cantidad" || detalleingreso.Columns[e.ColumnIndex].Name == "valorund")
            {
                DataGridViewRow row = detalleingreso.Rows[e.RowIndex];
                if (row.Cells["cantidad"].Value != null && row.Cells["valorund"].Value != null)
                {
                    decimal cantidad = Convert.ToDecimal(row.Cells["cantidad"].Value);
                    decimal valorund = Convert.ToDecimal(row.Cells["valorund"].Value);

                    row.Cells["subtotal"].Value = cantidad * valorund;

                    ActualizarTotalIngreso();
                }
            }
        }

        private void ActualizarTotalIngreso()
        {
            decimal totalIngreso = 0;

            foreach (DataGridViewRow row in detalleingreso.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["subtotal"].Value != null)
                {
                    totalIngreso += Convert.ToDecimal(row.Cells["subtotal"].Value);
                }
            }

            if (Encabezado.Rows.Count > 0)
            {
                Encabezado.Rows[0].Cells["valoringreso"].Value = totalIngreso; // Actualiza el total en la cabecera
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtidingreso.Text, out int idIngreso))
            {
                DialogResult confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este ingreso y todos sus detalles?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        if (conection.State == ConnectionState.Closed)
                            conection.Open();

                        // Eliminar registros en det_ingreso
                        string queryDeleteDet = "DELETE FROM det_ingreso WHERE idingreso = @idingreso";
                        using (SqlCommand commandDet = new SqlCommand(queryDeleteDet, conection))
                        {
                            commandDet.Parameters.AddWithValue("@idingreso", idIngreso);
                            commandDet.ExecuteNonQuery();
                        }

                        // Eliminar registro en ingresos
                        string queryDeleteCab = "DELETE FROM ingresos WHERE idingreso = @idingreso";
                        using (SqlCommand commandCab = new SqlCommand(queryDeleteCab, conection))
                        {
                            commandCab.Parameters.AddWithValue("@idingreso", idIngreso);
                            commandCab.ExecuteNonQuery();
                        }

                        MessageBox.Show("Ingreso eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Encabezado.DataSource = null;
                        detalleingreso.DataSource = null;
                        txtidingreso.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el ingreso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conection.State == ConnectionState.Open)
                            conection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de ingreso válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento del nuevo botón para cargar toda la información
        private void BtnCargarTodos_Click(object sender, EventArgs e)
        {
            CargarTodosLosIngresos();
        }
    }
}

