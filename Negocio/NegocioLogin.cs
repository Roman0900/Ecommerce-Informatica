using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using Datos;
using System.Data.SqlClient;


namespace Negocio
{
    public class NegocioLogin
    {

        public DataTable ObtenerLogin(String nombre, String pass)
        {

            DatosLogin dao = new DatosLogin();

            return dao.getLogin(nombre, pass);

        }

        
    }
}
