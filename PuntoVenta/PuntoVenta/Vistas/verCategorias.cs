using PuntoVenta.DAOS;
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
    public partial class verCategorias : Form
    {
        public verCategorias()
        {
            InitializeComponent();
            DaoCategoria dc = new DaoCategoria();
            gridCategorias.DataSource = dc.getAll();
        }

        private void verCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}
