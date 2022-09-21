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
    public class NegocioCiudad
    {

        public bool NuevaCiudad(String nombre , String idProv)
        {

            int cantFilas = 0;

            Ciudad ciu = new Ciudad();

            DatosCiudades dao = new DatosCiudades();

            ciu.SetIdCiudad(dao.NuevoIdCiudad());

            ciu.SetIdProvincia(idProv);

            ciu.SetNombre(nombre);

            if (dao.ExisteCiudad(ciu) == false)
            {
                cantFilas = dao.AgregarCiudad(ciu);
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
        public DataTable ObtenerDatoss(string consulta)
        {

            DatosCiudades datos = new DatosCiudades();

            return datos.ObtenerDatoss(consulta);

        }
        public DataTable ObtenerTablaCiudades(string table, string query)
        {

            DatosCiudades datciu = new DatosCiudades();

            return datciu.ObtenerTabla(table, query);

        }

        public IDataReader ObtenerDatos(string consulta)
        {

            DatosCiudades dao = new DatosCiudades();

            return dao.ObtenerDatos(consulta);

        }

        public bool EliminarCiudad(string id)
        {

            DatosCiudades datciu = new DatosCiudades();

            Ciudad ciu = new Ciudad();

            ciu.SetIdCiudad(id);
            int op = datciu.eliminarCiudad(ciu);

            if (op == 1)
                return true;
            else
                return false;
        }

        public int ActualizarCiudad(String query)
        {
            DatosCiudades dao = new DatosCiudades();

            return dao.ActualizarCiudad(query);

        }

        public DataTable GetTablaProvincias()
        {
            DatosCiudades dao = new DatosCiudades();
            return dao.GetProvincias();
        }



    }
}

