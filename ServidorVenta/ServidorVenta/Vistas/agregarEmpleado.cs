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
    public partial class agregarEmpleado : Form
    {
        public agregarEmpleado()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Empleados em = new Empleados();
            em.nss = txtnss.Text;
            em.rfc = txtrfc.Text;
            em.nombre = txtnombre.Text;
            em.apellidos = txtApellidos.Text;
            em.telefono = txtTelefono.Text;
            em.direccion = txtDireccion.Text;
            em.password = txtPassword.Text;
            DaoEmpleados de = new DaoEmpleados();

            if (de.agregarEmpleado(em))
            {
                MessageBox.Show("Empleado agregado");
            }
            else {
                MessageBox.Show("Problema al agregar empleados");
            }
        }
    }
}
