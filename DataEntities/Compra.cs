using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class Compra
    {
        public int IdAlmacen { get; set; }
        public int IdCompra { get; set; }
        public int? IdUsuario { get; set; }
        public string UserName { get; set; }
        public int? IdProveedor { get; set; }
        public string Compania { get; set; }
        public DateTime? FechaCompra { get; set; }
        public string NoFactura { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
        public string Estado { get; set; }
        public List<Detalle> detalle { get; set; } = new List<Detalle>();
    }

    public class Detalle  {

        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Total { get; set; }
        public int IdMarca{ get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public int IdColor{ get; set; }
        public int IdTalla{ get; set; }
        public string Talla { get; set; }
        public decimal Unidad{ get; set; }
        public decimal PrecioVenta { get; set; }
        public string Almacen{ get; set; }

    }
}
