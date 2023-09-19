using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRACTICA3.Modelos
{
    //CREACION DE LA CLASE VENTA

    public class Venta
    {
        //CREACION DE LAS PROPIEDADES DE LA CLASE VENTAN SUS RESPECTIVAS VALIDACIONES 

        public int VentaID { get; set; }
       
        public int ClienteID { get; set; } 
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double PrecioTotal { get; set; }
        public Cliente Clientes { get; set; }
        public List<Producto> Productos { get; set; }
        

    }
}
