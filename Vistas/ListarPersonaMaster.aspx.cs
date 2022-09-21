using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
namespace Vistas
{
    public partial class ListarPersonaMaster : System.Web.UI.Page
    {
        NegocioPersona neg = new NegocioPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion();
            lblcargar();

            if (IsPostBack == false)
            {
                MostrarPersonas();
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


        public void MostrarPersonas()
        {
            txtDNI.Text = "";          
            gvPersonas.DataSource = neg.ObtenerDatitos();
            gvPersonas.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta = txtDNI.Text;

            if (txtDNI.Text != "")
            {
                lblMensaje.Text = "";
                gvPersonas.DataSource = neg.ObtenerDatoss(consulta);
                gvPersonas.DataBind();
            }
            else
            {

                lblMensaje.Text = "Ingrese algo para filtrar";
            }
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarPersonas();
        }

       

        protected void gvPersonas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPersonas.EditIndex = -1;

            MostrarPersonas();
        }

       
       

        protected void gvPersonas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPersonas.EditIndex = e.NewEditIndex;

            MostrarPersonas(); 
        }

        protected void gvPersonas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dni = ((Label)gvPersonas.Rows[e.RowIndex].FindControl("lbl_item_documento")).Text;

            string nom = ((TextBox)gvPersonas.Rows[e.RowIndex].FindControl("txt_edit_nombre")).Text;

            string ape = ((TextBox)gvPersonas.Rows[e.RowIndex].FindControl("txt_edit_apellido")).Text;

            string tel = ((TextBox)gvPersonas.Rows[e.RowIndex].FindControl("txt_edit_telefono")).Text;

            string mai = ((TextBox)gvPersonas.Rows[e.RowIndex].FindControl("txt_edit_mail")).Text;

            string query = $"update dbo.Personas set Nombre_per ='{ nom }',Apellido_per ='{ape}',Telefono_per ='{tel}', Email_per ='{mai}' where Dni_per ='{dni}'";
            
            neg.ActualizarPersona(query);

            gvPersonas.EditIndex = -1;

            MostrarPersonas();
        }

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EliminarClick")
            {
                string dni = e.CommandArgument.ToString();

                if (neg.EliminarPersona(dni) == 1)
                {
                    lblMensaje.Text = $"Se ha eliminado la persona con dni { dni }";
                }
                MostrarPersonas();

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

        protected void gvPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPersonas.PageIndex = e.NewPageIndex;

            MostrarPersonas();
        }
    }
}