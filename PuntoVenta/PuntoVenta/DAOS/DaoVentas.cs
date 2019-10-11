using MySql.Data.MySqlClient;
using PuntoVenta.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta.DAOS
{
    public class DaoVentas
    {
        String conectar = "server=localhost; database=oxxo; user=root; pwd=root";

        public Boolean agregarVenta(Ventas v, List<DetalleVenta> detalle) {
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            MySqlConnection con = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            MySqlTransaction trans = null;
            try {
                con.ConnectionString = conectar;
                con.Open();
                 trans = con.BeginTransaction();
                string sql = "insert into ventas(fecha,total,iva,subtotal,caja,idempleado)" +
                   "values (@fecha, @total, @iva,@subtotal,@caja,@idempleado)";
                query = new MySqlCommand(sql, con);
                query.Parameters.AddWithValue("fecha", v.fecha);
                query.Parameters.AddWithValue("total", v.total);
                query.Parameters.AddWithValue("iva", v.iva);
                query.Parameters.AddWithValue("subtotal", v.subtotal);
                query.Parameters.AddWithValue("caja", v.caja);
                query.Parameters.AddWithValue("idempleado", v.idEmpleado);
                query.ExecuteNonQuery();

                foreach (DetalleVenta dv in detalle)
                {
                    sql = "insert into detalles_venta values(@folio,@idproducto,@cantidad,@precio,@importe)";
                    query = new MySqlCommand(sql, con);
                    query.Parameters.AddWithValue("@folio", dv.folio);
                    query.Parameters.AddWithValue("@idproducto", dv.idProducto);
                    query.Parameters.AddWithValue("@cantidad", dv.cantidad);
                    query.Parameters.AddWithValue("@precio", dv.precio);
                    query.Parameters.AddWithValue("@importe", dv.importe);
                    query.ExecuteNonQuery();
                    query.Dispose();

                }
                trans.Commit();
                return true;
            }
            catch (Exception e) {
                trans.Rollback();
                return false;
            } finally {
                /// FINALIZAMOS LA CONEXION CERRAMOS TODO
                query.Dispose();
                con.Close();
                con.Dispose();
            }


        }

        public int ultimaVenta() {
            MySqlConnection con = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            try {
                con.ConnectionString = conectar;
                con.Open();
                string sql = "select max(folio) from ventas";
                query = new MySqlCommand(sql, con);
                MySqlDataReader dr = query.ExecuteReader();
                int idVenta = 0;
                while (dr.Read()) {
                    idVenta = dr.GetInt32(0);
                }
                return idVenta;
            } catch {
                return 0;
            } finally {
                query.Dispose();
                con.Close();
                con.Dispose();
            }

        }

    }


}
