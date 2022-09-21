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
    public class DatosCiudades
    {
        AccesoDatos ds = new AccesoDatos();

        public String NuevoIdCiudad()
        {
            int cant;
            cant = ds.ObtenerMaximo("SELECT count(IdCiudad_ciu) FROM Ciudades") + 1;
            String ID = "CIU" + cant;
            return ID;
        }
        public DataTable ObtenerDatoss(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("Ciudades", "select c.IdCiudad_ciu as 'Codigo',P.Nombre_pro AS 'Provincia', c.Nombre_ciu as 'Nombre' from Ciudades as C inner join Provincias as P on c.IdProvincia_ciu= p.IdProvincia_pro where c.Estado_ciu=1 AND C.Nombre_ciu LIKE '" + consulta + "%'" );
            return tablita;
        }
        public bool ExisteCiudad(Ciudad ciu)
        {

            String consulta = "Select * from Ciudades where Nombre_ciu='" + ciu.GetNombre() + "'";
            return ds.existe(consulta);
        }

        public int AgregarCiudad(Ciudad ciu)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposCiudad(ref comando, ciu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCiudad");
        }

        private void VincularCamposCiudad(ref SqlCommand co, Ciudad ciu)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDCiudad", SqlDbType.Char);
            SqlParametros.Value = ciu.GetIdCiudad();
            SqlParametros = co.Parameters.Add("@IDProvincia", SqlDbType.Char);
            SqlParametros.Value = ciu.GetIdProvincia();
            SqlParametros = co.Parameters.Add("@NombreCiudad", SqlDbType.VarChar);
            SqlParametros.Value = ciu.GetNombre();

        }

        public DataTable ObtenerTabla(string table, string query)
        {
            return ds.ObtenerTabla(table, query);
        }

        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }

        private void ArmarParametrosEliminar(ref SqlCommand Comando, Ciudad ciu)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDCiudad", SqlDbType.Char);
            SqlParametros.Value = ciu.GetIdCiudad();
        }

        public int eliminarCiudad(Ciudad ciu)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, ciu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarCiudad");
        }

        public int ActualizarCiudad(String query)
        {

            return ds.Update(query);

        }
        public DataTable GetProvincias()
        {
            DataTable tabla = ds.ObtenerTabla("Provincias", "Select * from Provincias");

            return tabla;
        }

    }
}
