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
    public partial class MenuFacturas : System.Web.UI.Page
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
            txtFiltro.Text = "";

            
            gvFacturas.DataSource = neg.ObtenerDatitos();
            gvFacturas.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta =txtFiltro.Text;
            if (txtFiltro.Text != "")
            {
                lblMensajeList.Text = "";
                gvFacturas.DataSource = neg.ObtenerDatoss(consulta);
                gvFacturas.DataBind();
            }
            else
            {

                lblMensajeList.Text = "Ingrese algo para filtrar";
            }

        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            MostrarFacturas();
        }

       

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {
            String id = string.Empty;

                if (e.CommandName == "EliminarClick")
                {
                id = e.CommandArgument.ToString();
               
                }

            if (neg.EliminarFactura(id))
            {
               lblMensajeList.Text = "SE ELIMINO LA FACTURA CON CODIGO " + id;
                MostrarFacturas();
            }
            



        }

        protected void LBCodigo_Command(object sender, CommandEventArgs e)
        {

            

            if (e.CommandName == "VerDetalle")
            {
                Session["fac"] = e.CommandArgument.ToString();

                Server.Transfer("DetalleFactura.aspx");

            }
        }

        protected void gvFacturas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id = ((Label)gvFacturas.Rows[e.NewSelectedIndex].FindControl("lbl_item_idfactura")).Text;

            Session["fac"] = id;

            Response.Redirect($"DetalleFactura.aspx?id={id}");
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

        protected void gvFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFacturas.PageIndex = e.NewPageIndex;
            MostrarFacturas();
        }
    }
}