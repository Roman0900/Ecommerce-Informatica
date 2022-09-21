using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["acceso"] = "Cerrar";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            NegocioLogin log = new NegocioLogin();
            DataTable dtLog = new DataTable();
            dtLog = log.ObtenerLogin(txtUsuario.Text, txtDni.Text);  
            Session["DNI"] = txtUsuario.Text;
            txtUsuario.Text = "";
            txtDni.Text = "";
            if (dtLog.Rows.Count != 0) 
            {
                Session["usuario"] = dtLog.Rows[0]["Nombre_per"].ToString();
                Session["acceso"] = dtLog.Rows[0]["Tipo_per"].ToString();
                Session["DNIx"] = dtLog.Rows[0]["DNI_per"].ToString();

                
                                                    
                redireccionar();

            }
            else { lblLogin.Text = "Contraseña o Dni Incorrectos Ingrese de nuevo"; }

        }

        public  void redireccionar()
        {
            
                if (Session["acceso"].ToString() == "True")
                {

                  Response.Redirect("PrincipalAdmin.aspx");
            }
                else if (Session["acceso"].ToString() == "False")
            {
                Response.Redirect("TiendaCliente.aspx");
            }
            
        }
    }
}