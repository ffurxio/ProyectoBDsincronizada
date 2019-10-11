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
    public partial class ActualizarSistema : Form
    {
        public ActualizarSistema()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            prBar1.Value = 0;
            DaoCategoria dc = new DaoCategoria();
            List<Categorias> listacategorias = new List<Categorias>();
            listacategorias = dc.importarCategorias();
            int total = listacategorias.Count();
            prBar1.Minimum = 0;
            prBar1.Maximum = total;
            for (int i = 0; i < total; i++)
            {
                dc.actualizarCategorias(listacategorias[i]);
                prBar1.Value = i + 1;
            }
            
        }

        private void btnActualizarEmpleados_Click(object sender, EventArgs e)
        {
            prBar1.Value = 0;
            DaoEmpleados de = new DaoEmpleados();
            List<Empleados> listaEmpleados = new List<Empleados>();
            listaEmpleados = de.importarEmpleados();
            int total = listaEmpleados.Count();
            prBar1.Minimum = 0;
            prBar1.Maximum = total;
            for (int i = 0; i < total; i++)
            {
                de.insertarEmpleadosImportados(listaEmpleados[i]);
                prBar1.Value = i + 1;
            }
        }

        private void btnActualizarProductos_Click(object sender, EventArgs e)
        {
            prBar1.Value = 0;
            DaoProductos dp = new DaoProductos();
            List<Productos> listaProductos = new List<Productos>();
            listaProductos = dp.importarProductos();
            int total = listaProductos.Count();
            prBar1.Minimum = 0;
            prBar1.Maximum = total;
            for (int i = 0; i < total; i++)
            {
                dp.actualizarProductoImportado(listaProductos[i]);
                prBar1.Value = i + 1;
            }
        }
    }
}
