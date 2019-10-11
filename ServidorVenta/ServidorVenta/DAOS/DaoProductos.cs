using ServidorVenta.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorVenta.DAOS
{
    public class DaoProductos
    {
       public static String conectarSQL = "Data Source=DESKTOP-30JQFB6\\SQLEXPRESS;Initial Catalog=oxxo;User ID=sa;Password=root";

        public bool AgregarProducto(Productos p)
        {
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            SqlConnection con = new SqlConnection();
            SqlCommand query = new SqlCommand();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                string sql = "insert into productos(clave,nombre,precio,foto,idCategoria) values (@Clave, @Nombre, @precio, @Foto,@Categoria)";
                query = new SqlCommand(sql, con);
                query.Parameters.AddWithValue("Clave", p.clave);
                query.Parameters.AddWithValue("Nombre", p.nombre);
                query.Parameters.AddWithValue("Precio", p.precio);
                if (p.foto == null)
                {
                    p.foto = "sinfoto";
                }
                query.Parameters.AddWithValue("Foto", p.foto);
                query.Parameters.AddWithValue("Categoria", p.idcategoria);
                query.ExecuteNonQuery();
                return true;
            }
            catch (Exception )
            {
                
                return false;
            }
            finally
            {
                query.Dispose();
                con.Close();
                con.Dispose();
            }


        }

        public bool EliminarProducto(Productos p)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand query = new SqlCommand();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                string sql = "delete from productos where (clave=@clave)";
                query = new SqlCommand(sql, con);
                query.Parameters.AddWithValue("@clave", p.clave);
                query.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                /// FINALIZAMOS LA CONEXION CERRAMOS TODO
                query.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public bool ActualizarProducto(Productos p)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand query = new SqlCommand();
            con.ConnectionString = conectarSQL;
            try
            {
                con.Open();
                String sql = "UPDATE productos SET nombre = @nombre, precio = @precio WHERE (clave = @clave)";
                query = new SqlCommand(sql, con);
                query.Parameters.AddWithValue("@nombre", p.nombre);
                query.Parameters.AddWithValue("@precio", p.precio);
                query.Parameters.AddWithValue("@clave", p.clave);
                query.ExecuteNonQuery();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            finally
            {
                query.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public List<Productos> ObtenerProductos()
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand query = new SqlCommand();
            try
            {
                cn.ConnectionString = conectarSQL;
                cn.Open();
                List<Productos> productos = new List<Productos>();
                string sql = "select * from productos";
                query = new SqlCommand(sql, cn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    Productos x = new Productos();
                    x.id = dr.GetInt32(0);
                    x.clave = dr.GetString(1);
                    x.nombre = dr.GetString(2);
                    x.precio =(double)dr.GetDecimal(3);
                    x.foto = dr.GetString(4);
                    x.idcategoria = dr.GetInt32(5);
                    productos.Add(x);
                }

                return productos;
            }
            catch(Exception ex)
            {

                return null;
            }
            finally
            {
                /// FINALIZAMOS LA CONEXION CERRAMOS TODO
                query.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public Productos obtenerProductoPorClave(String clave)
        {
            SqlConnection con = new SqlConnection();
            Productos p = new Productos();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                string sql = "SELECT * FROM productos where clave=@clave";
                SqlCommand query = new SqlCommand(sql,con);
                query.Parameters.AddWithValue("@clave",clave);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    p.id = dr.GetInt32(0);
                    p.clave = dr.GetString(1);
                    p.nombre = dr.GetString(2);
                    p.precio = (double)dr.GetDecimal(3);
                    p.foto = dr.GetString(4);
                    p.idcategoria = dr.GetInt32(5);
                }
                return p;
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
    }
}
