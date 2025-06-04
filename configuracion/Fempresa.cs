using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace casima.configuracion
{
    public partial class Fempresa : Form
    {
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);

        public Fempresa()
        {
            InitializeComponent();
            datalistaemp.SelectionChanged += Datalistaemp_SelectionChanged; // Manejar la selección de filas
        }

        // Evento para abrir un diálogo de selección de imagen al hacer clic en el PictureBox 'plogo'
        private void plogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cargar la imagen seleccionada en el PictureBox
                    plogo.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        // Evento que se dispara cuando se hace clic en el botón 'pcrearemp' para crear la empresa
        private void pcrearemp_Click(object sender, EventArgs e)
        {
            // Validar que los campos de entrada no estén vacíos
            if (string.IsNullOrEmpty(tnite.Text.Trim()) || string.IsNullOrEmpty(trazon.Text.Trim()) || string.IsNullOrEmpty(tadress.Text.Trim()) || plogo.Image == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios y seleccione una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el NIT sea numérico y de máximo 10 dígitos
            if (!int.TryParse(tnite.Text.Trim(), out int nit) || tnite.Text.Length > 10)
            {
                MessageBox.Show("El NIT debe ser un número válido de hasta 10 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convertir la imagen del PictureBox a un arreglo de bytes
            byte[] logoBytes = ImageToByteArray(plogo.Image);

            // Llamar al método para insertar los datos en la base de datos
            RegistrarEmpresa(nit, trazon.Text.Trim(), tadress.Text.Trim(), logoBytes);
        }

        // Método para insertar la empresa en la base de datos
        private void RegistrarEmpresa(int nit, string razonSocial, string direccion, byte[] logo)
        {
            try
            {
                // Primero, verificar si el NIT ya existe en la base de datos
                if (NitExiste(nit))
                {
                    MessageBox.Show("El NIT ya está registrado. Por favor, use un NIT diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = "INSERT INTO empresa (nit, razonsocial, direccion, logo) VALUES (@nit, @razonsocial, @direccion, @logo)";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nit", nit);                        // NIT capturado
                    command.Parameters.AddWithValue("@razonsocial", razonSocial);         // Razón Social capturada
                    command.Parameters.AddWithValue("@direccion", direccion);             // Dirección capturada
                    command.Parameters.AddWithValue("@logo", logo);                      // Logo convertido a byte[]

                    conection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Empresa creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conection.Close();

                    // Limpiar los campos
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conection.State == System.Data.ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }

        // Método para verificar si el NIT ya existe en la base de datos
        private bool NitExiste(int nit)
        {
            string query = "SELECT COUNT(*) FROM empresa WHERE nit = @nit";

            using (SqlCommand command = new SqlCommand(query, conection))
            {
                command.Parameters.AddWithValue("@nit", nit);

                conection.Open();
                int count = (int)command.ExecuteScalar(); // Contar cuántos registros tienen ese NIT
                conection.Close();

                return count > 0; // Devuelve true si el NIT ya existe
            }
        }

        // Método para convertir la imagen a un arreglo de bytes
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        // Método para limpiar los campos del formulario después de registrar la empresa
        private void LimpiarFormulario()
        {
            tnite.Clear();
            trazon.Clear();
            tadress.Clear();
            plogo.Image = null;
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            // Llamar al método para cargar los datos de la tabla 'empresa'
            CargarDatosEmpresa();
        }

        // Método para cargar datos de la tabla 'empresa' en el DataGridView
        private void CargarDatosEmpresa()
        {
            try
            {
                string query = "SELECT nit, razonsocial, direccion FROM empresa"; // Ajusta los campos según tu tabla
                SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
                DataTable dataTable = new DataTable();

                // Llenar el DataTable con los datos de la consulta
                adapter.Fill(dataTable);

                // Asignar el DataTable al DataGridView
                datalistaemp.DataSource = dataTable;

                // Ajustar el tamaño de las columnas para que se ajuste al contenido
                datalistaemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para manejar la selección de filas en el DataGridView
        private void Datalistaemp_SelectionChanged(object sender, EventArgs e)
        {
            if (datalistaemp.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = datalistaemp.SelectedRows[0];

                // Llenar los TextBox con los datos de la fila seleccionada
                tnite.Text = row.Cells["nit"].Value.ToString();
                trazon.Text = row.Cells["razonsocial"].Value.ToString();
                tadress.Text = row.Cells["direccion"].Value.ToString();

                // Habilitar los botones de editar y eliminar
                Editar.Enabled = true;
                Eliminar.Enabled = true;
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(tnite.Text.Trim()) || string.IsNullOrEmpty(trazon.Text.Trim()) || string.IsNullOrEmpty(tadress.Text.Trim()))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el NIT sea numérico y de máximo 10 dígitos
            if (!int.TryParse(tnite.Text.Trim(), out int nit) || tnite.Text.Length > 10)
            {
                MessageBox.Show("El NIT debe ser un número válido de hasta 10 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método para actualizar los datos en la base de datos
            ActualizarEmpresa(nit, trazon.Text.Trim(), tadress.Text.Trim());
        }

        private void ActualizarEmpresa(int nit, string razonSocial, string direccion)
        {
            try
            {
                string query = "UPDATE empresa SET razonsocial = @razonsocial, direccion = @direccion WHERE nit = @nit";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nit", nit);                        // NIT capturado
                    command.Parameters.AddWithValue("@razonsocial", razonSocial);         // Razón Social capturada
                    command.Parameters.AddWithValue("@direccion", direccion);             // Dirección capturada

                    conection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Empresa actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conection.Close();

                    // Limpiar los campos
                    LimpiarFormulario();
                    CargarDatosEmpresa(); // Recargar los datos en el DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conection.State == System.Data.ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una empresa
            if (datalistaemp.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una empresa para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmar eliminación
            if (MessageBox.Show("¿Está seguro de que desea eliminar esta empresa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Obtener el NIT de la fila seleccionada
                int nit = int.Parse(datalistaemp.SelectedRows[0].Cells["nit"].Value.ToString());
                EliminarEmpresa(nit);
            }
        }

        private void EliminarEmpresa(int nit)
        {
            try
            {
                string query = "DELETE FROM empresa WHERE nit = @nit";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nit", nit);
                    conection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Empresa eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conection.Close();

                    // Limpiar los campos
                    LimpiarFormulario();
                    CargarDatosEmpresa(); // Recargar los datos en el DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar la empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conection.State == System.Data.ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }
    }
}
