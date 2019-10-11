using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Modelos
{
    public class DetalleVenta
    {
        
        public int folio { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public double importe { get; set; }

    }
}
