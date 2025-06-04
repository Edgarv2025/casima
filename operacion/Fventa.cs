using casima.configuracion;
using casima.operacion;
using iText.Commons.Actions;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using static casima.Class2;


namespace casima
{
    public partial class Fventa : Form
    {
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);
        int idUsuario;  // El idUsuario será asignado dinámicamente

        public Fventa(int userId)
        {
            InitializeComponent();

            // Verificar si la caja está registrada antes de continuar
            if (!VerificarCajaRegistrada())
            {
                MessageBox.Show("Caja no registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // Cerrar el formulario si la caja no está registrada
                return;
            }

            // Inicializar la fecha y otros campos predeterminados
            idUsuario = userId;  // Asignar el id del usuario al ingresar al sistema
            dfechav.Value = DateTime.Now;
            CargarDatosUsuario();
            InicializarDataGrid();

            // Cargar el id de caja con el nombre del equipo
            tcajan.Text = ObtenerIdCaja();

            // Predeterminar cliente
            tclientev.Text = "1";

            // Asignar el evento CellValueChanged al DataGridView
            dataventa.CellValueChanged += dataventa_CellValueChanged;
            dataventa.CurrentCellDirtyStateChanged += dataventa_CurrentCellDirtyStateChanged; // Para activar la celda modificada
        }
        private void dataventa_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Verificar si la celda actual está sucia (es decir, si los cambios no se han confirmado)
            if (dataventa.IsCurrentCellDirty)
            {
                // Confirmar la edición de la celda actual
                dataventa.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private bool VerificarCajaRegistrada()
        {
            try
            {
                string nombreEquipo = System.Environment.MachineName;
                string query = "SELECT COUNT(*) FROM cajas WHERE nombreequipo = @nombreequipo";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nombreequipo", nombreEquipo);
                    conection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;  // Si count es mayor que 0, la caja está registrada
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la caja: " + ex.Message);
                return false;
            }
            finally
            {
                conection.Close();
            }
        }

        private string ObtenerIdCaja()
        {
            try
            {
                string nombreEquipo = System.Environment.MachineName;
                string query = "SELECT idcaja FROM cajas WHERE nombreequipo = @nombreequipo";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nombreequipo", nombreEquipo);
                    conection.Open();
                    var result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener ID de caja: " + ex.Message);
                return "0";
            }
            finally
            {
                conection.Close();
            }
        }

        // Método para cargar el nombre del usuario en tuser
        private void CargarDatosUsuario()
        {
            try
            {
                string query = "SELECT Nombre FROM Usuarios WHERE id_usuario = @id_usuario";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@id_usuario", idUsuario);  // Utiliza el idUsuario asignado al iniciar sesión
                    conection.Open();

                    // Ejecutar la consulta y obtener el resultado
                    var result = command.ExecuteScalar();

                    // Verificar si el resultado es nulo o vacío
                    if (result != null && !string.IsNullOrEmpty(result.ToString()))
                    {
                        tuserv.Text = result.ToString();  // Asignar el nombre del usuario
                    }
                    else
                    {
                        tuserv.Text = "Usuario no encontrado";  // Mostrar mensaje si no se encuentra el usuario
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión
                if (conection.State == System.Data.ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }
        private void InicializarDataGrid()
        {
            dataventa.Columns.Clear();

            // Agregar columnas al DataGridView
            dataventa.Columns.Add("codigo", "Código");
            dataventa.Columns.Add("producto", "Producto");
            dataventa.Columns.Add("cantidad", "Cantidad");
            dataventa.Columns.Add("valor unitario", "Valor Unitario");
            dataventa.Columns.Add("subtotal", "Subtotal");

            // Configurar propiedades de cada columna
            dataventa.Columns["codigo"].Width = 100;
            dataventa.Columns["producto"].Width = 200;
            dataventa.Columns["cantidad"].Width = 100;
            dataventa.Columns["valor unitario"].Width = 100;
            dataventa.Columns["subtotal"].Width = 100;

            // Configurar formato de la columna "subtotal" como moneda
            dataventa.Columns["subtotal"].DefaultCellStyle.Format = "C0";

            // Configurar todas las columnas como solo lectura excepto la de "cantidad" y "codigo"
            foreach (DataGridViewColumn column in dataventa.Columns)
            {
                column.ReadOnly = true;
            }
            dataventa.Columns["codigo"].ReadOnly = false;
            dataventa.Columns["cantidad"].ReadOnly = false;

            // Suscribir al evento DefaultValuesNeeded para establecer valor predeterminado en "cantidad"
            dataventa.DefaultValuesNeeded += dataventa_DefaultValuesNeeded;
            dataventa.CellValueChanged += dataventa_CellValueChanged;
            dataventa.CurrentCellDirtyStateChanged += dataventa_CurrentCellDirtyStateChanged;

        }

        private void dataventa_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["cantidad"].Value = 1; // Valor predeterminado de "cantidad" en 1
        }

        private void dataventa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataventa.Columns["codigo"].Index)
            {
                string codigo = dataventa.Rows[e.RowIndex].Cells["codigo"].Value?.ToString();
                if (!string.IsNullOrEmpty(codigo) && codigo.Length >= 3)
                {
                    CargarProducto(codigo, e.RowIndex);
                }
            }
            else if (e.ColumnIndex == dataventa.Columns["cantidad"].Index)
            {
                // Verificar que haya un código de producto en la fila antes de validar la cantidad
                if (dataventa.Rows[e.RowIndex].Cells["codigo"].Value != null)
                {
                    string codigo = dataventa.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                    string tipoProducto = ObtenerTipoProducto(codigo); // Obtener tipo de producto (inventario o preparado)

                    // Si el producto es de tipo "inventario", validar la cantidad contra el saldo en la tabla
                    if (tipoProducto == "inventario")
                    {
                        int cantidad = Convert.ToInt32(dataventa.Rows[e.RowIndex].Cells["cantidad"].Value ?? 0);
                        int saldoActual = ObtenerSaldoProducto(codigo);

                        // Validar si la cantidad excede el saldo disponible
                        if (cantidad > saldoActual)
                        {
                            MessageBox.Show($"La cantidad ingresada ({cantidad}) supera el saldo disponible del producto ({saldoActual}).",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                            // Establecer la cantidad máxima permitida como el saldo actual, si hay saldo, o a 1 por defecto
                            dataventa.Rows[e.RowIndex].Cells["cantidad"].Value = saldoActual > 0 ? saldoActual : 1;
                        }
                    }
                }

                // Calcular el subtotal después de la validación
                CalcularSubtotal(e.RowIndex);
                CalcularTotalVenta(); // Actualizar el total de la venta
            }
        }

        private string ObtenerTipoProducto(string codigo)
        {
            string tipoProducto = "";
            using (SqlConnection connection = new SqlConnection(casima.Class1.ConnectionString))
            {
                string query = "SELECT tipo FROM productos WHERE idproducto = @codigo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    connection.Open();
                    tipoProducto = command.ExecuteScalar()?.ToString();
                }
            }
            return tipoProducto;
        }

        private int ObtenerSaldoProducto(string codigo)
        {
            int saldo = 0; // Valor por defecto
            try
            {
                string query = "SELECT saldos FROM productos WHERE idproducto = @codigo";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    conection.Open();
                    saldo = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el saldo del producto: " + ex.Message);
            }
            finally
            {
                conection.Close();
            }
            return saldo;
        }

        private void CargarProducto(string codigo, int rowIndex)
        {
            try
            {
                string query = "SELECT idproducto, descripcion, valorund, saldos, tipo FROM productos WHERE idproducto = @codigo AND estado = 'activo'";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    conection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string tipoProducto = reader["tipo"].ToString();
                        int saldo = Convert.ToInt32(reader["saldos"]);

                        if (tipoProducto == "Inventario" && saldo <= 0)
                        {
                            MessageBox.Show("Producto sin existencia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LimpiarFila(rowIndex);
                        }
                        else
                        {
                            dataventa.Rows[rowIndex].Cells["producto"].Value = reader["descripcion"].ToString();
                            dataventa.Rows[rowIndex].Cells["valor unitario"].Value = Convert.ToInt32(reader["valorund"]);

                            // Si el producto es inventario y tiene saldo, establecer "1" en la cantidad por defecto
                            if (tipoProducto == "inventario" && saldo > 0)
                            {
                                dataventa.Rows[rowIndex].Cells["cantidad"].Value = 1;
                            }

                            // Calcular subtotal
                            CalcularSubtotal(rowIndex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto no está activo o no existe.", "Producto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LimpiarFila(rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar producto: " + ex.Message);
            }
            finally
            {
                conection.Close();
            }
        }

        private void LimpiarFila(int rowIndex)
        {
            dataventa.Rows[rowIndex].Cells["codigo"].Value = string.Empty;
            dataventa.Rows[rowIndex].Cells["producto"].Value = string.Empty;
            dataventa.Rows[rowIndex].Cells["valor unitario"].Value = string.Empty;
            dataventa.Rows[rowIndex].Cells["cantidad"].Value = 1;
            dataventa.Rows[rowIndex].Cells["subtotal"].Value = string.Empty;
        }

        private void CalcularSubtotal(int rowIndex)
        {
            int cantidad = Convert.ToInt32(dataventa.Rows[rowIndex].Cells["cantidad"].Value ?? 1);
            int valorUnitario = Convert.ToInt32(dataventa.Rows[rowIndex].Cells["valor unitario"].Value ?? 0);
            int subtotal = cantidad * valorUnitario;

            dataventa.Rows[rowIndex].Cells["subtotal"].Value = subtotal;
            
        }

        private void CalcularTotalVenta()
        {
            int total = 0;

            foreach (DataGridViewRow row in dataventa.Rows)
            {
                if (row.Cells["subtotal"].Value != null)
                {
                    int subtotal;
                    if (int.TryParse(row.Cells["subtotal"].Value.ToString(), out subtotal))
                    {
                        total += subtotal;
                    }
                    else
                    {
                        MessageBox.Show($"Error al convertir el subtotal en la fila {row.Index + 1}.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            totalventa.Text = total.ToString("N0"); // Formato sin decimales
            totalventa.Text = total.ToString("C0"); // Formato con moneda
        }

        private void MostrarResumenVenta(int idVenta)
        {
            StringBuilder resumen = new StringBuilder();
            resumen.AppendLine("========= TICKET =========");
            resumen.AppendLine($"ID Venta: {idVenta}");
            resumen.AppendLine($"Cliente: {tclientev.Text}");
            resumen.AppendLine($"Usuario: {tuserv.Text}");
            resumen.AppendLine($"Caja: {tcajan.Text}");
            resumen.AppendLine($"Fecha de Venta: {dfechav.Value.ToShortDateString()}");
            resumen.AppendLine("===========================");

            // Detallar los productos vendidos
            resumen.AppendLine("Productos Vendidos:");
            resumen.AppendLine($"{"Código",-10} {"Producto",-30} {"Cantidad",-10} {"Subtotal",-15}");
            resumen.AppendLine(new string('-', 65)); // Línea divisoria

            foreach (DataGridViewRow row in dataventa.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la nueva fila
                var codigo = row.Cells["codigo"].Value?.ToString() ?? "N/A";
                var producto = row.Cells["producto"].Value?.ToString() ?? "N/A";
                var cantidad = row.Cells["cantidad"].Value?.ToString() ?? "0";
                var subtotal = row.Cells["subtotal"].Value?.ToString() ?? "0";

                resumen.AppendLine($"{codigo,-10} {producto,-30} {cantidad,-10} {subtotal,-15}");
            }

            resumen.AppendLine("===========================");
            resumen.AppendLine($"{"Total Venta:",-40} {totalventa.Text}");

            // Mostrar el resumen en un MessageBox
            MessageBox.Show(resumen.ToString(), "Resumen de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void GuardarVenta()
        {
            // Verificar si hay celdas vacías en el DataGridView
            foreach (DataGridViewRow row in dataventa.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la nueva fila

                // Verificar que no haya celdas vacías
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir del método si hay celdas vacías
                    }
                }
            }
            try
            {
                conection.Open();

                // Insertar en cab_venta
                string queryCabecera = "INSERT INTO cab_venta (idcliente, idcaja, idusuario, fechaventa, fecharegistro, totalventa, estado) OUTPUT INSERTED.idventa " +
                                       "VALUES (@idcliente, @idcaja, @idusuario, @fechaventa, @fecharegistro, @totalventa, @estado)";
                int idVenta;
                using (SqlCommand commandCab = new SqlCommand(queryCabecera, conection))
                {
                    commandCab.Parameters.AddWithValue("@idcliente", tclientev.Text);
                    commandCab.Parameters.AddWithValue("@idcaja", tcajan.Text);
                    commandCab.Parameters.AddWithValue("@idusuario", idUsuario);
                    commandCab.Parameters.AddWithValue("@fechaventa", dfechav.Value);
                    commandCab.Parameters.AddWithValue("@fecharegistro", DateTime.Now);

                    // Asegurarse de que el total de la venta sea numérico
                    decimal total;
                    if (!decimal.TryParse(totalventa.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out total))
                    {
                        MessageBox.Show("Los campos no estan completos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    commandCab.Parameters.AddWithValue("@totalventa", total);
                    commandCab.Parameters.AddWithValue("@estado", "activo");
                    idVenta = (int)commandCab.ExecuteScalar();
                }

                // Insertar en det_venta
                foreach (DataGridViewRow row in dataventa.Rows)
                {
                    if (row.IsNewRow) continue;

                    string queryDetalle = "INSERT INTO det_venta (idventa, idproducto, cantidad, valorunidad, subtotal) " +
                                          "VALUES (@idventa, @idproducto, @cantidad, @valorunidad, @subtotal)";
                    using (SqlCommand commandDet = new SqlCommand(queryDetalle, conection))
                    {
                        commandDet.Parameters.AddWithValue("@idventa", idVenta);
                        commandDet.Parameters.AddWithValue("@idproducto", row.Cells["codigo"].Value.ToString());

                        // Validar cantidad
                        if (!int.TryParse(row.Cells["cantidad"].Value.ToString(), out int cantidad))
                        {
                            MessageBox.Show($"Cantidad en la fila {row.Index + 1} no es válida.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        commandDet.Parameters.AddWithValue("@cantidad", cantidad);

                        // Validar valor unidad
                        if (!decimal.TryParse(row.Cells["valor unitario"].Value.ToString(), out decimal valorUnidad))
                        {
                            MessageBox.Show($"Valor unitario en la fila {row.Index + 1} no es válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        commandDet.Parameters.AddWithValue("@valorunidad", valorUnidad);

                        // Validar subtotal
                        if (!decimal.TryParse(row.Cells["subtotal"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal subtotal))
                        {
                            MessageBox.Show($"Subtotal en la fila {row.Index + 1} no es válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        commandDet.Parameters.AddWithValue("@subtotal", subtotal);

                        commandDet.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Venta realizada con éxito. ID Venta: " + idVenta);
                MostrarResumenVenta(idVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message);
            }
            finally
            {
                conection.Close();
            }
        }
        // Método para registrar los saldos en la tabla saldoproductos
        private void RegistrarSaldosProductos()
        {
            try
            {
                foreach (DataGridViewRow row in dataventa.Rows)
                {
                    if (row.IsNewRow) continue; // Ignorar filas nuevas

                    // Obtener idProducto y cantidad de la fila
                    string idProducto = row.Cells["codigo"].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);

                    // Obtener el tipo de producto (inventario o preparado)
                    string tipoProducto = ObtenerTipoProducto(idProducto);

                    // Inserta los datos en la tabla saldoproductos
                    string queryInsert = "INSERT INTO saldoproductos (idProducto, ingresos, salidas) VALUES (@idProducto, @ingresos, @salidas)";

                    using (SqlConnection con = new SqlConnection(Class1.ConnectionString))
                    using (SqlCommand commandInsert = new SqlCommand(queryInsert, con))
                    {
                        commandInsert.Parameters.AddWithValue("@idProducto", idProducto);
                        commandInsert.Parameters.AddWithValue("@ingresos", 0); // Asumiendo que todo es ingreso
                        commandInsert.Parameters.AddWithValue("@salidas", cantidad); // No hay salidas en este caso

                        con.Open();
                        commandInsert.ExecuteNonQuery();
                    }

                    // Verificar si el producto es de tipo "preparado"
                    if (tipoProducto != "inventario")
                    {
                        // Si el producto no es tipo inventario, actualizar saldos con 0
                        string queryUpdate = "UPDATE productos SET saldos = 0 WHERE idproducto = @idProducto";

                        using (SqlConnection conUpdate = new SqlConnection(Class1.ConnectionString))
                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, conUpdate))
                        {
                            commandUpdate.Parameters.AddWithValue("@idProducto", idProducto);

                            conUpdate.Open();
                            commandUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Si el producto es tipo "inventario", actualizar los saldos de forma normal
                        string queryUpdate = "UPDATE productos SET saldos = saldos - @cantidad WHERE idproducto = @idProducto";

                        using (SqlConnection conUpdate = new SqlConnection(Class1.ConnectionString))
                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, conUpdate))
                        {
                            commandUpdate.Parameters.AddWithValue("@cantidad", cantidad);
                            commandUpdate.Parameters.AddWithValue("@idProducto", idProducto);

                            conUpdate.Open();
                            commandUpdate.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar los saldos de productos: " + ex.Message);
            }
        }


        private void pventa_Click(object sender, EventArgs e)
                {
                    GuardarVenta();

                    // Llama al método para registrar los saldos de los productos
                    RegistrarSaldosProductos();

                    // Abrir una nueva instancia de Fventa con el mismo idUsuario
                    Fventa nuevaVenta = new Fventa(idUsuario);
                    nuevaVenta.Show();

                    // Cerrar la instancia actual de Fventa
                    this.Close();
                }

                private void txtconf_Click(object sender, EventArgs e)
                {
                    // Definir el código de seguridad actual
                    string codigoSeguridad = "1234"; // Cambia esto por el código que prefieras usar

                    // Crear un nuevo formulario de diálogo para el ingreso del código de seguridad
                    Form dialogoCodigo = new Form();
                    dialogoCodigo.Text = "Código de Seguridad";
                    dialogoCodigo.Size = new Size(300, 150);
                    dialogoCodigo.StartPosition = FormStartPosition.CenterParent;

                    // Crear un Label y un TextBox para el código de seguridad
                    Label lblMensaje = new Label() { Left = 20, Top = 20, Text = "Ingrese el código de seguridad:", AutoSize = true };
                    TextBox txtCodigoInput = new TextBox() { Left = 20, Top = 50, Width = 240, UseSystemPasswordChar = true };
                    Button btnAceptar = new Button() { Text = "Aceptar", Left = 20, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                    Button btnCancelar = new Button() { Text = "Cancelar", Left = 140, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };

                    // Agregar controles al formulario de diálogo
                    dialogoCodigo.Controls.Add(lblMensaje);
                    dialogoCodigo.Controls.Add(txtCodigoInput);
                    dialogoCodigo.Controls.Add(btnAceptar);
                    dialogoCodigo.Controls.Add(btnCancelar);

                    // Definir el botón de aceptar como predeterminado
                    dialogoCodigo.AcceptButton = btnAceptar;
                    dialogoCodigo.CancelButton = btnCancelar;

                    // Mostrar el diálogo y verificar la entrada
                    if (dialogoCodigo.ShowDialog() == DialogResult.OK)
                    {
                        // Verificar si el código ingresado es correcto
                        if (txtCodigoInput.Text == codigoSeguridad)
                        {
                            // Código correcto: abrir el formulario Fcrudventa
                            Fcrudventa formCrudVenta = new Fcrudventa();
                            formCrudVenta.Show();
                        }
                        else
                        {
                            // Código incorrecto: mostrar un mensaje de advertencia
                            MessageBox.Show("Código de seguridad incorrecto. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    // Cerrar el formulario de diálogo
                    dialogoCodigo.Dispose();
                }

            }
} 

