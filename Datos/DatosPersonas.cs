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
    public class DatosPersonas
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable ObtenerDatitos()
        {
            DataTable tablita = ds.ObtenerTabla("Personas", "SELECT Dni_per as 'DNI',Nombre_per as 'Nombre',Apellido_per as 'Apellido',Telefono_per as 'Telefono',Email_per as 'Mail' FROM Personas where Estado_per =1");
            return tablita;
        }
        public DataTable ObtenerDatoss(string consulta)
        {
            DataTable tablita = ds.ObtenerTabla("Personas", "SELECT Dni_per as 'DNI',Nombre_per as 'Nombre',Apellido_per as 'Apellido',Telefono_per as 'Telefono',Email_per as 'Mail' FROM Personas WHERE Apellido_per LIKE '" + consulta + "%' AND Estado_per =1");
            return tablita;
        }
        public bool ExistePer(Personass per)
        {

            String consulta = "Select * from Personas where Dni_per='" + per.GetDni() + "'";
            return ds.existe(consulta);
        }
        public int AgregarPersona(Personass per)
        {
            SqlCommand comando = new SqlCommand();
            VincularCamposPer(ref comando, per);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarPersona");
        }
        private void VincularCamposPer(ref SqlCommand co, Personass per)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = co.Parameters.Add("@DNIPersona", SqlDbType.Char);
            SqlParametros.Value = per.GetDni();
            SqlParametros = co.Parameters.Add("@NombrePersona", SqlDbType.VarChar);
            SqlParametros.Value = per.GetNombre();
            SqlParametros = co.Parameters.Add("@ApellidoPersona", SqlDbType.VarChar);
            SqlParametros.Value = per.GetApellido();
            SqlParametros = co.Parameters.Add("@Contraseña", SqlDbType.VarChar);
            SqlParametros.Value = per.GetPassword();
            SqlParametros = co.Parameters.Add("@Telefono", SqlDbType.Char);
            SqlParametros.Value = per.GetTelefono();
            SqlParametros = co.Parameters.Add("@Mail", SqlDbType.VarChar);
            SqlParametros.Value = per.GetEmail();
            
        }
        public IDataReader ObtenerDatos(string consulta)
        {
            return ds.consultar(consulta);
        }

        public int EliminarPersona(string dni)
        {
            return ds.Update($"update dbo.Personas set Estado_per = 0 where Dni_per = '{ dni }'");

        }

        public int ActualizarPersona(string query)
        {

            return ds.Update(query);
        }



    }
}
