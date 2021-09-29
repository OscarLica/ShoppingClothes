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
    public interface IServiceProducto
    {
        List<TblProducto> GetAll();
        TblProducto Create(TblProducto catTalla);
        TblProducto Get(int Id);
        void Delete(int Id);
    }

    /// <summary>
    ///     Services de catalogo
    /// </summary>
    public class ServiceProducto : IServiceProducto
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
        public ServiceProducto(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;

        }

        /// <summary>
        ///     Consulta listado de categorias
        /// </summary>
        /// <returns></returns>
        public List<TblProducto> GetAll()
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryProducto.GetAll();
                return records;
            }
        }

        public TblProducto Create(TblProducto producto)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = producto.Id == default ? context.Repositories.repositoryProducto.Post(producto) : context.Repositories.repositoryProducto.Update(producto);
                // Confirm changes
                context.SaveChanges();
                return records;
            }
        }

        public TblProducto Get(int Id)
        {

            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryProducto.Get(Id);

                return records;
            }
        }

        public void Delete(int Id)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                 context.Repositories.repositoryProducto.Delete(Id);
                // Confirm changes
                context.SaveChanges();
            }
        }
    }
}
