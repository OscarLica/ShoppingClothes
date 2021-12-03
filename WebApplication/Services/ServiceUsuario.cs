using DataAccess.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Configuration;

namespace WebApplication.Services
{
    public interface IServiceUsuario {

        void InsertUsuario(string correo, string password);
        int GetUserByEmail(string correo);
    }
    public class ServiceUsuario : IServiceUsuario
    {
        /// <summary>
        ///     Interface de bd
        /// </summary>
        private IUnitOfWork _unitOfWork;
        public AppSettings Settings { get; set; }

        public ServiceUsuario(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            Settings = appSettings.Value;
        }
        public int GetUserByEmail(string correo)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                var records = context.Repositories.repositoryUsuario.GetIdUsuarioByUserSesion(correo);
                return records;
            }
        }

        public void InsertUsuario(string correo, string password)
        {
            using (var context = _unitOfWork.Create(Settings.DefaultConnection))
            {
                context.Repositories.repositoryUsuario.InsertUsuario(correo, password);
                context.SaveChanges();
            }
        }
    }
}
