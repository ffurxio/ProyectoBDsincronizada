using PuntoVenta.DAOS;
using PuntoVenta.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta.Vistas
{
    public partial class verProductos : Form
    {
        public verProductos()
        {
            InitializeComponent();
            DaoProductos dp = new DaoProductos();
            gridProductos.DataSource = dp.ObtenerProductos();
        }

        private void verProductos_Load(object sender, EventArgs e)
        {

        }

       
    }
}
