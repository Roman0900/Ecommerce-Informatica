<%@ Page Title="Agregar Proveedor" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="AgregarProveedorMasterr.aspx.cs" Inherits="Vistas.AgregarProveedorMasterr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height:10px;
            width: 1300px;
            text-align:left;
        }
        .auto-style2 {
            width: 749px;
            text-align: right;
        }
        .auto-style3 {
            width: 551px;
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
        Agregar Proveedor
    </h1>
    <h2 style="text-align:center; text-decoration: none; font-family: Cambria; font-style: normal; font-weight: normal;">
    Complete los Campos:    
    </h2>
    <div>
        
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Razon Social:</td>
                <td class="auto-style3"><asp:TextBox ID="txtRazonSocial" runat="server" Width="250px" required></asp:TextBox></td>
                <td>&nbsp;</td>
               
            </tr>
            <tr>
               
                <td class="auto-style2">Direccion:</td>
                <td class="auto-style3"><asp:TextBox ID="txtDireccion" runat="server" Width="250px" required></asp:TextBox></td>
                <td>&nbsp;</td>
               
            </tr>
            <tr>
               
                <td class="auto-style2">Provincia:</td>
                <td class="auto-style3"><asp:DropDownList ID="ddlProvincia" runat="server"  Width="260px" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                <td>&nbsp;</td>
                
            </tr>
            <tr>
               
                <td class="auto-style2">Ciudad:</td>
                <td class="auto-style3"><asp:DropDownList ID="ddlCiudad" runat="server" Width="260px" AutoPostBack="True" >
                    </asp:DropDownList></td>
                <td>&nbsp;</td>
               
            </tr>
            <tr>
              
                <td class="auto-style2">Telefono:</td>
                <td class="auto-style3"> <asp:TextBox ID="txtTelefono" runat="server" Width="250px" MaxLength="10" required onkeypress="return ((event.charCode >= 48 && event.charCode <= 57  ))"></asp:TextBox></td>
                <td>&nbsp;</td>
             
            </tr>
            <tr>
             
                <td class="auto-style2">WEB:</td>
                <td class="auto-style3"> <asp:TextBox ID="txtWeb" runat="server" Width="250px" required ></asp:TextBox></td>
                <td></td>
               
            </tr>
            <tr>
                
                <td class="auto-style2">Mail:</td>
                <td class="auto-style3"><asp:TextBox ID="txtMail" runat="server" Width="250px" required></asp:TextBox>

                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3"><asp:Button ID="btnAgregar" runat="server" CssClass="auto-style9" OnClick="btnAgregar_Click" Text="AGREGAR" Width="214px" /></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
              
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
              
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3"><asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </asp:Content>
