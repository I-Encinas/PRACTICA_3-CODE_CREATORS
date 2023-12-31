﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRACTICA3.Data;
using PRACTICA3.Modelos;

namespace PRACTICA3.Pages.Paginas
{
    public class comprasModel : PageModel
    {
        private readonly PRACTICA3.Data.PRACTICA3Context _context;

        [BindProperty(SupportsGet = true)]
        public string Cliente_id { get; set; }//almacenar id de cliente
        public string Productos_str { get; set; } = string.Empty;//almacenar una cadena de productos seleccionados

        [BindProperty]
        public List<Cliente> Clientes { get; set; }//lista de clientes
        public List<Producto> Productos { get; set; }//lista de productos
        [BindProperty]
        public List<int> Cantidad { get; set; } = new List<int>();//lista de cantidad de precio_unitario

        //verifica que cliente y productos no sean nulos
        public comprasModel(PRACTICA3.Data.PRACTICA3Context context)
        {
            _context = context;
            if (_context.Producto != null)
            {
                Productos = _context.Producto.ToList();
            }

            if (_context.Cliente != null)
            {
                Clientes = _context.Cliente.ToList();
            }

            
            foreach (var item in Productos)
            {
                Cantidad.Add(0);
            }
        }
        //trabaja con el metodo post
        public IActionResult OnPost()
        {
            int i = 0;
            //bucle para enlistar los productos
            foreach (var producto in Productos)
            {
                //verifica que la cantidad de producto sea mayor a cero
                if (Cantidad[i] > 0)
                {
                    Productos_str = Productos_str + producto.ProductoID + "*" + Cantidad[i].ToString() + "_";
                }
                i++;
            }
            if (ModelState.IsValid == false )
            {
                string errores = "";
                foreach (var entry in ModelState)
                {
                    var key = entry.Key;
                    var errors = entry.Value.Errors;

                    // Puedes acceder a los errores para una propiedad específica.
                    foreach (var error in errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        errores = errores + errorMessage + " ";
                        // Puedes hacer algo con el mensaje de error, como mostrarlo en la vista.
                    }
                }
                return RedirectToPage("/Paginas/Resumen", new { cliente = errores});
            }
            return RedirectToPage("/Paginas/Resumen", new { cliente = Cliente_id, productos = Productos_str});
        }
    }
}
