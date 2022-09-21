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
    public class DatosFactura
    {
        AccesoDatos ds = new AccesoDatos();

        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }

        public DataTable ObtenerDatos()
        {
            DataTable tablita = ds.ObtenerTabla("FACTURASADMIN", "Select * from FACTURASADMIN");
            return tablita;
        }

        public DataTable ObtenerDatoFecha(String FECHAINI, String FechaFinal)
        {
            DataTable tablita = ds.ObtenerTabla("FACTURASADMIN", "Select * from FACTURASADMIN WHERE FECHAFACTURA > '" + FECHAINI + " ' AND FECHAFACTURA < '" + FechaFinal + " ' ");
            return tablita;
        }

        public DataTable ObtenerDatoss(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("FACTURASADMIN", "SELECT * FROM FACTURASADMIN WHERE DNIFACTURA LIKE '" + consulta + "%'");
            return tablita;
        }

        public String NuevoIdFactura()
        {
            int cant;
            cant = ds.ObtenerMaximo("SELECT count(IdFactura_fa) FROM Facturas") + 1;
            String ID = "FAC" + cant;
            return ID;
        }

        public String obtenertotal(string fechaini, string final)
        {
            decimal cant;
            cant = ds.Obtenertotal("SELECT isnull(SUM(TotalFactura_fa),0) FROM facturas WHERE convert(date, Fecha_fa) > convert(date, '" + fechaini + "') and convert(date, Fecha_fa) < convert(date, '" + final + "')");
            String ID = cant.ToString();
            return ID;
        }

        public DataTable crearTablaSeleccionados()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("ARTICULO", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("MARCA", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("CATEGORIA", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            columna = new DataColumn("PRECIO", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);
            return dt;
        }


        public int AgregarFactura(Facturas fac)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposFactura(ref comando, fac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarFactura");
        }
        private void VincularCamposFactura(ref SqlCommand co, Facturas fac)
        {

            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDFactura", SqlDbType.Char);
            SqlParametros.Value = fac.GetIdFactura();
            SqlParametros = co.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = fac.GetDni();
            SqlParametros = co.Parameters.Add("@IDFormapago", SqlDbType.Char);
            SqlParametros.Value = fac.GetIdFormaPago();
            SqlParametros = co.Parameters.Add("@Total", SqlDbType.Decimal);
            SqlParametros.Value = fac.GetTotal();



        }

        public int eliminarFactura(Facturas fac)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, fac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarFactura");
        }

        private void ArmarParametrosEliminar(ref SqlCommand Comando, Facturas fac)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDFactura", SqlDbType.Char);
            SqlParametros.Value = fac.GetIdFactura();
        }

        public int ActualizarTotal(String query)
        {

            return ds.Update(query);

        }





    }
}
