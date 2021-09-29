using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryTalla
    {

        List<CatTalla> GetAll();
        CatTalla Post(CatTalla catTalla);
        CatTalla Update(CatTalla catTalla);
        CatTalla Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryTalla : Repository, IRepositoryTalla
    {
        public RepositoryTalla(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CatTalla Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cat_Talla WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new CatTalla
                {
                    Id = Convert.ToInt32(reader[nameof(CatTalla.Id)]),
                    Nombre = reader[nameof(CatTalla.Nombre)].ToString(),
                    Estado = reader[nameof(CatTalla.Estado)].ToString()
                };
            }
        }

        public List<CatTalla> GetAll()
        {
            var result = new List<CatTalla>();
            var command = CreateCommand("SELECT * FROM Cat_Talla");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CatTalla
                    {
                        Id = Convert.ToInt32(reader[nameof(CatTalla.Id)]),
                        Nombre = reader[nameof(CatTalla.Nombre)].ToString(),
                        Estado = reader[nameof(CatAlmacen.Estado)].ToString()
                    });
                }
            }
            return result;
        }

        public CatTalla Post(CatTalla catTalla)
        {
            var command = CreateCommand($"INSERT INTO Cat_Talla(Nombre, Estado) output INSERTED.ID values (@nombre, @act)");
            command.Parameters.AddWithValue("@nombre", catTalla.Nombre);
            command.Parameters.AddWithValue("@act", catTalla.Estado);

            catTalla.Id = Convert.ToInt32(command.ExecuteScalar());
            return catTalla;
        }

        public CatTalla Update(CatTalla catTalla)
        {
            var command = CreateCommand($"update Cat_Talla set Nombre=@nombre,Estado =@act where Id = @Id");
            command.Parameters.AddWithValue("@nombre", catTalla.Nombre);
            command.Parameters.AddWithValue("@act", catTalla.Estado);
            command.Parameters.AddWithValue("@Id", catTalla.Id);

            command.ExecuteNonQuery();
            return catTalla;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Cat_Talla where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
