using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
using System.Data.SqlClient;
namespace Vistas
{
    public partial class TiendaCliente : System.Web.UI.Page
    {
        NegocioCategoria cat = new NegocioCategoria();
        NegocioMarca mar = new NegocioMarca();
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion();
            lblcargar();

            if (IsPostBack == false){
                CargarCategorias();
                CargarMarcas();
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

        public void CargarCategorias()
        {
            DataTable tablaMarca = cat.GetTablaCategorias();

            ddlCategoria.DataSource = tablaMarca;
            ddlCategoria.DataTextField = "Nombre_cat";
            ddlCategoria.DataValueField = "IdCategoria_cat";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("--Seleccione Categoria--", "0"));
        }
        public void CargarMarcas()
        {
            DataTable tablaMarca = mar.GetTablaMarcas();

            ddlMarca.DataSource = tablaMarca;
            ddlMarca.DataTextField = "Nombre_mar";
            ddlMarca.DataValueField = "IdMarca_mar";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("--Seleccione Marca--", "0"));



        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM ARTICULOSCLIENTE2 WHERE ARTICULO LIKE '" + txtNombre.Text + "%'";

            if (txtNombre.Text != "")
            {
                ddlCategoria.SelectedIndex = 0;
                ddlMarca.SelectedIndex = 0;
                lblMensaje.Text = "";
                SqlDataSource1.SelectCommand = consulta;
            }
            else
            {

                lblMensaje.Text = "Ingrese algo para filtrar";
            }
        }

        public void MostrarArticulos()
        {
            txtNombre.Text = "";
            string consulta = "SELECT * FROM ARTICULOSCLIENTE2";
            SqlDataSource1.SelectCommand = consulta;



        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            ddlCategoria.SelectedIndex = 0;
            ddlMarca.SelectedIndex = 0;
            lblMensaje.Text = "";
            MostrarArticulos();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedItem.Text == "--Seleccione Categoria--")
            {
                if (ddlMarca.SelectedItem.Text == "--Seleccione Marca--")
                {
                    MostrarArticulos();
                }
                else
                {

                    String seleccionadoo = ddlMarca.SelectedItem.Text;
                    string consultaa = "SELECT * FROM ARTICULOSCLIENTE2 WHERE Marca ='" + seleccionadoo + "'";
                    SqlDataSource1.SelectCommand = consultaa;

                    
                }
            }
            else
            {
                if (ddlMarca.SelectedItem.Text == "--Seleccione Marca--")
                {
                     string seleccionado = ddlCategoria.SelectedItem.Text;
                    string consulte = "SELECT * FROM ARTICULOSCLIENTE2 WHERE Categoria ='" + seleccionado + "'";
                    SqlDataSource1.SelectCommand = consulte;
                }
                else
                {
                    String Marsec = ddlMarca.SelectedItem.Text;
                    String zeleccionado = ddlCategoria.SelectedItem.Text;
                    string consulta = "SELECT * FROM ARTICULOSCLIENTE2 WHERE Marca ='" + Marsec + "' and Categoria ='" + zeleccionado + "'";
                    SqlDataSource1.SelectCommand = consulta;
                }

                
            }

        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMarca.SelectedItem.Text == "--Seleccione Marca--")
            {
                if (ddlCategoria.SelectedItem.Text == "--Seleccione Categoria--")
                {
                    MostrarArticulos();
                }
                else
                {
                    String seleccionado = ddlMarca.SelectedItem.Text;
                    String zeleccionado = ddlCategoria.SelectedItem.Text;
                    string consulta = "SELECT * FROM ARTICULOSCLIENTE2 WHERE Categoria ='" + zeleccionado + "'";
                    SqlDataSource1.SelectCommand = consulta;

                }
            }
            else
            {
                if(ddlCategoria.SelectedItem.Text == "--Seleccione Categoria--")
                {
                    String seleccionadoo = ddlMarca.SelectedItem.Text;
                    string consultaa = "SELECT * FROM ARTICULOSCLIENTE2 WHERE Marca ='" + seleccionadoo + "'";
                    SqlDataSource1.SelectCommand = consultaa;
                }
                else
                {
                    String seleccionado = ddlMarca.SelectedItem.Text;
                    String zeleccionado = ddlCategoria.SelectedItem.Text;
                    string consulta = "SELECT * FROM ARTICULOSCLIENTE2 WHERE Marca ='" + seleccionado + "' and Categoria ='" + zeleccionado + "'";
                    SqlDataSource1.SelectCommand = consulta;


                }

                

            }

        }

        protected void btnSeleccion_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                Session["idArt"] = e.CommandArgument.ToString();
            }

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