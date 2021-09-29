using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer
{
    /// <summary>
    /// Contiene los repositorios
    /// </summary>
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {

        /// <summary>
        ///     Repositorio de catalogo
        /// </summary>
        public IRepositoryCatalogo repositoryCatalogo { get; }

        public IRepositoryAlmacen repositoryAlmacen { get; }

        public IRepositoryColor repositoryColor { get; }

        public IRepositoryMarca repositoryMarca { get; }

        public IRepositoryTalla repositoryTalla { get; }

        public IRepositorySubCategoria repositorySubCategoria { get; }

        public IRepositoryProveedor repositoryProveedor { get; }

        public IRepositoryProducto repositoryProducto { get; }

        public IRepositoryCompra repositoryCompra { get; }

        /// <summary>
        ///     Inicializa los repotorios
        /// </summary>
        /// <param name="context"></param>
        /// <param name="transaction"></param>
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            repositoryCatalogo = new RepositoryCatalogo(context, transaction);
            repositoryAlmacen = new RepositoryAlmacen(context, transaction);
            repositoryColor = new RepositoryColor(context, transaction);
            repositoryMarca = new RepositoryMarca(context, transaction);
            repositoryTalla = new RepositoryTalla(context, transaction);
            repositorySubCategoria = new RepositorySubCategoria(context, transaction);
            repositoryProveedor = new RepositoryProveedor(context, transaction);
            repositoryProducto = new RepositoryProducto(context, transaction);
            repositoryCompra = new RepositoryCompra(context, transaction);
        }

    }
}
