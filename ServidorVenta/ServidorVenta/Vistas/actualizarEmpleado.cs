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
    public partial class actualizarEmpleado : Form
    {
        public actualizarEmpleado(int id)
        {
            InitializeComponent();
            Empleados em = new Empleados();
            DaoEmpleados de = new DaoEmpleados();
            em = de.obtenerEmpleadoPorID(id);
            txtApellidos.Text = em.apellidos;
            txtDireccion.Text = em.direccion;
            txtnombre.Text = em.nombre;
            txtnss.Text = em.nss;
            txtPassword.Text = em.password;
            txtrfc.Text = em.rfc;
            txtTelefono.Text = em.telefono;
        }

        private void actualizarEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
}
