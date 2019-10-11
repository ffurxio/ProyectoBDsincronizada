using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Modelos
{
    public class Ventas
    {

        public int folio { get; set; }
        public string fecha { get; set; }
        public double total { get; set; }
        public double iva { get; set; }
        public double subtotal { get; set; }
        public string caja { get; set; }
        public int idEmpleado { get; set; }

    }
}
