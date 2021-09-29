using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer
{
    /// <summary>
    ///     Crea la conexión
    /// </summary>
    public class SqlServerAdapter : IUnitOfWorkAdapter
    {

        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private SqlConnection _context { get; set; }

        /// <summary>
        ///     transacción
        /// </summary>
        private SqlTransaction _transaction { get; set; }

        /// <summary>
        ///     Repositorios
        /// </summary>
        public IUnitOfWorkRepository Repositories { get; }


        /// <summary>
        ///     Constructor base, inicializa dependencias
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlServerAdapter(string connectionString)
        {
            _context = new SqlConnection(connectionString);
            _context.Open();

            _transaction = _context.BeginTransaction();
            Repositories = new UnitOfWorkSqlServerRepository(_context, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
