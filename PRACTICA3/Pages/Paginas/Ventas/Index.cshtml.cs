using System;
using System.Collections.Generic;
using System.Globalization;
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
        //hacemos el soporte de envio de datos
        [BindProperty(SupportsGet = true)]
        public string ValorTipo { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ValorFiltrado { get; set; }

        public async Task OnGetAsync()
        {
            //declaramos una consulta
            var venta = from m in _context.Venta select m;

            if (!string.IsNullOrEmpty(ValorTipo) && !string.IsNullOrEmpty(ValorFiltrado))
            {
                //segun al tipo buscaremos sus similares
                if (ValorTipo == "Fecha")
                {
                    venta = venta.Where(s => s.Fecha.Date.Equals(Convert.ToDateTime(ValorFiltrado)));
                }

                if (ValorTipo == "PrecioTotal")
                {
                    venta = venta.Where(s => s.PrecioTotal.Equals(Convert.ToDouble(ValorFiltrado)));
                }
                if (ValorTipo == "Clientes")
                {
                    venta = venta.Where(s => s.Clientes.Nombre.Equals(ValorFiltrado));
                }
            }
            Venta = await venta.Include(v => v.Clientes).ToListAsync();
        }

    }
}
