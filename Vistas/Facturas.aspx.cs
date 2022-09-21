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
    public partial class Facturas : System.Web.UI.Page
    {
        NegocioFactura neg = new NegocioFactura();

        protected void Page_Load(object sender, EventArgs e)
        {

            sesion();
            lblcargar();

            if (IsPostBack == false)
            {
                MostrarFacturas();

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

        public void MostrarFacturas()
        {
            string ID = Session["DNIx"].ToString();

            string consulta = "SELECT * FROM FACTURASADMIN WHERE DNIFACTURA = '" + ID + "'";
            gvFacturas.DataSource = neg.ObtenerDatos(consulta);
            gvFacturas.DataBind();
        }

       

        public void sesion()
        {
            if (Session["acceso"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            
        }

        protected void btnseleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                Session["fac"] = e.CommandArgument.ToString();

                Server.Transfer("DetalleFacturaCliente.aspx");

            }
        }
    }

}
