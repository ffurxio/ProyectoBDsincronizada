using MySql.Data.MySqlClient;
using PuntoVenta.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta.DAOS
{
    public class DaoProductos {
        String conectar = "server=localhost; database=oxxo; user=root; pwd=root";
        public static String conectarSQL= "Data Source=DELINCUENCIA-PC,1433;Initial Catalog=oxxo;User ID=sa;Password=root";

        public List<Productos> ObtenerProductos(){
            MySqlConnection cn = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            try{
                cn.ConnectionString = conectar;
                cn.Open();
                List<Productos> productos = new List<Productos>();
                string sql = "select * from productos";
                query = new MySqlCommand(sql, cn);
                MySqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    Productos x = new Productos();
                    x.id = dr.GetInt32("idproducto");
                    x.clave = dr.GetString("clave");
                    x.nombre = dr.GetString("nombre");
                    x.precio = dr.GetDouble("precio");
                    x.foto = dr.GetString("foto");
                    x.idcategoria = dr.GetInt32("idCategoria");                   
                    productos.Add(x);
                }
                
                return productos;
            }
            catch{
                return null;
            }
            finally{
                /// FINALIZAMOS LA CONEXION CERRAMOS TODO
                query.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public Productos ObtenerProductosClave(Productos pb){
            Productos p = new Productos();
            MySqlConnection con = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            try {
                con.ConnectionString = conectar;
                con.Open();
                string sql = "select * from productos where clave=@clave";
                query = new MySqlCommand(sql, con);
                query.Parameters.AddWithValue("@clave", pb.clave);
                MySqlDataReader dr = query.ExecuteReader();
                int cont = 0;
                while (dr.Read())
                {
                    cont++;
                    p.clave = dr.GetString("clave");
                    p.nombre = dr.GetString("nombre");
                    p.precio = dr.GetDouble("precio");
                    p.idcategoria = dr.GetInt32("idCategoria");
                }
                if (cont == 0)
                {
                    return null;
                }
                else
                {
                    return p;
                }

            } catch {

                return null;
                     
            } finally {
                query.Dispose();
                con.Close();
                con.Dispose();
            }
            

            

        }

        public int ObtenerIDProducto(string clave)
        {
            MySqlConnection con = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            try
            {
                con.ConnectionString = conectar;
                con.Open();
                string sql = "select idproducto from productos where clave=@clave";
                query = new MySqlCommand(sql, con);
                query.Parameters.AddWithValue("@clave", clave);
                MySqlDataReader dr = query.ExecuteReader();
                int cont = 0;
                int id = 0;
                while (dr.Read())
                {
                    cont++;
                    id = dr.GetInt32(0);
                }
                if (cont == 0)
                {
                    return id;
                }
                else
                {
                    return id;
                }

            }
            catch
            {

                return 0;

            }
            finally
            {
                query.Dispose();
                con.Close();
                con.Dispose();
            }




        }

        public List<Productos> importarProductos() {
            SqlConnection con = new SqlConnection();
            List<Productos> lista = new List<Productos>();

            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "select * from productos";
                SqlCommand query = new SqlCommand(sql, con);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    Productos p = new Productos();
                    p.id = dr.GetInt32(0);
                    p.clave = dr.GetString(1);
                    p.nombre = dr.GetString(2);
                    p.precio = (double)dr.GetDecimal(3);
                    p.foto = dr.GetString(4);
                    p.idcategoria = dr.GetInt32(5);
                    lista.Add(p);
                }
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

        public Boolean actualizarProductoImportado(Productos p) {
            MySqlConnection con = new MySqlConnection();

            try
            {
                con.ConnectionString = conectar;
                con.Open();
                String sql = "INSERT INTO productos (idproducto, clave, nombre,precio,foto,idcategoria)" +
                    "VALUES(@id, @clave,@nombre,@precio,@foto,@idcategoria) ON DUPLICATE KEY UPDATE nombre = @nombre,precio=@precio,foto=@foto";
                MySqlCommand query = new MySqlCommand(sql, con);
                query.Parameters.AddWithValue("@id", p.id);
                query.Parameters.AddWithValue("@clave", p.clave);
                query.Parameters.AddWithValue("@nombre", p.nombre);
                query.Parameters.AddWithValue("@precio", p.precio);
                query.Parameters.AddWithValue("@foto", p.foto);
                query.Parameters.AddWithValue("@idcategoria", p.idcategoria);
                query.ExecuteNonQuery();
                query.Dispose();
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
    }
}
