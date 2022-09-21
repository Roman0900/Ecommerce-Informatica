<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/MaterPage/BaseClienteProg3.Master" AutoEventWireup="true" CodeBehind="CarritoTienda.aspx.cs" Inherits="Vistas.CarritoTienda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        .auto-style1 {
           text-align:center;
        }
        .auto-style2 {
            width: 400px;
        }
       
        .auto-style3 {
            width: 550px;
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
         <h1 style="text-align:center; text-decoration: underline; font-family: Cambria; font-weight: bold;">
            Carro Compras</h1>
        </div>
    <div>
        <br />

        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ddlformapago" runat="server" Height="100px" Width="200px"></asp:DropDownList>
                    <br />
                    <asp:GridView ID="GVcarrito" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="200px" Width="900px" AutoGenerateColumns="False" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripcion">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio Unitario">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrecioUnitario" runat="server" Text= '<%# Bind("PrecioUnitario") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="eliminar" runat="server" ImageUrl="~/Imagenes/tachito.jpg" ControlStyle-Width="25px" CommandArgument='<%# Eval("Codigo") %>' CommandName="delete" OnCommand="eliminar_Command" Width="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>


                </td>
                <td>&nbsp;</td>
            </tr>
        </table>


    </div>
    <br />
    <div>
        
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnComprar" runat="server" Text="Comprar" Height="30px" WIDTH="300px" OnClick="btnComprar_Click"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnVaciar" runat="server" Text="Vaciar Carrito" Height="30px" WIDTH="300px" OnClick="btnVaciar_Click"/>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </div>
    <br />
    <div style="text-align:center">
        <asp:Label ID="lblcomprado" runat="server" Text=""></asp:Label>
    </div>


</asp:Content>
