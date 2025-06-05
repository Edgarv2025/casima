using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace casima
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
 
           /* bool isConnected = Class1.TestConnection();

            if (isConnected)
            {
                MessageBox.Show("Conexión correcta.", "Estado de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else
            {
                MessageBox.Show("Error de conexión.", "Estado de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Facceso());
        }
    }
}
