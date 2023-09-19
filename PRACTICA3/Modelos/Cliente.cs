using System.ComponentModel.DataAnnotations;

namespace PRACTICA3.Modelos
{
    //CREACION DE LA CLASE CLIENTES

    public class Cliente
    {
        //CREACION DE LA PROPIEDADES DE LA CLASE CLIENTES CON SUS RESPECTIVAS VALIDACIONES 

        public int ClienteID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El NOMBRE debe tener una cantidad minima de 3 caracteres.")]
        [RegularExpression(@"^[A-Z\s]*$", ErrorMessage = "Debe ingresar los datos en mayusculas.")]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El APELLIDO debe tener una cantidad minima de 3 caracteres.")]
        [RegularExpression(@"^[A-Z\s]*$", ErrorMessage = "Debe ingresar los datos en mayusculas.")]
        public string Apellido { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "En el CI solo se permiten números.")]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "El CI debe tener una cantidad minima de 7 caracteres.")]
        public string CI { get; set; } = string.Empty;

        public string NombreCompleto => $"{Nombre} {Apellido}";
        public List<Venta> Ventas { get; set; }
    }
}
