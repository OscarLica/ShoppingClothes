﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DataEntities
{
    public partial class CatTalla
    {
        public CatTalla()
        {
            TblAlmacenProducto = new HashSet<TblAlmacenProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<TblAlmacenProducto> TblAlmacenProducto { get; set; }
    }
}