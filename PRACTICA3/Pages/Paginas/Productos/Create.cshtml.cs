using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas.Productos
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
        public Producto Producto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Producto == null || Producto == null)
            {
                return Page();
            }

            _context.Producto.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
