using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public DeleteModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(m => m.ProductoID == id);

            if (producto == null)
            {
                return NotFound();
            }
            else 
            {
                Producto = producto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }
            var producto = await _context.Producto.FindAsync(id);

            if (producto != null)
            {
                Producto = producto;
                _context.Producto.Remove(Producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
