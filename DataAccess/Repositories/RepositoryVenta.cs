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
        TblVentas Post(TblVentas tblVentas, string user);
        ProductoTaller ProductoTaller(ProductoTaller productoTaller);
        List<ReporteProductos> GetProductoTallerSalida();
        ProductoTaller ProductoTallerSalida(ProductoTaller productoTaller);
    }
    public class RepositoryVenta : Repository, IRepositoryVenta
    {
        private readonly IRepositoryUsuario repositoryUsuario;
        public RepositoryVenta(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
            repositoryUsuario = new RepositoryUsuario(context, transaction);
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
            var command = CreateCommand(@$"select c.*, pr.Id as IdProducto, pr.NombreProducto, m.Nombre as Marca, t.Nombre as Talla, co.Nombre as Color, ap.PrecioVenta, case when (select count(*) from tbl_producto_taller t where t.IdProductoAlmacen = c.IdAlmacenProducto and t.IdVenta = c.IdVenta and t.FechaSalida is null) >= 1 then 1 else 0 end  as IsReported from Tbl_Detalle_Venta c
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
                        IdAlmacenProducto= Convert.ToInt32(reader[nameof(Detalle.IdAlmacenProducto)]),
                        Cantidad = Convert.ToInt32(reader[nameof(Detalle.Cantidad)]),
                        NombreProducto = Convert.ToString(reader[nameof(Detalle.NombreProducto)]),
                        SubTotal = Convert.ToDecimal(reader[nameof(Detalle.SubTotal)]),
                        Descuento = Convert.ToDecimal(reader[nameof(Detalle.Descuento)]),
                        Total = Convert.ToDecimal(reader[nameof(Detalle.Total)]),
                        PrecioVenta = Convert.ToDecimal(reader[nameof(Detalle.PrecioVenta)]),
                        Marca = Convert.ToString(reader[nameof(Detalle.Marca)]),
                        Color = Convert.ToString(reader[nameof(Detalle.Color)]),
                        Talla = Convert.ToString(reader[nameof(Detalle.Talla)]),
                        IsReported = Convert.ToBoolean(reader[nameof(Detalle.IsReported)]),

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
                        UserName = Convert.ToString(reader[nameof(TblVentas.UserName)]),
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

        public TblVentas Post(TblVentas tblVentas, string user)
        {

            var command = CreateCommand($"INSERT INTO Tbl_Ventas (IdUsuario, IdPromocion, NumeroFactura, NombreCliente, Fecha, IVA, SubTotal, Descuento, Total, PagoEfectivo, Cambio, Anular)  output INSERTED.IdVenta values" +
                                   $" (@IdUsuario, @IdPro,@NoFactura,@Cliente, @Fecha,@Iva, @SubTotal, @Descuento, @Total, @PagoEfectivo, @Cambio, @Anular)");

            var Idusuario = repositoryUsuario.GetIdUsuarioByUserSesion(user);

            command.Parameters.AddWithValue("@IdUsuario", Idusuario);
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

        public ProductoTaller ProductoTaller(ProductoTaller productoTaller)
        {
            var command = CreateCommand($"INSERT INTO Tbl_Producto_Taller (IdProductoAlmacen, IdVenta, DescripcionIngreso, FechaIngreso) output INSERTED.IdProductoTaller VALUES " +
                                  $" (@IdProductoAlmacen, @IdVenta,@Descripcion,@FechaIngreso)");

            command.Parameters.AddWithValue("@IdProductoAlmacen",productoTaller.IdProductoAlmacen);
            command.Parameters.AddWithValue("@IdVenta", productoTaller.IdVenta);
            command.Parameters.AddWithValue("@Descripcion", productoTaller.DescripcionIngreso);
            command.Parameters.AddWithValue("@FechaIngreso", DateTime.Now);

            productoTaller.IdProductoTaller = Convert.ToInt32(command.ExecuteScalar());
            return productoTaller;
        }

        public ProductoTaller ProductoTallerSalida(ProductoTaller productoTaller)
        {
            var command = CreateCommand($"UPDATE Tbl_Producto_Taller SET FechaSalida=@FechaSalida, DescripcionSalida=@Descripcion WHERE IdProductoTaller=@Id");

            command.Parameters.AddWithValue("@Id", productoTaller.IdProductoTaller);
            
            command.Parameters.AddWithValue("@Descripcion", productoTaller.DescripcionSalida);
            command.Parameters.AddWithValue("@FechaSalida", DateTime.Now);
            command.ExecuteNonQuery();
            return productoTaller;
        }

        public List<ReporteProductos> GetProductoTallerSalida()
        {
            var result = new List<ReporteProductos>();
            var command = CreateCommand($@"SELECT pr.NombreProducto as Producto,marca.Nombre as Marca, talla.Nombre as Talla, color.Nombre as Color, dv.DescripcionIngreso, dv.DescripcionSalida, dv.FechaIngreso, dv.FechaSalida
                                            FROM Tbl_Producto_Taller dv
                                            JOIN Tbl_Almacen_Producto ap on dv.IdProductoAlmacen = ap.IdAlmacenProducto
                                            JOIN Tbl_Producto pr on ap.IdProducto = pr.Id
                                            JOIN Cat_Marca marca on ap.IdMarca = marca.Id
                                            JOIN Cat_Talla talla on ap.IdTalla = talla.Id
                                            JOIN Cat_Color color on ap.IdColor = color.Id");


            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new ReporteProductos
                    {
                        Producto = reader[nameof(ReporteProductos.Producto)].ToString(),
                        Marca = reader[nameof(ReporteProductos.Marca)].ToString(),
                        Talla = reader[nameof(ReporteProductos.Talla)].ToString(),
                        Color = reader[nameof(ReporteProductos.Color)].ToString(),
                        DescripcionIngreso = reader[nameof(ReporteProductos.DescripcionIngreso)].ToString(),
                        DescripcionSalida = reader[nameof(ReporteProductos.DescripcionSalida)].ToString(),
                        FechaIngreso = Convert.ToDateTime(reader[nameof(ReporteProductos.FechaIngreso)]),
                        FechaSalida = Convert.ToDateTime(reader[nameof(ReporteProductos.FechaSalida)]),
                    });
                }
            }


            return result;
        }
    }
}
