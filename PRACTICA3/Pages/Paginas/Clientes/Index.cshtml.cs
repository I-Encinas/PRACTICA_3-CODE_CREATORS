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
    public class IndexModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public IndexModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;
        //hacemos el soporte de envio de datos
        [BindProperty(SupportsGet = true)]
        public string ValorFiltrado { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ValorTipo { get; set; }
        public async Task OnGetAsync()
        {
            //declaramos una consulta
            var valor = from m in _context.Cliente select m;
            //si ninguno de los valores estan vacios entonces
            if (!string.IsNullOrEmpty(ValorFiltrado) && !string.IsNullOrEmpty(ValorTipo))
            {
                //segun al tipo buscaremos sus similares
                if (ValorTipo == "CI")
                {
                    valor = valor.Where(s => s.CI.Equals(ValorFiltrado));
                }
                if (ValorTipo == "Nombre")
                {
                    valor = valor.Where(s => s.Nombre.Equals(ValorFiltrado));
                }
                if (ValorTipo == "Apellido")
                {
                    valor = valor.Where(s => s.Apellido.Equals(ValorFiltrado));
                }
            }
            Cliente = await valor.ToListAsync();
        }
    }
}
