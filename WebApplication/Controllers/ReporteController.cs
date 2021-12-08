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

        [HttpGet("Reporte/ReportProductosMasBendidos")]
        public async Task<IActionResult> ReportProductosMasBendidos()
        {
            var model = _serviceReport.ReportProductosMasBendidos();
            var pdfDocument = new ViewAsPdf("RptMVendidos", model)
            {
                PageSize = Size.Letter,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(11, 7, 20, 7)
            };

            var byteArray = await pdfDocument.BuildFile(ControllerContext);
            return Ok(byteArray);
        }

        [HttpGet("Reporte/ReportProductosMenosBendidos")]
        public async Task<IActionResult> ReportProductosMenosBendidos()
        {
            var model = _serviceReport.ReportProductosMasBendidos();
            var pdfDocument = new ViewAsPdf("RptMenosVendidos", model)
            {
                PageSize = Size.Letter,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(11, 7, 20, 7)
            };

            var byteArray = await pdfDocument.BuildFile(ControllerContext);
            return Ok(byteArray);
        }

        [HttpGet("Reporte/ReportProductosDaniados")]
        public async Task<IActionResult> ReportProductosDaniados()
        {
            var model = _serviceReport.ReportProductosDaniados();
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
