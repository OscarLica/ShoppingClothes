using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IServiceReport _serviceReport;
        public ReporteController(IServiceReport serviceReport)
        {
            _serviceReport = serviceReport;

        }

        [HttpGet("Reporte/ReportProductosMasBendidos/{inicio}/{fin}")]
        public async Task<IActionResult> ReportProductosMasBendidos(DateTime? Inicio, DateTime? Fin)
        {
            var model = _serviceReport.ReportProductosMasBendidos(Inicio, Fin);
            var pdfDocument = new ViewAsPdf("RptMVendidos", model)
            {
                PageSize = Size.Letter,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(11, 7, 20, 7)
            };

            var byteArray = await pdfDocument.BuildFile(ControllerContext);
            return Ok(byteArray);
        }

        [HttpGet("Reporte/ReportProductosMenosBendidos/{inicio}/{fin}")]
        public async Task<IActionResult> ReportProductosMenosBendidos(DateTime? Inicio, DateTime? Fin)
        {
            var model = _serviceReport.ReportProductosMenosBendidos(Inicio, Fin);
            var pdfDocument = new ViewAsPdf("RptMenosVendidos", model)
            {
                PageSize = Size.Letter,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(11, 7, 20, 7)
            };

            var byteArray = await pdfDocument.BuildFile(ControllerContext);
            return Ok(byteArray);
        }

        [HttpGet("Reporte/ReportProductosDaniados/{inicio}/{fin}")]
        public async Task<IActionResult> ReportProductosDaniados(DateTime? Inicio, DateTime? Fin)
        {
            var model = _serviceReport.ReportProductosDaniados(Inicio, Fin);
            var pdfDocument = new ViewAsPdf("RptPrDañados", model)
            {
                PageSize = Size.Letter,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(11, 7, 20, 7)
            };

            var byteArray = await pdfDocument.BuildFile(ControllerContext);
            return Ok(byteArray);
        }
    }
}
