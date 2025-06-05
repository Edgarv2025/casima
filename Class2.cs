using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casima
{
    internal class Class2
    {
        // Cadena de conexión para la base de datos
        public static string ConnectionString = @"Data Source=192.168.1.200\SOPORTE1;Initial Catalog=Casino;Persist Security Info=True;User ID=sa;Password=Snake1987@";
        public static class UsuarioAutenticado
        {
            public static int IdUsuario { get; private set; }
            public static string NombreUsuario { get; private set; }

            // Método para autenticar al usuario
            public static void AutenticarUsuario(int idUsuario, string nombreUsuario)
            {
                IdUsuario = idUsuario;
                NombreUsuario = nombreUsuario;
            }

            // Método para verificar si el usuario está autenticado
            public static bool EstaAutenticado()
            {
                return IdUsuario > 0;
            }
        }
    }
}