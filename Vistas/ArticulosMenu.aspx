<%@ Page Title="Menu Articulos" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="ArticulosMenu.aspx.cs" Inherits="Vistas.ArticulosMenu"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            text-align:center;
            font-family:Cambria;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
     <div style="text-align:right; font-family:'Times New Roman';">
        <br />
        <asp:Label ID="lblUsuario" runat="server" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    </div>
    
      
    <h1 style="text-align:center; text-decoration: underline; font-family: Cambria; font-style: normal; font-weight: bold;">
        Articulos
   </h1>
    <div>

        <table class="auto-style2">
            <tr>
                <td><strong><asp:HyperLink ID="hlAgregarProducto" runat="server" NavigateUrl="~/AgregarArticulo.aspx" CssClass="auto-style3">Agregar Articulos</asp:HyperLink></strong></td>
                <td><strong><asp:HyperLink ID="hlListarProductos" runat="server" NavigateUrl="~/ListadoArticulos.aspx" CssClass="auto-style3">Listado de Articulos</asp:HyperLink></strong></td>
            </tr>
        </table>

    </div>
   <br />
   <br />
        
</asp:Content>
