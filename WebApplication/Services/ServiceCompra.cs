using DataAccess.Interfaces;
using DataEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Configuration;

namespace WebApplication.Services
{
    public interface IServiceCompra
    {
        List<Compra> GetAll();
        List<Detalle> GetProductosComprados();
        Compra Post(Compra compra, string user);
        Compra Update(Compra compra);
        Compra Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServiceCompra : IServiceCompra
    {

        /// <summary>
        ///     Interface de bd
        /// </summary>
        private IUnitOfWork _unitOfWork;
        public AppSettings Settings{ get; set; }

        /// <summary>
        ///     Constructor base, inicializa dependencia
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="appSettings"></param>
        public ServiceCompra(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        public List<Compra> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryCompra.GetAll();
                return records;
            }
        }

        public List<Detalle> GetProductosComprados()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryCompra.GetProductosComprados();
                return records;
            }
        }

        public Compra Post(Compra compra, string user)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var total = context.Repositories.repositoryCompra.GetAll().Count() + 1 ;
                compra.NoFactura = total.ToString().PadLeft(5, '0');
                var records = context.Repositories.repositoryCompra.Post(compra, user);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public Compra Update(Compra compra)
        {
            throw new NotImplementedException();
        }

        public Compra Get(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryCompra.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
