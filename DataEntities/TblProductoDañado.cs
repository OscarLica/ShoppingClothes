// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DataEntities
{
    public partial class TblProductoDañado
    {
        public int IdProdDañado { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int? IdAlmacenProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? Cantidad { get; set; }
        public string Descripcion { get; set; }

        public virtual TblAlmacenProducto IdAlmacenProductoNavigation { get; set; }
        public virtual TblTipoMovimiento IdTipoMovimientoNavigation { get; set; }
    }
}