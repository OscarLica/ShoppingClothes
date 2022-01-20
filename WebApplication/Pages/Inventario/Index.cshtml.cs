using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Services;

namespace WebApplication.Pages.Inventario
{
    public class IndexModel : PageModel
    {
        private readonly IServiceInventario _serviceInventario;
        public List<DataEntities.DTO.Inventario> Inventario{ get; set; }
        public IndexModel(IServiceInventario serviceInventario)
        {
            _serviceInventario = serviceInventario;
        }
        public void OnGet()
        {
            Inventario = _serviceInventario.InventarioCompras();
        }
    }
}
