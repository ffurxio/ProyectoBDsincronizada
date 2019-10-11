using PuntoVenta.DAOS;
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
    public partial class verEmpleados : Form
    {
        public verEmpleados()
        {
            InitializeComponent();
            DaoEmpleados de = new DaoEmpleados();
            gridEmpleados.DataSource = de.ObtenerEmpleados();
        }

        private void verEmpleados_Load(object sender, EventArgs e)
        {

        }
    }
}
