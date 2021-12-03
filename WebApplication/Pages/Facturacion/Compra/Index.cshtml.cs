using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages.Facturacion.Compra
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public int Descuento => 10;
        public int Iva => 14;
        public DateTime Hoy  => DateTime.Now;
        public void OnGet()
        {
        }
    }
}
