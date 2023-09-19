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
    public class IndexModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public IndexModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get;set; } = default!;
        //hacemos el soporte de envio de datos
        [BindProperty(SupportsGet = true)]
        public string ValorTipo { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ValorFiltrado { set; get; }
        public async Task OnGetAsync()
        {
            //declaramos una consulta
            var prod = from m in _context.Producto select m;
            //segun al tipo buscaremos sus similares
            if (!string.IsNullOrEmpty(ValorTipo) && !string.IsNullOrEmpty(ValorFiltrado))
            {
                if (ValorTipo == "Nombre")
                {
                    prod = prod.Where(s => s.Nombre.Equals(ValorFiltrado));
                }
                if (ValorTipo == "PrecioU")
                {
                    prod = prod.Where(s => s.PrecioU >= Convert.ToDouble(ValorFiltrado));
                }
            }
            Producto = await prod.ToListAsync();
        }
    }
}
