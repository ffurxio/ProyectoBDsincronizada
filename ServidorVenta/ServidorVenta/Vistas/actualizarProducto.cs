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
    public partial class actualizarProducto : Form
    {
        public actualizarProducto(Productos pb)
        {
            InitializeComponent();
            DaoCategorias dp = new DaoCategorias();
            txtNombre.Text = pb.nombre;
            txtPrecio.Text = pb.precio.ToString();
            lbClave.Text = pb.clave;
            cbCategoria.DataSource = dp.obtenerCategorias();
            cbCategoria.ValueMember = "idcategoria";
            cbCategoria.DisplayMember = "nombre"
;        }

        private void actualizarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Productos p = new Productos();
            DaoProductos dp = new DaoProductos();
            p.clave = lbClave.Text.ToString();
            p.idcategoria = int.Parse(cbCategoria.SelectedValue.ToString());
            p.nombre = txtNombre.Text.ToString();
            p.precio = double.Parse(txtPrecio.Text.ToString());
            if (dp.ActualizarProducto(p))
            {
                MessageBox.Show("Actualizacion correcta");
            }
            else {
                MessageBox.Show("Prolema al actualizar");
            }
        }
    }
}
