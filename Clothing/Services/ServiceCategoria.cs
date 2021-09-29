using DataAccess.Interfaces;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothing.Services
{
    public interface IServiceCategoria {

        List<Categoria> GetAll();
    }
    public class ServiceCategoria : IServiceCategoria
    {
        private IUnitOfWork _unitOfWork;
        public ServiceCategoria(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Categoria> GetAll()
        {
            using (var _context = _unitOfWork.Create()) { 
            
            _context.Repositories.
            }
        }
    }
}
