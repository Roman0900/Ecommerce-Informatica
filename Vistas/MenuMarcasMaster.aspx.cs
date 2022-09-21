using System;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;




namespace Vistas
{
    public partial class MenuMarcasMaster : System.Web.UI.Page
    {
        NegocioMarca neg = new NegocioMarca();

        private const String query_default = "select m.IdMarca_mar as 'Codigo',m.Nombre_mar as 'Nombre' from dbo.Marcas as m where m.Estado_mar = 1";

        private string id = String.Empty;

        private string nombre = String.Empty;

        public void LoadGridView(String querydb)
        {
            gvMarcas.DataSource = neg.ObtenerTablaMarcas("Marcas", querydb);

            gvMarcas.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            sesion();
            lblcargar();
            if (!IsPostBack)
            {
                gvMarcas.PageSize = 5;

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

            estado = neg.NuevaMarca(txtNombre.Text);

            if (txtNombre.Text == "")
            {
                lblMensajeAgregado.Text = "Ingrese un Nombre de Marca";

            }
            else
            {
                lblMensajeAgregado.Text = "";

                if (estado == true)
                {
                    LoadGridView(query_default);
                    lblMensajeAgregado.Text = "Se agrego con exito la Marca :D";
                    txtNombre.Text = "";

                }
                else
                {
                    lblMensajeAgregado.Text = "Esa Marca ya existe";
                    txtNombre.Text = "";
                }
            }
        }


        protected void btnFiltrar_Click1(object sender, EventArgs e)
        {

            string consulta =txtFiltroMar.Text;

            if (txtFiltroMar.Text != "")
            {
                lblMensajeList.Text = "";
                gvMarcas.DataSource = neg.ObtenerDatoss(consulta);
                gvMarcas.DataBind();
            }
            else
            {

                lblMensajeList.Text = "Ingrese algo para filtrar";
            }
        }

        protected void btnMostrar_Click1(object sender, EventArgs e)
        {

            txtFiltroMar.Text= String.Empty;

            txtNombre.Text = String.Empty;

            LoadGridView(query_default);
        }

        protected void gvMarcas_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            gvMarcas.PageIndex = e.NewPageIndex;

            LoadGridView(query_default);
        }

       

        protected void gvMarcas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMarcas.EditIndex = e.NewEditIndex;

            LoadGridView(query_default);
        }

        protected void gvMarcas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMarcas.EditIndex = -1;

            LoadGridView(query_default);
        }

        protected void gvMarcas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            this.id = ((TextBox)gvMarcas.Rows[e.RowIndex].FindControl("txt_edit_codigo")).Text;

            this.nombre = ((TextBox)gvMarcas.Rows[e.RowIndex].FindControl("txt_edit_nombre")).Text;

            String query = $"update dbo.Marcas set  Nombre_mar = '{ nombre }' where IdMarca_mar = '{id}'";

            neg.ActualizarMarca(query);

            gvMarcas.EditIndex = -1;

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
                if (neg.eliminarMarca(id))
                {
                    lblMensajeList.Text = $"Se ha eliminado la marca con codigo { id}";
                }

                LoadGridView(query_default);


            }
        }
    }
}