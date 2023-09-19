using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas
{
    public class ResumenModel : PageModel
    {
        public Cliente Cliente { get; set; }//ALMACENA EL OBJETO CLIENTE
        public IList<Producto> Productos { get; set; } = default!;//ALMACENA LA LISTA DE PRODUCTOS
        public int[] idPr { get; set; } = new int[100];//ALMACENA LOS IDS DE LOS PRODUCTOS
        public int[] cantPr { get; set; } = new int[100];//ALMACENA LA CANTIDAD DES PRODUCTO
        public int[] subtotalPr { get; set; } = new int[100];//ALMACENA EL SUBTOTAL DEL SUBPRODUCTO
        public string dataprod { get; set; } = string.Empty;
        public double Total { get; set; } = 0;//TOTAL A PAGAR
        public double totalAux { get; set; }//VARIABLE AUXILIAR PARA REALIZAR CÁLCULOS
        public string idCli { get; set; }//ALMACENA EL ID DEL CLIENTE
        public int cantProd { get; set; }

        [BindProperty]
        public Venta Venta { get; set; } = default!;

        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        public ResumenModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
        }
        //FUNCION PARA HALLAR EL SUBTOTAL DE CADA PRODUCTO
        public double subtotal(double precio, int cant)
        {
            return precio * cant;
        }
        //FUNCION PARA HALLAR EL TOTAL A PAGAR
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
            //OBTIENE EL CLIENTE
            Cliente = _context.Cliente.FirstOrDefault(p => p.ClienteID == Convert.ToInt32(cliente));
            idCli = cliente;
            string[] filaProd = productos.Split('_');// Divide la cadena de productos en filas
            cantProd = filaProd.Length;
            for (int i = 0; i < filaProd.Length - 1; i++)
            {
                string[] colProd = filaProd[i].Split('*');// Divide la fila de productos en columnas
                if (colProd.Length == 2)
                {
                    idPr[i] = Convert.ToInt32(colProd[0]);// Obtiene el ID del producto y lo asigna al arreglo idPr
                    cantPr[i] = Convert.ToInt32(colProd[1]);// Obtiene la cantidad del producto y la asigna al arreglo cantPr
                }

            }
            Productos = _context.Producto.Where(p => idPr.Contains(p.ProductoID)).ToList();// Obtiene los objetos Producto con los IDs almacenados en idPr
            totalAux = total();//CALCULA EL TOTAL 
            Venta = new Venta { ClienteID = Convert.ToInt32(cliente), Fecha = DateTime.Now, PrecioTotal = totalAux};//ASIGNA LOS DATOS A LA TABLA VENTAS
            _context.Venta.Add(Venta);
            _context.SaveChanges();
            return Page();
        }
        public IActionResult OnPost()
        {
            //RETORNA AL INDEX
            return RedirectToPage("/Paginas/Ventas/Index");
        }
    }
}
