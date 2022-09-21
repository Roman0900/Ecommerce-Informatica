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
    public class NegocioProveedor
    {
        public DataTable ObtenerDatos(string consulta)
        {

            DatosProveedor datos = new DatosProveedor();

            return datos.ObtenerDatoss(consulta);

        }
        public DataTable ObtenerDatitos()
        {

            DatosProveedor datos = new DatosProveedor();

            return datos.ObtenerDatitos();

        }
        public bool NuevoProveedor(String razonSocial, String direccion, String provincia, String ciudad, String telefono, String web, String mail)
        {
            int cantFilas = 0;

            Proveedores pro = new Proveedores();
            DatosProveedor dao = new DatosProveedor();

            pro.SetIdProveedor(dao.NuevoIdProveedor());
            pro.SetRazonSocial(razonSocial);
            pro.SetDireccion(direccion);
            pro.SetProvincia(provincia);
            pro.SetCiudad(ciudad);
            pro.SetTelefono(telefono);
            pro.SetWeb(web);
            pro.SetEmail(mail);
            if (dao.ExisteProve(pro) == false)
            {
                cantFilas = dao.AgregarProveedor(pro);
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
        public DataTable ObtenerTablaciudades(string table, string query)
        {

            DatosProveedor dao = new DatosProveedor();

            return dao.ObtenerTabla(table, query);

        }

        public DataTable GetTablaProvincias()
        {
            DatosProveedor dao = new DatosProveedor();
            return dao.GetProvincias();
        }
        public DataTable GetTablaCiudades(String ID)
        {
            DatosProveedor dao = new DatosProveedor();
            return dao.GetCiudades(ID);
        }

        public bool eliminarProveedor(string id)
        {

            DatosProveedor dat = new DatosProveedor();
            Proveedores pro = new Proveedores();
            pro.SetIdProveedor(id);
            int op = dat.eliminarProve(pro);
            if (op == 1)
                return true;
            else
                return false;
        }


        public int ActualizarProveedor(string query)
        {
            DatosProveedor dat = new DatosProveedor();

            return dat.ActualizarProveedor(query);
        }
    }
}
