using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryVenta {
        List<TblVentas> GetAll();
        TblVentas Get(int Id);
        TblVentas Post(TblVentas tblVentas);
    }
    public class RepositoryVenta : Repository, IRepositoryVenta
    {
        public RepositoryVenta(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public TblVentas Get(int Id)
        {
            var command = CreateCommand(@$"SELECT c.*, CONCAT(r.PrimerNombre,' ', r.PrimerApellido) as UserName FROM Tbl_Ventas c
										   JOIN SesionUsuarios s on c.IdUsuario = s.IdUsuario
										   JOIN RegistroPersona r on s.IdRegistroPersona = r.IdRegistroPersona where c.IdVenta = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new TblVentas
                {
                    IdVenta = Convert.ToInt32(reader[nameof(TblVentas.IdVenta)]),
                    IdUsuario = Convert.ToInt32(reader[nameof(TblVentas.IdUsuario)]),
                    IdPromocion = Convert.ToInt32(reader[nameof(TblVentas.IdPromocion)]),
                    NumeroFactura = Convert.ToString(reader[nameof(TblVentas.NumeroFactura)]),
                    NombreCliente = Convert.ToString(reader[nameof(TblVentas.NombreCliente)]),
                    Fecha = Convert.ToDateTime(reader[nameof(TblVentas.Fecha)]),
                    SubTotal = Convert.ToDecimal(reader[nameof(TblVentas.SubTotal)]),
                    Descuento = Convert.ToDecimal(reader[nameof(TblVentas.Descuento)]),
                    Iva = Convert.ToDecimal(reader[nameof(TblVentas.Iva)]),
                    Total = Convert.ToDecimal(reader[nameof(TblVentas.Total)]),
                    detalle = GetDetalleById(Convert.ToInt32(reader[nameof(TblVentas.IdVenta)]))
                };
            }

        }

        public List<Detalle> GetDetalleById(int IdCompra)
        {
            var result = new List<Detalle>();
            var command = CreateCommand(@$"select c.*, pr.Id as IdProducto, pr.NombreProducto, m.Nombre as Marca, t.Nombre as Talla, co.Nombre as Color, ap.PrecioVenta from Tbl_Detalle_Venta c
                                            JOIN Tbl_Almacen_Producto ap on c.IdAlmacenProducto = ap.IdAlmacenProducto
                                            JOIN Tbl_Producto pr on ap.IdProducto = pr.Id
                                            JOIN Cat_Marca m on ap.IdMarca = m.Id
                                            JOIN Cat_Talla t on ap.IdTalla = t.Id
                                            JOIN Cat_Color co on ap.IdColor = co.Id where c.IdVenta =@Id");

            command.Parameters.AddWithValue("@Id", IdCompra);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Detalle
                    {
                        IdProducto = Convert.ToInt32(reader[nameof(Detalle.IdProducto)]),
                        Cantidad = Convert.ToInt32(reader[nameof(Detalle.Cantidad)]),
                        NombreProducto = Convert.ToString(reader[nameof(Detalle.NombreProducto)]),
                        SubTotal = Convert.ToDecimal(reader[nameof(Detalle.SubTotal)]),
                        Descuento = Convert.ToDecimal(reader[nameof(Detalle.Descuento)]),
                        Total = Convert.ToDecimal(reader[nameof(Detalle.Total)]),
                        PrecioVenta = Convert.ToDecimal(reader[nameof(Detalle.PrecioVenta)]),
                        Marca = Convert.ToString(reader[nameof(Detalle.Marca)]),
                        Color = Convert.ToString(reader[nameof(Detalle.Color)]),
                        Talla = Convert.ToString(reader[nameof(Detalle.Talla)]),

                    });
                }
            }
            return result;
        }

        public List<TblVentas> GetAll()
        {

            var result = new List<TblVentas>();
            var command = CreateCommand(@$"SELECT c.*, CONCAT(r.PrimerNombre,' ', r.PrimerApellido) as UserName FROM Tbl_Ventas c
										   JOIN SesionUsuarios s on c.IdUsuario = s.IdUsuario
										   JOIN RegistroPersona r on s.IdRegistroPersona = r.IdRegistroPersona");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new TblVentas
                    {
                        IdVenta = Convert.ToInt32(reader[nameof(TblVentas.IdVenta)]),
                        IdUsuario = Convert.ToInt32(reader[nameof(TblVentas.IdUsuario)]),
                        IdPromocion = Convert.ToInt32(reader[nameof(TblVentas.IdPromocion)]),
                        NumeroFactura = Convert.ToString(reader[nameof(TblVentas.NumeroFactura)]),
                        NombreCliente = Convert.ToString(reader[nameof(TblVentas.NombreCliente)]),
                        Fecha = Convert.ToDateTime(reader[nameof(TblVentas.Fecha)]),
                        SubTotal = Convert.ToDecimal(reader[nameof(TblVentas.SubTotal)]),
                        Descuento = Convert.ToDecimal(reader[nameof(TblVentas.Descuento)]),
                        Iva = Convert.ToDecimal(reader[nameof(TblVentas.Iva)]),
                        Total = Convert.ToDecimal(reader[nameof(TblVentas.Total)]),
                    });
                }
            }

            //foreach (var item in result)
            //    item.detalle = GetDetalleById(item.IdCompra);

            return result;
        }

        public TblVentas Post(TblVentas tblVentas)
        {

            var command = CreateCommand($"INSERT INTO Tbl_Ventas (IdUsuario, IdPromocion, NumeroFactura, NombreCliente, Fecha, IVA, SubTotal, Descuento, Total, PagoEfectivo, Cambio, Anular)  output INSERTED.IdVenta values" +
                                   $" (@IdUsuario, @IdPro,@NoFactura,@Cliente, @Fecha,@Iva, @SubTotal, @Descuento, @Total, @PagoEfectivo, @Cambio, @Anular)");
            command.Parameters.AddWithValue("@IdUsuario", 1);
            command.Parameters.AddWithValue("@IdPro", 1);
            command.Parameters.AddWithValue("@NoFactura", tblVentas.NumeroFactura ?? "01");
            command.Parameters.AddWithValue("@Cliente", tblVentas.NombreCliente);
            command.Parameters.AddWithValue("@Fecha", DateTime.Now);
            command.Parameters.AddWithValue("@Iva", tblVentas.Iva ?? default);
            command.Parameters.AddWithValue("@SubTotal", tblVentas.SubTotal ?? default);
            command.Parameters.AddWithValue("@Descuento", tblVentas.Descuento ?? default);
            command.Parameters.AddWithValue("@Total", tblVentas.Total ?? default);
            command.Parameters.AddWithValue("@PagoEfectivo", 0);
            command.Parameters.AddWithValue("@Cambio", 0);
            command.Parameters.AddWithValue("@Anular", false);

            tblVentas.IdVenta = Convert.ToInt32(command.ExecuteScalar());

            foreach (var item in tblVentas.detalle)
            {
                var commandDet = CreateCommand($"INSERT INTO Tbl_Detalle_Venta (IdVenta, IdAlmacenProducto, Cantidad, Precio, SubTotal, Descuento, Total) values" +
                                   $" (@IdVenta, @IdAlmacenProducto, @Cantidad, @Precio, @SubTotal, @Desc, @Total)");

                var commandGetAlmacenProducto = CreateCommand(@$"select * from Tbl_Almacen_Producto ap
                                                    JOIN Tbl_Producto p on ap.IdProducto = p.Id
                                                    JOIN Cat_Marca m on ap.IdMarca = m.Id
                                                    JOIN Cat_Talla t on ap.IdTalla = t.Id
                                                    JOIN Cat_Color co on ap.IdColor = co.Id
                                                    WHERE p.NombreProducto = @producto AND m.Nombre = @marca AND T.Nombre = @talla AND CO.Nombre = @color AND ap.PrecioVenta = @pv ");

                commandGetAlmacenProducto.Parameters.AddWithValue("@producto", item.NombreProducto);
                commandGetAlmacenProducto.Parameters.AddWithValue("@marca", item.Marca);
                commandGetAlmacenProducto.Parameters.AddWithValue("@talla", item.Talla);
                commandGetAlmacenProducto.Parameters.AddWithValue("@color", item.Color);
                commandGetAlmacenProducto.Parameters.AddWithValue("@pv", item.PrecioVenta);

                var almacenProducto = new TblAlmacenProducto();

                using (var reader = commandGetAlmacenProducto.ExecuteReader())
                {
                    reader.Read();

                    almacenProducto = new TblAlmacenProducto
                    {
                        IdAlmacenProducto = Convert.ToInt32(reader[nameof(TblAlmacenProducto.IdAlmacenProducto)]),
                        Cantidad = Convert.ToInt32(reader[nameof(TblAlmacenProducto.Cantidad)]),
                    };
                }

                commandDet.Parameters.AddWithValue("@IdVenta", tblVentas.IdVenta);
                commandDet.Parameters.AddWithValue("@IdAlmacenProducto", almacenProducto.IdAlmacenProducto);
                commandDet.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                commandDet.Parameters.AddWithValue("@Precio", item.PrecioVenta);
                commandDet.Parameters.AddWithValue("@SubTotal", item.SubTotal);
                commandDet.Parameters.AddWithValue("@Desc", item.Descuento ?? default);
                commandDet.Parameters.AddWithValue("@Total", item.SubTotal);
                commandDet.ExecuteScalar();

                var commandUpdate = CreateCommand($"UPDATE Tbl_Almacen_Producto set Cantidad = (Cantidad - @cnt) WHERE IdAlmacenProducto = @Id");
                commandUpdate.Parameters.AddWithValue("@Id", almacenProducto.IdAlmacenProducto);
                commandUpdate.Parameters.AddWithValue("@cnt", item.Cantidad);
                commandUpdate.ExecuteScalar();
            }

            return tblVentas;
        }
    }
}
