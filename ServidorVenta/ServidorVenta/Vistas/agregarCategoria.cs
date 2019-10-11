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
    public partial class agregarCategoria : Form
    {
        public agregarCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Categorias c = new Categorias();
            DaoCategorias dc = new DaoCategorias();
            c.nombre = txtNombre.Text.ToString();
            c.descripcion = txtCaracteristicas.Text.ToString();
            if (dc.insertarCategoria(c))
            {
                MessageBox.Show("Ingresado correctamente");
            }
            else {
                MessageBox.Show("Problema al ingresar");
            }
        }
    }
}
