using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryColor
    {

        List<CatColor> GetAll();
        CatColor Post(CatColor catColor);
        CatColor Update(CatColor catColor);
        CatColor Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryColor : Repository, IRepositoryColor
    {
        public RepositoryColor(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CatColor Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cat_Color WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new CatColor
                {
                    Id = Convert.ToInt32(reader[nameof(CatColor.Id)]),
                    Nombre = reader[nameof(CatColor.Nombre)].ToString(),
                    Estado = reader[nameof(CatColor.Estado)].ToString(),
                };
            }
        }

        public List<CatColor> GetAll()
        {
            var result = new List<CatColor>();
            var command = CreateCommand("SELECT * FROM Cat_Color");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CatColor
                    {
                        Id = Convert.ToInt32(reader[nameof(CatColor.Id)]),
                        Nombre= reader[nameof(CatColor.Nombre)].ToString(),
                        Estado = reader[nameof(CatColor.Estado)].ToString()
                    });
                }
            }
            return result;
        }

        public CatColor Post(CatColor catColor)
        {
            var command = CreateCommand($"INSERT INTO Cat_Color(Nombre, Estado) output INSERTED.ID values (@nombre, @ind)");
            command.Parameters.AddWithValue("@nombre", catColor.Nombre);
            command.Parameters.AddWithValue("@ind", catColor.Estado);

            catColor.Id = Convert.ToInt32(command.ExecuteScalar());
            return catColor;
        }

        public CatColor Update(CatColor catColor)
        {
            var command = CreateCommand($"update Cat_Color set Nombre=@nombre,Estado=@ind where Id = @Id");
            command.Parameters.AddWithValue("@nombre", catColor.Nombre);
            command.Parameters.AddWithValue("@ind", catColor.Estado);
            command.Parameters.AddWithValue("@Id", catColor.Id);

            command.ExecuteNonQuery();
            return catColor;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Cat_Color where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
