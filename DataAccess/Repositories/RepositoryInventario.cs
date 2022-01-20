using DataEntities.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryInventario
    {
        List<Inventario> InventarioCompras();
        List<Inventario> InventarioVentas();
        List<Inventario> InventarioGeneral();
    }
    public class RepositoryInventario : Repository, IRepositoryInventario
    {
        public RepositoryInventario(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public List<Inventario> InventarioCompras()
        {
            var result = new List<Inventario>();
            var command = CreateCommand(@"Select com.NoFactura, com.FechaCompra as Fecha, p.NombreProducto, m.Nombre as Marca, t.Nombre as Talla, co.Nombre as Color, c.PrecioCompra as Precio, c.Cantidad from Tbl_Detalle_Compra c
                                            JOIN Tbl_Compras com on c.IdCompra = com.IdCompra
                                            JOIN Tbl_Almacen_Producto ap on c.IdCompra = ap.IdCompra
                                            JOIN Tbl_Producto  p on ap.IdProducto = p.Id
                                            JOIN Cat_Marca m on ap.IdMarca = m.Id
                                            JOIN Cat_Talla t on ap.IdTalla = t.Id
                                            JOIN Cat_Color co on ap.IdColor = co.Id");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Inventario
                    {
                        NoFactura = reader[nameof(Inventario.NoFactura)].ToString(),
                        Fecha = Convert.ToDateTime(reader[nameof(Inventario.Fecha)]),
                        NombreProducto = reader[nameof(Inventario.NombreProducto)].ToString(),
                        Marca = reader[nameof(Inventario.Marca)].ToString(),
                        Talla = reader[nameof(Inventario.Talla)].ToString(),
                        Color = reader[nameof(Inventario.Color)].ToString(),
                        Precio = Convert.ToDecimal(reader[nameof(Inventario.Precio)]),
                        Cantidad = Convert.ToInt32(reader[nameof(Inventario.Cantidad)])
                    });
                }
            }
            return result;
        }

        public List<Inventario> InventarioVentas()
        {
            var result = new List<Inventario>();
            var command = CreateCommand(@"Select v.NumeroFactura as NoFactura, v.Fecha,p.NombreProducto, m.Nombre as Marca, t.Nombre as Talla, co.Nombre as Color, dv.Precio, dv.Cantidad
                                            from Tbl_Detalle_Venta dv
                                            JOIN Tbl_Ventas v on dv.IdVenta = v.IdVenta
                                            JOIN Tbl_Almacen_Producto ap on dv.IdAlmacenProducto = ap.IdAlmacenProducto
                                            JOIN Tbl_Producto  p on ap.IdProducto = p.Id
                                            JOIN Cat_Marca m on ap.IdMarca = m.Id
                                            JOIN Cat_Talla t on ap.IdTalla = t.Id
                                            JOIN Cat_Color co on ap.IdColor = co.Id");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Inventario
                    {
                        NoFactura = reader[nameof(Inventario.NoFactura)].ToString(),
                        Fecha = Convert.ToDateTime(reader[nameof(Inventario.Fecha)]),
                        NombreProducto = reader[nameof(Inventario.NombreProducto)].ToString(),
                        Marca = reader[nameof(Inventario.Marca)].ToString(),
                        Talla = reader[nameof(Inventario.Talla)].ToString(),
                        Color = reader[nameof(Inventario.Color)].ToString(),
                        Precio = Convert.ToDecimal(reader[nameof(Inventario.Precio)]),
                        Cantidad = Convert.ToInt32(reader[nameof(Inventario.Cantidad)])
                    });
                }
            }
            return result;
        }

        public List<Inventario> InventarioGeneral()
        {
            var result = new List<Inventario>();
            var command = CreateCommand(@"Select p.NombreProducto, m.Nombre as Marca, t.Nombre as Talla, co.Nombre as Color, ap.Cantidad, ap.PrecioVenta as Precio
                                        from Tbl_Almacen_Producto ap
                                        JOIN Tbl_Producto  p on ap.IdProducto = p.Id
                                        JOIN Cat_Marca m on ap.IdMarca = m.Id
                                        JOIN Cat_Talla t on ap.IdTalla = t.Id
                                        JOIN Cat_Color co on ap.IdColor = co.Id");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Inventario
                    {
                        
                        NombreProducto = reader[nameof(Inventario.NombreProducto)].ToString(),
                        Marca = reader[nameof(Inventario.Marca)].ToString(),
                        Talla = reader[nameof(Inventario.Talla)].ToString(),
                        Color = reader[nameof(Inventario.Color)].ToString(),
                        Precio = Convert.ToDecimal(reader[nameof(Inventario.Precio)]),
                        Cantidad = Convert.ToInt32(reader[nameof(Inventario.Cantidad)])
                    });
                }
            }
            return result;
        }
    }
}
