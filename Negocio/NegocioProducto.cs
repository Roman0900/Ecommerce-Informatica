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
    public class NegocioProducto
    {
        public DataTable ObtenerDatos()
        {

            DatosPorducto datos = new DatosPorducto();

            return datos.ObtenerDatos();

        }
        public DataTable ObtenerDatos(string consulta)
        {

            DatosPorducto datos = new DatosPorducto();

            return datos.ObtenerDatitos(consulta);

        }
        public DataTable GetTablaMarca()
        {
            DatosPorducto dao = new DatosPorducto();
            return dao.GetMarcas();
        }
        public DataTable GetTablaCategoria()
        {
            DatosPorducto dao = new DatosPorducto();
            return dao.GetCategorias();
        }
        public DataTable GetTablaProveedores()
        {
            DatosPorducto dao = new DatosPorducto();
            return dao.GetProveedores();
        }
        public bool eliminarProducto(string id)
        {

            DatosPorducto dat = new DatosPorducto();
            Productos pro = new Productos();
            pro.SetIdArticulo(id);
            int op = dat.eliminarProducto(pro);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool NuevoProducto(String nombre, String IDProveedor, String IDMarca, String IDCategoria, int Stock, decimal PrecioU )
        {

            int cantFilas = 0;

             Productos pro = new Productos();
            DatosPorducto dao = new DatosPorducto();
            pro.SetIdArticulo(dao.NuevoIdProducto());
            pro.SetNombreArticulo(nombre);
            pro.SetIdProveedor(IDProveedor);
            pro.SetIdMarca(IDMarca);
            pro.SetIdCategoria(IDCategoria);
            pro.SetStock(Stock);
            pro.SetPrecioUnitario(PrecioU);

            if (dao.ExistePro(pro) == false)
            {
                cantFilas = dao.AgregarProducto(pro);
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
        public int ActualizarProducto(String query)
        {
            DatosPorducto pro = new DatosPorducto();

            return pro.ActualizarProducto(query);

        }

        public DataTable IdXRegistro(DataTable tabla, string id)
        {
            Productos art = new Productos();

            DatosPorducto datos = new DatosPorducto();

            art.SetIdArticulo(id);
            art.SetNombreArticulo(datos.idXNombre(id));
            art.SetPrecioUnitario(Convert.ToDecimal(datos.idXPrecio(id)));

            DataRow fila = tabla.NewRow();
            fila["Codigo"] = art.GetIdArticulo();
            fila["Descripcion"] = art.GetNombreArticulo();

             
            fila["PrecioUnitario"] = art.GetPrecioUnitario();
            fila["Cantidad"] = 1;

            tabla.Rows.Add(fila);
            return tabla;

        }


        public int IDXSTOCK(string id)
        {
            Productos art = new Productos();

            DatosPorducto datos = new DatosPorducto();

            art.SetStock(Convert.ToInt32(datos.idxstock(id) ));

            return art.GetStock();

        }


    }
}
