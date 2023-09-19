using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas.Ventas
{
    public class EditModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public EditModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Venta Venta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta =  await _context.Venta.FirstOrDefaultAsync(m => m.VentaID == id);
            if (venta == null)
            {
                return NotFound();
            }
            Venta = venta;
           ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Apellido");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(Venta.VentaID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VentaExists(int id)
        {
          return (_context.Venta?.Any(e => e.VentaID == id)).GetValueOrDefault();
        }
    }
}
