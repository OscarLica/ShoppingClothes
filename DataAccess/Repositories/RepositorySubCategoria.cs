using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositorySubCategoria
    {

        List<CatSubCategoria> GetAll();
        CatSubCategoria Post(CatSubCategoria catSubCategoria);
        CatSubCategoria Update(CatSubCategoria catSubCategoria);
        CatSubCategoria Get(int Id);
        void Delete(int Id);
    }
    public class RepositorySubCategoria : Repository, IRepositorySubCategoria
    {
        public RepositorySubCategoria(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CatSubCategoria Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cat_SubCategoria WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new CatSubCategoria
                {
                    Id = Convert.ToInt32(reader[nameof(CatSubCategoria.Id)]),
                    IdCategoria= Convert.ToInt32(reader[nameof(CatSubCategoria.IdCategoria)]),
                    Nombre = reader[nameof(CatSubCategoria.Nombre)].ToString(),
                    Estado = reader[nameof(CatSubCategoria.Estado)].ToString()
                };
            }
        }

        public List<CatSubCategoria> GetAll()
        {
            var result = new List<CatSubCategoria>();
            var command = CreateCommand("SELECT * FROM Cat_SubCategoria");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CatSubCategoria
                    {
                        Id = Convert.ToInt32(reader[nameof(CatSubCategoria.Id)]),
                        IdCategoria = Convert.ToInt32(reader[nameof(CatSubCategoria.IdCategoria)]),
                        Nombre = reader[nameof(CatSubCategoria.Nombre)].ToString(),
                        Estado = reader[nameof(CatSubCategoria.Estado)].ToString()
                    });
                }
            }
            return result;
        }

        public CatSubCategoria Post(CatSubCategoria catSubCategoria)
        {
            var command = CreateCommand($"INSERT INTO Cat_SubCategoria(IdCategoria, Nombre, Estado) output INSERTED.ID values (@idcat, @nombre, @act)");
            command.Parameters.AddWithValue("@nombre", catSubCategoria.Nombre);
            command.Parameters.AddWithValue("@idcat", catSubCategoria.IdCategoria);
            command.Parameters.AddWithValue("@act", catSubCategoria.Estado);

            catSubCategoria.Id = Convert.ToInt32(command.ExecuteScalar());
            return catSubCategoria;
        }

        public CatSubCategoria Update(CatSubCategoria catSubCategoria)
        {
            var command = CreateCommand($"update Cat_SubCategoria set Nombre=@nombre,Estado =@act, IdCategoria = @idcat where Id = @Id");
            command.Parameters.AddWithValue("@nombre", catSubCategoria.Nombre);
            command.Parameters.AddWithValue("@act", catSubCategoria.Estado);
            command.Parameters.AddWithValue("@idcat", catSubCategoria.IdCategoria);
            command.Parameters.AddWithValue("@Id", catSubCategoria.Id);

            command.ExecuteNonQuery();
            return catSubCategoria;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Cat_SubCategoria where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
