<%@ Page Title="Detalle Factura" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="DetalleFactura.aspx.cs" Inherits="Vistas.DetalleFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            text-align:center;
        }
        .auto-style2 {
            width: 330px;
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
             Detalle de Factura
             </h1>
    </div>
    <div>
           <h1 style="text-align:center; font-family:Cambria; font-size:x-large">
               <asp:Label ID="lblFacturaid" runat="server"></asp:Label>
        </h1>
    </div>
    <br />
    <div>

        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="lblMensajeList" runat="server"></asp:Label>
                <br />
                <br />
                Filtrar por Articulo:&nbsp;
                 <asp:TextBox ID="txtFiltro" runat="server" Width="250px"></asp:TextBox>&nbsp;&nbsp;
                 <asp:Button ID="btnFiltrar" runat="server" height="25px" Width="250px" Text="FILTRAR" OnClick="btnFiltrar_Click"/>
                 <asp:Button ID="btnMostrarTodo" runat="server"  Height="25px" Width="250px" Text="MOSTRAR TODO" OnClick="btnMostrarTodo_Click"/>
                   
                </td>
                <td>&nbsp;</td>
            </tr>
           
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                      <br />
                     <asp:GridView ID="gvDetalle" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="200px" Width="900px" PageSize="6" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField HeaderText="Codigo">
                                 <ItemTemplate>
                                     <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("IDFACTURA") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Articulo">
                                 <ItemTemplate>
                                     <asp:Label ID="lblArticulo" runat="server" Text='<%# Bind("ARTICULO") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Cantidad">
                                 <ItemTemplate>
                                     <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("CANTIDAD") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Precio Unitario">
                                 <ItemTemplate>
                                     <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("PRECIOUNI") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="center" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>               
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>


</asp:Content>
