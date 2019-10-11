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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verProductos vp = new verProductos();
            vp.MdiParent = this;
            vp.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verEmpleados ve = new verEmpleados();
            ve.MdiParent = this;
            ve.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verCategorias vc = new verCategorias();
            vc.MdiParent = this;
            vc.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizar act = new actualizar();
            act.MdiParent = this;
            act.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verVentas vv = new verVentas();
            vv.MdiParent = this;
            vv.Show();
        }
    }
}
