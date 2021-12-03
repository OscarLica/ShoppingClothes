using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryCompra
    {

        List<Compra> GetAll();
        List<Detalle> GetDetalleById(int IdCompra);
        List<Detalle> GetProductosComprados();
        Compra Post(Compra almacen);
        Compra Update(Compra almacen);
        Compra Get(int Id);
        void Delete(int Id);
    }
    public class RepositoryCompra : Repository, IRepositoryCompra
    {
        public RepositoryCompra(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Compra Get(int Id)
        {
            var command = CreateCommand(@$"SELECT c.*, p.NombreCompañia as Compania, CONCAT(r.PrimerNombre,' ', r.PrimerApellido) as UserName FROM Tbl_Compras c
                                           JOIN Cat_Proveedor p on c.IdProveedor = p.Id
										   JOIN SesionUsuarios s on c.IdUsuario = s.IdUsuario
										   JOIN RegistroPersona r on s.IdRegistroPersona = r.IdRegistroPersona where c.IdCompra = @Id");

            command.Parameters.AddWithValue("@Id", Id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Compra
                {
                    IdCompra = Convert.ToInt32(reader[nameof(Compra.IdCompra)]),
                    IdUsuario = Convert.ToInt32(reader[nameof(Compra.IdUsuario)]),
                    UserName = Convert.ToString(reader[nameof(Compra.UserName)]),
                    IdProveedor = Convert.ToInt32(reader[nameof(Compra.IdProveedor)]),
                    Compania = Convert.ToString(reader[nameof(Compra.Compania)]),
                    FechaCompra = Convert.ToDateTime(reader[nameof(Compra.FechaCompra)]),
                    NoFactura = reader[nameof(Compra.NoFactura)].ToString(),
                    SubTotal = Convert.ToDecimal(reader[nameof(Compra.SubTotal)]),
                    Descuento = Convert.ToDecimal(reader[nameof(Compra.Descuento)]),
                    Iva = Convert.ToDecimal(reader[nameof(Compra.Iva)]),
                    Total = Convert.ToDecimal(reader[nameof(Compra.Total)]),
                    Estado = reader[nameof(Compra.Estado)].ToString(),
                    detalle = GetDetalleById(Convert.ToInt32(reader[nameof(Compra.IdCompra)]))
                };
            }

        }

        public List<Compra> GetAll()
        {
            var result = new List<Compra>();
            var command = CreateCommand(@$"SELECT c.*, p.NombreCompañia as Compania, CONCAT(r.PrimerNombre,' ', r.PrimerApellido) as UserName FROM Tbl_Compras c
                                           JOIN Cat_Proveedor p on c.IdProveedor = p.Id
										   JOIN SesionUsuarios s on c.IdUsuario = s.IdUsuario
										   JOIN RegistroPersona r on s.IdRegistroPersona = r.IdRegistroPersona");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Compra
                    {
                        IdCompra = Convert.ToInt32(reader[nameof(Compra.IdCompra)]),
                        IdUsuario = Convert.ToInt32(reader[nameof(Compra.IdUsuario)]),
                        UserName = Convert.ToString(reader[nameof(Compra.UserName)]),
                        IdProveedor = Convert.ToInt32(reader[nameof(Compra.IdProveedor)]),
                        Compania = Convert.ToString(reader[nameof(Compra.Compania)]),
                        FechaCompra = Convert.ToDateTime(reader[nameof(Compra.FechaCompra)]),
                        NoFactura = reader[nameof(Compra.NoFactura)].ToString(),
                        SubTotal = Convert.ToDecimal(reader[nameof(Compra.SubTotal)]),
                        Descuento = Convert.ToDecimal(reader[nameof(Compra.Descuento)]),
                        Iva = Convert.ToDecimal(reader[nameof(Compra.Iva)]),
                        Total = Convert.ToDecimal(reader[nameof(Compra.Total)]),
                        Estado = reader[nameof(Compra.Estado)].ToString()
                    });
                }
            }

            foreach (var item in result)
                item.detalle = GetDetalleById(item.IdCompra);

            return result;
        }

        public List<Detalle> GetDetalleById(int IdCompra)
        {
            var result = new List<Detalle>();
            var command = CreateCommand(@$"select c.*, p.NombreProducto, m.Nombre as Marca, t.Nombre as Talla, co.Nombre as Color, alm.Nombre as Almacen,ap.PrecioVenta from Tbl_Detalle_Compra c
                                            JOIN Tbl_Producto p on c.IdProducto = p.Id
                                            JOIN Tbl_Almacen_Producto ap on p.Id = ap.IdProducto and ap.IdCompra = c.IdCompra
                                            JOIN Cat_Almacen alm on ap.IdAlmacen = alm.Id
                                            JOIN Cat_Marca m on ap.IdMarca = m.Id
                                            JOIN Cat_Talla t on ap.IdTalla = t.Id
                                            JOIN Cat_Color co on ap.IdColor = co.Id where c.IdCompra =@Id");

            command.Parameters.AddWithValue("@Id", IdCompra);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Detalle
                    {
                        IdProducto = Convert.ToInt32(reader[nameof(Detalle.IdProducto)]),
                        Cantidad = Convert.ToInt32(reader[nameof(Detalle.Cantidad)]),
                        PrecioCompra = Convert.ToDecimal(reader[nameof(Detalle.PrecioCompra)]),
                        NombreProducto = Convert.ToString(reader[nameof(Detalle.NombreProducto)]),
                        Almacen = Convert.ToString(reader[nameof(Detalle.Almacen)]),
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

        public List<Detalle> GetProductosComprados()
        {
            var result = new List<Detalle>();
            var command = CreateCommand(@$"select c.*, p.NombreProducto, m.Nombre as Marca, t.Nombre as Talla, co.Nombre as Color, alm.Nombre as Almacen, ap.PrecioVenta, ap.Cantidad from Tbl_Detalle_Compra c
                                            JOIN Tbl_Producto p on c.IdProducto = p.Id
                                            JOIN Tbl_Almacen_Producto ap on p.Id = ap.IdProducto and ap.IdCompra = c.IdCompra
                                            JOIN Cat_Almacen alm on ap.IdAlmacen = alm.Id
                                            JOIN Cat_Marca m on ap.IdMarca = m.Id
                                            JOIN Cat_Talla t on ap.IdTalla = t.Id
                                            JOIN Cat_Color co on ap.IdColor = co.Id");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Detalle
                    {
                        IdProducto = Convert.ToInt32(reader[nameof(Detalle.IdProducto)]),
                        Cantidad = Convert.ToInt32(reader[nameof(Detalle.Cantidad)]),
                        PrecioCompra = Convert.ToDecimal(reader[nameof(Detalle.PrecioCompra)]),
                        NombreProducto = Convert.ToString(reader[nameof(Detalle.NombreProducto)]),
                        Almacen = Convert.ToString(reader[nameof(Detalle.Almacen)]),
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

            result = (from r in result
                      group r by new { r.IdProducto, r.NombreProducto, r.Marca, r.Talla, r.Color, r.PrecioVenta }
                      into grupoP
                      select new Detalle
                      {
                          IdProducto = grupoP.Key.IdProducto,
                          NombreProducto = grupoP.Key.NombreProducto,
                          Cantidad = grupoP.FirstOrDefault(x => x.NombreProducto == grupoP.Key.NombreProducto && x.Talla == grupoP.Key.Talla && x.Color == grupoP.Key.Color && x.Marca == grupoP.Key.Marca && x.PrecioVenta == grupoP.Key.PrecioVenta )?.Cantidad,
                          Marca = grupoP.Key.Marca,
                          Talla = grupoP.Key.Talla,
                          Color = grupoP.Key.Color,
                          PrecioVenta = grupoP.Key.PrecioVenta
                      }).ToList();
            return result;
        }

        public Compra Post(Compra compra)
        {
            var command = CreateCommand($"INSERT INTO Tbl_Compras (IdUsuario, IdProveedor, FechaCompra, NoFactura, SubTotal, Descuento, Iva, Total, Estado)  output INSERTED.IdCompra values" +
                                    $" (@IdUsuario, @IdPro, @Fecha,@NoFactura, @SubTotal, @Descuento, @Iva, @Total, @Estado)");
            command.Parameters.AddWithValue("@IdUsuario", 1);
            command.Parameters.AddWithValue("@IdPro", compra.IdProveedor);
            command.Parameters.AddWithValue("@Fecha", compra.FechaCompra);
            command.Parameters.AddWithValue("@NoFactura", compra.NoFactura ?? "01");
            command.Parameters.AddWithValue("@SubTotal", compra.SubTotal ?? default);
            command.Parameters.AddWithValue("@Descuento", compra.Descuento ?? default);
            command.Parameters.AddWithValue("@Iva", compra.Iva ?? default);
            command.Parameters.AddWithValue("@Total", compra.Total ?? default);
            command.Parameters.AddWithValue("@Estado", "");

            compra.IdCompra = Convert.ToInt32(command.ExecuteScalar());


            foreach (var item in compra.detalle)
            {
                var commandDet = CreateCommand($"INSERT INTO Tbl_Detalle_Compra (IdCompra, IdProducto, Producto, Descripcion, Cantidad, PrecioCompra, SubTotal, Descuento, Total) values" +
                                   $" (@IdCompra, @IdProducto, @Producto,@Descripcion, @Cantidad, @PCompra, @SubTotal, @Desc, @Total)");

                commandDet.Parameters.AddWithValue("@IdCompra", compra.IdCompra);
                commandDet.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                commandDet.Parameters.AddWithValue("@Producto", "");
                commandDet.Parameters.AddWithValue("@Descripcion", "");
                commandDet.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                commandDet.Parameters.AddWithValue("@PCompra", item.PrecioCompra);
                commandDet.Parameters.AddWithValue("@SubTotal", item.SubTotal);
                commandDet.Parameters.AddWithValue("@Desc", compra.Descuento);
                commandDet.Parameters.AddWithValue("@Total", item.SubTotal);
                commandDet.ExecuteScalar();

                var comandInsertAlm = CreateCommand($"insert into Tbl_Almacen_Producto(IdAlmacen, IdProducto, IdMarca, IdTalla, IdColor, NombreProducto, DescripcionArticulo, PrecioUnitario, Cantidad, PrecioVenta, Unidades, UnidadesTotales, IdCompra)" +
                    $"  values(@IdAlmacen, @IdProducto, @IdMarca, @IdTalla, @IdColor, @NombreProducto, @DescripcionArticulo, @PrecioUnitario, @Cantidad, @PrecioVenta, @Unidades, @UnidadesTotales, @IdCompra)");
                comandInsertAlm.Parameters.AddWithValue("@IdAlmacen", compra.IdAlmacen);
                comandInsertAlm.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                comandInsertAlm.Parameters.AddWithValue("@IdMarca", item.IdMarca);
                comandInsertAlm.Parameters.AddWithValue("@IdTalla", item.IdTalla);
                comandInsertAlm.Parameters.AddWithValue("@IdColor", item.IdColor);
                comandInsertAlm.Parameters.AddWithValue("@NombreProducto", "");
                comandInsertAlm.Parameters.AddWithValue("@DescripcionArticulo", "");
                comandInsertAlm.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                comandInsertAlm.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                comandInsertAlm.Parameters.AddWithValue("@PrecioVenta", item.PrecioVenta);
                comandInsertAlm.Parameters.AddWithValue("@Unidades", item.Cantidad);
                comandInsertAlm.Parameters.AddWithValue("@UnidadesTotales", item.Cantidad);
                comandInsertAlm.Parameters.AddWithValue("@IdCompra", compra.IdCompra);

                comandInsertAlm.ExecuteScalar();



            }

            return compra;
        }

        public Compra Update(Compra almacen)
        {
            throw new NotImplementedException();
        }
    }
}
