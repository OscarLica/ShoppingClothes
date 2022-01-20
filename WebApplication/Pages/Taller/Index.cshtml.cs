using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Services;

namespace WebApplication.Pages.Taller
{
    public class IndexModel : PageModel
    {
        private readonly IServiceReport _serviceReport;
        public List<DataEntities.ReporteProductos> productosTaller { get; set; }
        public IndexModel(IServiceReport serviceReport)
        {
            _serviceReport = serviceReport;
        }
        public void OnGet()
        {
            productosTaller = _serviceReport.ReportProductosDaniados(null,null);
        }
    }
}
