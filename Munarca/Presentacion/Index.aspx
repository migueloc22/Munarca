<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Munarca</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/JavaScript.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/locationpicker.jquery.js"></script>
    <script src="js/jquery.MultiFile.js"></script>
    <style>
        .fondo {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
</head>
<body>

    <div id="encabezaso"></div>
    <div id="Contenedor">
        <img src="img/logoFinal.png" id="logo" />
        <form id="form1" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="cajaLogin">
                        <center>
                <h2><span class="glyphicon glyphicon-log-in"></span> Login</h2>
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

                            <ajaxToolkit:ModalPopupExtender ID="HyperLink3_ModalPopupExtender" runat="server" BehaviorID="HyperLink3_ModalPopupExtender" TargetControlID="HyperLink3" PopupControlID="PanelRegistro" CancelControlID="exit" BackgroundCssClass="fondo">
                            </ajaxToolkit:ModalPopupExtender>

                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-danger" OnClick="btnEntrar_Click" />
                            <input type="reset" class="btn btn-default" />
                        </div>
                    </div>
                    <%-- Inicio Modal --%>
                    <asp:Panel ID="PanelRegistro" runat="server" Style="display: none; background-color: white; width: 600px; height: auto;">
                        <div class="modal-header">

                            <button id="exit" type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Registro de Usuario</h4>

                        </div>
                        <div class="scrolling">
                            <div class="modal-body">

                                <div class="form-group">
                                    <div class="form-group">
                                        <asp:DropDownList ID="dlTipoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <asp:TextBox ID="txtNom1" runat="server" CssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNom2" runat="server" CssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="txtApe1" runat="server" CssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="txtApe2" runat="server" CssClass="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:DropDownList ID="dlTipoDoc" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" placeholder="Numero Documento"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="dlDpto" runat="server" CssClass="form-control" OnSelectedIndexChanged="dlDpto_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="dlCiudad" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="contraseña" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtConfContraseña" TextMode="Password" runat="server" CssClass="form-control" placeholder="Confirmar contraseña"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtDir" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFechaNac" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender runat="server" BehaviorID="txtFechaNac_CalendarExtender" TargetControlID="txtFechaNac" ID="txtFechaNac_CalendarExtender"></ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Telefono"></asp:TextBox>
                                    </div>

                                    <asp:FileUpload ID="FileUpload1" runat="server" accept="gif|jpg|png" class="multi" maxlength="1" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnRegistro" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block" CausesValidation="False" OnClick="btnRegistro_Click" />
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </div>

                    </asp:Panel>
                    <%-- Panel Modal --%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </div>
    <div id="pie">
        <div id="sudpie1"></div>
        <div id="sudpie2"></div>
    </div>
</body>
</html>

