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
    public interface IServiceCatalogo {
        List<CatCategoria> GetAll();
        CatCategoria Create(CatCategoria categoria);
        CatCategoria Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServiceCatalogo : IServiceCatalogo
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
        public ServiceCatalogo(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        /// <summary>
        ///     Consulta listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<CatCategoria> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryCatalogo.GetAll();
                return records;
            }
        }

        public CatCategoria Create(CatCategoria categoria)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = categoria.Id == default ? context.Repositories.repositoryCatalogo.Post(categoria) : context.Repositories.repositoryCatalogo.Update(categoria);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public CatCategoria Get(int Id)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryCatalogo.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                 context.Repositories.repositoryCatalogo.Delete(Id);
                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
