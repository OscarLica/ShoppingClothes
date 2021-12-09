using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IRepositoryReport
    {
        List<ReporteProductos> ReportProductosMasBendidos();
        List<ReporteProductos> ReportProductosMenosBendidos();
        List<ReporteProductos> ReportProductosDaniados();
    }
    public class RepositoryReport : Repository, IRepositoryReport
    {
        public RepositoryReport(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public List<ReporteProductos> ReportProductosDaniados()
        {
            var result = new List<ReporteProductos>();
            var command = CreateCommand(@"select v.NumeroFactura, t.IdProductoTaller as Id, pr.NombreProducto as Producto,marca.Nombre as Marca, talla.Nombre as Talla, color.Nombre as Color, T.DescripcionIngreso, T.DescripcionSalida, T.FechaIngreso, T.FechaSalida from Tbl_Producto_Taller t
JOIN Tbl_Almacen_Producto al on t.IdProductoAlmacen = al.IdAlmacenProducto
JOIN Tbl_Ventas v on t.IdVenta = v.IdVenta
JOIN Tbl_Producto pr on al.IdProducto = pr.Id
JOIN Cat_Marca marca on al.IdMarca = marca.Id
JOIN Cat_Talla talla on al.IdTalla = talla.Id
JOIN Cat_Color color on al.IdColor = color.Id");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new ReporteProductos
                    {
                        Id = Convert.ToInt32(reader[nameof(ReporteProductos.Id)]),
                        NumeroFactura = Convert.ToString(reader[nameof(ReporteProductos.NumeroFactura)]),
                        Producto = reader[nameof(ReporteProductos.Producto)].ToString(),
                        Marca = reader[nameof(ReporteProductos.Marca)].ToString(),
                        Talla = reader[nameof(ReporteProductos.Talla)].ToString(),
                        Color = reader[nameof(ReporteProductos.Color)].ToString(),
                        DescripcionIngreso = reader[nameof(ReporteProductos.DescripcionIngreso)]?.ToString() ?? string.Empty,
                        DescripcionSalida = reader[nameof(ReporteProductos.DescripcionSalida)]?.ToString() ?? string.Empty,
                        FechaIngreso = reader[nameof(ReporteProductos.FechaIngreso)] == DBNull.Value ? null  : Convert.ToDateTime(reader[nameof(ReporteProductos.FechaIngreso)]),
                        FechaSalida = reader[nameof(ReporteProductos.FechaSalida)] == DBNull.Value ? null : Convert.ToDateTime(reader[nameof(ReporteProductos.FechaSalida)]),
                    });
                }
            }


            return result;

        }

        public List<ReporteProductos> ReportProductosMasBendidos()
        {
            var result = new List<ReporteProductos>();
            var command = CreateCommand(@"SELECT pr.NombreProducto as Producto,marca.Nombre as Marca, talla.Nombre as Talla, color.Nombre as Color, dv.Cantidad , dv.Total FROM Tbl_Detalle_Venta dv
                                            JOIN Tbl_Almacen_Producto ap on dv.IdAlmacenProducto = ap.IdAlmacenProducto
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
                        Cantidad = Convert.ToInt32(reader[nameof(ReporteProductos.Cantidad)]),
                        Total = Convert.ToDecimal(reader[nameof(ReporteProductos.Total)]),
                    });
                }
            }

            var group = (from produco in result
                         group produco by new { produco.Producto, produco.Marca, produco.Talla, produco.Color }
                          into grupoP
                         select new ReporteProductos
                         {
                             Producto = grupoP.Key.Producto,
                             Marca = grupoP.Key.Marca,
                             Talla = grupoP.Key.Talla,
                             Color = grupoP.Key.Talla,
                             Cantidad = grupoP.Sum(x => x.Cantidad),
                             Total = grupoP.Sum(x => x.Total)
                         }).OrderByDescending(x => x.Cantidad);

            return result;
        }

        public List<ReporteProductos> ReportProductosMenosBendidos()
        {
            var result = new List<ReporteProductos>();
            var command = CreateCommand(@"SELECT pr.NombreProducto as Producto,marca.Nombre as Marca, talla.Nombre as Talla, color.Nombre as Color, dv.Cantidad , dv.Total FROM Tbl_Detalle_Venta dv
                                            JOIN Tbl_Almacen_Producto ap on dv.IdAlmacenProducto = ap.IdAlmacenProducto
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
                        Cantidad = Convert.ToInt32(reader[nameof(ReporteProductos.Cantidad)]),
                        Total = Convert.ToDecimal(reader[nameof(ReporteProductos.Total)]),
                    });
                }
            }

            var group = (from produco in result
                         group produco by new { produco.Producto, produco.Marca, produco.Talla, produco.Color }
                          into grupoP
                         select new ReporteProductos
                         {
                             Producto = grupoP.Key.Producto,
                             Marca = grupoP.Key.Marca,
                             Talla = grupoP.Key.Talla,
                             Color = grupoP.Key.Talla,
                             Cantidad = grupoP.Sum(x => x.Cantidad),
                             Total = grupoP.Sum(x => x.Total)
                         }).OrderBy(x => x.Cantidad);

            return result;
        }

    }
}
