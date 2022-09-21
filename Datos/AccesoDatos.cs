using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    class AccesoDatos
    {
        string ruta = "Data Source=localhost\\sqlexpress;Initial Catalog = LaboratorioTIF; Integrated Security = True";
        private SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(ruta);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }


        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection wifi = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, wifi);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }
        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public IDataReader consultar(string consultita)
        {
            SqlConnection cn = new SqlConnection(ruta);
            cn.Open();
            SqlCommand cmd = new SqlCommand(consultita, cn);
            SqlDataReader dr = cmd.ExecuteReader();



            return dr;

        }
        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }

        public decimal Obtenertotal(String consulta)
        {
            decimal max = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                
                    max = Convert.ToDecimal(datos[0].ToString());
                
                
            }
            return max;
        }

        public int Update(String query)
        {
            
            SqlConnection Conexion = ObtenerConexion();

            SqlCommand cmd = new SqlCommand(query, Conexion);

            return cmd.ExecuteNonQuery();

        }

        public string ObtenerDato(String consulta)
        {
            string dato = string.Empty;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
               dato = Convert.ToString(datos[0]);
            }
            return dato;
        }

    }
}

