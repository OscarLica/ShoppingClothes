using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IServiceReport _serviceReport;

        public ReportController(IServiceReport serviceReport)
        {
            _serviceReport = serviceReport;
        }

        public async Task<byte[]> ReportProductosMasBendidos() {
            var model = _serviceReport.ReportProductosMasBendidos();
            var pdfDocument = new ViewAsPdf("Report", model)
            {
                PageSize = Size.Letter,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(11, 7, 20, 7)                
            };

            var byteArray = await pdfDocument.BuildFile(ControllerContext);
            return byteArray;
        }
        public async Task<byte[]> ReportProductosMenosBendidos() {
            return new byte[0];
        }
        public async Task<byte[]> ReportProductosDaniados() {
            return new byte[0];
        }
    }
}
