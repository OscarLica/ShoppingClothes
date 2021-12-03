using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Services;

namespace WebApplication.Pages.Facturacion.Compra
{
    [Authorize]
    public class DetalleModel : PageModel
    {
        private readonly IServiceCompra Service;
        public DataEntities.Compra Compra { get; set; }
        public DetalleModel(IServiceCompra service)
        {
            Service = service;
        }
        
        [HttpGet("")]
        public void OnGet(int IdCompra)
        {
            Compra = Service.Get(IdCompra);
        }
    }
}
