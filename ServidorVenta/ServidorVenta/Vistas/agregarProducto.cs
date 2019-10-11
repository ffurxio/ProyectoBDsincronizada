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
    public partial class agregarProducto : Form
    {
        public agregarProducto()
        {
            InitializeComponent();
            DaoCategorias dc = new DaoCategorias();
            cbCategoria.DataSource = dc.obtenerCategorias();
            cbCategoria.DisplayMember = "nombre";
            cbCategoria.ValueMember = "idcategoria";
        }

        private void agregarProducto_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Productos p = new Productos();
            p.clave = txtClave.Text.ToString();
            p.nombre = txtNombre.Text.ToString();
            p.precio = float.Parse(txtPrecio.Text.ToString());
            p.idcategoria = int.Parse(cbCategoria.SelectedValue.ToString());
            DaoProductos dp = new DaoProductos();
            if (dp.AgregarProducto(p))
            {
                MessageBox.Show("Producto Agregado", "nani");
            }
            else
            {
                MessageBox.Show("Error al agregar producto", "nani");
            }
        }
    }
}
