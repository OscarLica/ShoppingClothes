using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryAlmacen
    {

        List<CatAlmacen> GetAll();
        CatAlmacen Post(CatAlmacen almacen);
        CatAlmacen Update(CatAlmacen almacen);
        CatAlmacen Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryAlmacen : Repository, IRepositoryAlmacen
    {
        public RepositoryAlmacen(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CatAlmacen Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cat_Almacen WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new CatAlmacen
                {
                    Id = Convert.ToInt32(reader[nameof(CatAlmacen.Id)]),
                    Nombre = reader[nameof(CatAlmacen.Nombre)].ToString(),
                    Descripcion = reader[nameof(CatAlmacen.Descripcion)].ToString(),
                    Estado = reader[nameof(CatAlmacen.Estado)].ToString()
                };
            }
        }

        public List<CatAlmacen> GetAll()
        {
            var result = new List<CatAlmacen>();
            var command = CreateCommand("SELECT * FROM Cat_Almacen");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CatAlmacen
                    {
                        Id = Convert.ToInt32(reader[nameof(CatAlmacen.Id)]),
                        Nombre = reader[nameof(CatAlmacen.Nombre)].ToString(),
                        Descripcion = reader[nameof(CatAlmacen.Descripcion)].ToString(),
                        Estado = reader[nameof(CatAlmacen.Estado)].ToString()
                    });
                }
            }
            return result;
        }

        public CatAlmacen Post(CatAlmacen catAlmacen)
        {
            var command = CreateCommand($"INSERT INTO Cat_Almacen(Nombre, Descripcion, Estado) output INSERTED.ID values (@nombre, @desc, @act)");
            command.Parameters.AddWithValue("@nombre", catAlmacen.Nombre);
            command.Parameters.AddWithValue("@desc", catAlmacen.Descripcion);
            command.Parameters.AddWithValue("@act", catAlmacen.Estado);

            catAlmacen.Id = Convert.ToInt32(command.ExecuteScalar());
            return catAlmacen;
        }

        public CatAlmacen Update(CatAlmacen catAlmacen)
        {
            var command = CreateCommand($"update Cat_Almacen set Nombre=@nombre, Descripcion = @desc, Estado =@act where Id = @Id");
            command.Parameters.AddWithValue("@nombre", catAlmacen.Nombre);
            command.Parameters.AddWithValue("@desc", catAlmacen.Descripcion);
            command.Parameters.AddWithValue("@act", catAlmacen.Estado);
            command.Parameters.AddWithValue("@Id", catAlmacen.Id);

            command.ExecuteNonQuery();
            return catAlmacen;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Cat_Almacen where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
