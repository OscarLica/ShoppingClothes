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
    public interface IServiceProveedor
    {
        List<CatProveedor> GetAll();
        CatProveedor Create(CatProveedor catProveedor);
        CatProveedor Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServiceProveedor : IServiceProveedor
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
        public ServiceProveedor(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        /// <summary>
        ///     Consulta listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<CatProveedor> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryProveedor.GetAll();
                return records;
            }
        }

        public CatProveedor Create(CatProveedor catProveedor)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = catProveedor.Id == default ? context.Repositories.repositoryProveedor.Post(catProveedor) : context.Repositories.repositoryProveedor.Update(catProveedor);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public CatProveedor Get(int Id)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryProveedor.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                 context.Repositories.repositoryProveedor.Delete(Id);
                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
