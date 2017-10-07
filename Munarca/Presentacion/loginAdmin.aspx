<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginAdmin.aspx.cs" Inherits="Presentacion.loginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/estiloAdmin.css" rel="stylesheet" />
    <script src="js/jquery-ui.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/JavaScript.js"></script>
    <title></title>
</head>
<body>


    <form id="form1" runat="server">
        <div class="container">
            <div class="row vertical-offset-100">
                <div class="col-md-5 col-md-offset-7">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Login Administrador</h3>
                        </div>
                        <div class="panel-body">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control" placeholder="E-mail"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>

                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input name="remember" type="checkbox" value="Remember Me">
                                        Remember Me
			    	    
                                    </label>
                                    <asp:Label ID="lbValidar" runat="server" Text="Label"></asp:Label>
                                </div>
                                <asp:Button ID="btnEntrar" runat="server" Text="Ingresar" OnClick="btnEntrar_Click" CssClass="btn btn-lg btn-danger btn-block" />
                                
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>

</body>
</html>
