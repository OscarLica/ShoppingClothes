using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities.DTO
{
    public class Inventario
    {
        public string NoFactura{ get; set; }
        public DateTime Fecha{ get; set; }
        public string NombreProducto{ get; set; }
        public string Marca{ get; set; }
        public string Talla{ get; set; }
        public string Color{ get; set; }
        public decimal Precio{ get; set; }
        public int Cantidad{ get; set; }
    }
}
