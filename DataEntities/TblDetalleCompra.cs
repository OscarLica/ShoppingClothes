// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DataEntities
{
    public partial class TblDetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Total { get; set; }

        public virtual TblCompras IdCompraNavigation { get; set; }
        public virtual TblProducto IdProductoNavigation { get; set; }
    }
}