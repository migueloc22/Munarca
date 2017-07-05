<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Munarca</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <div id="encabezaso"></div>
    <div id="cuerpo">
        <img src="img/logoFinal.png" id="logo" />
        <form id="form1" runat="server">
            <div id="cajaLogin">
                <center>
                <h2><span class="glyphicon glyphicon-log-in"></span>Login</h2>
                </center>
                <div class="btn-group btn-group-justified">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn .btn-link btn-lg active" ForeColor="Black"><span class="glyphicon glyphicon-user"></span> Suscriptor </asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn .btn-link btn-lg" ForeColor="Black"><span class="glyphicon glyphicon-flag"></span> Propietario </asp:HyperLink>
                </div>
                <br />
                <div class="form-group">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-group-lg" placeholder="email" TextMode="Email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control form-group-lg" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                </div>
                 <div class="form-group">
                   
                     <asp:HyperLink ID="HyperLink3" runat="server">Registrarse</asp:HyperLink>
                   
                </div>
                <div class="form-group">
                    <asp:Button ID="Button1" runat="server" Text="Entrar" CssClass="btn btn-danger" />
                    <input type="reset" class="btn btn-default"/>
                </div>
            </div>
        </form>
    </div>
    <div id="pie">
        <div id="sudpie1"></div>
        <div id="sudpie2"></div>
    </div>
</body>
</html>
