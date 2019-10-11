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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarProducto ap = new agregarProducto();
            ap.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DaoProductos dp = new DaoProductos();
            Productos p = new Productos();
            int row = gridProductos.SelectedRows[0].Index;
            String clave = gridProductos.Rows[row].Cells[1].Value.ToString();
            p.clave = clave;

            if (dp.EliminarProducto(p))
            {
                MessageBox.Show("Producto Eliminado", "NANI");
                gridProductos.DataSource = dp.ObtenerProductos();

            }
            else
            {
                MessageBox.Show("Problema al elimiar el producto", "NANI");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DaoProductos dp = new DaoProductos();
            Productos p = new Productos();
            int row = gridProductos.SelectedRows[0].Index;
            String clave = gridProductos.Rows[row].Cells[1].Value.ToString();
            p = dp.obtenerProductoPorClave(clave);
            actualizarProducto ap = new actualizarProducto(p);
            ap.Show();

            
        }
    }
}
