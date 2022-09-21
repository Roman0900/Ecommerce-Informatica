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
    public class NegocioPersona
    {
        public bool NuevaPersona(String DNI, String nombre, String apellido, String contraseña, String telefono, String mail)
        {

            int cantFilas = 0;

            Personass per = new Personass();
            DatosPersonas dao = new DatosPersonas();
            per.SetDni(DNI);
            per.SetNombre(nombre);
            per.SetApellido(apellido);
            per.SetPassword(contraseña);
            per.SetTelefono(telefono);
            per.SetEmail(mail);

            if (dao.ExistePer(per) == false)
            {
                cantFilas = dao.AgregarPersona(per);
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
        public IDataReader ObtenerDatos(string consulta)
        {

            DatosPersonas datos = new DatosPersonas();

            return datos.ObtenerDatos(consulta);

        }
        public DataTable ObtenerDatoss(string consulta)
        {

            DatosPersonas datos = new DatosPersonas();

            return datos.ObtenerDatoss(consulta);

        }
        public DataTable ObtenerDatitos()
        {

            DatosPersonas datos = new DatosPersonas();

            return datos.ObtenerDatitos();

        }

        public int EliminarPersona(string dni)
        {
            DatosPersonas datos = new DatosPersonas();

            return datos.EliminarPersona(dni);

        }


        public int ActualizarPersona(string query)
        {
            DatosPersonas datos = new DatosPersonas();
           
            return datos.ActualizarPersona(query);

        }


    }
}
