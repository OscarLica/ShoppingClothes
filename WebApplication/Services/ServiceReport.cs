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
        List<ReporteProductos> ReportProductosMasBendidos(DateTime? Inicio, DateTime? Fin);
        List<ReporteProductos> ReportProductosMenosBendidos(DateTime? Inicio, DateTime? Fin);
        List<ReporteProductos> ReportProductosDaniados(DateTime? Inicio, DateTime? Fin);
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
        public List<ReporteProductos> ReportProductosDaniados(DateTime? Inicio, DateTime? Fin)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repository.ReportProductosDaniados(Inicio, Fin);
                return records;
            }
        }

        public List<ReporteProductos> ReportProductosMasBendidos(DateTime? Inicio, DateTime? Fin)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repository.ReportProductosMasBendidos(Inicio, Fin);
                return records;
            }
        }

        public List<ReporteProductos> ReportProductosMenosBendidos(DateTime? Inicio, DateTime? Fin)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repository.ReportProductosMenosBendidos(Inicio, Fin);
                return records;
            }
        }
    }
}
