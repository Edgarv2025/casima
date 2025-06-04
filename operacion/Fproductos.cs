using casima.productos;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima
{
    public partial class Fproductos : Form
    {
        SqlConnection connection = new SqlConnection(Class1.ConnectionString);

        public Fproductos()
        {
            InitializeComponent();
            // Asigna el evento TextChanged al TextBox tdesproducto para forzar mayúsculas
            tdesproducto.TextChanged += Tdesproducto_TextChanged;
        }

        private void Tdesproducto_TextChanged(object sender, EventArgs e)
        {
            // Convierte el texto a mayúsculas
            tdesproducto.Text = tdesproducto.Text.ToUpper();
            // Mueve el cursor al final del texto para evitar problemas de edición
            tdesproducto.SelectionStart = tdesproducto.Text.Length;
        }

        private void Fproductos_Load(object sender, EventArgs e)
        {
            // Cargar valores para los ComboBox si es necesario
        }

        private void pproductos_Click(object sender, EventArgs e)
        {
            // Obtener valores de los controles
            string descripcionProducto = tdesproducto.Text.Trim();
            string tipoProducto = ctipo.SelectedItem?.ToString();

            // Cambiar el manejo del estado y kardex
            string estadoProducto = "activo"; // Siempre "activo"
            string kardex = (tipoProducto.Equals("inventario", StringComparison.OrdinalIgnoreCase)) ? "si" : "no";

            // Validar que no haya campos vacíos
            if (string.IsNullOrEmpty(descripcionProducto) || string.IsNullOrEmpty(tipoProducto))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar valor unitario
            if (!int.TryParse(tvaloruntp.Text.Trim(), out int valorUnitario))
            {
                MessageBox.Show("Por favor, ingrese un valor unitario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insertar el producto
            RegistrarProducto(descripcionProducto, valorUnitario, tipoProducto, kardex, estadoProducto);
        }

        private void RegistrarProducto(string descripcion, int valorUnitario, string tipo, string kardex, string estado)
        {
            try
            {
                connection.Open();

                // Verificar si ya existe el producto
                string checkQuery = "SELECT COUNT(*) FROM Productos WHERE descripcion = @descripcion";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@descripcion", descripcion);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe un producto con esta descripción. Ingrese una descripción diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Insertar producto en la tabla Productos con saldo inicial 0
                string query = "INSERT INTO Productos (descripcion, valorund, tipo, kardex, estado, saldos) VALUES (@descripcion, @valorund, @tipo, @kardex, @estado, 0)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@valorund", valorUnitario);
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.Parameters.AddWithValue("@kardex", kardex);
                    command.Parameters.AddWithValue("@estado", estado);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Producto registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                
                Fproductos nuevoproducto = new Fproductos();
                nuevoproducto.Show();

               this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void bveredit_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fverproductos)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fverproductos verproductosForm = new Fverproductos();
                verproductosForm.Show();
                this.Close();
            }
        }
    }
}


