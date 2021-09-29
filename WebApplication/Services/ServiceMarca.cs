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
    public interface IServiceMarca
    {
        List<CatMarca> GetAll();
        CatMarca Create(CatMarca catMarca);
        CatMarca Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServiceMarca : IServiceMarca
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
        public ServiceMarca(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        /// <summary>
        ///     Consulta listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<CatMarca> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryMarca.GetAll();
                return records;
            }
        }

        public CatMarca Create(CatMarca catMarca)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = catMarca.Id == default ? context.Repositories.repositoryMarca.Post(catMarca) : context.Repositories.repositoryMarca.Update(catMarca);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public CatMarca Get(int Id)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryMarca.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                 context.Repositories.repositoryMarca.Delete(Id);
                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
