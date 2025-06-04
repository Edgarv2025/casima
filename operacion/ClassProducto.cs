using System;

namespace casima.productos
{
    public class classProducto
    {
        // Propiedades que corresponden a los campos de la tabla Productos
        public int Idproducto { get; set; }        // Código o ID del producto
        public string Descripcion { get; set; }    // Descripción del producto
        public int Valorund { get; set; }      // Valor por unidad del producto
        public string Tipo { get; set; }           // Tipo de producto (e.g., tipo de categoría)
        public string Kardex { get; set; }           // Indica si el producto está registrado en kardex
        public string Estado { get; set; }         // Estado del producto (activo o inactivo, etc.)

        // Constructor vacío
        public classProducto() { }

        // Constructor que permite inicializar todas las propiedades
        public classProducto(int idproducto, string descripcion, int valorund, string tipo, string kardex, string estado)
        {
            Idproducto = idproducto;
            Descripcion = descripcion;
            Valorund = valorund;
            Tipo = tipo;
            Kardex = kardex;
            Estado = estado;
        }
    }
}

