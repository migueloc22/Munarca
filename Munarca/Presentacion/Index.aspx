<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Munarca</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <div id="encabezaso"></div>
    <div id="cuerpo">
    <img src="img/logoFinal.png" id="logo" />
        <form id="form1" runat="server">
            <div id="cajaLogin">
                <div class="form-group">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-group-lg" placeholder="email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control form-group-lg" placeholder="Contraseña"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn  btn-primary" />
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
