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
    public partial class verCategorias : Form
    {
        public verCategorias()
        {
            InitializeComponent();
            DaoCategorias dc = new DaoCategorias();
            gridCategorias.DataSource = dc.obtenerCategorias();
        }

        private void verCategorias_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarCategoria ag = new agregarCategoria();            
            ag.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int row = gridCategorias.SelectedRows[0].Index;
            Categorias c = new Categorias();
            c.idCategoria = int.Parse(gridCategorias.Rows[row].Cells[0].Value.ToString());
            actualizarCategoria ac = new actualizarCategoria(c.idCategoria);
            ac.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int row = gridCategorias.SelectedRows[0].Index;
            Categorias c = new Categorias();
            DaoCategorias dc = new DaoCategorias();


            c.idCategoria =int.Parse(gridCategorias.Rows[row].Cells[0].Value.ToString());
            if (dc.eliminarCategorias(c.idCategoria))
            {
                MessageBox.Show("Categoria eliminada");
                gridCategorias.DataSource = dc.obtenerCategorias();
            }
            else {
                MessageBox.Show("Hubo un problema comuniqueselo al encargado");
            }

        }
    }
}
