namespace casima.roles
{
    public class Classrooles
    {
        // Propiedades que corresponden a los campos de la tabla Roles
        public int Id_rol { get; set; }
        public string Nombre { get; set; }
        public string Ventas { get; set; }
        public string Inventario { get; set; }
        public string Informes { get; set; }
        public string Cierre { get; set; }
        public string Config { get; set; }

        // Constructor vacío
        public Classrooles() { }

        // Constructor que permite inicializar todas las propiedades
        public Classrooles(int id_rol, string nombre, string ventas, string inventario, string informes, string cierre, string config)
        {
            Id_rol = id_rol;
            Nombre = nombre;
            Ventas = ventas;
            Inventario = inventario;
            Informes = informes;
            Cierre = cierre;
            Config = config;
        }
    }
}

