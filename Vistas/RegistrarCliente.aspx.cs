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
    public partial class RegistrarCliente : System.Web.UI.Page
    {
        NegocioPersona neg = new NegocioPersona();
        protected void Page_Load(object sender, EventArgs e)
        {

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
        private Boolean SoloNumeros()
        {
            // true al ingresar un numero o caracteres que no sean letras

            return Regex.IsMatch(txtDNI.Text, @"[^A-Z  a-z\u00E0-\u00FC\u00f1\u00d1]{1,}");
        }
        private Boolean SoloNumeros2()
        {
            // true al ingresar un numero o caracteres que no sean letras

            return Regex.IsMatch(txtTelefono.Text, @"[^A-Z  a-z\u00E0-\u00FC\u00f1\u00d1]{1,}");
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Boolean estado = false;
            if (NoNumerosNiCosasRaras() == true || SoloNumeros()==false || SoloNumeros2()==false || txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text ==" " || txtContraseña.Text == " " || txtContraseña2.Text==" " || txtContraseña2.Text!=txtContraseña.Text || txtTelefono.Text == " " || txtMail.Text == " ")
            {
                lblMensaje.Text = "Datos vacios o incorrectos";
               
            }
            else
            {
                estado = neg.NuevaPersona(txtDNI.Text, txtNombre.Text, txtApellido.Text, txtContraseña.Text, txtTelefono.Text, txtMail.Text);
                if (estado == true)
                {
                    lblMensaje.Text = "Agregado";
                    txtDNI.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtContraseña.Text = "";
                    txtTelefono.Text = "";
                    txtMail.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Esa persona ya existe";
                    txtDNI.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtContraseña.Text = "";
                    txtTelefono.Text = "";
                    txtMail.Text = "";

                }
            }
            
        }
    }
}