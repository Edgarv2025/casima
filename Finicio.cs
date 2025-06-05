using casima.autenticacion;
using casima.configuracion;
using casima.informes;
using casima.operacion;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using static casima.Class2;

namespace casima
{
    public partial class Finicio : Form

    {
        // Definir la conexión a la base de datos
        SqlConnection conection = new SqlConnection(Class1.ConnectionString);

        private int id_rol;
        private int userId;  // Variable para almacenar el ID del usuario

        // Constructor que acepta un parámetro id_rol y userId
        public Finicio(int rol, int userId)
        {
            InitializeComponent();
            id_rol = rol;
            this.userId = userId;  // Asignar el userId


        }

        private void Frmmenu_Load(object sender, EventArgs e)
        {
            // Llamar al método que obtiene y aplica los permisos de rol
            ObtenerPermisosRol();
        }

        // Método para obtener los permisos del rol desde la base de datos
        private void ObtenerPermisosRol()
        {
            try
            {
                // Conectar a la base de datos usando la cadena de conexión de Class1
                using (SqlConnection connection = new SqlConnection(Class1.ConnectionString))
                {
                    connection.Open();

                    // Consultar los permisos del rol basado en el id_rol
                    string query = "SELECT ventas, inventario, informes, cierre, config FROM Roles WHERE id_rol = @id_rol";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_rol", id_rol);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Obtener los valores de los permisos desde la base de datos
                            string ventas = reader["ventas"].ToString();
                            string inventario = reader["inventario"].ToString();
                            string informes = reader["informes"].ToString();
                            string cierre = reader["cierre"].ToString();
                            string config = reader["config"].ToString();

                            // Aplicar la visibilidad de los botones según los permisos
                            bventas.Visible = (ventas == "si");
                            bingresos.Visible = (inventario == "si");
                            bproveed.Visible = (inventario == "si");
                            bclientes.Visible = (inventario == "si");
                            binfor.Visible = (informes == "si");
                            bcierre.Visible = (cierre == "si");

                            // Condición especial para el permiso de configuración
                            if (config == "si")
                            {
                                bproductos.Visible = true;
                                bgestcajas.Visible = true;
                                bdatosemp.Visible = true;
                                bgestUser.Visible = true;
                            }
                            else
                            {
                                bproductos.Visible = false;
                                bgestcajas.Visible = false;
                                bdatosemp.Visible = false;
                                bgestUser.Visible = false;
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los permisos del rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Métodos para abrir otros formularios o manejar eventos
        private void bproductos_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fproductos)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fproductos productosForm = new Fproductos();
                productosForm.Show();
            }
        }

        private void bproveed_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fproveedor)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fproveedor proveedorForm = new Fproveedor();
                proveedorForm.Show();
            }
        }

        private void bclientes_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fcliente)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fcliente clienteForm = new Fcliente();
                clienteForm.Show();
            }
        }

        private void bingresos_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fingreso)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                // Pasar el userId al constructor de Fingreso
                Fingreso ingresoForm = new Fingreso(userId);
                ingresoForm.Show();
            }
        }

        private void bventas_Click(object sender, EventArgs e)
        {
            // Deshabilitar temporalmente el botón para evitar múltiples clics
            bventas.Enabled = false;

            try
            {
                // Verificar si hay una caja registrada y que su fecha de cierre no sea la misma que la fecha actual
                if (!CajaDisponible())
                {
                    MessageBox.Show("No hay caja disponible para hoy o ya ha sido cerrada. No es posible el ingreso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;  // Detener la ejecución si no hay caja o está cerrada
                }

                // Verificar si el formulario Fventa ya está abierto
                bool isOpen = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Fventa)
                    {
                        isOpen = true;
                        form.BringToFront();  // Traer el formulario al frente si ya está abierto
                        break;
                    }
                }

                // Abrir el formulario si no está abierto
                if (!isOpen)
                {
                    Fventa ventaForm = new Fventa(userId);  // Pasar el userId al constructor
                    ventaForm.Show();
                }
            }
            finally
            {
                // Rehabilitar el botón para que el usuario pueda intentar nuevamente
                bventas.Enabled = true;
            }
        }

        // Método para verificar si la caja está disponible para hoy
        private bool CajaDisponible()
        {
            try
            {
                string nombreEquipo = System.Environment.MachineName;
                string query = "SELECT fecha_cierre FROM cajas WHERE nombreequipo = @nombreequipo";

                using (SqlCommand command = new SqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@nombreequipo", nombreEquipo);
                    conection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        DateTime fechaCierre = Convert.ToDateTime(result);
                        DateTime fechaActual = DateTime.Today;

                        // Retornar false si la fecha de cierre es igual a la fecha actual
                        return fechaCierre.Date != fechaActual.Date;
                    }
                    else
                    {
                        // Si no hay registro de caja, la función retorna false para indicar que no está disponible
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;  // Si hay un error, retornar false
            }
            finally
            {
                conection.Close();
            }
        }


        private void bcajas_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fcajas)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fcajas cajasForm = new Fcajas();
                cajasForm.Show();
            }
        }

        private void bdatosemp_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fempresa)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fempresa empresaForm = new Fempresa();
                empresaForm.Show();
            }
        }

        private void bgestUser_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fgestionuser)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Fgestionuser gestionuserForm = new Fgestionuser();
                gestionuserForm.Show();
            }
        }

        private void bcierre_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Fcierrecajas)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {

                // Asegúrate de tener `userId` aquí
                string userId = this.userId.ToString(); // Usar el userId almacenado en el formulario
                Fcierrecajas cierrecajasForm = new Fcierrecajas(userId);
                cierrecajasForm.Show();
            }
        }

        private void binfor_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form is Finforme)
                {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }

            if (!isOpen)
            {
                Finforme informeForm = new Finforme();
                informeForm.Show();
            }
        }

        // Variable de control para evitar múltiples confirmaciones
        private bool confirmacionCierre = false;

        private void Finicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si la confirmación ya se ha hecho, no preguntar de nuevo
            if (confirmacionCierre)
            {
                return; // Permitir que el formulario se cierre sin preguntar
            }

            // Pregunta al usuario si realmente quiere salir
            DialogResult resultado = MessageBox.Show("¿va ha salir del sistema, esta seguro?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario selecciona "Sí", cierra la aplicación
            if (resultado == DialogResult.Yes)
            {
                confirmacionCierre = true; // Marcar que ya se ha confirmado
                Application.Exit(); // Cierra la aplicación
            }
            else
            {
                e.Cancel = true; // Cancela el cierre del formulario
            }
        }

    }
}
