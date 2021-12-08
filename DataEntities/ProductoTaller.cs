using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class ProductoTaller
    {
        public int IdProductoTaller { get; set; }
        public int IdProductoAlmacen { get; set; }
        public int IdVenta { get; set; }
        public string DescripcionIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string DescripcionSalida { get; set; }
    }
}
