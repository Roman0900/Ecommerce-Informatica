using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class ReportesAdmin : System.Web.UI.Page
    {
        NegocioFactura neg = new NegocioFactura();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            sesion();
            lblcargar();

            if (IsPostBack == false)
            {
                

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

       

       
      

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if(txtFechaIni.Text == "" || txtFechaFinal.Text == "")
            {
                lblAviso.Text = "No se ingreso un rango de fechas para el reporte";

            }
            else if(Convert.ToDateTime(txtFechaIni.Text) > Convert.ToDateTime(txtFechaFinal.Text))
            {
                lblAviso.Text ="La fecha inicial debe ser mayor a la final";
            }
            else
            {
                lbltotal.Text = "El total de dinero que entro en la tienda es de " + neg.obtenertotal(txtFechaIni.Text.ToString(), txtFechaFinal.Text.ToString()) ;

                
                
                txtFechaIni.Text = "";
                txtFechaFinal.Text = "";
            }
        }
    }
}