using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace Vistas
{
    public partial class CarritoTienda : System.Web.UI.Page
    {
        NegocioProducto neg = new NegocioProducto();
        NegocioFactura nfac = new NegocioFactura();
        NegocioFormaPago nfp = new NegocioFormaPago();
        DataTable emp = new DataTable();
        
          

        

        protected void Page_Load(object sender, EventArgs e)
        {

            lblcargar();

            if (IsPostBack == false){
                sesion();
                CargarFormaPago();

                cargarCarrito();
                Session["dt"] = emp;

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

        public void cargarTabla()
        {
            emp.Columns.Add("Codigo");
            emp.Columns.Add("Descripcion");
            emp.Columns.Add("PrecioUnitario");
            emp.Columns.Add("Cantidad");
            if (Session["idArt"] == null)
            {

            }
            else
            {
                string id = Session["idArt"].ToString();
                neg.IdXRegistro(emp, id);
            }

        }

        public void cargarCarrito()
        {
            if (Session["dt"] == null) {
                cargarTabla();
            }
            else
            {
               emp = (DataTable)Session["dt"];
                if(Session["idArt"] == null)
                {

                }
                else
                {
                    string id = Session["idArt"].ToString();
                    Boolean repetido = false;

                    foreach (DataRow row in emp.Rows)
                    {
                        if (row["Codigo"].ToString() == id)
                        {
                            repetido = true;
                        }

                    }

                    if( repetido == true)
                    {
                        foreach (DataRow row in emp.Rows)
                        {
                            if (row["Codigo"].ToString() == id)
                            {
                                if (Convert.ToInt32(row["Cantidad"]) < neg.IDXSTOCK(id))
                                {
                                    row["Cantidad"] = Convert.ToInt32(row["Cantidad"]) + 1;
                                }
                                else
                                {

                                }
                            }

                        }
                    }
                    else
                    {
                        neg.IdXRegistro(emp, id);
                    }
                    
                    
                }
                

            }
            Session["idArt"] = null;
         
            GVcarrito.DataSource = emp;
            GVcarrito.DataBind();

          

            
        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            emp.Rows.Clear();
            Session["dt"] = null;
            lblcomprado.Text = "Se Vacio el Carrito de Compras";
            cargarCarrito();

        }

        protected void eliminar_Command(object sender, CommandEventArgs e)
        {
            //if (e.CommandName == "delete")
            //{





            //    foreach (DataRow row in emp.Rows)
            //    {
            //        if (row["Codigo"].ToString() ==  e.CommandArgument.ToString())
            //        {
            //            lblcomprado.Text = row["Codigo"].ToString();
            //            row.Delete();

            //            Session["dt"] = emp;
            //        }
            //        else
            //        {

            //        }

            //    }
            //    emp = (DataTable)Session["dt"];
            //    GVcarrito.DataSource = emp;
            //    GVcarrito.DataBind();
            //}



        }

        public void CargarFormaPago()
        {
            DataTable TablaFormaPago = nfp.GetTablaFormaPago();

            ddlformapago.DataSource = TablaFormaPago;
            ddlformapago.DataTextField = "Nombre_fp";
            ddlformapago.DataValueField = "IdFormaPago_fp";
            ddlformapago.DataBind();
            ddlformapago.Items.Insert(0, new ListItem("--Seleccione Forma de Pago--", "0"));
            



        }


        protected void btnComprar_Click(object sender, EventArgs e)
        {
            string dni = Session["DNIx"].ToString();
            string IDformapago = String.Empty;
            emp = (DataTable)Session["dt"];

            if (ddlformapago.SelectedItem.Text == "--Seleccione Forma de Pago--" || GVcarrito.Rows.Count.ToString()=="0")
            {
                lblcomprado.Text ="Seleccione una Forma de Pago para comprar o Cargue algo en el carrito";
            }
       else
            {

                IDformapago = ddlformapago.SelectedValue;


                nfac.RealizarFactura(emp, dni, IDformapago);

                emp.Rows.Clear();
                Session["dt"] = null;

                GVcarrito.DataSource = emp;
                GVcarrito.DataBind();
                ddlformapago.SelectedIndex = 0;
                lblcomprado.Text = "COMPRA REALIZADA MUCHAS GRACIAS";

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