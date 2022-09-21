using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;
using System.Text.RegularExpressions;
namespace Vistas
{
    public partial class Cuenta : System.Web.UI.Page
    {
        NegocioPersona per = new NegocioPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion();
            lblcargar();
            if (IsPostBack == false)
            {
                MostrarPersona();
            }
        }

        public void lblcargar()
        {
            String nombre = string.Empty;
            if (Session["usuario"] != null)
            {
                nombre = Session["usuario"].ToString();
            }
            lblUsuario.Text = "Bienvenido " + nombre;
        }

        public void MostrarPersona()
        {
            if (Session["DNI"] != null)
            {
                string consulta = "SELECT Dni_per as 'DNI',Nombre_per as 'Nombre',Apellido_per as 'Apellido',Telefono_per as 'Telefono',Email_per as 'Mail' FROM Personas where Dni_per ='" + Session["DNI"].ToString() + "'";
                gvCliente.DataSource = per.ObtenerDatos(consulta);
                gvCliente.DataBind();
            }
           
        }
        private string GetInput()
        {

            return txtNombre.Text + txtApellido.Text;
        }
        private Boolean NoNumerosNiCosasRaras()
        {
            // true al ingresar un numero o caracteres que no sean letras

            return Regex.IsMatch(GetInput(), @"[^A-Z  a-z\u00E0-\u00FC\u00f1\u00d1]{1,}");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (NoNumerosNiCosasRaras() == true || txtNombre.Text == "" || txtApellido.Text == " " || txtContraseña.Text == " " || txtTelefono.Text == " " || txtMail.Text == " ")
            {
                lblMensajito.Text = "Datos vacios o incorrectos";

            }
            else
            {
                
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string constraseña = txtContraseña.Text;
                string telefono = txtTelefono.Text;
                string mail = txtMail.Text;
                string consulta = $"UPDATE dbo.Personas set Nombre_per = '{ nombre }',Apellido_per = '{ apellido }', Password_per = '{ constraseña }',Telefono_per = '{ telefono }',Email_per = '{ mail }' where Dni_per = '{Session["DNI"].ToString() }'";
                per.ActualizarPersona(consulta);
                lblMensajito.Text = "Actualizado";
                MostrarPersona();
            }
            
        }



        public void sesion()
        {
            if (Session["acceso"] == null)
            {
                Response.Redirect("Login.aspx");
            }

          
        }

    }
}