<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="AgregarProveedorMaster.aspx.cs" Inherits="Vistas.MenuProveedoresMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style14 {
            font-size: xx-large;
        }
        
        .auto-style13 {
            text-decoration: underline;
            font-size: xx-large;
        }
        .auto-style15 {
            width: 100%;
        }
        .auto-style16 {
            width: 428px;
        }
        .auto-style18 {
            width: 187px;
            font-size: x-large;
        }
        .auto-style19 {
            width: 281px;
        }
        .auto-style20 {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <p>
        <strong><span class="auto-style14"><strong style="font-size: xx-large">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span class="auto-style13">Ingrese el campo correrspondiente:</span><span class="auto-style14">&nbsp;</span></strong></p>
        <table class="auto-style15">
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">Razon Social:</td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtRazonSocial" runat="server" Width="207px"></asp:TextBox>
                </td>
                <td style="font-size: large">
                    <asp:RequiredFieldValidator ID="rfvRZ" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="*Ingrese Razon Social"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">Direccion:</td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtDireccion" runat="server" Width="206px"></asp:TextBox>
                </td>
                <td style="font-size: large">
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="*Ingrese Direccion"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">Provincia:</td>
                <td class="auto-style19">
                    <asp:DropDownList ID="ddlProvincia" runat="server" Height="38px" Width="213px">
                    </asp:DropDownList>
                </td>
                <td style="font-size: large">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">Ciudad:</td>
                <td class="auto-style19">
                    <asp:DropDownList ID="ddlCiudad" runat="server" Height="39px" Width="211px">
                    </asp:DropDownList>
                </td>
                <td style="font-size: large">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">Telefono: </td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtTelefono" runat="server" Width="206px"></asp:TextBox>
                </td>
                <td style="font-size: large">
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*Ingrese Telefono"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="*Solo se ingresan numeros" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">Web:</td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtWeb" runat="server" Width="205px"></asp:TextBox>
                </td>
                <td style="font-size: large">
                    <asp:RequiredFieldValidator ID="rfvWeb" runat="server" ControlToValidate="txtWeb" ErrorMessage="*Ingrese Web"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">Mail:</td>
                <td class="auto-style19">
                    <asp:TextBox ID="txtMail" runat="server" Width="203px"></asp:TextBox>
                </td>
                <td style="font-size: large">
                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ControlToValidate="txtMail" ErrorMessage="*Ingrese Mail"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td style="font-size: large">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style19"><strong>
                    <asp:Button ID="btnAgregar" runat="server" CssClass="auto-style20" OnClick="btnAgregar_Click" Text="AGREGAR" Width="213px" />
                    </strong></td>
                <td style="font-size: large">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
                <td style="font-size: large">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
                <td class="auto-style19" style="font-size: large">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td><strong style="font-size: large">
                    <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/MenuProveedores.aspx">Volver al Menu de Proveedores</asp:HyperLink>
                    </strong></td>
            </tr>
        </table>
    </asp:Content>
