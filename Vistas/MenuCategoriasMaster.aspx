<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="MenuCategoriasMaster.aspx.cs" Inherits="Vistas.MenuCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .auto-style1{
            width:100%;
            text-align:center;
           
        }
        .auto-style2{
           
            text-align:center;
           
        }
        
        .auto-style3 {
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
        <h1 style="text-align:center; text-decoration: underline; font-family: Cambria; font-style: normal; font-weight: bold;">
            Categorias
        </h1>
    </div>
    <div>
        <h1 style="text-align:center; font-family:Cambria; font-size:x-large">
            Completar Para Agregado
        </h1>

    </div>
    <div>

        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>Nombre:&nbsp; <asp:TextBox ID="txtNombre" runat="server" Width="250px" Height="18px"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><br /><asp:Button ID="btnAgregar" runat="server"  Width="250px" Height="25px" Text="AGREGAR" OnClick="btnAgregar_Click" /></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><br /> <asp:Label ID="lblMensajeAgregado" runat="server"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
    <div>
         <h1 style="text-align:center; font-family:Cambria; font-size:x-large">
            Listado De Categorias
        </h1>
    </div>
    <div>
         <table>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2"><asp:Label ID="lblMensajeList" runat="server"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <span class="auto-style2">Ingrese Categoria:</span>&nbsp;&nbsp;
                    <asp:TextBox ID="txtFiltroCat" runat="server" Width="260px"></asp:TextBox>
                    <strong>
                    <asp:Button ID="btnFiltrar" runat="server" height="25px" Width="250px" Text="FILTRAR" OnClick="btnFiltrar_Click"/>
                     </strong>
                    <asp:Button ID="btnMostrarTodo" runat="server"  Height="25px" Width="250px" Text="MOSTRAR TODO" OnClick="btnMostrarTodo_Click"/>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <br />
                    <asp:GridView ID="gvCategorias" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="200px" Width="900px" PageSize="5" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="gvCategorias_RowCancelingEdit" OnRowEditing="gvCategorias_RowEditing" OnRowUpdating="gvCategorias_RowUpdating" AllowPaging="True" OnPageIndexChanging="gvCategorias_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_codigo" runat="server" Text='<%# Bind("Codigo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="eliminar" runat="server" CommandArgument='<%# Eval("Codigo") %>' CommandName="EliminarClick" ControlStyle-Width="25px" ImageUrl="~/Imagenes/tachito.jpg" OnClientClick="javascript:return confirm('Esta seguro que quiere eliminar esta Categoria?');" OnCommand="eliminar_Command" Width="25px" />
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </asp:Content>
