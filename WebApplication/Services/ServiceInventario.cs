using DataAccess.Interfaces;
using DataEntities.DTO;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Configuration;

namespace WebApplication.Services
{
    public interface IServiceInventario
    {
        List<Inventario> InventarioCompras();
        List<Inventario> InventarioVentas();
        List<Inventario> InventarioGeneral();
    }
    public class ServiceInventario : IServiceInventario
    {
        /// <summary>
        ///     Interface de bd
        /// </summary>
        private IUnitOfWork _unitOfWork;
        public AppSettings Settings { get; set; }

        /// <summary>
        ///     Constructor base, inicializa dependencia
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="appSettings"></param>
        public ServiceInventario(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        public List<Inventario> InventarioCompras()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryInventario.InventarioCompras();
                return records;
            }
        }

        public List<Inventario> InventarioGeneral()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryInventario.InventarioGeneral();
                return records;
            }
        }

        public List<Inventario> InventarioVentas()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryInventario.InventarioVentas();
                return records;
            }
        }
    }
}
