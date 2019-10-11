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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verProductos vp = new verProductos();
            vp.MdiParent = this;
            vp.Show();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verVenta vv = new verVenta();
            vv.MdiParent = this;
            vv.Show();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarSistema act= new ActualizarSistema();
            act.MdiParent = this;
            act.Show();
        }

        private void verToolStripMenuItem1_Click(object sender, EventArgs e)
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
    }
}
