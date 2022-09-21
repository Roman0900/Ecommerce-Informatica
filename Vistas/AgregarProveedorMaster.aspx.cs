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
    public partial class MenuProveedoresMaster : System.Web.UI.Page
    {
        NegocioProveedor neg = new NegocioProveedor();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.Form.Attributes.Add("autocomplete", "off");

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Boolean estado = false;
            int seleccionado = ddlProvincia.SelectedIndex;
            int zeleccionado = ddlCiudad.SelectedIndex;
            estado = neg.NuevoProveedor(txtRazonSocial.Text, txtDireccion.Text, Convert.ToString(seleccionado), Convert.ToString(zeleccionado), txtTelefono.Text, txtWeb.Text, txtMail.Text);
            if (estado == true)
            {
                lblMensaje.Text = "Se agrego con exito el Proveedor :D";
                txtRazonSocial.Text = "";
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
                ddlProvincia.SelectedIndex = 0;
                ddlCiudad.SelectedIndex = 0;
                txtWeb.Text = "";
                txtMail.Text = "";
            }
        }
    }
}