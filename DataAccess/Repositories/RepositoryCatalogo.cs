using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryCatalogo {

        List<CatCategoria> GetAll();
        CatCategoria Post(CatCategoria categoria);
        CatCategoria Update(CatCategoria categoria);
        CatCategoria Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryCatalogo : Repository, IRepositoryCatalogo
    {
        public RepositoryCatalogo(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CatCategoria Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cat_Categoria WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new CatCategoria
                {
                    Id = Convert.ToInt32(reader[nameof(CatCategoria.Id)]),
                    Nombre= reader[nameof(CatCategoria.Nombre)].ToString(),
                    Estado = reader[nameof(CatCategoria.Estado)].ToString(),
          
                };
            }
        }

        public List<CatCategoria> GetAll()
        {
            var result = new List<CatCategoria>();
            var command = CreateCommand("SELECT * FROM Cat_Categoria");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CatCategoria
                    {
                        Id = Convert.ToInt32(reader[nameof(CatCategoria.Id)]),
                        Nombre= reader[nameof(CatCategoria.Nombre)].ToString(),
                        Estado = reader[nameof(CatCategoria.Estado)].ToString()
                      
                    });
                }
            }
            return result;
        }

        public CatCategoria Post(CatCategoria categoria)
        {
            var command = CreateCommand($"INSERT INTO Cat_Categoria(Nombre,Estado) output INSERTED.ID values (@nombre, @act)");
            command.Parameters.AddWithValue("@nombre", categoria.Nombre);
            command.Parameters.AddWithValue("@act", categoria.Estado);
        

            categoria.Id = Convert.ToInt32(command.ExecuteScalar());
            return categoria;
        }

        public CatCategoria Update(CatCategoria categoria)
        {
            var command = CreateCommand($"update Cat_Categoria set Nombre=@nombre, Estado=@act where Id = @Id");
            command.Parameters.AddWithValue("@nombre", categoria.Nombre);
            command.Parameters.AddWithValue("@act", categoria.Estado);
      
            command.Parameters.AddWithValue("@Id", categoria.Id);

            command.ExecuteNonQuery();
            return categoria;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Cat_Categoria where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
