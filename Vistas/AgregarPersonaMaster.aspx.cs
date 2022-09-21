using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;
namespace Vistas
{
    public partial class AgregarPersonaMaster : System.Web.UI.Page
    {
        NegocioPersona neg = new NegocioPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion();
            lblcargar();
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Boolean estado = false;          
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

        public void sesion()
        {
            if (Session["acceso"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else if (Session["acceso"].ToString() != "True")
            {

                Response.Redirect("Login.aspx");
            }
        }

    }
    }
