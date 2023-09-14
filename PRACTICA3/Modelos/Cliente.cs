﻿using System.ComponentModel.DataAnnotations;

namespace PRACTICA3.Modelos
{

    public class Cliente
    {
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
        public int CI { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
