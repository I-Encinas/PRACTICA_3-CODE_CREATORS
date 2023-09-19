using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRACTICA3.Modelos
{
    //CREACION DE L CLASE PRODUCTO

    public class Producto
    {
        //CREACION DE LAS PROPIEDADES DE LA CLASE PRODUCTO CON SUS RESPECTIVAS VALIDACIONES 

        public int ProductoID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El NOMBRE debe tener una cantidad minima de 3 caracteres.")]
        [RegularExpression(@"^[A-Z\s]*$", ErrorMessage = "Debe ingresar los datos en mayusculas.")]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "float")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El PRECIO debe ser mayor que cero.")]
        public double PrecioU { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
