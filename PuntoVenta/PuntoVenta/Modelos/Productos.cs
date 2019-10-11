using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.Modelos
{
   public class Productos
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string  foto { get; set; }
        public int  idcategoria { get; set; }
    }
}
