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
    public partial class verVenta : Form
    {
        private int renglon = 0;
        private double subtotal = 0;
        private double iva = 0;
        private double total = 0;
        String fecha = DateTime.Now.Year.ToString()
                    + "/" + DateTime.Now.Month.ToString()
                    + "/" + DateTime.Now.Day.ToString();
                    
        public verVenta()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void verVenta_Load(object sender, EventArgs e)
        {
            txtNombreEmpleado.Text = globalEmpleado.nombre;
            txtFecha.Text = fecha;
        }

        public void calcularTotal()
        {
            subtotal = 0;
            iva = 0;
            total = 0;
            foreach (DataGridViewRow row in gridVenta.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    subtotal += double.Parse(row.Cells["total"].Value.ToString());
                }
            }
                
            lbsubtotal.Text = subtotal + "";
            iva = subtotal * .15;
            lbiva.Text = iva + "";
            total = subtotal + iva;
            lbtotal.Text = total + "";
            
        }

        public void regresarFocus() {
            txtClave.Text = "";
            txtMensaje.Text = "";
            txtClave.Focus();
            calcularTotal();
        }

        public Boolean estaEnElGrid(string clave)
        {
            foreach (DataGridViewRow row in gridVenta.Rows)
            {
                if (row.Cells[0].Value != null)
                {

                    if (row.Cells[0].Value.ToString() == clave)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public void BuscarProducto() {
            Productos pb = new Productos();
            Productos p = new Productos();
            DaoProductos dp = new DaoProductos();
            pb.clave = txtClave.Text.ToString();
            p = dp.ObtenerProductosClave(pb);
            if (p == null)
            {
                txtMensaje.Text = "Producto no encontrado";
            }
            else
            {
                if (renglon == 0)
                {
                    gridVenta.Rows.Add();
                    gridVenta.Rows[renglon].Cells[0].Value = p.clave.ToString();
                    gridVenta.Rows[renglon].Cells[1].Value = p.nombre.ToString();
                    gridVenta.Rows[renglon].Cells[2].Value = p.precio.ToString();
                    gridVenta.Rows[renglon].Cells[3].Value = 1;
                    gridVenta.Rows[renglon].Cells[4].Value = p.precio.ToString();
                    renglon++;
                }
                else {

                    if (estaEnElGrid(p.clave.ToString()))
                    {
                        int temp = 0;
                        foreach (DataGridViewRow row in gridVenta.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                if (row.Cells[0].Value.ToString() == p.clave)
                                {
                                    temp = int.Parse(row.Cells[3].Value.ToString());
                                    temp++;
                                    row.Cells[3].Value = temp;
                                    row.Cells[4].Value = temp * double.Parse(row.Cells[2].Value.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        gridVenta.Rows.Add();
                        gridVenta.Rows[renglon].Cells[0].Value = p.clave.ToString();
                        gridVenta.Rows[renglon].Cells[1].Value = p.nombre.ToString();
                        gridVenta.Rows[renglon].Cells[2].Value = p.precio.ToString();
                        gridVenta.Rows[renglon].Cells[3].Value = 1;
                        gridVenta.Rows[renglon].Cells[4].Value = p.precio.ToString();
                        renglon++;
                    }
                }            
            }

            regresarFocus();      
        }
     
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void txtClave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProducto();
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            
            DaoVentas dv = new DaoVentas();
            int folio = dv.ultimaVenta()+1;
            Ventas v = new Ventas();
                v.folio = folio;
                v.fecha = fecha;
                v.total = total;
                v.iva = iva;
                v.subtotal = subtotal;
                v.caja ="caja1";
                v.idEmpleado =globalEmpleado.idEmpleado;
             
            
            List<DetalleVenta> detalles = new List<DetalleVenta>();
            DetalleVenta dev;
            DaoProductos dp = new DaoProductos();
            foreach (DataGridViewRow row in gridVenta.Rows) {
                dev = new DetalleVenta();
                dev.folio = folio;
                dev.idProducto = dp.ObtenerIDProducto(row.Cells["ClaveProducto"].Value.ToString());
                dev.precio = double.Parse(row.Cells["Precio"].Value.ToString());
                dev.cantidad = int.Parse(row.Cells["cantidad"].Value.ToString());
                dev.importe = double.Parse(row.Cells["total"].Value.ToString());

                detalles.Add(dev);
            }
            dv.agregarVenta(v,detalles);


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    }

