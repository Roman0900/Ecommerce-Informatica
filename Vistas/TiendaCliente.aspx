<%@ Page Title="Tienda" Language="C#" MasterPageFile="~/MaterPage/BaseClienteProg3.Master" AutoEventWireup="true" CodeBehind="TiendaCliente.aspx.cs" Inherits="Vistas.TiendaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">

        .auto-style1 {
           text-align:center; 
           
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
            Articulos Disponibles</h1>
        </div>
   <br />
    <div>

        <table class="auto-style1">
            <tr>
                <td></td>
                <td> <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    <br />
                    <br />
                    Ingrese nombre del Articulo:&nbsp;&nbsp;
                    <asp:TextBox ID="txtNombre" runat="server" Width="260px"></asp:TextBox>
                        <asp:Button ID="btnFiltrar" runat="server"  Height="30px" OnClick="btnFiltrar_Click" Text="FILTRAR" Width="250px" />
                        <asp:Button ID="btnMostrar" runat="server"  Height="30px" OnClick="btnMostrar_Click" Text="MOSTRAR TODO" Width="250px" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Filtrar por categoria:&nbsp;
                    <asp:DropDownList ID="ddlCategoria" runat="server" Height="28px" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" Width="200px" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td> Filtrar por marca:&nbsp;
                   <asp:DropDownList ID="ddlMarca" runat="server" Height="28px" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:ListView ID="lvArticulos" runat="server" DataSourceID="SqlDataSource1" GroupItemCount="4" >
              
                <EditItemTemplate>
                    <td runat="server" style="background-color: #999999;">Imagen:
                        <asp:TextBox ID="ImagenTextBox" runat="server" Text='<%# Bind("Imagen") %>' />
                        <br />Articulo:
                        <asp:TextBox ID="ArticuloTextBox" runat="server" Text='<%# Bind("Articulo") %>' />
                        <br />Marca:
                        <asp:TextBox ID="MarcaTextBox" runat="server" Text='<%# Bind("Marca") %>' />
                        <br />Categoria:
                        <asp:TextBox ID="CategoriaTextBox" runat="server" Text='<%# Bind("Categoria") %>' />
                        <br />Precio:
                        <asp:TextBox ID="PrecioTextBox" runat="server" Text='<%# Bind("Precio") %>' />
                        <br />
                        Codigo_Articulo:
                        <asp:TextBox ID="Codigo_ArticuloTextBox" runat="server" Text='<%# Bind("Codigo_Articulo") %>' />
                        <br />
                        Codigo_Marca:
                        <asp:TextBox ID="Codigo_MarcaTextBox" runat="server" Text='<%# Bind("Codigo_Marca") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No se han devuelto datos.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
<td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">Imagen:
                        <asp:TextBox ID="ImagenTextBox0" runat="server" Text='<%# Bind("Imagen") %>' />
                        <br />Articulo:
                        <asp:TextBox ID="ArticuloTextBox0" runat="server" Text='<%# Bind("Articulo") %>' />
                        <br />Marca:
                        <asp:TextBox ID="MarcaTextBox0" runat="server" Text='<%# Bind("Marca") %>' />
                        <br />Categoria:
                        <asp:TextBox ID="CategoriaTextBox0" runat="server" Text='<%# Bind("Categoria") %>' />
                        <br />Precio:
                        <asp:TextBox ID="PrecioTextBox0" runat="server" Text='<%# Bind("Precio") %>' />
                        <br />
                        Codigo_Articulo:
                        <asp:TextBox ID="Codigo_ArticuloTextBox0" runat="server" Text='<%# Bind("Codigo_Articulo") %>' />
                        <br />
                        Codigo_Marca:
                        <asp:TextBox ID="Codigo_MarcaTextBox0" runat="server" Text='<%# Bind("Codigo_Marca") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton0" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #E0FFFF;color: #333333;" class="auto-style20">
                        <asp:Image ID="Image2" runat="server" Height="100px" ImageUrl='<%# Eval("Imagen") %>' Width="100px" />
                        <br />
                        <asp:Label ID="ArticuloLabel0" runat="server" Text='<%# Eval("Articulo") %>' />
                        <br />
                        <asp:Label ID="MarcaLabel0" runat="server" Text='<%# Eval("Marca") %>' />
                        <br />
                        <asp:Label ID="CategoriaLabel0" runat="server" Text='<%# Eval("Categoria") %>' />
                        <br />Precio:
                        <asp:Label ID="PrecioLabel0" runat="server" Text='<%# Eval("Precio") %>' />
                        <br />
                        Stock:
                        <asp:Label ID="StockLabel0" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
                        <br />
                        <strong>
                        <asp:Button ID="btnSeleccion" runat="server" CommandArgument='<%# Eval("CodigoArticulo") %>' CommandName="Agregar" CssClass="auto-style1" Height="25px" Text="AGREGAR" Width="143px" OnCommand="btnSeleccion_Command" />
                        </strong>&nbsp;&nbsp;&nbsp;&nbsp; 
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="8">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">Imagen:
                        <asp:Label ID="ImagenLabel" runat="server" Text='<%# Eval("Imagen") %>' />
                        <br />Articulo:
                        <asp:Label ID="ArticuloLabel1" runat="server" Text='<%# Eval("Articulo") %>' />
                        <br />Marca:
                        <asp:Label ID="MarcaLabel1" runat="server" Text='<%# Eval("Marca") %>' />
                        <br />Categoria:
                        <asp:Label ID="CategoriaLabel1" runat="server" Text='<%# Eval("Categoria") %>' />
                        <br />Precio:
                        <asp:Label ID="PrecioLabel1" runat="server" Text='<%# Eval("Precio") %>' />
                        <br />Codigo_Articulo:
                        <asp:Label ID="Codigo_ArticuloLabel" runat="server" Text='<%# Eval("Codigo_Articulo") %>' />
                        <br />
                        Codigo_Marca:
                        <asp:Label ID="Codigo_MarcaLabel" runat="server" Text='<%# Eval("Codigo_Marca") %>' />
                        <br />
                    </td>
                </SelectedItemTemplate>
            </asp:ListView>

                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
    <br />

    <div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LaboratorioTIFConnectionString %>" 
    SelectCommand="SELECT [Imagen], [Articulo], [Marca], [Categoria], [Precio], [Stock], [CodigoArticulo] FROM [ARTICULOSCLIENTE2]"></asp:SqlDataSource>
        
    </div>
         

</asp:Content>
