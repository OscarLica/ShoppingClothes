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
    public interface IServicesSubCategoria
    {
        List<CatSubCategoria> GetAll();
        CatSubCategoria Create(CatSubCategoria catSubCategoria);
        CatSubCategoria Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServicesSubCategoria : IServicesSubCategoria
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
        public ServicesSubCategoria(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        /// <summary>
        ///     Consulta listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<CatSubCategoria> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositorySubCategoria.GetAll();
                return records;
            }
        }

        public CatSubCategoria Create(CatSubCategoria subCategoria)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = subCategoria.Id == default ? context.Repositories.repositorySubCategoria.Post(subCategoria) : context.Repositories.repositorySubCategoria.Update(subCategoria);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public CatSubCategoria Get(int Id)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositorySubCategoria.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                 context.Repositories.repositorySubCategoria.Delete(Id);
                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
