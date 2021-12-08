using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IRepositoryCatalogo repositoryCatalogo { get; }

        IRepositoryAlmacen repositoryAlmacen{ get; }
        IRepositoryColor repositoryColor{ get; }
        IRepositoryMarca repositoryMarca{ get; }
        IRepositoryTalla repositoryTalla{ get; }
        IRepositorySubCategoria repositorySubCategoria{ get; }
        IRepositoryProveedor repositoryProveedor{ get; }
        IRepositoryProducto repositoryProducto{ get; }
        IRepositoryCompra repositoryCompra{ get; }
        IRepositoryVenta repositoryVenta{ get; }
        IRepositoryUsuario repositoryUsuario { get; }
        IRepositoryReport repository { get; }
    }
}
