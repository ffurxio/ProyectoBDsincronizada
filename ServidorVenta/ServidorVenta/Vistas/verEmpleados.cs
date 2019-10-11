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
    public partial class verEmpleados : Form
    {
        public verEmpleados()
        {
            InitializeComponent();
            DaoEmpleados de = new DaoEmpleados();
            gridEmpleados.DataSource = de.obtenerEmpleados();
        }

        private void verEmpleados_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarEmpleado ae = new agregarEmpleado();
            ae.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int row = gridEmpleados.SelectedRows[0].Index;
            Empleados em = new Empleados();
            em.idEmpleado = int.Parse(gridEmpleados.Rows[row].Cells[0].Value.ToString());
            actualizarEmpleado ac = new actualizarEmpleado(em.idEmpleado);
            ac.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int row = gridEmpleados.SelectedRows[0].Index;
            DaoEmpleados de = new DaoEmpleados();
            Empleados em = new Empleados();
            em.idEmpleado = int.Parse(gridEmpleados.Rows[row].Cells[0].Value.ToString());
            if (de.eliminarEmpleado(em))
            {
                MessageBox.Show("Empleado eliminado");
                gridEmpleados.DataSource = de.obtenerEmpleados();
            }
            else {
                MessageBox.Show("Problema al eliminar empleado");
            }
        }
    }
}
