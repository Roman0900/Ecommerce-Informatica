using System;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioMarca
    {
        public bool NuevaMarca(String nombre)
        {

            int cantFilas = 0;

            Marcas mar = new Marcas();

            DatosMarca dao = new DatosMarca();

            mar.SetIdMarca(dao.NuevoIdMarca());
            mar.SetNombreMarca(nombre);

            if (dao.ExisteMar(mar) == false)
            {
                cantFilas = dao.AgregarMarca(mar);
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
        public DataTable ObtenerTablaMarcas(string table, string query)
        {

            DatosMarca datmar = new DatosMarca();

            return datmar.ObtenerTabla(table, query);

        }

        public IDataReader ObtenerDatos(string consulta)
        {

            DatosMarca datos = new DatosMarca();

            return datos.ObtenerDatos(consulta);

        }
        public DataTable ObtenerDatoss(string consulta)
        {

            DatosMarca datos = new DatosMarca();

            return datos.ObtenerDatoss(consulta);

        }

        public bool eliminarMarca(string id)
        {

            DatosMarca dat = new DatosMarca();
            Marcas pro = new Marcas();
            pro.SetIdMarca(id);
            int op = dat.eliminarMarca(pro);
            if (op == 1)
                return true;
            else
                return false;
        }

        public int ActualizarMarca(String query)
        {
            DatosMarca mar = new DatosMarca();

            return mar.ActualizarMarca(query);
           
        }

        public DataTable GetTablaMarcas()
        {
            DatosMarca dao = new DatosMarca();
            return dao.GetMarcas();
        }

    }
}
