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
    public class DatosMarca
    {
        AccesoDatos ds = new AccesoDatos();
        public String NuevoIdMarca()
        {
            int cant;
            cant = ds.ObtenerMaximo("SELECT count(IdMarca_mar) FROM Marcas") + 1;
            String ID = "MAR" + cant;
            return ID;
        }
        public DataTable ObtenerDatoss(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("Marcas", "select m.IdMarca_mar as 'Codigo',m.Nombre_mar as 'Nombre' from dbo.Marcas as m where m.Estado_mar = 1 AND Nombre_mar LIKE '" + consulta + "%'");
            return tablita;
        }
        public bool ExisteMar(Marcas mar)
        {

            String consulta = "Select * from Marcas where Nombre_mar='" + mar.GetNombreMarca() + "'";
            return ds.existe(consulta);
        }
        public int AgregarMarca(Marcas mar)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposMar(ref comando, mar);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarMarca");
        }
        private void VincularCamposMar(ref SqlCommand co, Marcas mar)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDMarca", SqlDbType.Char);
            SqlParametros.Value = mar.GetIdmarca();
            SqlParametros = co.Parameters.Add("@NombreMarca", SqlDbType.VarChar);
            SqlParametros.Value = mar.GetNombreMarca();
          
        }
        public DataTable ObtenerTabla(string table, string query)
        {
            return ds.ObtenerTabla(table, query);
        }
        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }
        private void ArmarParametrosEliminar(ref SqlCommand Comando, Marcas pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDMarca", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdmarca();
        }

        public int eliminarMarca(Marcas pro)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarMarca");
        }

        public int ActualizarMarca(String query)
        {

            return ds.Update(query);

        }
        public DataTable GetMarcas()
        {
            DataTable tabla = ds.ObtenerTabla("Marcas", "Select * from Marcas");

            return tabla;
        }
    }
}
