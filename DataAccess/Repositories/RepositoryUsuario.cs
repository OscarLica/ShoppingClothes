using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryUsuario
    {
        void InsertUsuario(string correo, string password);
        int GetIdUsuarioByUserSesion(string userId);
    }
    public class RepositoryUsuario : Repository, IRepositoryUsuario
    {
        public RepositoryUsuario(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public int GetIdUsuarioByUserSesion(string userId)
        {
            var command = CreateCommand("SELECT * FROM [SesionUsuarios] WITH(NOLOCK) WHERE Email = @email");

            command.Parameters.AddWithValue("@email", userId);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return Convert.ToInt32(reader["IdUsuario"]);
            }
        }
        public void InsertUsuario(string correo, string password)
        {

            var command = CreateCommand($"INSERT INTO [RegistroPersona](PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Direccion,Telefono,Email) " +
                $"output INSERTED.IdRegistroPersona values (@correo, '','','','','',@correo)");
            command.Parameters.AddWithValue("@correo", correo);

            var commandSesion = CreateCommand($"INSERT INTO [SesionUsuarios](IdRegistroPersona,Email,Contraseña) " +
                $"output INSERTED.IdUsuario values (@IdRegistro, @correo, @Contraseña)");

            var Id = Convert.ToInt32(command.ExecuteScalar());

            commandSesion.Parameters.AddWithValue("@IdRegistro", Id);
            commandSesion.Parameters.AddWithValue("@correo", correo);
            commandSesion.Parameters.AddWithValue("@Contraseña", password);

           var result = commandSesion.ExecuteScalar();
        }
    }
}
