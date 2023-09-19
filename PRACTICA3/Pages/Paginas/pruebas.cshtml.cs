using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRACTICA3.Pages.Paginas
{
    public class pruebasModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string cliente { get; set; }// Propiedad para almacenar el valor del par�metro "cliente"
        [BindProperty(SupportsGet = true)]
        public string productos { get; set; }// Propiedad para almacenar el valor del par�metro de consulta "productos"
        public void OnGet()
        {
            //VALIDA QUE CLIENTE NO SEA NULO, SI LO ES, LE ASIGNA UN VALOR EST�TICO
            if(cliente == null)
            {
                cliente = "Hola";
            }
        }
    }
}
