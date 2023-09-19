using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas.Ventas
{
    public class CreateModel : PageModel
    {
        public Cliente Cliente { get; set; }
        public double TotalCompras { get; set; }
        public int idCli { get; set; }
        public string prueba { get; set; }

        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public CreateModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var dato1 = TempData["idCliente"] as string;
            if (!string.IsNullOrEmpty(dato1))
            {
                prueba = (dato1);
            }
            
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Apellido");
            return Page();
        }

        [BindProperty]
        public Venta Venta { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Venta == null || Venta == null)
            {
                return Page();
            }

            _context.Venta.Add(Venta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
