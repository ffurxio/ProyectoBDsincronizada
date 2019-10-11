using ServidorVenta.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorVenta.DAOS
{
   public class DaoEmpleados
    {
        String conectarSQL = DaoProductos.conectarSQL;
        public bool agregarEmpleado(Empleados e)
        {
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            SqlConnection con = new SqlConnection();
            SqlCommand query = new SqlCommand();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                string sql = "INSERT INTO empleados(nss,rfc,nombre,apellidos,telefono,direccion,password) VALUES(@nss, @rfc, @nombre,@apellidos,@telefono,@direccion,@pass)";
                query = new SqlCommand(sql, con);
                query.Parameters.AddWithValue("@nss", e.nss);
                query.Parameters.AddWithValue("@rfc", e.rfc);
                query.Parameters.AddWithValue("@nombre", e.nombre);
                query.Parameters.AddWithValue("@apellidos", e.apellidos);
                query.Parameters.AddWithValue("@telefono", e.telefono);
                query.Parameters.AddWithValue("@direccion", e.direccion);
                query.Parameters.AddWithValue("@pass",e.password);
                query.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) { 

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
        public bool eliminarEmpleado(Empleados e) {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "DELETE FROM empleados where idempleado=@id";
                SqlCommand query = new SqlCommand(sql, con);
                query.Parameters.AddWithValue("@id", e.idEmpleado);
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
        public bool actualizarEmpleado(Empleados e) {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();                
                String sql = "UPDATE empleados SET nns=@nss,rfc=@rfc,nombre=@nombre,apellidos=@apellidos,telefono=@telefono,direccion=@direccion,password=@password WHERE (idempleado=@id)";
                SqlCommand query = new SqlCommand(sql,con);
                query.Parameters.AddWithValue("@nss",e.nss);
                query.Parameters.AddWithValue("@rfc",e.rfc);
                query.Parameters.AddWithValue("@nombre",e.nombre);
                query.Parameters.AddWithValue("@apellidos",e.apellidos);
                query.Parameters.AddWithValue("@telefono",e.telefono);
                query.Parameters.AddWithValue("@direccion",e.direccion);
                query.Parameters.AddWithValue("@password",e.password);
                query.Parameters.AddWithValue("@id",e.idEmpleado);
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
        public List<Empleados> obtenerEmpleados() {
            SqlConnection con = new SqlConnection();
            List<Empleados> lista = new List<Empleados>();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "SELECT * FROM empleados";
                SqlCommand query = new SqlCommand(sql,con);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    Empleados e = new Empleados();
                    e.idEmpleado = dr.GetInt32(0);
                    e.nss = dr.GetString(1);
                    e.rfc = dr.GetString(2);
                    e.nombre = dr.GetString(3);
                    e.apellidos = dr.GetString(4);
                    e.telefono = dr.GetString(5);
                    e.direccion = dr.GetString(6);
                    lista.Add(e);
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
        public Empleados obtenerEmpleadoPorID(int id) {
            SqlConnection con = new SqlConnection();
            Empleados em = new Empleados();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "SELECT * FROM empleados WHERE idempleado=@id";
                SqlCommand query = new SqlCommand(sql,con);
                query.Parameters.AddWithValue("@id",id);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    em.idEmpleado = dr.GetInt32(0);
                    em.nss = dr.GetString(1);
                    em.rfc = dr.GetString(2);
                    em.nombre = dr.GetString(3);
                    em.apellidos = dr.GetString(4);
                    em.telefono = dr.GetString(5);
                    em.direccion = dr.GetString(6);
                    em.password = dr.GetString(7);
                }
                return em;
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
    }
}
