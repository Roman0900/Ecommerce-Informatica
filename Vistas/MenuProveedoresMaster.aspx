<%@ Page Title="Menu Proveedores" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="MenuProveedoresMaster.aspx.cs" Inherits="Vistas.MenuProveedoresMaster" %>
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
        Proveedores
   </h1>
    <div>

        <table class="auto-style2">
            <tr>
                <td><strong><asp:HyperLink ID="hlAgregarProveedor" runat="server" NavigateUrl="~/AgregarProveedorMasterr.aspx" CssClass="auto-style3">Agregar Proveedor</asp:HyperLink></strong></td>
                <td><strong><asp:HyperLink ID="hlListarProveedor" runat="server" NavigateUrl="~/ListarProveedoresMaster.aspx" CssClass="auto-style3">Listado Proveedor</asp:HyperLink></strong></td>
            </tr>
        </table>

    </div>
   <br />
   <br />
</asp:Content>
