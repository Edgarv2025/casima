using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima.operacion
{
    public partial class Fcrudventa : Form
    {
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);

        public Fcrudventa()
        {
            InitializeComponent();
            detalleventa.CellEndEdit += detalleventa_CellEndEdit;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtidventa.Text, out int idVenta))
            {
                CargarDatosVenta(idVenta);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de venta válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDatosVenta(int idVenta)
        {
            try
            {
                if (conection.State == ConnectionState.Closed)
                    conection.Open();

                // Cargar datos de la cabecera
                string queryCabecera = "SELECT * FROM cab_venta WHERE idventa = @idventa";
                using (SqlCommand commandCab = new SqlCommand(queryCabecera, conection))
                {
                    commandCab.Parameters.AddWithValue("@idventa", idVenta);
                    SqlDataAdapter adapterCab = new SqlDataAdapter(commandCab);
                    DataTable dtCabecera = new DataTable();
                    adapterCab.Fill(dtCabecera);
                    Encabezado.DataSource = dtCabecera;
                }

                // Cargar datos de detalle
                string queryDetalle = "SELECT * FROM det_venta WHERE idventa = @idventa";
                using (SqlCommand commandDet = new SqlCommand(queryDetalle, conection))
                {
                    commandDet.Parameters.AddWithValue("@idventa", idVenta);
                    SqlDataAdapter adapterDet = new SqlDataAdapter(commandDet);
                    DataTable dtDetalle = new DataTable();
                    adapterDet.Fill(dtDetalle);
                    detalleventa.DataSource = dtDetalle;
                }

                // Configurar Encabezado como solo lectura
                foreach (DataGridViewColumn column in Encabezado.Columns)
                {
                    column.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la venta: " + ex.Message);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                    conection.Close();
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            EditarVenta();
        }

        private void EditarVenta()
        {
            try
            {
                if (conection.State == ConnectionState.Closed)
                    conection.Open();

                ActualizarTotalVenta();

                // Actualizar cabecera
                string queryUpdateCab = "UPDATE cab_venta SET idcliente = @idcliente, idcaja = @idcaja, idusuario = @idusuario, fechaventa = @fechaventa, totalventa = @totalventa WHERE idventa = @idventa";
                using (SqlCommand commandCab = new SqlCommand(queryUpdateCab, conection))
                {
                    commandCab.Parameters.AddWithValue("@idventa", Convert.ToInt32(txtidventa.Text));
                    commandCab.Parameters.AddWithValue("@idcliente", Encabezado.Rows[0].Cells["idcliente"].Value);
                    commandCab.Parameters.AddWithValue("@idcaja", Encabezado.Rows[0].Cells["idcaja"].Value);
                    commandCab.Parameters.AddWithValue("@idusuario", Encabezado.Rows[0].Cells["idusuario"].Value);
                    commandCab.Parameters.AddWithValue("@fechaventa", Encabezado.Rows[0].Cells["fechaventa"].Value);
                    commandCab.Parameters.AddWithValue("@totalventa", Encabezado.Rows[0].Cells["totalventa"].Value);
                    commandCab.ExecuteNonQuery();
                }

                // Actualizar detalle
                foreach (DataGridViewRow row in detalleventa.Rows)
                {
                    if (row.IsNewRow) continue;
                    string queryUpdateDet = "UPDATE det_venta SET cantidad = @cantidad, valorunidad = @valorunidad, subtotal = @subtotal WHERE idventa = @idventa AND idproducto = @idproducto";
                    using (SqlCommand commandDet = new SqlCommand(queryUpdateDet, conection))
                    {
                        commandDet.Parameters.AddWithValue("@idventa", Convert.ToInt32(txtidventa.Text));
                        commandDet.Parameters.AddWithValue("@idproducto", row.Cells["idproducto"].Value);
                        commandDet.Parameters.AddWithValue("@cantidad", row.Cells["cantidad"].Value);
                        commandDet.Parameters.AddWithValue("@valorunidad", row.Cells["valorunidad"].Value);
                        commandDet.Parameters.AddWithValue("@subtotal", row.Cells["subtotal"].Value);
                        commandDet.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Venta editada con éxito.");
                CargarDatosVenta(Convert.ToInt32(txtidventa.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la venta: " + ex.Message);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                    conection.Close();
            }
        }

        private void detalleventa_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (detalleventa.Columns[e.ColumnIndex].Name == "cantidad" || detalleventa.Columns[e.ColumnIndex].Name == "valorunidad")
            {
                DataGridViewRow row = detalleventa.Rows[e.RowIndex];
                if (row.Cells["cantidad"].Value != null && row.Cells["valorunidad"].Value != null)
                {
                    decimal cantidad = Convert.ToDecimal(row.Cells["cantidad"].Value);
                    decimal valorunidad = Convert.ToDecimal(row.Cells["valorunidad"].Value);

                    row.Cells["subtotal"].Value = cantidad * valorunidad;

                    ActualizarTotalVenta();
                }
            }
        }

        private void ActualizarTotalVenta()
        {
            decimal totalVenta = 0;

            foreach (DataGridViewRow row in detalleventa.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["subtotal"].Value != null)
                {
                    totalVenta += Convert.ToDecimal(row.Cells["subtotal"].Value);
                }
            }

            if (Encabezado.Rows.Count > 0)
            {
                Encabezado.Rows[0].Cells["totalventa"].Value = totalVenta;
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtidventa.Text, out int idVenta))
            {
                DialogResult confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar esta venta y todos sus detalles?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        if (conection.State == ConnectionState.Closed)
                            conection.Open();

                        // Eliminar registros en det_venta
                        string queryDeleteDet = "DELETE FROM det_venta WHERE idventa = @idventa";
                        using (SqlCommand commandDet = new SqlCommand(queryDeleteDet, conection))
                        {
                            commandDet.Parameters.AddWithValue("@idventa", idVenta);
                            commandDet.ExecuteNonQuery();
                        }

                        // Eliminar registro en cab_venta
                        string queryDeleteCab = "DELETE FROM cab_venta WHERE idventa = @idventa";
                        using (SqlCommand commandCab = new SqlCommand(queryDeleteCab, conection))
                        {
                            commandCab.Parameters.AddWithValue("@idventa", idVenta);
                            commandCab.ExecuteNonQuery();
                        }

                        MessageBox.Show("Venta eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Encabezado.DataSource = null;
                        detalleventa.DataSource = null;
                        txtidventa.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Por favor, ingrese un ID de venta válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCargarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (conection.State == ConnectionState.Closed)
                    conection.Open();

                // Cargar todos los datos de la cabecera
                string queryCabecera = "SELECT * FROM cab_venta";
                using (SqlCommand commandCab = new SqlCommand(queryCabecera, conection))
                {
                    SqlDataAdapter adapterCab = new SqlDataAdapter(commandCab);
                    DataTable dtCabecera = new DataTable();
                    adapterCab.Fill(dtCabecera);
                    Encabezado.DataSource = dtCabecera;
                }

                // Cargar todos los datos de detalle
                string queryDetalle = "SELECT * FROM det_venta";
                using (SqlCommand commandDet = new SqlCommand(queryDetalle, conection))
                {
                    SqlDataAdapter adapterDet = new SqlDataAdapter(commandDet);
                    DataTable dtDetalle = new DataTable();
                    adapterDet.Fill(dtDetalle);
                    detalleventa.DataSource = dtDetalle;
                }

                // Configurar Encabezado como solo lectura
                foreach (DataGridViewColumn column in Encabezado.Columns)
                {
                    column.ReadOnly = true;
                }

                MessageBox.Show("Datos cargados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar todos los datos: " + ex.Message);
            }
            finally
            {
                if (conection.State == ConnectionState.Open)
                    conection.Close();
            }
        }
    }
}
