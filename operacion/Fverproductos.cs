using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima.productos
{
    public partial class Fverproductos : Form
    {
        private SqlConnection _connection = new SqlConnection(Class1.ConnectionString);
        private List<classProducto> _productos;

        public Fverproductos()
        {
            InitializeComponent();
            datalistaproductos.ReadOnly = true;
        }

        private void Fverproductos_Load(object sender, EventArgs e)
        {
            CargarProductos(); // Cargar todos los productos al cargar el formulario
        }

        // Método para cargar todos los productos
        private void CargarProductos()
        {
            _productos = new List<classProducto>();
            string query = "SELECT Idproducto, Descripcion, Valorund, Tipo, Kardex, Estado FROM Productos";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Convertir cada campo con los tipos adecuados
                        _productos.Add(new classProducto
                        {
                            Idproducto = Convert.ToInt32(reader["Idproducto"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Valorund = Convert.ToInt32(reader["Valorund"]),
                            Tipo = reader["Tipo"].ToString(),
                            Kardex = reader["Kardex"].ToString(),
                            Estado = reader["Estado"].ToString(),

                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el producto: " + ex.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }

            // Vincular la lista de productos al DataGridView
            datalistaproductos.DataSource = null;
            datalistaproductos.DataSource = _productos;

            // Mostrar los nombres correctos en las columnas
            datalistaproductos.Columns["Idproducto"].HeaderText = "ID Producto";
            datalistaproductos.Columns["Descripcion"].HeaderText = "Descripción";
            datalistaproductos.Columns["Valorund"].HeaderText = "Valor Unitario";
            datalistaproductos.Columns["Tipo"].HeaderText = "Tipo";
            datalistaproductos.Columns["Kardex"].HeaderText = "Kardex";
            datalistaproductos.Columns["Estado"].HeaderText = "Estado";

            // Formatear Idproducto para que siempre aparezca con 3 dígitos en el DataGridView
            datalistaproductos.CellFormatting += (s, e) =>
            {
                if (datalistaproductos.Columns[e.ColumnIndex].Name == "Idproducto" && e.Value is int)
                {
                    e.Value = ((int)e.Value).ToString("D3");  // Convertir a formato de 3 dígitos
                    e.FormattingApplied = true;
                }
            };
        }

        // Método para buscar un producto por su Idproducto y llenar los TextBoxes
        private void BuscarProductoPorId(int idProducto)
        {
            string query = "SELECT Idproducto, Descripcion, Valorund, Tipo, Kardex, Estado FROM Productos WHERE Idproducto = @Idproducto";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Idproducto", idProducto);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Llenar los controles con la información del producto encontrado
                        txtcodigo.Text = reader["Idproducto"].ToString();
                        txtproducto.Text = reader["Descripcion"].ToString();
                        txtvalor.Text = reader["Valorund"].ToString();
                        ctipo.SelectedItem = reader["Tipo"].ToString();
                        ckardex.Checked = reader["Kardex"].ToString() == "Sí";
                        cestado.SelectedItem = reader["Estado"].ToString();

                        // Filtrar el DataGridView para mostrar solo el producto encontrado
                        List<classProducto> productosFiltrados = new List<classProducto>
                        {
                            new classProducto
                            {
                                Idproducto = Convert.ToInt32(reader["Idproducto"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                Valorund = Convert.ToInt32(reader["Valorund"]),
                                Tipo = reader["Tipo"].ToString(),
                                Kardex = reader["Kardex"].ToString(),
                                Estado = reader["Estado"].ToString()
                            }
                        };

                        datalistaproductos.DataSource = null;
                        datalistaproductos.DataSource = productosFiltrados;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún producto con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el producto: " + ex.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        // Evento del botón buscar por ID
        private void bbuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtcodigo.Text.Trim(), out int idProducto))
            {
                BuscarProductoPorId(idProducto);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón mostrar todos los productos
        private void bmtodos_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        // Método para cargar un producto por su Idproducto
        private void CargarProductoPorId(int idProducto)
        {
            string query = "SELECT Idproducto, Descripcion, Valorund, Tipo, Kardex, Estado FROM Productos WHERE Idproducto = @Idproducto";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@Idproducto", idProducto);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtcodigo.Text = reader["Idproducto"].ToString();
                        txtproducto.Text = reader["Descripcion"].ToString();
                        txtvalor.Text = reader["Valorund"].ToString();
                        ctipo.SelectedItem = reader["Tipo"].ToString();
                        ckardex.Checked = reader["Kardex"].ToString() == "Sí";
                        cestado.SelectedItem = reader["Estado"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún producto con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el producto: " + ex.Message);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        // Evento del botón bmid para cargar un producto por ID y mostrar en el DataGridView
        private void bmid_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtcodigo.Text.Trim(), out int idProducto))
            {
                CargarProductoPorId(idProducto); // Cargar los datos en los TextBoxes
                BuscarProductoPorId(idProducto); // Filtrar el DataGridView para mostrar solo el producto
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para editar un producto
        private void EditarProducto()
        {
            if (datalistaproductos.CurrentRow != null)
            {
                int idProducto = ((classProducto)datalistaproductos.CurrentRow.DataBoundItem).Idproducto;
                string descripcion = txtproducto.Text.Trim();
                int valorund;

                if (!int.TryParse(txtvalor.Text.Trim(), out valorund))
                {
                    MessageBox.Show("Por favor, ingrese un valor válido para el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tipo = ctipo.SelectedItem.ToString();
                string kardex = ckardex.Checked ? "Sí" : "No";
                string estado = cestado.SelectedItem != null ? cestado.SelectedItem.ToString() : string.Empty;

                if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(estado))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string updateQuery = "UPDATE Productos SET Descripcion = @Descripcion, Valorund = @Valorund, Tipo = @Tipo, Kardex = @Kardex, Estado = @Estado WHERE Idproducto = @Idproducto";

                using (SqlCommand command = new SqlCommand(updateQuery, _connection))
                {
                    command.Parameters.AddWithValue("@Idproducto", idProducto);
                    command.Parameters.AddWithValue("@Descripcion", descripcion);
                    command.Parameters.AddWithValue("@Valorund", valorund);
                    command.Parameters.AddWithValue("@Tipo", tipo);
                    command.Parameters.AddWithValue("@Kardex", kardex);
                    command.Parameters.AddWithValue("@Estado", estado);

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar el producto: " + ex.Message);
                    }
                    finally
                    {
                        _connection.Close();
                        LimpiarCampos();
                        CargarProductos(); // Recargar la lista de productos
                    }
                }
            }
        }

        // Método para eliminar un producto
        private void EliminarProducto()
        {
            if (datalistaproductos.CurrentRow != null)
            {
                int idProducto = ((classProducto)datalistaproductos.CurrentRow.DataBoundItem).Idproducto;

                string deleteQuery = "DELETE FROM Productos WHERE Idproducto = @Idproducto";

                using (SqlCommand command = new SqlCommand(deleteQuery, _connection))
                {
                    command.Parameters.AddWithValue("@Idproducto", idProducto);

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                    }
                    finally
                    {
                        _connection.Close();
                        LimpiarCampos();
                        CargarProductos(); // Recargar la lista de productos
                    }
                }
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            txtcodigo.Clear();
            txtproducto.Clear();
            txtvalor.Clear();
            ctipo.SelectedIndex = -1;
            ckardex.Checked = false;
            cestado.SelectedIndex = -1;
        }

        // Evento del botón editar
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            EditarProducto();
        }

        // Evento del botón eliminar
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
        }

        // Evento del DataGridView para seleccionar un producto
        private void datalistaproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datalistaproductos.CurrentRow != null)
            {
                classProducto productoSeleccionado = (classProducto)datalistaproductos.CurrentRow.DataBoundItem;
                txtcodigo.Text = productoSeleccionado.Idproducto.ToString();
                txtproducto.Text = productoSeleccionado.Descripcion;
                txtvalor.Text = productoSeleccionado.Valorund.ToString();
                ctipo.SelectedItem = productoSeleccionado.Tipo;
                ckardex.Checked = productoSeleccionado.Kardex == "Sí";
                cestado.SelectedItem = productoSeleccionado.Estado;
            }
        }
    }
}
