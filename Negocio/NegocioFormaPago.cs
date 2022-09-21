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
    public class NegocioFormaPago
    {

        public DataTable GetTablaFormaPago()
        {
            DatosFormaPago dao = new DatosFormaPago();
            return dao.GetFormaPago();
        }
    }
}
