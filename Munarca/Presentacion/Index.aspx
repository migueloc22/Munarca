<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Munarca</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <script src="js/jquery-3.2.1.min.js"></script>
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
                    <asp:LinkButton ID="btnAtivador1" runat="server" ForeColor="White" OnClick="btnAtivador1_Click" CssClass="btn btn-danger btn-lg"><span class="glyphicon glyphicon-user"></span> Suscriptor </asp:LinkButton>
                    <asp:LinkButton ID="btnAtivador2" runat="server" ForeColor="Gray" OnClick="btnAtivador2_Click" CssClass="btn btn-link btn-lg"><span class="glyphicon glyphicon-flag"></span> Propietario </asp:LinkButton>
                </div>
                <br />
                <div class="form-group">
                    <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control form-group-lg" placeholder="email" required="" TextMode="Email" MaxLength="20"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control form-group-lg" required="" placeholder="Contraseña" TextMode="Password" MaxLength="15"></asp:TextBox>
                </div>
                <div class="form-group">

                    <asp:HyperLink ID="HyperLink3" runat="server">Registrarse</asp:HyperLink>

                </div>
                <div class="form-group">
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-danger" OnClick="btnEntrar_Click"  />
                    <input type="reset" class="btn btn-default" />
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

