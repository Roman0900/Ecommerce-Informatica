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
    public partial class ListarProveedoresMaster : System.Web.UI.Page
    {
        NegocioProveedor neg = new NegocioProveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion();
            lblcargar();

            if (IsPostBack == false)
            {
                MostrarProveedores();
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

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarProveedores();

        }

        public void MostrarProveedores()
        {
          
            txtFiltro.Text = "";
            gvProductos.DataSource = neg.ObtenerDatitos();
            gvProductos.DataBind();

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta = txtFiltro.Text;

            if (txtFiltro.Text != "")
            {
                lblMensaje.Text = "";
                gvProductos.DataSource = neg.ObtenerDatos(consulta);
                gvProductos.DataBind();
            }
            else
            {

                lblMensaje.Text = "Ingrese algo para filtrar";
            }
        }

       

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;

            MostrarProveedores();
        }

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;

            MostrarProveedores();
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_item_codigoproveedor")).Text;

            string nombre = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_item_proveedor")).Text;

            if (neg.eliminarProveedor(id))
            {
                lblMensaje.Text = $"Se ha eliminado el proveedor { nombre } con codigo { id }";
            }
            MostrarProveedores();
        }

        private String GetValue_DDl(string ddlname, int index)
        {
            DropDownList ddlcontrol = ((DropDownList)gvProductos.Rows[index].FindControl(ddlname));

            foreach (ListItem item in ddlcontrol.Items)
            {
                if (item.Selected) return item.Value;
            }

            return String.Empty;


        }

  
        protected void gvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_item_codigoproveedor")).Text;

            string nom= ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_proveedor")).Text;

            string dir = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_direccion")).Text;

            string pro = GetValue_DDl("ddl_edit_provincia", e.RowIndex);

            if (pro == String.Empty)
            {
                pro= ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_item_provincia")).Text;
            }

            string ciu = GetValue_DDl("ddl_edit_ciudad", e.RowIndex);

            if (ciu == String.Empty)
            {
                ciu = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_item_ciudad")).Text;
            }

            string tel= ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_telefono")).Text;

            string web = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_paginaweb")).Text;

            string mai = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_email")).Text;

            string query = $"update dbo.Proveedores set RazonZocial_prov='{nom}',Direccion_prov='{dir}',IdProvincia_prov='{pro}',IdCiudad_prov='{ciu}',Telefono_prov='{tel}',Web_prov='{web}',Email_prov='{mai}' where IdProveedor_prov='{id}'";

            neg.ActualizarProveedor(query);

            gvProductos.EditIndex = -1;

            MostrarProveedores();
        }

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "EliminarClick")
            {
                string id = e.CommandArgument.ToString();



                if (neg.eliminarProveedor(id))
                {
                    lblMensaje.Text = $"Se ha eliminado el proveedor con codigo { id }";
                }
                MostrarProveedores();
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

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;

            MostrarProveedores();
        }
    }
}