using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace casima
{
    public partial class Fingreso : Form
    {
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);
        int idUsuario;  // El idUsuario será asignado dinámicamente

        public Fingreso(int userId)
        {
            InitializeComponent();
            idUsuario = userId;  // Asignar el id del usuario al ingresar al sistema
            dfechai.Value = DateTime.Now;  // Fecha predeterminada actual
            CargarDatosUsuario();          // Cargar el nombre del usuario

            // Inicializar DataGridView
            InitializeDataGridView();

            // Asignar el evento Leave a tnitp para cargar el proveedor
            tnitp.Leave += Tnitp_Leave;

            // Asignar el evento CellValueChanged al DataGridView
            dataingreso.CellValueChanged += dataingreso_CellValueChanged;
            dataingreso.CurrentCellDirtyStateChanged += dataingreso_CurrentCellDirtyStateChanged; // Para activar la celda modificada
        }

        private void InitializeDataGridView()
        {
            dataingreso.Columns.Clear();
            dataingreso.Columns.Add("codigo", "Código");
            dataingreso.Columns.Add("producto", "Producto");
            dataingreso.Columns.Add("cantidad", "Cantidad");
            dataingreso.Columns.Add("valor unitario", "Valor Unitario");
            dataingreso.Columns.Add("subtotal", "Subtotal");

            // Establecer las propiedades de las columnas si es necesario
            dataingreso.Columns["codigo"].Width = 100;
            dataingreso.Columns["producto"].Width = 200;
            dataingreso.Columns["cantidad"].Width = 100;
            dataingreso.Columns["valor unitario"].Width = 100;
            dataingreso.Columns["subtotal"].Width = 100;

            // Aplicar formato de moneda a la columna "subtotal"
            dataingreso.Columns["subtotal"].DefaultCellStyle.Format = "C0"; // Sin decimales

            // Configurar todas las columnas como solo lectura excepto la de "cantidad"
            foreach (DataGridViewColumn column in dataingreso.Columns)
            {
                column.ReadOnly = true;
            }
            dataingreso.Columns["codigo"].ReadOnly = false;
            dataingreso.Columns["cantidad"].ReadOnly = false;
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
                        tuser.Text = result.ToString();  // Asignar el nombre del usuario
                    }
                    else
                    {
                        tuser.Text = "Usuario no encontrado";  // Mostrar mensaje si no se encuentra el usuario
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

        // Evento que se ejecuta cuando se pierde el foco en tnitp
        private void Tnitp_Leave(object sender, EventArgs e)
        {
            CargarDatosProveedor();  // Cargar el proveedor
        }

        // Método para cargar un proveedor en tprovi según el NIT ingresado en tnitp
        private void CargarDatosProveedor()
        {
            if (int.TryParse(tnitp.Text.Trim(), out int idProveedor))
            {
                string query = "SELECT idproveedor, nombre FROM Proveedores WHERE idproveedor = @idproveedor";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@idproveedor", idProveedor);
                    conection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Asignar la descripción del proveedor
                        tprovi.Text = reader["nombre"] != DBNull.Value ? reader["nombre"].ToString() : "Descripción no encontrada";
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conection.Close();
                }
            }
            else
            {
                MessageBox.Show("El ID debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento cuando se hace click en pingresos
        private void pingresos_Click(object sender, EventArgs e)
        {
            // Validar los campos de entrada
            if (string.IsNullOrEmpty(tuser.Text.Trim()) ||
                string.IsNullOrEmpty(tnitp.Text.Trim()) ||
                string.IsNullOrEmpty(tprovi.Text.Trim()) ||
                string.IsNullOrEmpty(tdoci.Text.Trim()))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(tnitp.Text.Trim(), out int idProveedor))
            {
                MessageBox.Show("El NIT del proveedor debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que haya productos en el DataGridView
            if (dataingreso.Rows.Count == 0 || dataingreso.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Debe ingresar al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar cada fila del DataGridView
            foreach (DataGridViewRow row in dataingreso.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la nueva fila en blanco

                // Verificar que las celdas necesarias no estén vacías
                if (string.IsNullOrWhiteSpace(row.Cells["codigo"].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells["producto"].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells["cantidad"].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells["valor unitario"].Value?.ToString()))
                {
                    MessageBox.Show("Todos los campos de cada producto deben estar completos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que la cantidad y el valor unitario sean números válidos
                if (!int.TryParse(row.Cells["cantidad"].Value?.ToString(), out _) ||
                    !decimal.TryParse(row.Cells["valor unitario"].Value?.ToString(), out _))
                {
                    MessageBox.Show("La cantidad y el valor unitario deben ser números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            // Sumar el total de ingreso (subtotal de los productos)
            decimal totalIngreso = 0;
            foreach (DataGridViewRow row in dataingreso.Rows)
            {
                if (row.Cells["subtotal"].Value != null)
                {
                    totalIngreso += Convert.ToDecimal(row.Cells["subtotal"].Value);
                }
            }

            totalingreso.Text = totalIngreso.ToString();

            // Insertar los datos en la base de datos
            RegistrarIngreso(idProveedor, totalIngreso);
        }

        // Método para registrar el ingreso en la tabla Ingresos
        private void RegistrarIngreso(int idProveedor, decimal totalIngreso)
        {
            try
            {
                conection.Open();
                string queryIngresos = "INSERT INTO Ingresos (idproveedor, fechaingreso, valoringreso, idusuario, docsoporte) " +
                                        "OUTPUT INSERTED.idingreso VALUES (@idproveedor, @fechaingreso, @valoringreso, @idusuario, @docsoporte)";

                int idIngreso;  // Para capturar el idingreso generado automáticamente

                using (SqlCommand commandIngresos = new SqlCommand(queryIngresos, conection))
                {

                    commandIngresos.Parameters.AddWithValue("@idproveedor", int.Parse(tnitp.Text)); // tnitp es el ID del proveedor (NIT)
                    commandIngresos.Parameters.AddWithValue("@fechaingreso", dfechai.Value);  // Fecha de ingreso
                    commandIngresos.Parameters.AddWithValue("@valoringreso", Convert.ToInt32(totalIngreso));   // Total de ingreso convertido a entero
                    commandIngresos.Parameters.AddWithValue("@idusuario", idUsuario);         // ID del usuario
                    commandIngresos.Parameters.AddWithValue("@docsoporte", tdoci.Text);

                    // Ejecutar el comando y capturar el idingreso generado
                    idIngreso = (int)commandIngresos.ExecuteScalar();
                }

                // Registrar detalles en la tabla Det_Ingreso
                RegistrarDetalleIngreso(idIngreso);

                MessageBox.Show("Ingreso registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el ingreso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conection.Close();
            }
        }
        // Método para registrar los saldos en la tabla saldoproductos
        private void RegistrarSaldosProductos(int idIngreso)
        {
            foreach (DataGridViewRow row in dataingreso.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar filas nuevas

                // Obtener idProducto y cantidad de la fila
                string idProducto = row.Cells["codigo"].Value.ToString();
                int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);

                // Inserta los datos en la tabla saldoproductos
                string query = "INSERT INTO saldoproductos (idProducto, ingresos, salidas) VALUES (@idProducto, @ingresos, @salidas)";

                using (SqlConnection con = new SqlConnection(Class1.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    command.Parameters.AddWithValue("@ingresos", cantidad);
                    command.Parameters.AddWithValue("@salidas", 0); // Asumimos que en este contexto solo se registran ingresos

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }



        // Método para registrar los detalles del ingreso en la tabla Det_Ingreso
        private void RegistrarDetalleIngreso(int idIngreso)
        {
            try
            {
                foreach (DataGridViewRow row in dataingreso.Rows)
                {
                    if (row.IsNewRow) continue;

                    string idProducto = row.Cells["codigo"].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                    decimal valorund = Convert.ToDecimal(row.Cells["valor unitario"].Value);
                    decimal subtotal = Convert.ToDecimal(row.Cells["subtotal"].Value);

                    // Insertar detalle en Det_Ingreso
                    string queryDetalle = "INSERT INTO Det_Ingreso (idingreso, idproducto, cantidad, valorund, subtotal, idusuario) " +
                                          "VALUES (@idingreso, @idproducto, @cantidad, @valorund, @subtotal, @idusuario)";

                    using (SqlCommand commandDetalle = new SqlCommand(queryDetalle, conection))
                    {
                        commandDetalle.Parameters.AddWithValue("@idingreso", idIngreso);
                        commandDetalle.Parameters.AddWithValue("@idproducto", idProducto);
                        commandDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                        commandDetalle.Parameters.AddWithValue("@valorund", valorund);
                        commandDetalle.Parameters.AddWithValue("@subtotal", subtotal);
                        commandDetalle.Parameters.AddWithValue("@idusuario", idUsuario); // Asignar el ID del usuario

                        commandDetalle.ExecuteNonQuery();
                    }

                    // Actualizar la columna saldos en la tabla productos
                    string queryActualizarSaldo = "UPDATE Productos SET saldos = saldos + @cantidad WHERE idproducto = @idproducto";

                    using (SqlCommand commandActualizarSaldo = new SqlCommand(queryActualizarSaldo, conection))
                    {
                        commandActualizarSaldo.Parameters.AddWithValue("@cantidad", cantidad);
                        commandActualizarSaldo.Parameters.AddWithValue("@idproducto", idProducto);

                        commandActualizarSaldo.ExecuteNonQuery();
                    }
                }

                // Llama al método para registrar los saldos en Saldoproductos después de registrar los detalles de ingreso
                RegistrarSaldosProductos(idIngreso);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar los detalles del ingreso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataingreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataingreso.Columns["codigo"].Index)
            {
                DataGridViewRow row = dataingreso.Rows[e.RowIndex];
                string codigo = row.Cells["codigo"].Value?.ToString();

                // Verificar si el código es vacío
                if (!string.IsNullOrWhiteSpace(codigo) && codigo.Length < 3)
                {
                    return; // Salir si el código es vacío, no mostrar mensaje de error
                }

                // Intentar buscar el producto en la base de datos
                try
                {
                    string query = "SELECT idproducto, descripcion, valorund FROM Productos WHERE idproducto = @idproducto";
                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        command.Parameters.AddWithValue("@idproducto", codigo);
                        conection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            row.Cells["producto"].Value = reader["descripcion"] != DBNull.Value ? reader["descripcion"].ToString() : "Descripción no encontrada";
                            row.Cells["valor unitario"].Value = reader["valorund"] != DBNull.Value ? reader["valorund"].ToString() : "0";
                        }
                        else
                        {
                            MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conection.Close();
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataingreso.Columns["cantidad"].Index)
            {
                DataGridViewRow row = dataingreso.Rows[e.RowIndex];
                if (int.TryParse(row.Cells["cantidad"].Value?.ToString(), out int cantidad) &&
                    decimal.TryParse(row.Cells["valor unitario"].Value?.ToString(), out decimal valorUnitario))
                {
                    row.Cells["subtotal"].Value = cantidad * valorUnitario;
                }
                else
                {
                    MessageBox.Show("La cantidad y el valor unitario deben ser números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataingreso_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataingreso.IsCurrentCellDirty)
            {
                dataingreso.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        

        // Método para buscar el producto en la base de datos
        private void BuscarProducto(string codigo, int rowIndex)
        {
            try
            {
                string query = "SELECT descripcion, valorund FROM Productos WHERE idproducto = @codigo";
                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@codigo", codigo);
                    conection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Asignar valores a las columnas correspondientes
                        dataingreso.Rows[rowIndex].Cells["producto"].Value = reader["descripcion"].ToString();
                        dataingreso.Rows[rowIndex].Cells["valor unitario"].Value = Convert.ToDecimal(reader["valorund"]);
                        ActualizarSubtotal(rowIndex); // Actualizar el subtotal tras obtener el valor unitario
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conection.Close();
            }
        }

        // Método para actualizar el subtotal
        private void ActualizarSubtotal(int rowIndex)
        {
            if (dataingreso.Rows[rowIndex].Cells["cantidad"].Value != null && dataingreso.Rows[rowIndex].Cells["valor unitario"].Value != null)
            {
                int cantidad = Convert.ToInt32(dataingreso.Rows[rowIndex].Cells["cantidad"].Value);
                int valorUnitario = Convert.ToInt32(dataingreso.Rows[rowIndex].Cells["valor unitario"].Value); // Cambiar a int
                int subtotal = cantidad * valorUnitario; // Cambiar a int

                dataingreso.Rows[rowIndex].Cells["subtotal"].Value = subtotal; // Asegúrate de que esto sea un entero

                // Llama al método para calcular el total de la columna subtotal
                CalcularTotalIngreso();
            }
        }
        // Método para calcular el total de la columna "subtotal" como enteros
        private void CalcularTotalIngreso()
        {
            int totalIngreso = 0; // Cambiar a int

            // Recorre todas las filas del DataGridView y suma los valores de la columna "subtotal"
            foreach (DataGridViewRow row in dataingreso.Rows)
            {
                if (row.Cells["subtotal"].Value != null) // Asegúrate de que no sea nulo
                {
                    totalIngreso += Convert.ToInt32(row.Cells["subtotal"].Value); // Convertir a int
                }
            }

            // Muestra el total en el TextBox "totalingreso"
            totalingreso.Text = totalIngreso.ToString("C0"); // Sin formato decimal
        }
    }
}
     


