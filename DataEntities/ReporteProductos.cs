using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class ReporteProductos
    {
        public string Producto { get; set; }
        public string Marca { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string DescripcionIngreso{ get; set; }
        public string DescripcionSalida{ get; set; }
    }
}
