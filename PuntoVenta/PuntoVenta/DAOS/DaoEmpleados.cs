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
    public class DaoEmpleados
    {
        String conectar = "server=localhost; database=oxxo; user=root; pwd=root";
        String conectarSQL = DaoProductos.conectarSQL;
        public List<Empleados> ObtenerEmpleados() {
            List<Empleados> lista = new List<Empleados>();
            MySqlConnection con = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();


            try
            {
                con.ConnectionString = conectar;
                con.Open();
                string sql = "SELECT * FROM empleados";
                query = new MySqlCommand(sql, con);
                MySqlDataReader dr = query.ExecuteReader();
                while (dr.Read()) {
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

                return lista;
            } catch (Exception ex){
                
                return null;
            } finally {
                query.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public Empleados EmpleadoID(string nombre) {
            Empleados e = new Empleados();
            MySqlConnection con = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            try
            {
                con.ConnectionString = conectar;
                con.Open();
                string sql = "select * from empleados where nombre=@nombre";
                query = new MySqlCommand(sql, con);
                query.Parameters.AddWithValue("@nombre",nombre);
                MySqlDataReader dr = query.ExecuteReader();
                int cont = 0;
                while (dr.Read())
                {
                    cont++;
                    e.idEmpleado = dr.GetInt32(0);
                    e.nss = dr.GetString(1);
                    e.rfc = dr.GetString(2);
                    e.nombre = dr.GetString(3);
                    e.apellidos = dr.GetString(4);
                    e.telefono = dr.GetString(5);
                    e.direccion = dr.GetString(6);
                    e.password = dr.GetString(7);
                }
                if (cont == 0)
                {
                    return null;
                }
                else
                {
                    return e;
                }

            }
            catch
            {

                return null;

            }
            finally
            {
                query.Dispose();
                con.Close();
                con.Dispose();
            }




        }

        public List<Empleados> importarEmpleados() {
            SqlConnection con = new SqlConnection();
            List<Empleados> lista = new List<Empleados>();
            try
            {
                con.ConnectionString = conectarSQL;
                con.Open();
                String sql = "select * from empleados";
                SqlCommand query = new SqlCommand(sql, con);
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
                    e.password = dr.GetString(7);
                    lista.Add(e);

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

        public Boolean insertarEmpleadosImportados(Empleados e) {
            MySqlConnection con = new MySqlConnection();
            MySqlCommand query = new MySqlCommand();
            try
            {
                con.ConnectionString = conectar;
                con.Open();
                String sql = "INSERT INTO empleados(idempleado,nss,rfc,nombre,apellidos,telefono,direccion,password) VALUES(@id,@nss,@rfc,@nombre,@apellidos,@tele,@dir,@pass) ON DUPLICATE KEY UPDATE nss=@nss,rfc=@rfc,nombre=@nombre,apellidos=@apellidos,telefono=@tele,direccion=@dir,password=@pass";
                query = new MySqlCommand(sql,con);
                query.Parameters.AddWithValue("@id",e.idEmpleado);
                query.Parameters.AddWithValue("@nss", e.nss);
                query.Parameters.AddWithValue("@rfc",e.rfc);
                query.Parameters.AddWithValue("@nombre",e.nombre);
                query.Parameters.AddWithValue("@apellidos",e.apellidos);
                query.Parameters.AddWithValue("@tele",e.telefono);
                query.Parameters.AddWithValue("@dir",e.direccion);
                query.Parameters.AddWithValue("@pass",e.password);
                query.ExecuteNonQuery();
                query.Dispose();
                return true;
            }
            catch(Exception ex) {
                return false;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            

        }

    }
}
