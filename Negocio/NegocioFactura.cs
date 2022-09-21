using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;



namespace Negocio
{
    public class NegocioFactura
    {
        public IDataReader ObtenerDatos(string consulta)
        {

            DatosFactura datos = new DatosFactura();

            return datos.ObtenerDatos(consulta);

        }
        public DataTable ObtenerDatitos2(String FECHAINI, String FechaFinal)
        {

            DatosFactura datos = new DatosFactura();

            return datos.ObtenerDatoFecha(FECHAINI, FechaFinal);

        }

        public string obtenertotal(string fechaini, string fechafinal)
        {
            DatosFactura datos = new DatosFactura();

             return datos.obtenertotal(fechaini, fechafinal);

        }


        public DataTable ObtenerDatitos()
        {

            DatosFactura datos = new DatosFactura();

            return datos.ObtenerDatos();

        }
        public DataTable ObtenerDatoss(string consulta)
        {

            DatosFactura datos = new DatosFactura();

            return datos.ObtenerDatoss(consulta);

        }


        public DataTable GetTablaSeleccionados()
        {
                DatosFactura dao = new DatosFactura();
                return dao.crearTablaSeleccionados(); 
        }



        public int ActualizarTotal(String query)
        {
            DatosFactura dao = new DatosFactura();

            return dao.ActualizarTotal(query);

        }


        public bool EliminarFactura(string id)
        {

            DatosFactura datfac = new DatosFactura();

            Facturas fac = new Facturas();


            fac.SetIdFactura(id);

            int op = datfac.eliminarFactura(fac);

            if (op == 1)
                return true;
            else
                return false;
        }

        public bool RealizarFactura(DataTable tabla,string dni, string FormaPago)
        {

            int cantFilas = 0;

            Facturas fac = new Facturas();
            DatosFactura dao = new DatosFactura();
            NegocioDetalleFactura negdf = new NegocioDetalleFactura();

            float total=0;

            fac.SetIdFactura(dao.NuevoIdFactura());
            fac.SetDni(dni);
            fac.SetIdFormaPago(FormaPago);
            fac.SetTotal(0);
 
            cantFilas = dao.AgregarFactura(fac);

           
            
                foreach (DataRow row in tabla.Rows)
                {
                    negdf.NuevoDetalle(fac.GetIdFactura(), row["Codigo"].ToString(), Convert.ToInt32(row["Cantidad"].ToString()));

                }
               
         
                

            String query = "update dbo.Facturas set TotalFactura_fa=(SELECT SUM(CANTIDAD_df * PRECIOUNITARIO_DF) FROM DetalleFactura WHERE idFactura_df ='" + fac.GetIdFactura() + "') WHERE idFactura_fa ='" + fac.GetIdFactura()+ "'";
           

            ActualizarTotal(query);

            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

    }
}
