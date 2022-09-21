using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas
{
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        NegocioProducto neg = new NegocioProducto();

        private string id = String.Empty;

        private string nombre = String.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {

            sesion();
            lblcargar();

            if (IsPostBack == false)
            {
                MostrarArticulos();
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
            MostrarArticulos();

        }

        public void MostrarArticulos()
        {
            txtidart.Text = "";
            
            gvProductos.DataSource = neg.ObtenerDatos();
            gvProductos.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

            string consulta =  txtidart.Text;

            if (txtidart.Text != "")
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

       

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;

            MostrarArticulos();
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)

        {
           

           

        }

        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;

            MostrarArticulos();
        }



        private String GetValue_DDl(string ddlname,int index)
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

            string id = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_item_codigoarticulo")).Text;

            string pro = GetValue_DDl("ddl_edit_proveedor", e.RowIndex);

            string mar = GetValue_DDl("ddl_edit_marca", e.RowIndex);

            string cat = GetValue_DDl("ddl_edit_categoria", e.RowIndex);

            string art = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_articulo")).Text;

            int sto = Convert.ToInt32(((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_stock")).Text);

            string aux= ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_edit_precio")).Text;

            string[] aux_array = aux.Split('$');

            double pre = Convert.ToDouble(aux_array[1]); 

            string query = $"update dbo.Articulos set IdProveedor_ar = '{ pro}',IdMarca_ar = '{ mar }',IdCategoria_ar = '{ cat }', Descripcion_ar = '{ art }',Stock_ar = { sto },PrecioUnitario_ar = { pre } where IdArticulo_ar = '{id}'";

            neg.ActualizarProducto(query);

            gvProductos.EditIndex = -1;

            MostrarArticulos();


        }

        protected void eliminar_Command(object sender, CommandEventArgs e)

        {
            if (e.CommandName == "EliminarClick")
            {

                this.id = e.CommandArgument.ToString();



                if (neg.eliminarProducto(id))
                {
                    lblMensaje.Text = $"Se ha eliminado el articulo con código { id }";
                }

                MostrarArticulos();
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

            MostrarArticulos();
        }
    }
}