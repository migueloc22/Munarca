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
    <script src="js/jquery.MultiFile.js"></script>
    <script src="js/JavaScript.js"></script>
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
    <form id="form1" runat="server">
        <div id="encabezaso"></div>
        <div id="Contenedor">
            <img src="img/logoFinal.png" id="logo" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="cajaLogin">
                        <center>
                <h2><span class="glyphicon glyphicon-log-in"></span> Login</h2>
                </center>
                        <div class="btn-group btn-group-justified">
                            <asp:LinkButton ID="btnAtivador1" runat="server" ForeColor="White" OnClick="btnAtivador1_Click" CssClass="btn btn-danger btn-lg" CausesValidation="false"><span class="glyphicon glyphicon-user"></span> Suscriptor </asp:LinkButton>
                            <asp:LinkButton ID="btnAtivador2" runat="server" ForeColor="Gray" OnClick="btnAtivador2_Click" CssClass="btn btn-link btn-lg" CausesValidation="false"><span class="glyphicon glyphicon-flag"></span> Propietario </asp:LinkButton>
                        </div>
                        <br />
                        <div class="form-group">
                            <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control form-group-lg" placeholder="email" TextMode="Email" MaxLength="25"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control form-group-lg" placeholder="Contraseña" TextMode="Password" MaxLength="15"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <asp:HyperLink ID="HyperLink3" runat="server">Registrarse</asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/recuperarPass.aspx">Recuperar Contraseña</asp:HyperLink>
                            <ajaxToolkit:ModalPopupExtender ID="HyperLink3_ModalPopupExtender" runat="server" BehaviorID="HyperLink3_ModalPopupExtender" TargetControlID="HyperLink3" PopupControlID="PanelRegistro" CancelControlID="exit" BackgroundCssClass="fondo">
                            </ajaxToolkit:ModalPopupExtender>
                            <br />
                            <asp:Label ID="lbValidacionUser" runat="server" Text="" ForeColor="red"></asp:Label>
                            
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-danger" OnClick="btnEntrar_Click" CausesValidation="false" />
                            <input type="reset" class="btn btn-default" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%-- Inicio Modal --%>

        <asp:Panel ID="PanelRegistro" runat="server" Style="display: none; background-color: white; width: 600px; height: auto;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-header">

                        <button id="exit" type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Registro de Usuario</h4>

                    </div>
                    <div class="scrolling">

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNom1" runat="server" CssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNom1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtApe1" runat="server" CssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtApe1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Telefono"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtTelefono" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="dlDpto" runat="server" CssClass="form-control" OnSelectedIndexChanged="dlDpto_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label class="label">Tipo de Usuario</label>
                                        <asp:DropDownList ID="dlTipoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <br />
                                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtCorreo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" placeholder="Fecha de Nacimiento"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtFechaNac" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <ajaxToolkit:CalendarExtender runat="server" BehaviorID="txtFechaNac_CalendarExtender" TargetControlID="txtFechaNac" ID="txtFechaNac_CalendarExtender" Format="yyyy/M/d"></ajaxToolkit:CalendarExtender>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNom2" runat="server" CssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNom2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtApe2" runat="server" CssClass="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtApe2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" placeholder="Numero Documento"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNumDoc" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-group">
                                        <asp:DropDownList ID="dlCiudad" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label class="label">Tipo de Usuario</label>
                                        <asp:DropDownList ID="dlTipoDoc" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <br />
                                        <asp:TextBox ID="txtDir" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDir" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                </div>

                            </div>
                            <div class="alert alert-success">
                                <strong>Informacion</strong> Su contraseña sera enviada a su correo electronio.
                            </div>
                            <asp:Literal ID="ltMensaje" runat="server"></asp:Literal>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        </div>


                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="modal-footer">
                <asp:Button ID="btnRegistro" runat="server" Text="Agregar" CssClass="btn btn-danger btn-block" CausesValidation="true" OnClick="btnRegistro_Click" />

            </div>

        </asp:Panel>

        <%-- Panel Modal --%>
    </form>

    <div id="pie">
        <div class="row">
        <div id="sudpie1" class="col-xs-12"></div>
        <div id="sudpie2"class="col-xs-12"></div>
        </div>
        
    </div>
</body>
</html>

