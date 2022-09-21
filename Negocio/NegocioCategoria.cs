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
    public class NegocioCategoria
    {

        public bool NuevaCategoria(String nombre)
        {

            int cantFilas = 0;

            Categoriass cat = new Categoriass();
            DatosCategorias dao = new DatosCategorias();
            cat.SetIdCategoria(dao.NuevoIdCategoria());
            cat.SetNombreCategoria(nombre);

            if (dao.ExisteCat(cat) == false)
            {
                cantFilas = dao.AgregarCategoria(cat);
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
        public DataTable ObtenerTablaCategoria(string table, string query)
        {

            DatosCategorias datcat = new DatosCategorias();

            return datcat.ObtenerTabla(table, query);

        }
        public IDataReader ObtenerDatos(string consulta)
        {

            DatosCategorias datos = new DatosCategorias();

            return datos.ObtenerDatos(consulta);

        }
        public DataTable ObtenerDatoss(string consulta)
        {

            DatosCategorias datos = new DatosCategorias();

            return datos.ObtenerDatoss(consulta);

        }

        public bool EliminarCategoria(string id)
        {

            DatosCategorias dat = new DatosCategorias();
            Categoriass pro = new Categoriass();
            pro.SetIdCategoria(id);
            int op = dat.eliminarCategoria(pro);
            if (op == 1)
                return true;
            else
                return false;
        }

        public int ActualizarCategoria(String query)
        {
            DatosCategorias cat = new DatosCategorias();

            return cat.ActualizarCategoria(query);

        }
        public DataTable GetTablaCategorias()
        {
            DatosCategorias dao = new DatosCategorias();
            return dao.GetCategorias();
        }



    }
}
