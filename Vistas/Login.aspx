<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />

 
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>

 
</head>
<body style="background-color:forestgreen; height: 269px;">
    
    <form id="form1" runat="server" style="background-color:darkgreen;">
        <div  class="container jumbotron bg-light" style =" width:35%; text-align:center;"> 
            <br />
            
            
                <div class="card-header-pills bg-dark text-white">
                    <h2>Login UTN</h2>
                </div>
                    <div style="text-align:center;">
                        <br />
            <asp:TextBox ID="txtUsuario" runat="server" Width="200px" placeholder="Ingrese DNI"></asp:TextBox>
                   
            <br />
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario">Ingrese DNI</asp:RequiredFieldValidator>
            <br />
                         <asp:TextBox ID="txtDni" runat="server" Width="200px" Height="25px" placeholder="Ingrese Contraseña" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni">Ingrese Contraseña</asp:RequiredFieldValidator>
                        <br />
                         </div>
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Iniciar Sesion" BackColor="#009933" BorderStyle="Ridge" Font-Bold="True" Font-Size="X-Large" Height="48px" Width="182px" />
            <br />
            <asp:Label ID="lblLogin" runat="server"></asp:Label>
            
                <br />
            <strong>
            <asp:HyperLink ID="hlRegistrarse" runat="server" CssClass="auto-style1" NavigateUrl="~/RegistrarCliente.aspx">Registrarse</asp:HyperLink>
            </strong>
            
                <br />
            <br />
            
                </div>
           
    </form>
       
</body>
</html>
