using System;
using System.Data.SqlClient;

namespace casima
{
    internal class Class1
    {
        // Cadena de conexión para la base de datos
        public static string ConnectionString = @"Data Source=192.168.1.200\SOPORTE1;Initial Catalog=Casino;Persist Security Info=True;User ID=sa;Password=Snake1987@";

        // Método para probar la conexión a la base de datos
        public static bool TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Si la conexión es exitosa, se puede retornar true
                    return true;
                }
                catch (SqlException)
                {
                    // Si hay un error, se retorna false
                    return false;
                }
            }
        }
    }
}

