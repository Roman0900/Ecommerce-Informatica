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
    public class DatosFormaPago
    {
        AccesoDatos ds = new AccesoDatos();
        public String NuevoIdFormaPago()
        {
            int cant;
            cant = ds.ObtenerMaximo("SELECT count(IdFormaPago_fp) FROM FormaPago") + 1;
            String ID = "FP" + cant;
            return ID;
        }

        public bool ExisteFormaPago(FormaPago fp)
        {

            String consulta = "Select * from FormaPago where Nombre_fp='" + fp.GetNombre() + "'";
            return ds.existe(consulta);
        }

        public int AgregarFormaPago(FormaPago fp)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposFormaPago(ref comando, fp);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarFormaPago");
        }

        private void VincularCamposFormaPago(ref SqlCommand co, FormaPago fp)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDFormaPago", SqlDbType.Char);
            SqlParametros.Value = fp.GetIdFormaPago();
            SqlParametros = co.Parameters.Add("@NombreFP", SqlDbType.VarChar);
            SqlParametros.Value = fp.GetNombre();

        }

        public DataTable GetFormaPago()
        {
            DataTable tabla = ds.ObtenerTabla("FormaPago", "Select * from FormaPago where Estado_fp=1");

            return tabla;
        }

        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }

        private void ArmarParametrosEliminar(ref SqlCommand Comando, FormaPago fp)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDFormaPago", SqlDbType.Char);
            SqlParametros.Value = fp.GetIdFormaPago();
        }

        public int eliminarFormaPago(FormaPago fp)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, fp);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarFormaPago");
        }

        
    }
}
