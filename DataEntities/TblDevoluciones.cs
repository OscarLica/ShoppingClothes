// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DataEntities
{
    public partial class TblDevoluciones
    {
        public int IdProdDev { get; set; }
        public int? IdProducto { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVenta { get; set; }
        public DateTime? FechaDeDevolucion { get; set; }
        public string NoFactura { get; set; }
        public int? Cantidad { get; set; }
        public string Descripcion { get; set; }

        public virtual TblProducto IdProductoNavigation { get; set; }
        public virtual TblVentas IdVentaNavigation { get; set; }
    }
}