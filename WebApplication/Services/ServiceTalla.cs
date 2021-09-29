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
    public interface IServiceTalla
    {
        List<CatTalla> GetAll();
        CatTalla Create(CatTalla catTalla);
        CatTalla Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServiceTalla : IServiceTalla
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
        public ServiceTalla(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        /// <summary>
        ///     Consulta listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<CatTalla> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryTalla.GetAll();
                return records;
            }
        }

        public CatTalla Create(CatTalla catTalla)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = catTalla.Id == default ? context.Repositories.repositoryTalla.Post(catTalla) : context.Repositories.repositoryTalla.Update(catTalla);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public CatTalla Get(int Id)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryTalla.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                 context.Repositories.repositoryTalla.Delete(Id);
                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
