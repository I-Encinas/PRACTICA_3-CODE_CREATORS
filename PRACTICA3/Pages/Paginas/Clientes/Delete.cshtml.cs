using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public DeleteModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Cliente Cliente { get; set; } = default!;//PROPIEDAD QUE ENLAZA EL MODELO CLIENTE

        // Método que se ejecuta al realizar una solicitud GET a la página con un parámetro de identificación "id"
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //VALIDA QUE LO INGRESADO NO SEA NULO

            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.ClienteID == id);

            if (cliente == null)
            {
                return NotFound();
            }
            else 
            {
                Cliente = cliente;
            }
            return Page();
        }
        // Método que se ejecuta al realizar una solicitud POST a la página con un parámetro de identificación "id" 

        public async Task<IActionResult> OnPostAsync(int? id)
        {            
            //VALIDA QUE LO INGRESADO NO SEA NULO

            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente != null)
            {
                Cliente = cliente;
                _context.Cliente.Remove(Cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
