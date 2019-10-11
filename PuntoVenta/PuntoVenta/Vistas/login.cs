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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnEntrar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Login();
            }
        }
        public void Login() {
            String nombre = txtUser.Text.ToString();
            String pass = txtPass.Text.ToString();
            DaoEmpleados de = new DaoEmpleados();
            Empleados em = new Empleados();
            em = de.EmpleadoID(nombre);
            if (em != null)
            {
                if (em.password == pass)
                {
                    globalEmpleado.idEmpleado = em.idEmpleado;
                    globalEmpleado.nombre = em.nombre;
                    menu m = new menu();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    txtmensaje.Text="Constraseña incorrecta";
                    txtPass.Text = "";
                }
            }
            else
            {
                txtmensaje.Text = "Usuario no encontrado";
            }
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
}
