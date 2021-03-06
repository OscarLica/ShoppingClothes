// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DataEntities
{
    public partial class TblCompras
    {
        public TblCompras()
        {
            TblDetalleCompra = new HashSet<TblDetalleCompra>();
        }

        public int IdCompra { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdProveedor { get; set; }
        public DateTime? FechaCompra { get; set; }
        public string NoFactura { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
        public string Estado { get; set; }

        public virtual CatProveedor IdProveedorNavigation { get; set; }
        public virtual SesionUsuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<TblDetalleCompra> TblDetalleCompra { get; set; }
    }
}