<%@ Page Title="Listado Proveedores" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="ListarProveedoresMaster.aspx.cs" Inherits="Vistas.ListarProveedoresMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style2 {
            text-align:center;
            
        }
       
        .auto-style3 {
            text-align: center;
            width: 400px;
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
       <h1 style="text-align:center; font-family:Cambria; font-size:x-large">
           Listado de Proveedores
       </h1>

    </div>

    <div>
        <table>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2"><asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style2">
                    <span class="auto-style2">Ingrese Proveedor:</span>&nbsp;&nbsp;
                    <asp:TextBox ID="txtFiltro" runat="server" Width="195px"></asp:TextBox>
                    <strong>
                    <asp:Button ID="btnFiltrar" runat="server" height="25px" Width="250px" Text="FILTRAR" OnClick="btnFiltrar_Click" />
                     </strong>
                    <asp:Button ID="btnMostrar" runat="server"  Height="25px" Width="250px" Text="MOSTRAR TODO" OnClick="btnMostrar_Click" />
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <br />
                    <asp:GridView ID="gvProductos" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="200px" Width="900px" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="gvProductos_RowCancelingEdit" OnRowEditing="gvProductos_RowEditing" OnRowUpdating="gvProductos_RowUpdating" AllowPaging="True" OnPageIndexChanging="gvProductos_PageIndexChanging" PageSize="5">
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo Proveedor">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_codigoproveedor" runat="server" Text='<%# Bind("CodigoProveedor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proveedor">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_proveedor" runat="server" Text='<%# Bind("Proveedor") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_proveedor" runat="server" Text='<%# Bind("Proveedor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Direccion">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Provincia">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_edit_provincia" runat="server" DataSourceID="sds_provincia" DataTextField="Nombre_pro" DataValueField="IdProvincia_pro">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sds_provincia" runat="server" ConnectionString="<%$ ConnectionStrings:LaboratorioTIFConnectionString %>" SelectCommand="SELECT * FROM [Provincias]"></asp:SqlDataSource>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ciudad">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_edit_ciudad" runat="server" DataSourceID="sds_ciudad" DataTextField="Nombre_ciu" DataValueField="IdCiudad_ciu">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sds_ciudad" runat="server" ConnectionString="<%$ ConnectionStrings:LaboratorioTIFConnectionString %>" SelectCommand="SELECT * FROM [Ciudades]"></asp:SqlDataSource>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_ciudad" runat="server" Text='<%# Bind("Ciudad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telefono">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pagina Web">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_paginaweb" runat="server" Text='<%# Bind("PaginaWeb") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_paginaweb" runat="server" Text='<%# Bind("PaginaWeb") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_email" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_email" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="eliminar" runat="server" CommandArgument='<%# Eval("CodigoProveedor") %>' CommandName="EliminarClick" ControlStyle-Width="25px" ImageUrl="~/Imagenes/tachito.jpg" OnClientClick="javascript:return confirm('Esta seguro que quiere eliminar este Proveedor?');" OnCommand="eliminar_Command" Width="25px" />
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
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
        </table>
        </div>
    </asp:Content>
