<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperarPass.aspx.cs" Inherits="Presentacion.recuperarPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <title></title>
</head>
<body class="well">
    <form id="form1" runat="server">
        <div style="height: 80px;"></div>
        <div class="col-xs-4 col-xs-offset-4">
            <div class="panel ">
                <div class="panel-heading">
                    <legend>
                        <h3>Recuperacion de contraseña!!!</h3>
                    </legend>

                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:TextBox ID="txtCorreo" CssClass="form-control input-lg" MaxLength="35"  placeholder="Correo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Vacio" ControlToValidate="txtCorreo" ForeColor="Red"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Escriba Un Correo" ControlToValidate="txtCorreo" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        
                    </div>
                                       

                    <asp:Label ID="lbRespuesta" runat="server" Text="" ForeColor="Red"></asp:Label>                   
                    <div class="alert alert-link">
                        <strong>Informacion</strong> Su contraseña sera enviada a su correo electronio. para regresar a la pagina inicial siga este
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Index.aspx" runat="server">link</asp:HyperLink>.
                    </div>
                    <div class="form-group">
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-danger btn-block" OnClick="btnEnviar_Click1" />
                </div>
                </div>
                
            </div>
    </form>
</body>
</html>
