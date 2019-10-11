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
    public partial class actualizarCategoria : Form
    {
        public actualizarCategoria(int id)
        {
            InitializeComponent();
            Categorias c = new Categorias();
            DaoCategorias dc = new DaoCategorias();
            c=dc.obtenerCategoriaPorId(id);
            
            idCategoria.Text = id+"";
            txtNombre.Text = c.nombre;
            txtCaracteristicas.Text = c.descripcion;
        }

        private void actualizarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Categorias c = new Categorias();
            c.idCategoria = int.Parse(idCategoria.Text);
            c.nombre = txtNombre.Text;
            c.descripcion = txtCaracteristicas.Text;
            DaoCategorias dc = new DaoCategorias();
            if (dc.actualizarCategorias(c)) {
                MessageBox.Show("Actualiacion correcta");
               
            } else {
                MessageBox.Show("Error");
            }
        }
    }
}
