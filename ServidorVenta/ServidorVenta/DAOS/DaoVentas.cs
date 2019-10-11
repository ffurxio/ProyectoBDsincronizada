using MySql.Data.MySqlClient;
using ServidorVenta.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorVenta.DAOS
{
   public  class DaoVentas
    {
        String conectar = "server=localhost; database=oxxo; user=root; pwd=root";
        String conectarSQL = DaoProductos.conectarSQL;
        public List<Ventas> importarVentas() {
            MySqlConnection con = new MySqlConnection();
            List<Ventas> lista = new List<Ventas>();
            try
            {
                con.ConnectionString = conectar;
                con.Open();
                string sql = "SELECT * FROM ventas";
                MySqlCommand query = new MySqlCommand(sql,con);
                MySqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    String folio = dr.GetString(5) + "-" + dr.GetString(0);
                    Ventas v = new Ventas();
                    v.folio = folio;
                    v.fecha = dr.GetString(1);
                    v.total = dr.GetDecimal(2);
                    v.iva = dr.GetDecimal(3);
                    v.subtotal = dr.GetDecimal(4);
                    v.caja = dr.GetString(5);
                    v.idEmpelado = dr.GetInt32(6);
                    lista.Add(v);
                }
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
            finally {
                con.Close();
                con.Dispose();
            }

        }
        public Boolean agregarVentasImportadas(List<Ventas> lv) {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "INSERT INTO ventas VALUES(@folio,@fecha,@total,@iva,@subtotal,@caja,@idempleado)";

                foreach (Ventas venta in lv)
                {
                    SqlCommand query = new SqlCommand(sql, con);
                    query.Parameters.AddWithValue("@folio", venta.folio);
                    query.Parameters.AddWithValue("@fecha",venta.fecha);
                    query.Parameters.AddWithValue("@total",venta.total);
                    query.Parameters.AddWithValue("@iva",venta.iva);
                    query.Parameters.AddWithValue("@subtotal",venta.subtotal);
                    query.Parameters.AddWithValue("@caja",venta.caja);
                    query.Parameters.AddWithValue("idempleado",venta.idEmpelado);
                    query.ExecuteNonQuery();
                    query.Dispose();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally {
                con.Close();
                con.Dispose();
            }
        }
        public List<Ventas> obtenerVentas() {
            SqlConnection con = new SqlConnection();
            List<Ventas> lista = new List<Ventas>();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "SELECT * FROM ventas";
                SqlCommand query = new SqlCommand(sql,con);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    Ventas v = new Ventas();
                    v.folio = dr.GetString(0);
                    v.fecha = dr.GetDateTime(1).ToString();
                    v.total = dr.GetDecimal(2);
                    v.iva = dr.GetDecimal(3);
                    v.subtotal = dr.GetDecimal(4);
                    v.caja = dr.GetString(5);
                    v.idEmpelado = dr.GetInt32(6);
                    lista.Add(v);
                }
                return lista;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally {
                con.Dispose();
                con.Close();
            }

        }
    }
}
