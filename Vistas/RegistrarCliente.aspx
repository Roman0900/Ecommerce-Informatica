<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCliente.aspx.cs" Inherits="Vistas.RegistrarCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registrarse</title>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 3px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
*,::after,::before{text-shadow:none!important;box-shadow:none!important}*,::after,::before{box-sizing:border-box}.col-md-12{-ms-flex:0 0 100%;flex:0 0 100%;max-width:100%}.col,.col-1,.col-10,.col-11,.col-12,.col-2,.col-3,.col-4,.col-5,.col-6,.col-7,.col-8,.col-9,.col-auto,.col-lg,.col-lg-1,.col-lg-10,.col-lg-11,.col-lg-12,.col-lg-2,.col-lg-3,.col-lg-4,.col-lg-5,.col-lg-6,.col-lg-7,.col-lg-8,.col-lg-9,.col-lg-auto,.col-md,.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9,.col-md-auto,.col-sm,.col-sm-1,.col-sm-10,.col-sm-11,.col-sm-12,.col-sm-2,.col-sm-3,.col-sm-4,.col-sm-5,.col-sm-6,.col-sm-7,.col-sm-8,.col-sm-9,.col-sm-auto,.col-xl,.col-xl-1,.col-xl-10,.col-xl-11,.col-xl-12,.col-xl-2,.col-xl-3,.col-xl-4,.col-xl-5,.col-xl-6,.col-xl-7,.col-xl-8,.col-xl-9,.col-xl-auto{position:relative;width:100%;min-height:1px;padding-right:15px;padding-left:15px}.text-info{color:#17a2b8!important}.text-center{text-align:center!important}h2,h3{page-break-after:avoid}h2,h3,p{orphans:3;widows:3}.h3,h3{font-size:1.75rem}.h1,.h2,.h3,.h4,.h5,.h6,h1,h2,h3,h4,h5,h6{margin-bottom:.5rem;font-family:inherit;font-weight:500;line-height:1.2;color:inherit}h1,h2,h3,h4,h5,h6{margin-top:0;margin-bottom:.5rem}.form-group{margin-bottom:1rem}label{display:inline-block;margin-bottom:.5rem}.form-control{transition:none}.form-control{display:block;width:100%;padding:.375rem .75rem;font-size:1rem;line-height:1.5;color:#495057;background-color:#fff;background-clip:padding-box;border:1px solid #ced4da;border-radius:.25rem;transition:border-color .15s ease-in-out,box-shadow .15s ease-in-out}button,input{overflow:visible}button,input,optgroup,select,textarea{margin:0;font-family:inherit;font-size:inherit;line-height:inherit}.btn-info{color:#fff;background-color:#17a2b8;border-color:#17a2b8}.btn{transition:none}.btn{display:inline-block;font-weight:400;text-align:center;white-space:nowrap;vertical-align:middle;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;border:1px solid transparent;padding:.375rem .75rem;font-size:1rem;line-height:1.5;border-radius:.25rem;transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out}[type=reset],[type=submit],button,html [type=button]{-webkit-appearance:button}
        .auto-style2 {
            font-size: medium;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
                <div id="login-column" class="auto-style1">
                    <div id="login-box" class="col-md-12" style="font-size: medium">
                            <h3 class="text-center text-info">COMPLETE LOS CAMPOS</h3>
                            <div class="form-group">
                                <label for="username" class="text-info"><span class="auto-style2" style="font-size: medium">&nbsp;DNI:</span></label><br/>
                                &nbsp;<label for="username" class="text-info"><asp:TextBox ID="txtDNI" runat="server" class="form-control" Width="486px" required="" MaxLength="8"></asp:TextBox>
                                </label>&nbsp;&nbsp;&nbsp;
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info">Nombre<span class="auto-style2"> :</span></label><br/>
                                &nbsp;<label for="username" class="text-info"><asp:TextBox ID="txtNombre" runat="server" class="form-control" Width="486px" requidred=""></asp:TextBox>
                                </label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            <label for="password" class="text-info">Apellido :</label><br/>
                                &nbsp;<label for="username" class="text-info"><asp:TextBox ID="txtApellido" runat="server" class="form-control" Width="486px" required=""></asp:TextBox>
                                </label>
                            <br />
                            <label for="password" class="text-info" style="font-size: medium">Contraseña :</label><br/>
                                &nbsp;<label for="username" class="text-info"><asp:TextBox ID="txtContraseña" runat="server" class="form-control" Width="486px" TextMode="Password" required=""></asp:TextBox>
                                </label>
                            <br />
                            <label for="password" class="text-info">
                            <label for="username" class="text-info">
                            <label for="password" class="text-info" style="font-size: medium">Repita la contraseña :</label><asp:TextBox ID="txtContraseña2" runat="server" class="form-control" Width="486px" TextMode="Password" required=""></asp:TextBox>
                                </label>
                            <br />
                            Telefono :</label><br/>
                                &nbsp;<label for="username" class="text-info"><asp:TextBox ID="txtTelefono" runat="server" class="form-control" Width="486px" required="" MaxLength="12"></asp:TextBox>
                                </label>
                            <br />
                                <label for="password" class="text-info">Mail :</label><br/>
                                &nbsp;<label for="username" class="text-info"><asp:TextBox ID="txtMail" runat="server" class="form-control" Width="486px" required=""></asp:TextBox>
                                </label>
                            <br />
                            <div class="form-group">
                                
                                <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" class="btn btn-info btn-md" OnClick="btnRegistrarse_Click"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblMensaje" runat="server" CssClass="auto-style3"></asp:Label>
                                <br />
                                <br />
                                <asp:HyperLink ID="HPlinkRegister" runat="server" NavigateUrl="~/Login.aspx" CssClass="auto-style3">Volver a Inicio de sesion</asp:HyperLink>

                            </div>                            
                    </div>
                </div>
    </form>
</body>
</html>
