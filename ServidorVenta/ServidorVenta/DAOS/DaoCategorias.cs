using ServidorVenta.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorVenta.DAOS
{
    public class DaoCategorias
    {
        String conectarSQL = DaoProductos.conectarSQL;

        public List<Categorias> obtenerCategorias() {
            SqlConnection con = new SqlConnection();
            List<Categorias> lista = new List<Categorias>();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = " SELECT * FROM categorias";
                SqlCommand query = new SqlCommand(sql, con);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    Categorias c = new Categorias();
                    c.idCategoria = dr.GetInt32(0);
                    c.nombre = dr.GetString(1);
                    c.descripcion = dr.GetString(2);
                    lista.Add(c);
                }
                query.Dispose();
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
        public Boolean insertarCategoria(Categorias c) {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "INSERT INTO categorias(nombre,descripcion) VALUES(@nom,@desc)";
                SqlCommand query = new SqlCommand(sql,con);
                query.Parameters.AddWithValue("@nom",c.nombre);
                query.Parameters.AddWithValue("@desc",c.descripcion);
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
        public Boolean eliminarCategorias(int id) {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "DELETE FROM categorias WHERE idcategorias=@id";
                SqlCommand query = new SqlCommand(sql,con);
                query.Parameters.AddWithValue("@id",id);
                query.ExecuteNonQuery();
                query.Dispose();
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
            finally {
                con.Dispose();
                con.Close();
            }
        }
        public Boolean actualizarCategorias(Categorias c) {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "UPDATE categorias SET nombre=@nom,descripcion=@desc WHERE idcategorias=@id";
                SqlCommand query = new SqlCommand(sql,con);
                query.Parameters.AddWithValue("@nom",c.nombre);
                query.Parameters.AddWithValue("@desc",c.descripcion);
                query.Parameters.AddWithValue("@id",c.idCategoria);
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
        public Categorias obtenerCategoriaPorId(int id) {
            SqlConnection con = new SqlConnection();
            Categorias x = new Categorias();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "SELECT * FROM categorias WHERE idcategorias=@id";
                SqlCommand query = new SqlCommand(sql,con);
                query.Parameters.AddWithValue("@id",id);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    
                    x.idCategoria = id;
                    x.nombre = dr.GetString(1);
                    x.descripcion = dr.GetString(2);

                }
                return x;
            }
            catch (Exception ex )
            {
                String asd = ex.ToString();
                return null;
            }
            finally{
                con.Dispose();
                con.Close();
            }
        }

    }
}
