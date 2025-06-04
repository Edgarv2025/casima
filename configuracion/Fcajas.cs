using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace casima.configuracion
{
    public partial class Fcajas : Form
    {
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);

        public Fcajas()
        {
            InitializeComponent();
            datacierre.Value = DateTime.Now;
        }

        private void pcrearcaja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tnombrecaja.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreEquipo = tnombrecaja.Text.Trim();
            DateTime fechaCierre = datacierre.Value;

            if (CajaExiste(nombreEquipo))
            {
                MessageBox.Show("El nombre de la caja ya existe. Por favor, ingrese un nombre diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegistrarCaja(nombreEquipo, fechaCierre);
        }

        private bool CajaExiste(string nombreEquipo)
        {
            bool existe = false;
            try
            {
                string query = "SELECT COUNT(*) FROM cajas WHERE nombreequipo = @nombreequipo";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nombreequipo", nombreEquipo);
                    conection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        existe = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al verificar la existencia de la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conection.Close();
            }

            return existe;
        }

        private void RegistrarCaja(string nombreEquipo, DateTime fechaCierre)
        {
            try
            {
                string query = "INSERT INTO cajas (nombreequipo, fecha_cierre) VALUES (@nombreequipo, @fecha_cierre)";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nombreequipo", nombreEquipo);
                    command.Parameters.AddWithValue("@fecha_cierre", fechaCierre);

                    conection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Caja creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conection.Close();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conection.State == System.Data.ConnectionState.Open)
                {
                    conection.Close();
                }
            }
        }

        private void LimpiarFormulario()
        {
            tnombrecaja.Clear();
            datacierre.Value = DateTime.Now;
        }

        private void bvercajas_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT idcaja, nombreequipo, fecha_cierre FROM cajas";
                SqlDataAdapter da = new SqlDataAdapter(query, conection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datavercajas.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las cajas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar la caja seleccionada en el DataGridView
        private void beliminar_Click(object sender, EventArgs e)
        {
            if (datavercajas.SelectedRows.Count > 0)
            {
                // Obtener el idcaja de la fila seleccionada
                int idCaja = Convert.ToInt32(datavercajas.SelectedRows[0].Cells["idcaja"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la caja seleccionada?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    EliminarCaja(idCaja);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una caja para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para eliminar la caja de la base de datos
        private void EliminarCaja(int idCaja)
        {
            try
            {
                string query = "DELETE FROM cajas WHERE idcaja = @idcaja";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@idcaja", idCaja);
                    conection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Caja eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bvercajas_Click(null, null);  // Actualizar el DataGridView después de la eliminación
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la caja. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conection.Close();
            }
        }

        private void btseguridad_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fseguridad)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fseguridad FseguridadForm = new Fseguridad();
                FseguridadForm.Show();
                this.Close();
            }
        }
    }
}


