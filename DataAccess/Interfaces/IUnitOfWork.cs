using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    /// <summary>
    ///     Interfaz crea la conexión
    /// </summary>
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create(string connectionString);
    }
}
