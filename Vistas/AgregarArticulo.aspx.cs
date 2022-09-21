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
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        
            NegocioProducto neg = new NegocioProducto();

            protected void Page_Load(object sender, EventArgs e)
            {
                 sesion();

                this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
                this.Form.Attributes.Add("autocomplete", "off");
                if (IsPostBack == false)
                {
                    CargarMarcas();
                    CargarCategorias();
                CargarProveedor();
                    lblcargar();
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
            String seleccionado = ddlMarca.SelectedValue;
            String zeleccionado = ddlCategoria.SelectedValue;
            string selected = ddlprov.SelectedValue;
            if (ddlCategoria.SelectedIndex == 0 || ddlMarca.SelectedIndex == 0 || ddlprov.SelectedIndex == 0)
            {
                lblMensaje.Text = "Faltan Seleccionar Opciones";

            }
            else
            {
                estado = neg.NuevoProducto(txtNombreProducto.Text, Convert.ToString(selected), Convert.ToString(seleccionado), Convert.ToString(zeleccionado), Convert.ToInt32(txtStock.Text), Convert.ToDecimal(txtPrecioUnitario.Text));
                if (estado == true)
                {
                    lblMensaje.Text = "Se agrego el producto";
                    txtNombreProducto.Text = "";
                    ddlprov.SelectedIndex = 0;
                    ddlMarca.SelectedIndex = 0;
                    ddlCategoria.SelectedIndex = 0;
                    txtStock.Text = "";
                    txtPrecioUnitario.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Ese producto ya existe";
                    txtNombreProducto.Text = "";
                    ddlprov.SelectedIndex = 0;
                    ddlMarca.SelectedIndex = 0;
                    ddlCategoria.SelectedIndex = 0;
                    txtStock.Text = "";
                    txtPrecioUnitario.Text = "";

                }
            }
        }

            public void CargarMarcas()
            {
                DataTable tablaMarca = neg.GetTablaMarca();

                ddlMarca.DataSource = tablaMarca;
                ddlMarca.DataTextField = "Nombre_mar";
                ddlMarca.DataValueField = "IdMarca_mar";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("--Seleccione Marca--", "0"));

            }

            public void CargarCategorias()
            {
                DataTable tablaCategoria = neg.GetTablaCategoria();

                ddlCategoria.DataSource = tablaCategoria;
                ddlCategoria.DataTextField = "Nombre_cat";
                ddlCategoria.DataValueField = "IdCategoria_cat";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("--Seleccione Categoria--", "0"));

            }

            public void CargarProveedor()
            {
                DataTable tablaProveedores = neg.GetTablaProveedores();

                ddlprov.DataSource = tablaProveedores;
                ddlprov.DataTextField = "RazonZocial_prov";
                ddlprov.DataValueField = "IdProveedor_prov";
                ddlprov.DataBind();
                ddlprov.Items.Insert(0, new ListItem("--Seleccione Proveedor--", "0"));

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



    }

       
    
}