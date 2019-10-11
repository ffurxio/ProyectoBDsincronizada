using MySql.Data.MySqlClient;
using PuntoVenta.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DAOS
{
   public class DaoCategoria  {
        String conectar = "server=localhost; database=oxxo; user=root; pwd=root";
        String conectarSQL = DaoProductos.conectarSQL;
        public List<Categorias> getAll() {
            List<Categorias> lista = new List<Categorias>();
            MySqlConnection cn = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            Categorias c;
            try {
                cn.ConnectionString = conectar;
                cn.Open();
                string sql = "select * from categorias";
                query = new MySqlCommand(sql, cn);
                MySqlDataReader dr = query.ExecuteReader();
                while (dr.Read()) {
                    c = new Categorias();
                    c.idCategoria = dr.GetInt32("idcategoria");
                    c.nombre = dr.GetString("nombre");
                    c.descripcion = dr.GetString("descripcion");
                    lista.Add(c);
                }
                return lista;
            } catch {
                return null;
            } finally {
                query.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public List<Categorias> importarCategorias() {        
            List<Categorias> lista = new List<Categorias>();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "select * from categorias";
                SqlCommand query = new SqlCommand(sql,con);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read()) {
                    Categorias c = new Categorias();
                    c.idCategoria = dr.GetInt32(0);
                    c.nombre = dr.GetString(1);
                    c.descripcion = dr.GetString(2);
                    lista.Add(c);
                }
                query.Dispose();
                return lista;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally {
                con.Close();
                con.Dispose();
                
            }
            

          
        }

        public Boolean actualizarCategorias(Categorias cat) {
            MySqlConnection con = new MySqlConnection();
            try
            {
                con.ConnectionString = conectar;
                con.Open();
                String sql = "INSERT INTO categorias (idcategoria, nombre, descripcion) VALUES(@id, @nombre,@desc) ON DUPLICATE KEY UPDATE nombre = @nombre, descripcion=@desc";
                MySqlCommand query = new MySqlCommand(sql, con);
                
                    query.Parameters.AddWithValue("@id", cat.idCategoria);
                    query.Parameters.AddWithValue("@nombre", cat.nombre);
                    query.Parameters.AddWithValue("@desc", cat.descripcion);
                    query.ExecuteNonQuery();
                

                query.Dispose();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally {
                con.Close();
                con.Dispose();
            }

        }

    }
}
    