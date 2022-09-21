<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="ReporteFechaAdmin.aspx.cs" Inherits="Vistas.ReportesAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        .auto-style1 {
           width:100%;
            text-align:center;
        }
        .auto-style2 {
            width: 360px;
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
    <div>
        
       <h1 style="text-align:center; text-decoration: underline; font-family: Cambria; font-style: normal; font-weight: bold;">
             Reporte de Facturas</h1>
    
    </div>
      <div>
           <h1 style="text-align:center; font-family:Cambria; font-size:x-large">
            Reporte de dinero ingresado en un rango de fechas
        </h1>
          </div>
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>

            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>Seleccione una Fecha Inicial:&nbsp;
                <asp:TextBox ID="txtFechaIni" runat="server" Width="250px" TextMode="Date"></asp:TextBox>

            </td>
            <td>Seleccione una Fecha Final:&nbsp;
                <asp:TextBox ID="txtFechaFinal" runat="server" Width="250px" TextMode="Date"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar " height="25px" Width="250px" OnClick="btnFiltrar_Click" />
            </td>
        </tr>
        </table>
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <br />
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div style="text-align:center;">
        <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
