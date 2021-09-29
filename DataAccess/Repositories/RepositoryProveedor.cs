using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryProveedor
    {

        List<CatProveedor> GetAll();
        CatProveedor Post(CatProveedor catProveedor);
        CatProveedor Update(CatProveedor catProveedor);
        CatProveedor Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryProveedor : Repository, IRepositoryProveedor
    {
        public RepositoryProveedor(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CatProveedor Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Cat_Proveedor WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new CatProveedor
                {
                    Id = Convert.ToInt32(reader[nameof(CatProveedor.Id)]),
                    NombreCompañia= reader[nameof(CatProveedor.NombreCompañia)].ToString(),
                    NombreContacto= reader[nameof(CatProveedor.NombreContacto)].ToString(),
                    CargoContacto= reader[nameof(CatProveedor.CargoContacto)].ToString(),
                    Direccion= reader[nameof(CatProveedor.Direccion)].ToString(),
                    Telefono = reader[nameof(CatProveedor.Telefono)].ToString(),
                    Email = reader[nameof(CatProveedor.Email)].ToString()
                };
            }
        }

        public List<CatProveedor> GetAll()
        {
            var result = new List<CatProveedor>();
            var command = CreateCommand("SELECT * FROM Cat_Proveedor");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CatProveedor
                    {
                        Id = Convert.ToInt32(reader[nameof(CatProveedor.Id)]),
                        NombreCompañia = reader[nameof(CatProveedor.NombreCompañia)].ToString(),
                        NombreContacto = reader[nameof(CatProveedor.NombreContacto)].ToString(),
                        CargoContacto = reader[nameof(CatProveedor.CargoContacto)].ToString(),
                        Direccion = reader[nameof(CatProveedor.Direccion)].ToString(),
                        Telefono = reader[nameof(CatProveedor.Telefono)].ToString(),
                        Email = reader[nameof(CatProveedor.Email)].ToString()
                    });
                }
            }
            return result;
        }

        public CatProveedor Post(CatProveedor catProveedor)
        {
            var command = CreateCommand($"INSERT INTO Cat_Proveedor(NombreCompañia,NombreContacto,CargoContacto,Direccion, Telefono, Email) output INSERTED.ID values (@nombre, @contacto, @cargo,@direccion, @telefono, @email)");
            command.Parameters.AddWithValue("@nombre", catProveedor.NombreCompañia);
            command.Parameters.AddWithValue("@contacto", catProveedor.NombreContacto);
            command.Parameters.AddWithValue("@cargo", catProveedor.CargoContacto);
            command.Parameters.AddWithValue("@direccion", catProveedor.Direccion);
            command.Parameters.AddWithValue("@telefono", catProveedor.Telefono);
            command.Parameters.AddWithValue("@email", catProveedor.Email);

            catProveedor.Id = Convert.ToInt32(command.ExecuteScalar());
            return catProveedor;
        }

        public CatProveedor Update(CatProveedor catProveedor)
        {
            var command = CreateCommand($"update Cat_Proveedor set NombreCompañia=@nombre, NombreContacto = @contacto, CargoContacto = @cargo, Direccion = @direccion, Telefono=@telefono, Email = @email  where Id = @Id");
            command.Parameters.AddWithValue("@nombre", catProveedor.NombreCompañia);
            command.Parameters.AddWithValue("@contacto", catProveedor.NombreContacto);
            command.Parameters.AddWithValue("@cargo", catProveedor.CargoContacto);
            command.Parameters.AddWithValue("@direccion", catProveedor.Direccion);
            command.Parameters.AddWithValue("@telefono", catProveedor.Telefono);
            command.Parameters.AddWithValue("@email", catProveedor.Email);
            command.Parameters.AddWithValue("@Id", catProveedor.Id);

            command.ExecuteNonQuery();
            return catProveedor;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Cat_Proveedor where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
