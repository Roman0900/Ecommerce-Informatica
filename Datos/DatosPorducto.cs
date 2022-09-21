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
    public class DatosPorducto
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable ObtenerDatos()
        {
            DataTable tablita = ds.ObtenerTabla("ARTICULOSADMIN", "Select * from ARTICULOSADMIN");
            return tablita;
        }
        public DataTable ObtenerDatitos(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("ARTICULOSADMIN", "SELECT * FROM ARTICULOSADMIN WHERE ARTICULO LIKE '" + consulta + "%'");
            return tablita;
        }
        public DataTable GetMarcas()
        {
            DataTable tabla = ds.ObtenerTabla("Marcas", "Select * from Marcas");

            return tabla;
        }
        public DataTable GetCategorias()
        {
            DataTable tabla = ds.ObtenerTabla("Categorias", "Select * from Categorias");

            return tabla;
        }
        public DataTable GetProveedores()
        {
            DataTable tabla = ds.ObtenerTabla("Proveedores", "Select * from Proveedores");

            return tabla;
        }
        public bool ExistePro(Productos pro)
        {

            String consulta = "Select * from Articulos where Descripcion_ar='" + pro.GetNombreArticulo() + "'";
            return ds.existe(consulta);
        }
        public int AgregarProducto(Productos pro)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposPro(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProducto");
        }   

        public String NuevoIdProducto()
        {
            int cant;
            cant=ds.ObtenerMaximo("SELECT count(IdArticulo_ar) FROM Articulos") + 1;
            String ID = "ART"+cant;
            return ID;
        }

        private void VincularCamposPro(ref SqlCommand co, Productos pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@IDProducto", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdArticulo();
            SqlParametros = co.Parameters.Add("@IDProveedor", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdProveedor();
            SqlParametros = co.Parameters.Add("@IDMarca", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdMarca();
            SqlParametros = co.Parameters.Add("@IDCategoria", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdCategoria();
            SqlParametros = co.Parameters.Add("@NombreArticulo", SqlDbType.VarChar);
            SqlParametros.Value = pro.GetNombreArticulo();
            SqlParametros = co.Parameters.Add("@Stock", SqlDbType.Int);
            SqlParametros.Value = pro.GetStock();
            SqlParametros = co.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
            SqlParametros.Value = pro.GetPrecioUnitario();
        }
        private void ArmarParametrosEliminar(ref SqlCommand Comando, Productos pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdProducto", SqlDbType.Char);
            SqlParametros.Value = pro.GetIdArticulo();
        }
        public int eliminarProducto(Productos pro)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarProducto");
        }

        public int ActualizarProducto(String query)
        {

            return ds.Update(query);

        }


        public string idXNombre(string id)
        {
            string nombre = string.Empty;
            string consulta = "SELECT DESCRIPCION_AR FROM ARTICULOS WHERE IDARTICULO_AR='" + id + "'"; 
            nombre=ds.ObtenerDato(consulta);
            return nombre;
        }

        public string idXPrecio(string id)
        {
            string Precio;
            string consulta = "SELECT PrecioUnitario_AR FROM ARTICULOS WHERE IDARTICULO_AR='" + id + "'";
            Precio = ds.ObtenerDato(consulta);
            return Precio;
        }

        public string idxstock(string id)
        {
            string stock;
            string consulta = "SELECT Stock_AR FROM ARTICULOS WHERE IDARTICULO_AR='" + id + "'";
            stock = ds.ObtenerDato(consulta);
            return stock;
        }

    }
}
