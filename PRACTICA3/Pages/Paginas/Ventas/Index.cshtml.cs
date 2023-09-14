using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas.Ventas
{
    public class IndexModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public IndexModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        public IList<Venta> Venta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Venta != null)
            {
                Venta = await _context.Venta
                .Include(v => v.Clientes).ToListAsync();
            }
        }
    }
}
