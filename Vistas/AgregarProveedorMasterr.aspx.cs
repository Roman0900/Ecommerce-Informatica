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
    public partial class AgregarProveedorMasterr : System.Web.UI.Page
    {
        NegocioProveedor neg = new NegocioProveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion();
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.Form.Attributes.Add("autocomplete", "off");
           
            if (IsPostBack == false)
            {
                CargarProvincias();
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
            String seleccionado = ddlProvincia.SelectedValue;
            String zeleccionado = ddlCiudad.SelectedValue;

            if(ddlCiudad.SelectedIndex==0 || ddlProvincia.SelectedIndex == 0)
            {
                lblMensaje.Text = "Olvido Seleccionar alguna opcion";
            }
            else
            {
                lblMensaje.Text = "";

                estado = neg.NuevoProveedor(txtRazonSocial.Text, txtDireccion.Text, Convert.ToString(seleccionado), Convert.ToString(zeleccionado), txtTelefono.Text, txtWeb.Text, txtMail.Text);
                if (estado == true)
                {
                    lblMensaje.Text = "Se agrego con exito el Proveedor :D";
                    txtRazonSocial.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    ddlProvincia.SelectedIndex = 0;
                    ddlCiudad.SelectedIndex = 0;
                    txtWeb.Text = "";
                    txtMail.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Ese Proveedor ya existe";
                    txtRazonSocial.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    ddlProvincia.SelectedIndex = 0;
                    ddlCiudad.SelectedIndex = 0;
                    txtWeb.Text = "";
                    txtMail.Text = "";
                }
            }
            
        }

        public void CargarProvincias()
        {
            DataTable tablaMarca = neg.GetTablaProvincias();

            ddlProvincia.DataSource = tablaMarca;
            ddlProvincia.DataTextField = "Nombre_pro";
            ddlProvincia.DataValueField = "IdProvincia_pro";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione Provincia--", "0"));
            ddlCiudad.Items.Insert(0, new ListItem("--Seleccione Ciudad--", "0"));

            

        }

       

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String idProvincia = ddlProvincia.SelectedItem.Text;
            string consulta = "SELECT IdCIUDAD_CIU, NOMBRE_CIU, NOMBRE_PRO FROM Ciudades INNER JOIN Provincias ON IdProvincia_pro = IdProvincia_ciu WHERE Nombre_pro = '" + idProvincia + "'";
            //"SELECT * from Ciudades where idProvincia_ciu =" + idProvincia;
            ddlCiudad.DataSource = neg.ObtenerTablaciudades("Ciudades", consulta);
            ddlCiudad.DataTextField = "Nombre_ciu";
            ddlCiudad.DataValueField = "IdCiudad_ciu";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("--Seleccione Ciudad--", "0"));
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