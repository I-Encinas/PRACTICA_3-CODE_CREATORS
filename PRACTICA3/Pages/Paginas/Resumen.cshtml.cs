using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas
{
    public class ResumenModel : PageModel
    {
        public Cliente Cliente { get; set; }
        public IList<Producto> Productos { get; set; } = default!;
        public int[] idPr { get; set; } = new int[100];
        public int[] cantPr { get; set; } = new int[100];
        public int[] subtotalPr { get; set; } = new int[100];
        public string dataprod { get; set; } = string.Empty;
        public double Total { get; set; } = 0;
        public double totalAux { get; set; }
        public string idCli { get; set; }
        public int cantProd { get; set; }

        [BindProperty]
        public Venta Venta { get; set; } = default!;

        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public ResumenModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }

        public double subtotal(double precio, int cant)
        {
            return precio * cant;
        }
        public double total()
        {
            for (int i = 0; i < Productos.Count; i++)
            {
                this.Total += Productos[i].PrecioU * cantPr[i];
            }
            return this.Total;
        }

        public IActionResult OnGet(string productos, string cliente)
        {
            Cliente = _context.Cliente.FirstOrDefault(p => p.ClienteID == Convert.ToInt32(cliente));
            idCli = cliente;
            string[] filaProd = productos.Split('_');
            cantProd = filaProd.Length;
            for (int i = 0; i < filaProd.Length - 1; i++)
            {
                string[] colProd = filaProd[i].Split('*');
                if (colProd.Length == 2)
                {
                    idPr[i] = Convert.ToInt32(colProd[0]);
                    cantPr[i] = Convert.ToInt32(colProd[1]);
                }

            }
            Productos = _context.Producto.Where(p => idPr.Contains(p.ProductoID)).ToList();
            totalAux = total();
            Venta = new Venta { ClienteID = Convert.ToInt32(cliente), Fecha = DateTime.Now, PrecioTotal = totalAux};
            _context.Venta.Add(Venta);
            _context.SaveChanges();
            return Page();
        }
        public IActionResult OnPost()
        {
            
            return RedirectToPage("/Paginas/Ventas/Index");
        }
    }
}
