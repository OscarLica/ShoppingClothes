using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryProducto
    {

        List<TblProducto> GetAll();
        TblProducto Post(TblProducto tblProducto);
        TblProducto Update(TblProducto tblProducto);
        TblProducto Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryProducto : Repository, IRepositoryProducto
    {
        public RepositoryProducto(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public TblProducto Get(int Id)
        {
            var command = CreateCommand("SELECT * FROM Tbl_Producto WITH(NOLOCK) WHERE Id = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new TblProducto
                {
                    Id = Convert.ToInt32(reader[nameof(TblProducto.Id)]),
                    IdSubCategoria = Convert.ToInt32(reader[nameof(TblProducto.IdSubCategoria)]),
                    NombreProducto = reader[nameof(TblProducto.NombreProducto)].ToString(),
                    Descripcion = reader[nameof(TblProducto.Descripcion)].ToString(),
                    Estado = reader[nameof(TblProducto.Estado)].ToString()
                };
            }
        }

        public List<TblProducto> GetAll()
        {
            var result = new List<TblProducto>();
            var command = CreateCommand("SELECT * FROM Tbl_Producto");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new TblProducto
                    {
                        Id = Convert.ToInt32(reader[nameof(TblProducto.Id)]),
                        IdSubCategoria = Convert.ToInt32(reader[nameof(TblProducto.IdSubCategoria)]),
                        NombreProducto = reader[nameof(TblProducto.NombreProducto)].ToString(),
                        Descripcion = reader[nameof(TblProducto.Descripcion)].ToString(),
                        Estado = reader[nameof(TblProducto.Estado)].ToString()
                    });
                }
            }
            return result;
        }

        public TblProducto Post(TblProducto producto)
        {
            var command = CreateCommand($"INSERT INTO Tbl_Producto(NombreProducto,Descripcion, IdSubCategoria, Estado) output INSERTED.ID values (@nombre,@desc,@idsub, @act)");
            command.Parameters.AddWithValue("@nombre", producto.NombreProducto);
            command.Parameters.AddWithValue("@desc", producto.Descripcion);
            command.Parameters.AddWithValue("@idsub", producto.IdSubCategoria);
            command.Parameters.AddWithValue("@act", producto.Estado);

            producto.Id = Convert.ToInt32(command.ExecuteScalar());
            return producto;
        }

        public TblProducto Update(TblProducto producto)
        {
            var command = CreateCommand($"update Tbl_Producto set NombreProducto=@nombre,Descripcion=@desc, IdSubCategoria = @idsub, Estado =@act where Id = @Id");
            command.Parameters.AddWithValue("@nombre", producto.NombreProducto);
            command.Parameters.AddWithValue("@desc", producto.Descripcion);
            command.Parameters.AddWithValue("@idsub", producto.IdSubCategoria);
            command.Parameters.AddWithValue("@act", producto.Estado);
            command.Parameters.AddWithValue("@Id", producto.Id);

            command.ExecuteNonQuery();
            return producto;
        }

        public void Delete(int Id)
        {
            var command = CreateCommand($"delete from Tbl_Producto where Id = @Id");
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }

    }
}
