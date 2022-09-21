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
    public class NegocioDetalleFactura
    {
        public IDataReader ObtenerDatos(string consulta)
        {

            DatosDetalleFactura datos = new DatosDetalleFactura();

            return datos.ObtenerDatos(consulta);

        }

        public bool NuevoDetalle(string idFactura,string idarticulo,int cantidad)
        {
            int cantFilas = 0;

            DatosPorducto datos2 = new DatosPorducto();
            DatosDetalleFactura datos = new DatosDetalleFactura();
            DetalleFactura df = new DetalleFactura();

            df.SetIdFactura(idFactura);
            df.SetIdArticulo(idarticulo);
            df.SetCantidad(cantidad);
            df.SetPrecioUnitario((Convert.ToDecimal(datos2.idXPrecio(idarticulo))));

            cantFilas = datos.AgregarDetalleFactura(df);

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
