using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Services;

namespace WebApplication.Pages.Facturacion.Venta
{
    public class DetalleModel : PageModel
    {
        private readonly IServiceVenta Service;
        public DataEntities.TblVentas venta { get; set; }
        public DetalleModel(IServiceVenta service)
        {
            Service = service;
        }
        public void OnGet(int IdVenta)
        {
            venta =  Service.Get(IdVenta);
        }
    }
}
