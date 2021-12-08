using DataAccess.Interfaces;
using DataEntities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Configuration;

namespace WebApplication.Services
{
    public interface IServiceReport {
        List<ReporteProductos> ReportProductosMasBendidos();
        List<ReporteProductos> ReportProductosMenosBendidos();
        List<ReporteProductos> ReportProductosDaniados();
    }

    public class ServiceReport : IServiceReport
    {
        /// <summary>
        ///     Interface de bd
        /// </summary>
        private IUnitOfWork _unitOfWork;
        public AppSettings Settings { get; set; }
        public ServiceReport(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;
        }
        public List<ReporteProductos> ReportProductosDaniados()
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repository.ReportProductosDaniados();
                return records;
            }
        }

        public List<ReporteProductos> ReportProductosMasBendidos()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repository.ReportProductosMasBendidos();
                return records;
            }
        }

        public List<ReporteProductos> ReportProductosMenosBendidos()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repository.ReportProductosMenosBendidos();
                return records;
            }
        }
    }
}
