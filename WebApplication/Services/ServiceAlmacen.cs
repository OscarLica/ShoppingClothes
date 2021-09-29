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
    public interface IServiceAlmacen
    {
        List<CatAlmacen> GetAll();
        CatAlmacen Create(CatAlmacen catAlmacen);
        CatAlmacen Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServiceAlmacen : IServiceAlmacen
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
        public ServiceAlmacen(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        /// <summary>
        ///     Consulta listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<CatAlmacen> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryAlmacen.GetAll();
                return records;
            }
        }

        public CatAlmacen Create(CatAlmacen catAlmacen)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = catAlmacen.Id == default ? context.Repositories.repositoryAlmacen.Post(catAlmacen) : context.Repositories.repositoryAlmacen.Update(catAlmacen);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public CatAlmacen Get(int Id)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryAlmacen.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                 context.Repositories.repositoryAlmacen.Delete(Id);
                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
