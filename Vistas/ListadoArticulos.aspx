<%@ Page Title="Articulos" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="Vistas.ListadoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 281px;
        }
        .auto-style4 {
            width: 531px;
        }
        .auto-style5 {
            width: 281px;
            height: 31px;
        }
        .auto-style6 {
            width: 531px;
            height: 31px;
            text-align:center;
        }
        .auto-style7 {
            height: 31px;
        }
        .auto-style8 {
            font-weight: bold;
        }
        .auto-style10 {
            width: 531px;
            font-size: x-large;
             text-align:center;
        }
        .auto-style11 {
            text-decoration: underline;
            font-size: xx-large;
            text-align:center;
        }
        .auto-style12 {
            margin-right: 1px;
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

        <table class="auto-style2">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style10"><strong><span class="auto-style11">Listado de Articulos</span></strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6" style="font-size: x-large">Ingrese Nombre de Articulo:&nbsp;&nbsp;
                    <asp:TextBox ID="txtidart" runat="server" Width="245px"></asp:TextBox>
                    <strong>
                    <asp:Button ID="btnMostrar" runat="server" CssClass="auto-style8" Height="28px" Text="MOSTRAR TODO" OnClick="btnMostrar_Click" />
                    <asp:Button ID="btnFiltrar" runat="server" CssClass="auto-style8" Height="28px" Text="FILTRAR" OnClick="btnFiltrar_Click" />
                    <asp:Label ID="lblMensaje" runat="server" Font-Size="Small"></asp:Label>
                    </strong>
                </td>
                <td class="auto-style7"><strong>

                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    <br />
                    <asp:GridView ID="gvProductos" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="6" Height="200px" Width="1000px" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="gvProductos_RowCancelingEdit"   OnRowEditing="gvProductos_RowEditing" OnRowUpdating="gvProductos_RowUpdating" CssClass="auto-style12" AllowPaging="True" OnPageIndexChanging="gvProductos_PageIndexChanging" PageSize="5" >
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo Articulo">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_codigoarticulo" runat="server" Text='<%# Bind("CodigoArticulo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proveedor">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_edit_proveedor" runat="server" DataSourceID="sds_proveedor" DataTextField="RazonZocial_prov" DataValueField="IdProveedor_prov">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sds_proveedor" runat="server" ConnectionString="<%$ ConnectionStrings:LaboratorioTIFConnectionString2 %>" SelectCommand="SELECT * FROM [Proveedores] WHERE ([Estado_prov] = 1)"></asp:SqlDataSource>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_proveedor" runat="server" Text='<%# Bind("Proveedor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Marca">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_edit_marca" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nombre_mar" DataValueField="IdMarca_mar">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LaboratorioTIFConnectionString2 %>" SelectCommand="SELECT * FROM [Marcas]"></asp:SqlDataSource>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_marca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_edit_categoria" runat="server" DataSourceID="sds_categorias" DataTextField="Nombre_cat" DataValueField="IdCategoria_cat">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sds_categorias" runat="server" ConnectionString="<%$ ConnectionStrings:LaboratorioTIFConnectionString %>" SelectCommand="SELECT * FROM [Categorias]"></asp:SqlDataSource>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_categoria" runat="server" Text='<%# Bind("categoria") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Articulo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_articulo" runat="server" Text='<%# Bind("Articulo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_articulo" runat="server" Text='<%# Bind("Articulo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stock">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_stock" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_stock" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_precio" runat="server" Text='<%# Bind("Precio") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="eliminar" runat="server" CommandArgument='<%# Eval("CodigoArticulo") %>' CommandName="EliminarClick" ControlStyle-Width="25px" ImageUrl="~/Imagenes/tachito.jpg" OnClientClick="javascript:return confirm('Esta seguro que quiere eliminar este Articulo?');" OnCommand="eliminar_Command" Width="25px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
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
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
    
                    
            
        </table>
</asp:Content>
