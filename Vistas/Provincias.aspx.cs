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
    public partial class Provincias : System.Web.UI.Page
    {
        NegocioProvincia neg = new NegocioProvincia();

        private const String query_default = "select P.IdProvincia_pro as 'Codigo', P.Nombre_pro as 'Nombre' from dbo.Provincias as P where P.Estado_pro = 1";

        private string id = String.Empty;

        private string nombre = String.Empty;

        public void LoadGridView(String querydb)
        {
            gvProvincia.DataSource = neg.ObtenerTablaProvincia("Provincias", querydb);

            gvProvincia.DataBind();

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

        protected void Page_Load(object sender, EventArgs e)
        {

            sesion();
            lblcargar();

            if (!IsPostBack)
            {

                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

                this.Form.Attributes.Add("autocomplete", "off");

                LoadGridView(query_default);

            }
           

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Boolean estado = false;

            

            if (txtNombre.Text == "")
            {
                lblMensajeAgregado.Text = "Ingrese un Nombre para Provincia";
               

            }
            else
            {
                estado = neg.NuevaProvincia(txtNombre.Text);

                lblMensajeAgregado.Text = "";

                if (estado == true)
                {
                    LoadGridView(query_default);
                    lblMensajeAgregado.Text = "Se agregó la Provincia";
                    txtNombre.Text = "";

                }
                else
                {
                    lblMensajeAgregado.Text = "Esa Provincia ya existe";
                    txtNombre.Text = "";
                }
            }

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta =txtFiltroPro.Text;

            if (txtFiltroPro.Text != "")
            {
                lblMensajeList.Text = "";
                gvProvincia.DataSource = neg.ObtenerDatoss(consulta);
                gvProvincia.DataBind();
            }
            else
            {

                lblMensajeList.Text = "Ingrese algo para filtrar";
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtFiltroPro.Text = String.Empty;

            txtNombre.Text = String.Empty;

            LoadGridView(query_default);
        }

       

        protected void gvProvincia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProvincia.EditIndex = e.NewEditIndex;

            LoadGridView(query_default);
        }

        protected void gvProvincia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProvincia.EditIndex = -1;

            LoadGridView(query_default);
        }

        protected void gvProvincia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.id = ((Label)gvProvincia.Rows[e.RowIndex].FindControl("lbl_item_codigo")).Text;

            this.nombre = ((TextBox)gvProvincia.Rows[e.RowIndex].FindControl("txt_edit_nombre")).Text;

            String query = $"update dbo.Provincias set Nombre_pro='{ nombre }' where IdProvincia_pro='{ id }'";


            neg.ActualizarProvincia(query);

            gvProvincia.EditIndex = -1;

            LoadGridView(query_default);
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

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EliminarClick")
            {
                string id = e.CommandArgument.ToString();

                if (neg.EliminarProvincia(id))
                {
                    lblMensajeList.Text = $"Se ha eliminado la Provincia con codigo { id }";
                }

                LoadGridView(query_default);
            }

        }

        protected void gvProvincia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProvincia.PageIndex = e.NewPageIndex;

            LoadGridView(query_default);
        }
    }
}