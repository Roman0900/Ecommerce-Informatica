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
    public class DatosLogin
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getLogin(string usuario, string pass)
        {
            
            String consulta = "select * from Personas where Dni_per = '" + usuario + "' and Password_per = '" + pass + "' and Estado_per = 1";
            //DataTable tabla
            
            return  ds.ObtenerTabla("Personas", consulta);
            //return tabla;
        }

      
    }
}
