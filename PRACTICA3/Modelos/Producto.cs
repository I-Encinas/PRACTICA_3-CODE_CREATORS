using System.ComponentModel.DataAnnotations;

namespace PRACTICA3.Modelos
{

    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public double PrecioU { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
