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
    public interface IServiceVenta
    {
        List<TblVentas> GetAll();
        TblVentas Get(int IdVenta);
        TblVentas Post(TblVentas tblVentas, string user);
        ProductoTaller ProductoTaller(ProductoTaller productoTaller);
        List<ReporteProductos> GetProductoTallerSalida();
        ProductoTaller ProductoTallerSalida(ProductoTaller productoTaller);
    }
    public class ServiceVenta : IServiceVenta
    {

        /// <summary>
        ///     Interface de bd
        /// </summary>
        private IUnitOfWork _unitOfWork;
        public AppSettings Settings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="appSettings"></param>
        public ServiceVenta(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;
        }
        public List<TblVentas> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryVenta.GetAll();
                return records;
            }
        }

        public TblVentas Post(TblVentas tblVentas, string user)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var total = context.Repositories.repositoryVenta.GetAll().Count() + 1;
                tblVentas.NumeroFactura = total.ToString().PadLeft(5, '0');
                var records = context.Repositories.repositoryVenta.Post(tblVentas, user);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public TblVentas Get(int IdVenta)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryVenta.Get(IdVenta);

                return records;
            }
        }

        public ProductoTaller ProductoTaller(ProductoTaller productoTaller)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryVenta.ProductoTaller(productoTaller);
                context.SaveChanges();
                return records;
            }
        }

        public List<ReporteProductos> GetProductoTallerSalida()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryVenta.GetProductoTallerSalida();

                return records;
            }
        }

        public ProductoTaller ProductoTallerSalida(ProductoTaller productoTaller)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryVenta.ProductoTallerSalida(productoTaller);
                context.SaveChanges();
                return records;
            }
        }
    }
}
