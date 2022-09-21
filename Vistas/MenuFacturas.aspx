<%@ Page Title="Facturas" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="MenuFacturas.aspx.cs" Inherits="Vistas.MenuFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
           
            text-align: center;
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
             Facturas&nbsp;</h1>
    </div>
    <div>
           <h1 style="text-align:center; font-family:Cambria; font-size:x-large">
            Listado De Facturas
        </h1>
    </div>
    <br />
<div>

    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td><asp:Label ID="lblMensajeList" runat="server"></asp:Label>
                <br />
                <br />
                Filtrar por DNI Cliente:&nbsp;
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
                <asp:GridView ID="gvFacturas" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="200px" Width="900px" PageSize="5" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvFacturas_SelectedIndexChanging" AllowPaging="True" OnPageIndexChanging="gvFacturas_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_idfactura" runat="server" Text='<%# Bind("IDFACTURA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <ItemTemplate>
                                    <asp:Label ID="lblDni" runat="server" Text='<%# Bind("DNIFACTURA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre Completo">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreCompleto" runat="server" Text='<%# Bind("NOMBREDNIFACTURA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma de Pago">
                                <ItemTemplate>
                                    <asp:Label ID="lblFormaPago" runat="server" Text='<%# Bind("FORMAPAGO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FECHAFACTURA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("TOTALFACTURA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">                                
                                <ItemTemplate>
                                    
                                    <asp:ImageButton ID="eliminar" runat="server" ImageUrl="~/Imagenes/tachito.jpg" ControlStyle-Width="25px" CommandArgument='<%# Eval("IDFACTURA") %>' OnCommand="eliminar_Command" Width="25px" CommandName="EliminarClick"  OnClientClick="javascript:return confirm('Esta seguro que quiere eliminar esta factura?');" />
       
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
