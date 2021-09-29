using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Services;

namespace WebApplication.Pages.Facturacion.Compra
{
    public class ComprasModel : PageModel
    {
        private readonly IServiceCompra Service;
        public List<DataEntities.Compra> Compra { get; set; }
        public ComprasModel(IServiceCompra service)
        {
            Service = service;
        }
        public void OnGet()
        {
            Compra = Service.GetAll();
        }
    }
}
