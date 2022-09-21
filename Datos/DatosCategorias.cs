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
    
    public class DatosCategorias
    {
        AccesoDatos ds = new AccesoDatos();
        public String NuevoIdCategoria()
        {
            int cant;
            cant = ds.ObtenerMaximo("SELECT count(IdCategoria_cat) FROM Categorias") + 1;
            String ID = "CAT" + cant;
            return ID;
        }
        public DataTable ObtenerDatoss(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("Categorias", "select c.IdCategoria_cat as 'Codigo',c.Nombre_cat as 'Nombre' from dbo.Categorias as c where Estado_cat =1 AND c.Nombre_cat LIKE '" + consulta + "%'");
            return tablita;
        }
        public bool ExisteCat(Categoriass cat)
        {

            String consulta = "Select * from Categorias where Nombre_cat='" + cat.GetNombreCategoria() + "'";
            return ds.existe(consulta);
        }

        public int AgregarCategoria(Categoriass cat)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposCat(ref comando, cat);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCategoria");
        }

        private void VincularCamposCat(ref SqlCommand co, Categoriass cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDCategoria", SqlDbType.Char);
            SqlParametros.Value = cat.GetIdCategoria();
            SqlParametros = co.Parameters.Add("@NombreCategoria", SqlDbType.VarChar);
            SqlParametros.Value = cat.GetNombreCategoria();

        }

        public DataTable ObtenerTabla(string table, string query)
        {
            return ds.ObtenerTabla(table, query);
        }

        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }

        private void ArmarParametrosEliminar(ref SqlCommand Comando, Categoriass pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDCategoria", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdCategoria();
        }

        public int eliminarCategoria(Categoriass pro)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarCategoria");
        }

        public int ActualizarCategoria(String query)
        {

            return ds.Update(query);

        }
        public DataTable GetCategorias()
        {
            DataTable tabla = ds.ObtenerTabla("Categorias", "Select * from Categorias");

            return tabla;
        }
    }
}
