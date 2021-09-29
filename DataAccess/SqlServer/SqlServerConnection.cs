using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServer
{
    public class SqlServerConnection : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create(string connectionString)
         => new SqlServerAdapter(connectionString);
    }
}
