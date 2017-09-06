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
    
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
    
        <br />
        <asp:Button ID="btnEntrar" runat="server" OnClick="Button1_Click" Text="Ingresar" />
    
    </div>
    </form>
</body>
</html>
