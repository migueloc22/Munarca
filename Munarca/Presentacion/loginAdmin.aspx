<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginAdmin.aspx.cs" Inherits="Presentacion.loginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
    
        <br />
        <asp:Button ID="btnEntrar" runat="server" Text="Ingresar" OnClick="btnEntrar_Click" />
    
        <asp:Label ID="lbValidar" runat="server" ForeColor="#CC0000"></asp:Label>
    
    </div>
    </form>
</body>
</html>
