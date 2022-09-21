<%@ Page Title="Personas" Language="C#" MasterPageFile="~/MaterPage/BaseProg3.Master" AutoEventWireup="true" CodeBehind="ListarPersonaMaster.aspx.cs" Inherits="Vistas.ListarPersonaMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 452px;
            height: 31px;
        }
        .auto-style6 {
            width: 531px;
            height: 31px;
            text-align:center;
        }
        .auto-style8 {
            font-weight: bold;
        }
        .auto-style7 {
            height: 31px;
        }
        .auto-style3 {
            width: 452px;
        }
        .auto-style4 {
            width: 531px;
        }
        .auto-style2 {
            width: 100%;
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
             Listado de Personas
             </h1>
 </div>
    <div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6" style="font-size: x-large">Ingrese Apellido de la Persona:&nbsp;&nbsp;
                    <asp:TextBox ID="txtDNI" runat="server" Width="245px"></asp:TextBox>
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
                    <asp:GridView ID="gvPersonas" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="200px" Width="800px" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="gvPersonas_RowCancelingEdit" OnRowEditing="gvPersonas_RowEditing" OnRowUpdating="gvPersonas_RowUpdating" AllowPaging="True" OnPageIndexChanging="gvPersonas_PageIndexChanging" PageSize="5">
                        <Columns>
                            <asp:TemplateField HeaderText="Documento">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_documento" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Apellido">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Mail">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_edit_mail" runat="server" Text='<%# Bind("Mail") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbl_item_mail" runat="server" Text='<%# Bind("Mail") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="eliminar" runat="server" CommandArgument='<%# Eval("DNI") %>' CommandName="EliminarClick" ControlStyle-Width="25px" ImageUrl="~/Imagenes/tachito.jpg" OnClientClick="javascript:return confirm('Esta seguro que quiere eliminar esta persona?');" OnCommand="eliminar_Command" Width="25px" />
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
        </div>
</asp:Content>
