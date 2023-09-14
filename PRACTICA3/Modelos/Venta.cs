using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRACTICA3.Modelos
{
    //public class Venta
    //{
    //    [Required]
    //    public int ID { get; set; }
    //    [Required]
    //    [ForeignKey("Cliente")]
    //    public int IDCliente { get; set; }
    //    [Required]
    //    [ForeignKey("Producto")]
    //    public int IDProducto { get; set; }
    //    [Required]
    //    public double PrecioTotal { get; set; }
        
    //    public Cliente Clientes  { get; set; }
    //   // public Producto Productos  { get; set; }
    //    public List<Producto> Productos { get; set; }
    //}
    public class Venta
    {
        public int VentaID { get; set; }
       
        public int ClienteID { get; set; } 
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double PrecioTotal { get; set; }
        public Cliente Clientes { get; set; }
        public List<Producto> Productos { get; set; }
        

    }
}
