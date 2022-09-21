using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProvincia
    {
        AccesoDatos ds = new AccesoDatos();
        public String NuevoIdProvincia()
        {
            int cant;
            cant = ds.ObtenerMaximo("SELECT count(IdProvincia_pro) FROM Provincias") + 1;
            String ID = "PRO" + cant;
            return ID;
        }
        public DataTable ObtenerDatoss(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("Provincias", "select P.IdProvincia_pro as 'Codigo', P.Nombre_pro as 'Nombre' from dbo.Provincias as P where P.Estado_pro = 1 AND P.Nombre_pro LIKE '" + consulta + "%'");
            return tablita;
        }
        public bool Existeprovincia(Provincia  pro)
        {

            String consulta = "Select * from Provincias where Nombre_pro='" + pro.GetNombre() + "'";
            return ds.existe(consulta);
        }

        public int AgregarProvincia(Provincia pro)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposProvincia(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProvincia");
        }

        private void VincularCamposProvincia(ref SqlCommand co, Provincia pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDProvincia", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdProvincia();
            SqlParametros = co.Parameters.Add("@NombreProvincia", SqlDbType.VarChar);
            SqlParametros.Value = pro.GetNombre();

        }

        public DataTable ObtenerTabla(string table, string query)
        {
            return ds.ObtenerTabla(table, query);
        }

        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }

        private void ArmarParametrosEliminar(ref SqlCommand Comando, Provincia pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDProvincia", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdProvincia();
        }

        public int eliminarProvincia(Provincia pro)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarProvincia");
        }

        public int ActualizarProvincia(String query)
        {

            return ds.Update(query);

        }
    }
}
