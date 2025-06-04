using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace casima
{
    public partial class FRegistro : Form
    {
        // Diccionario para almacenar los roles (id_rol, nombre)
        private Dictionary<int, string> rolesDict = new Dictionary<int, string>();

        public FRegistro()
        {
            InitializeComponent();

            // Asignar manejadores de eventos para los TextBox
            Tdocumento.KeyPress += new KeyPressEventHandler(Tdocumento_KeyPress);
            Tpassword.Enter += new EventHandler(Tpassword_Enter);
            Tpassword.Leave += new EventHandler(Tpassword_Leave);
            Tnombres.KeyPress += new KeyPressEventHandler(OnlyUppercaseLetters_KeyPress);
            Tapellidos.KeyPress += new KeyPressEventHandler(OnlyUppercaseLetters_KeyPress);
            Tcargo.KeyPress += new KeyPressEventHandler(OnlyUppercaseLetters_KeyPress);

            // Asignar el evento KeyDown para manejar la tecla Enter en los TextBox
            Tdocumento.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            Tnombres.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            Tapellidos.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            Tcargo.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            Tpassword.KeyDown += new KeyEventHandler(TextBox_KeyDown);

            // Mostrar el placeholder inicial en Tpassword
            MostrarPlaceholderPassword();
        }

        // Método para permitir solo letras mayúsculas en Tnombres, Tapellidos, y Tcargo
        private void OnlyUppercaseLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es letra, control o espacio
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar); // Convertir a mayúsculas
            }
            else
            {
                e.Handled = true; // Bloquear caracteres no permitidos
                MessageBox.Show("Solo se permiten letras en mayúsculas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Evento para solo permitir números en el TextBox Tdocumento
        private void Tdocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Comprobar si el carácter presionado es un número o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evitar que el carácter no numérico sea ingresado

                // Mostrar mensaje de advertencia
                MessageBox.Show("Solo se admiten números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Evento para pasar al siguiente control al presionar Enter
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el sonido de "ding" al presionar Enter
                this.SelectNextControl((Control)sender, true, true, true, true); // Mueve al siguiente control en el orden de tabulación
            }
        }

        // Evento que se ejecuta al cargar el formulario
        private void FRegistro_Load(object sender, EventArgs e)
        {
            CargarRoles(); // Llamar al método que carga los roles en el ComboBox cbroll
        }

        // Método para cargar los roles en el ComboBox cbroll
        private void CargarRoles()
        {
            try
            {
                // Usamos la conexión de Class1 para conectarnos a la base de datos
                using (SqlConnection conection = new SqlConnection(Class1.ConnectionString))
                {
                    conection.Open();

                    // Consulta SQL para obtener los id_rol y nombres de los roles
                    string query = "SELECT id_rol, nombre FROM Roles";

                    // Crear un comando SQL
                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        // Ejecutar la consulta y obtener un SqlDataReader
                        SqlDataReader reader = command.ExecuteReader();

                        // Limpiar cualquier ítem anterior del ComboBox cbroll
                        cbroll.Items.Clear();
                        rolesDict.Clear(); // Limpiar el diccionario de roles

                        // Leer los resultados y agregar los nombres al ComboBox cbroll
                        while (reader.Read())
                        {
                            int idRol = (int)reader["id_rol"];
                            string nombreRol = reader["nombre"].ToString();

                            // Añadir el rol al diccionario
                            rolesDict.Add(idRol, nombreRol);

                            // Agregar el nombre al ComboBox
                            cbroll.Items.Add(nombreRol);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message);
            }
        }

        // Método para obtener el id_rol correspondiente al rol seleccionado
        private int ObtenerIdRolSeleccionado()
        {
            if (cbroll.SelectedItem == null)
            {
                return -1; // No se ha seleccionado ningún rol
            }

            string nombreRolSeleccionado = cbroll.SelectedItem.ToString();

            // Buscar el id_rol correspondiente al nombre seleccionado en el diccionario
            if (rolesDict.ContainsValue(nombreRolSeleccionado))
            {
                return rolesDict.FirstOrDefault(r => r.Value == nombreRolSeleccionado).Key;
            }

            return -1; // Retornar -1 si no se encuentra el rol
        }

        // Método para encriptar la contraseña
        private string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Evento click del botón Guardar
        private void Guardar1_Click_1(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string documento = Tdocumento.Text.Trim();
            string nombre = Tnombres.Text.Trim();
            string apellidos = Tapellidos.Text.Trim();
            string cargo = Tcargo.Text.Trim();
            string contraseña = Tpassword.Text.Trim();

            // Validar que no haya campos vacíos
            if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(cargo) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar la contraseña (mínimo 6 caracteres y al menos una mayúscula)
            if (contraseña.Length < 6 || !contraseña.Any(char.IsUpper) || !contraseña.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres, una mayúscula y un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Encriptar la contraseña
            string contraseñaEncriptada = EncriptarContraseña(contraseña);

            // Insertar el usuario en la base de datos
            InsertarUsuario(documento, nombre, apellidos, cargo, contraseñaEncriptada);
        }

        // Método para insertar el usuario en la base de datos
        private void InsertarUsuario(string documento, string nombre, string apellidos, string cargo, string contraseñaEncriptada)
        {
            int idRolSeleccionado = ObtenerIdRolSeleccionado();
            if (idRolSeleccionado == -1)
            {
                MessageBox.Show("Error: No se ha seleccionado un rol válido.");
                return;
            }

            try
            {
                // Usamos la conexión de Class1 para conectarnos a la base de datos
                using (SqlConnection conection = new SqlConnection(Class1.ConnectionString))
                {
                    conection.Open();

                    // Consulta SQL para insertar los datos en la tabla Usuarios
                    string query = "INSERT INTO Usuarios (Id_usuario, nombre, apellidos, cargo, id_rol, contraseña) VALUES (@Id_usuario, @nombre, @apellidos, @cargo, @id_rol, @contraseña)";

                    using (SqlCommand command = new SqlCommand(query, conection))
                    {
                        // Pasar los parámetros a la consulta
                        command.Parameters.AddWithValue("@Id_usuario", documento);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellidos", apellidos);
                        command.Parameters.AddWithValue("@cargo", cargo);
                        command.Parameters.AddWithValue("@id_rol", idRolSeleccionado);
                        command.Parameters.AddWithValue("@contraseña", contraseñaEncriptada);

                        // Ejecutar el comando y verificar si se insertó algún registro
                        int resultado = command.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cerrar el formulario actual
                            this.Close();

                            // Abrir el formulario FAcceso
                            Facceso accesoForm = new Facceso();
                            accesoForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error al crear el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para mostrar el texto de ayuda en el TextBox Tpassword
        private void MostrarPlaceholderPassword()
        {
            if (string.IsNullOrWhiteSpace(Tpassword.Text))
            {
                Tpassword.Text = "mínimo 6 caracteres, 1 mayúscula y 1 número";
                Tpassword.ForeColor = System.Drawing.Color.Gray; // Cambiar color a gris para simular un placeholder
                Tpassword.UseSystemPasswordChar = false; // Mostrar el texto como texto normal
            }
        }

        // Evento que se ejecuta cuando el TextBox Tpassword recibe el foco
        private void Tpassword_Enter(object sender, EventArgs e)
        {
            if (Tpassword.Text == "mínimo 6 caracteres, 1 mayúscula y 1 número")
            {
                Tpassword.Text = ""; // Limpiar el placeholder
                Tpassword.ForeColor = System.Drawing.Color.Black; // Cambiar el color a negro para el texto normal
                Tpassword.UseSystemPasswordChar = true; // Ocultar el texto como contraseña
            }
        }

        // Evento que se ejecuta cuando el TextBox Tpassword pierde el foco
        private void Tpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tpassword.Text))
            {
                MostrarPlaceholderPassword(); // Mostrar el placeholder si está vacío
            }
        }
    }
}



