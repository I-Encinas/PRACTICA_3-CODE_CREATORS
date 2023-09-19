using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public CreateModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!; //PROPIEDAD QUE ENLAZA EL MODELO CLIENTE 



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        
        //Método que se ejecuta al realizar una solicitud POST al formulario

        public async Task<IActionResult> OnPostAsync()
        {
            //VALIDA QUE LO INGRESADO NO SEA NULO

            if (_context.Cliente == null || Cliente == null)
            {
                return Page();//SI ES NULO RETORNA A LA PAGINA
            }
            //AGREGA EL MODELO CLIENTE A LA BD

            _context.Cliente.Add(Cliente);
            //GUARDA LOS CAMBIOS

            await _context.SaveChangesAsync();
            //REDIRIGGE A INDEX

            return RedirectToPage("./Index");
        }
    }
}
