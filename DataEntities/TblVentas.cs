﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DataEntities
{
    public partial class TblVentas
    {
        public TblVentas()
        {
            TblDetalleVenta = new HashSet<TblDetalleVenta>();
            TblDevoluciones = new HashSet<TblDevoluciones>();
        }

        public int IdVenta { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPromocion { get; set; }
        public string NumeroFactura { get; set; }
        public string NombreCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Iva { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Total { get; set; }
        public decimal? PagoEfectivo { get; set; }
        public decimal? Cambio { get; set; }
        public string Anular { get; set; }

        public virtual TblPromocion IdPromocionNavigation { get; set; }
        public virtual SesionUsuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<TblDetalleVenta> TblDetalleVenta { get; set; }
        public virtual ICollection<TblDevoluciones> TblDevoluciones { get; set; }
    }
}