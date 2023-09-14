using System.ComponentModel.DataAnnotations;

namespace PRACTICA3.Modelos
{

    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int CI { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
