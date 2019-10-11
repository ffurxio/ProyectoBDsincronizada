using ServidorVenta.DAOS;
using ServidorVenta.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServidorVenta.Vistas
{
    public partial class actualizar : Form
    {
        public actualizar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prgb.Minimum = 0;
            DaoVentas dv = new DaoVentas();
            List<Ventas> listaVentas = new List<Ventas>();
            listaVentas = dv.importarVentas();
            if (dv.agregarVentasImportadas(listaVentas))
            {
                MessageBox.Show("Exito");
            }
            else {
                MessageBox.Show("Sin Exito");
            }
        }
    }
}
