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
    public class NegocioProvincia
    {

        public bool NuevaProvincia(String nombre)
        {

            int cantFilas = 0;

            Provincia pro = new Provincia();

            DatosProvincia dao = new DatosProvincia();

            pro.SetIdProvincia(dao.NuevoIdProvincia());

            pro.SetNombre(nombre);

            if (dao.Existeprovincia(pro) == false)
            {
                cantFilas = dao.AgregarProvincia(pro);
            }

            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DataTable ObtenerTablaProvincia(string table, string query)
        {

            DatosProvincia datpro = new DatosProvincia();

            return datpro.ObtenerTabla(table, query);

        }

        public IDataReader ObtenerDatos(string consulta)
        {

            DatosProvincia datos = new DatosProvincia();

            return datos.ObtenerDatos(consulta);

        }
        public DataTable ObtenerDatoss(string consulta)
        {

            DatosProvincia datos = new DatosProvincia();

            return datos.ObtenerDatoss(consulta);

        }

        public bool EliminarProvincia(string id)
        {

            DatosProvincia datpro = new DatosProvincia();

            Provincia pro = new Provincia();

            pro.SetIdProvincia(id);
            int op = datpro.eliminarProvincia(pro);

            if (op == 1)
                return true;
            else
                return false;
        }

        public int ActualizarProvincia(String query)
        {
            DatosProvincia dao = new DatosProvincia();

            return dao.ActualizarProvincia(query);

        }




    }
}
