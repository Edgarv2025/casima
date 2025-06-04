using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casima.autenticacion
{
    public class classUsuario
    {
        // Propiedades que corresponden a los campos de la tabla Usuarios
        public int Id_usuario { get; set; }    // Documento o Id de usuario
        public string Nombre { get; set; }      // Nombre del usuario
        public string Apellido { get; set; }    // Apellido del usuario
        public string Cargo { get; set; }       // Cargo del usuario
        public int Id_rol { get; set; }         // Rol del usuario (opcional, dependiendo de tus necesidades)

        // Constructor vacío
        public classUsuario() { }

        // Constructor que permite inicializar todas las propiedades
        public classUsuario(int id_usuario, string nombre, string apellido, string cargo, int id_rol)
        {
            Id_usuario = id_usuario;
            Nombre = nombre;
            Apellido = apellido;
            Cargo = cargo;
            Id_rol = id_rol;
        }
    }
}

