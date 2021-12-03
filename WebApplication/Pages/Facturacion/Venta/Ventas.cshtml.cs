using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Services;

namespace WebApplication.Pages.Facturacion.Venta
{
    public class VentasModel : PageModel
    {
        public IServiceVenta _ServiceVenta;
        public List<DataEntities.TblVentas> Ventas { get; set; }
        public VentasModel(IServiceVenta serviceVenta)
        {
            _ServiceVenta = serviceVenta;
        }
        public void OnGet()
        {
            Ventas = _ServiceVenta.GetAll();
        }
    }
}
