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
    public partial class Ciudades : System.Web.UI.Page
    {
        NegocioCiudad neg = new NegocioCiudad();

        private const String query_default = "select c.IdCiudad_ciu as 'Codigo',P.Nombre_pro AS 'Provincia', c.Nombre_ciu as 'Nombre' from Ciudades as C inner join Provincias as P on c.IdProvincia_ciu= p.IdProvincia_pro where c.Estado_ciu=1";

        private string id = String.Empty;

        private string nombre = String.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            sesion();
            if (!IsPostBack)
            {
                lblcargar();

                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

                this.Form.Attributes.Add("autocomplete", "off");

                LoadGridView(query_default);

                CargarProvincias();

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

        public void LoadGridView(String querydb)
        {
            gvCiudades.DataSource = neg.ObtenerTablaCiudades("Ciudades", querydb);

            gvCiudades.DataBind();

        }

        public void CargarProvincias()
        {
            DataTable TablaProvincias = neg.GetTablaProvincias();

            ddlPro.DataSource = TablaProvincias;
            ddlPro.DataTextField = "Nombre_pro";
            ddlPro.DataValueField = "IdProvincia_pro";
            ddlPro.DataBind();
            ddlPro.Items.Insert(0, new ListItem("--Seleccione Provincia--", "0"));
           
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Boolean estado = false;

         

            if (txtNombre.Text == "" || ddlPro.SelectedItem.Text == "--Seleccione Provincia--")
            {
                lblMensajeAgregado.Text = "No completo el Formulario Completamente";


            }
            else
            {
                estado = neg.NuevaCiudad(txtNombre.Text,ddlPro.SelectedValue);

                lblMensajeAgregado.Text = "";

                if (estado == true)
                {
                    LoadGridView(query_default);
                    lblMensajeAgregado.Text = "Se agregó la Ciudad";
                    txtNombre.Text = "";
                    ddlPro.SelectedIndex = 0;

                }
                else
                {
                    lblMensajeAgregado.Text = "Esa Ciudad ya existe";
                    txtNombre.Text = "";
                    ddlPro.SelectedIndex = 0;
                }
            }

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta = txtFiltroCiu.Text;

            if (txtFiltroCiu.Text != "")
            {
                lblMensajeList.Text = "";
                gvCiudades.DataSource = neg.ObtenerDatoss(consulta);
                gvCiudades.DataBind();
            }
            else
            {

                lblMensajeList.Text = "Ingrese algo para filtrar";
            }
        }

        protected void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtFiltroCiu.Text = String.Empty;

            txtNombre.Text = String.Empty;

            LoadGridView(query_default);
        }

       

        protected void gvCiudades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCiudades.EditIndex = e.NewEditIndex;
            LoadGridView(query_default);
        }

        protected void gvCiudades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.id = ((Label)gvCiudades.Rows[e.RowIndex].FindControl("lbl_item_codigo")).Text;

            this.nombre = ((TextBox)gvCiudades.Rows[e.RowIndex].FindControl("txt_edit_nombre")).Text;

            String idprov = ((DropDownList)gvCiudades.Rows[e.RowIndex].FindControl("ddlProEdit")).SelectedValue;

            String query = $"update dbo.Ciudades set Nombre_ciu='{ nombre }',IdProvincia_ciu= '{idprov}' where IdCiudad_ciu='{ id }'";


            neg.ActualizarCiudad(query);

            gvCiudades.EditIndex = -1;

            LoadGridView(query_default);
        }

        protected void gvCiudades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlProEdit");
                if(ddl != null)
                {
                    DataTable TablaProvincias = neg.GetTablaProvincias();

                    ddl.DataSource = TablaProvincias;
                    ddl.DataTextField = "Nombre_pro";
                    ddl.DataValueField = "IdProvincia_pro";
                    ddl.DataBind();
                }
            }

        }

        protected void gvCiudades_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCiudades.EditIndex = -1;

            LoadGridView(query_default);
        }

        protected void gvCiudades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCiudades.PageIndex = e.NewPageIndex;
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
                if (neg.EliminarCiudad(id))
                {
                    lblMensajeList.Text = $"Se ha eliminado la Ciudad con codigo { id }";
                }

                LoadGridView(query_default);

            }
        }
    }
}