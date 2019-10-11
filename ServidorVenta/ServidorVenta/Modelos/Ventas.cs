using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorVenta.Modelos
{
    public class Ventas
    {
        public String folio { get; set; }
        public String fecha { get; set; }
        public Decimal total { get; set; }
        public Decimal iva { get; set; }
        public Decimal subtotal { get; set; }
        public String caja { get; set; }
        public int idEmpelado { get; set; }
    }
}
