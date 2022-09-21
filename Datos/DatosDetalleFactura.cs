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
   public class DatosDetalleFactura
    {
        AccesoDatos ds = new AccesoDatos();

        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }


        public int AgregarDetalleFactura(DetalleFactura df)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposDetalleFactura(ref comando, df);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarDetalleFactura");
        }
        private void VincularCamposDetalleFactura(ref SqlCommand co, DetalleFactura df)
        {

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDFactura", SqlDbType.Char);
            SqlParametros.Value = df.GetIdFactura();
            SqlParametros = co.Parameters.Add("@IDArticulo", SqlDbType.Char);
            SqlParametros.Value = df.GetIdArticulo();
            SqlParametros = co.Parameters.Add("@Cantidad", SqlDbType.Int);
            SqlParametros.Value = df.GetCantidad();
            SqlParametros = co.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
            SqlParametros.Value = df.GetPrecioUnitario();
            



        }
    }
}
