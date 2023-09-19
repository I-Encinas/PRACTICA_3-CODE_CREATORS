using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRACTICA3.Pages.Paginas
{
    public class pruebasModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string cliente { get; set; }
        [BindProperty(SupportsGet = true)]
        public string productos { get; set; }
        public void OnGet()
        {
            if(cliente == null)
            {
                cliente = "Hola";
            }
        }
    }
}
