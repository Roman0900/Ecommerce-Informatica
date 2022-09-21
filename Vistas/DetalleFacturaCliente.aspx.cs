using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
namespace Vistas
{
    public partial class DetalleFacturaCliente : System.Web.UI.Page
    {
        NegocioDetalleFactura neg = new NegocioDetalleFactura();



        protected void Page_Load(object sender, EventArgs e)
        {
            string aux = Session["fac"].ToString();
            sesion();
            lblcargar();

            if (IsPostBack == false)
            {
                lblFacturaid.Text = "VISUALIZANDO FACTURA: " + aux;
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
            string aux = Session["fac"].ToString();


            txtFiltro.Text = "";
            string consulta = "SELECT * FROM DETALLEFACTURASADMIN WHERE IDFACTURA='" + aux + "'";
            gvDetalle.DataSource = neg.ObtenerDatos(consulta);
            gvDetalle.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string aux = Session["fac"].ToString();

            string consulta = "SELECT* FROM DETALLEFACTURASADMIN WHERE IDFACTURA = '" + aux + "' AND ARTICULO LIKE '" + txtFiltro.Text + "%'";

            if (txtFiltro.Text != "")
            {
                lblMensajeList.Text = "";
                gvDetalle.DataSource = neg.ObtenerDatos(consulta);
                gvDetalle.DataBind();
            }
            else
            {

                lblMensajeList.Text = "Ingrese algo para filtrar";
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            lblMensajeList.Text = "";
            MostrarFacturas();
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