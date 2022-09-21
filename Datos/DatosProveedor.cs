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
    public class DatosProveedor
    {
        AccesoDatos ds = new AccesoDatos();
        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }
        public DataTable ObtenerDatoss(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("PROVEEDORESADMIN", "SELECT * FROM PROVEEDORESADMIN WHERE PROVEEDOR LIKE '" + consulta + "%'");
            return tablita;
        }
        public DataTable ObtenerDatitos()
        {
            DataTable tablita = ds.ObtenerTabla("PROVEEDORESADMIN", "Select * from PROVEEDORESADMIN");
            return tablita;
        }
        public bool ExisteProve(Proveedores pro)
        {

            String consulta = "Select * from Proveedores where RazonZocial_prov='" + pro.GetRazonSocial() + "'";
            return ds.existe(consulta);
        }
        public int AgregarProveedor(Proveedores pro)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposProve(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProveedor");
        }
        public DataTable GetProvincias()
        {
            DataTable tabla = ds.ObtenerTabla("Provincias", "Select * from Provincias");

            return tabla;
        }
        public String NuevoIdProveedor()
        {
            int cant;
            cant = ds.ObtenerMaximo("SELECT count(IdProveedor_prov) FROM Proveedores") + 1;
            String ID = "PROV" + cant;
            return ID;
        }

        public DataTable ObtenerTabla(string table, string query)
        {
            return ds.ObtenerTabla(table, query);
        }

        public DataTable GetCiudades(string ID)

        {
          
            DataTable tabla = ds.ObtenerTabla("Ciudades", "Select * from Ciudades where IdProvincia_ciu='"+ ID + "'");

            return tabla;
        }

        private void VincularCamposProve(ref SqlCommand co, Proveedores pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@RazonZocial", SqlDbType.VarChar);
            SqlParametros.Value = pro.GetRazonSocial();
            SqlParametros = co.Parameters.Add("@IdProveedor", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdProveedor();
            SqlParametros = co.Parameters.Add("@Direccion", SqlDbType.VarChar);
            SqlParametros.Value = pro.GetDireccion();
            SqlParametros = co.Parameters.Add("@IdProvincia", SqlDbType.Char);
            SqlParametros.Value = pro.GetProvincia();
            SqlParametros = co.Parameters.Add("@IdCiudad", SqlDbType.Char);
            SqlParametros.Value = pro.GetCiudad();
            SqlParametros = co.Parameters.Add("@Telefono", SqlDbType.VarChar);
            SqlParametros.Value = pro.GetTelefono();
            SqlParametros = co.Parameters.Add("@Web", SqlDbType.VarChar);
            SqlParametros.Value = pro.GetWeb();
            SqlParametros = co.Parameters.Add("@Mail", SqlDbType.VarChar);
            SqlParametros.Value = pro.GetEmail();
        }
        private void ArmarParametrosEliminar(ref SqlCommand Comando, Proveedores pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdProveedor", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdProveedor();
        }
        public int eliminarProve(Proveedores pro)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarProveedor");
        }

        public int  ActualizarProveedor(string query)
        {

            return ds.Update(query);
        }
    }
}
