using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryMarca
    {

        List<CatMarca> GetAll();
        CatMarca Post(CatMarca catTalla);
        CatMarca Update(CatMarca catTalla);
        CatMarca Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryMarca : Repository, IRepositoryMarca
    {
        public RepositoryMarca(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CatMarca Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cat_Marca WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new CatMarca
                {
                    Id = Convert.ToInt32(reader[nameof(CatMarca.Id)]),
                    Nombre = reader[nameof(CatMarca.Nombre)].ToString(),
                    Estado = reader[nameof(CatMarca.Estado)].ToString()
                };
            }
        }

        public List<CatMarca> GetAll()
        {
            var result = new List<CatMarca>();
            var command = CreateCommand("SELECT * FROM Cat_Marca");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CatMarca
                    {
                        Id = Convert.ToInt32(reader[nameof(CatMarca.Id)]),
                        Nombre = reader[nameof(CatMarca.Nombre)].ToString(),
                        Estado = reader[nameof(CatMarca.Estado)].ToString()
                    });
                }
            }
            return result;
        }

        public CatMarca Post(CatMarca catMarca)
        {
            var command = CreateCommand($"INSERT INTO Cat_Marca(Nombre, Estado) output INSERTED.ID values (@nombre, @act)");
            command.Parameters.AddWithValue("@nombre", catMarca.Nombre);
            command.Parameters.AddWithValue("@act", catMarca.Estado);

            catMarca.Id = Convert.ToInt32(command.ExecuteScalar());
            return catMarca;
        }

        public CatMarca Update(CatMarca catMarca)
        {
            var command = CreateCommand($"update Cat_Marca set Nombre=@nombre,Estado =@act where Id = @Id");
            command.Parameters.AddWithValue("@nombre", catMarca.Nombre);
            command.Parameters.AddWithValue("@act", catMarca.Estado);
            command.Parameters.AddWithValue("@Id", catMarca.Id);

            command.ExecuteNonQuery();
            return catMarca;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Cat_Marca where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
