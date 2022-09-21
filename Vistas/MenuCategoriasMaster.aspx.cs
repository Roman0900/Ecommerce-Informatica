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
    public partial class MenuCategorias : System.Web.UI.Page
    {
        NegocioCategoria neg = new NegocioCategoria();
        
        private const String query_default = "select c.IdCategoria_cat as 'Codigo',c.Nombre_cat as 'Nombre' from dbo.Categorias as c where Estado_cat =1";

        private string id = String.Empty;

        private string nombre = String.Empty;

        public void LoadGridView(String querydb)
        {
            gvCategorias.DataSource = neg.ObtenerTablaCategoria("Categorias", querydb);

            gvCategorias.DataBind();

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

            estado = neg.NuevaCategoria(txtNombre.Text);

            if (txtNombre.Text == "")
            {
                lblMensajeAgregado.Text = "Ingrese un Nombre de Categoria";

            }
            else
            {
                lblMensajeAgregado.Text = "";

                if (estado == true)
                {
                    LoadGridView(query_default);
                    lblMensajeAgregado.Text = "Se agregó la Categoria";
                    txtNombre.Text = "";

                }
                else
                {
                    lblMensajeAgregado.Text = "Esa Categoria ya existe";
                    txtNombre.Text = "";
                }
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta =txtFiltroCat.Text;

            if (txtFiltroCat.Text != "")
            {
                lblMensajeList.Text = "";
                gvCategorias.DataSource = neg.ObtenerDatoss(consulta);
                gvCategorias.DataBind();
            }
            else
            {

                lblMensajeList.Text = "Ingrese algo para filtrar";
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {

            txtFiltroCat.Text = String.Empty;

            txtNombre.Text = String.Empty;

            LoadGridView(query_default);
        }

       

        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategorias.EditIndex = e.NewEditIndex;

            LoadGridView(query_default);
        }

        protected void gvCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategorias.EditIndex = -1;

            LoadGridView(query_default);


        }

        protected void gvCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.id = ((Label)gvCategorias.Rows[e.RowIndex].FindControl("lbl_item_codigo")).Text;

            this.nombre = ((TextBox)gvCategorias.Rows[e.RowIndex].FindControl("txt_edit_nombre")).Text;

            String query = $"update dbo.Categorias set Nombre_cat='{ nombre }' where IdCategoria_cat='{ id }'";
         
            
            neg.ActualizarCategoria(query);

            gvCategorias.EditIndex = -1;

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


                if (neg.EliminarCategoria(id))
                {
                    lblMensajeList.Text = $"Se ha eliminado la marca { nombre } con codigo { id }";
                }

                LoadGridView(query_default);
            }
        }

        protected void gvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategorias.PageIndex = e.NewPageIndex;
            LoadGridView(query_default);
        }
    }
}