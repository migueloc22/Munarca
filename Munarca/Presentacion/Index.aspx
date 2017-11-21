<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Munarca</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/jquery-ui.min.css" rel="stylesheet" />
    <link href="css/estilos.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.MultiFile.js"></script>
    <script>
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '<Ant',
            nextText: 'Sig>',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);
        $(function () {
            $(".DataPicker").datepicker({
                dateFormat: "yy/mm/dd",
                yearRange: '1950:2001',
                changeMonth: true,
                changeYear: true


            });
        });


    </script>
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
        <div>
            <img src="img/logoFinal.png" id="logo" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="cajaLogin">
                        <center>
                <h2><span class="glyphicon glyphicon-log-in"></span> Login</h2>
                </center>
                        <div class="form-group">
                            <asp:DropDownList ID="drListUsu" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>

                        <%--<div class="btn-group btn-group-justified">
                            <asp:LinkButton ID="btnAtivador1" runat="server" ForeColor="White" OnClick="btnAtivador1_Click" CssClass="btn btn-danger btn-lg" CausesValidation="false"><span class="glyphicon glyphicon-user"></span> Suscriptor </asp:LinkButton>
                            <asp:LinkButton ID="btnAtivador2" runat="server" ForeColor="Gray" OnClick="btnAtivador2_Click" CssClass="btn btn-link btn-lg" CausesValidation="false"><span class="glyphicon glyphicon-flag"></span> Propietario </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Gray" OnClick="btnAtivador2_Click" CssClass="btn btn-link btn-lg" CausesValidation="false"><span class="glyphicon glyphicon-flag"></span> Administrador </asp:LinkButton>
                        </div>--%>

                        <div class="form-group">
                            <asp:TextBox ID="txtEMail" runat="server" CssClass="form-control form-group-lg" placeholder="email" TextMode="Email" MaxLength="35"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control form-group-lg" placeholder="Contraseña" TextMode="Password" MaxLength="30"></asp:TextBox>
                        </div>
                        <div class="form-group">

                            <asp:HyperLink ID="HyperLink3" runat="server">Registrarse</asp:HyperLink><br />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/recuperarPass.aspx">Recuperar Contraseña</asp:HyperLink>
                            <ajaxToolkit:ModalPopupExtender ID="HyperLink3_ModalPopupExtender" runat="server" BehaviorID="HyperLink3_ModalPopupExtender" TargetControlID="HyperLink3" PopupControlID="PanelRegistro" CancelControlID="exit" BackgroundCssClass="fondo">
                            </ajaxToolkit:ModalPopupExtender>
                            <br />
                            <asp:Label ID="lbValidacionUser" runat="server" Text="" ForeColor="red"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Button" Enabled="false" Style="display: none" />

                            <ajaxToolkit:ModalPopupExtender runat="server" BehaviorID="Button1_ModalPopupExtender" TargetControlID="Button1" ID="Button1_ModalPopupExtender" PopupControlID="pnResultado" CancelControlID="cerrar" BackgroundCssClass="fondo"></ajaxToolkit:ModalPopupExtender>


                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="btn btn-danger" CausesValidation="false" OnClick="btnEntrar_Click" />
                            <input type="reset" class="btn default" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%-- Inicio Modal --%>

        <asp:Panel ID="PanelRegistro" runat="server" Style="display: none; background-color: white; width: auto; height: auto; border-radius: 5px; margin-top: 1%">
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
                                        <label for="usr">Primer Nombre:</label>
                                        <asp:TextBox ID="txtNom1" runat="server" CssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNom1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Primer Apellido</label>
                                        <asp:TextBox ID="txtApe1" runat="server" CssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtApe1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Telefono:</label>
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Telefono"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtTelefono" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Departamento:</label>
                                        <asp:DropDownList ID="dlDpto" runat="server" CssClass="form-control" OnSelectedIndexChanged="dlDpto_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Tipo De Documento:</label>
                                        <asp:DropDownList ID="dlTipoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Numero Documento:</label>
                                        <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" placeholder="Numero Documento"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNumDoc" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Correo:</label>
                                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
                                        <asp:Label ID="lbRepuesta" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCorreo" runat="server" ForeColor="red" ErrorMessage="Correo Invalido" ValidationExpression="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtCorreo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="usr">Segundo Nombre:</label>
                                        <asp:TextBox ID="txtNom2" runat="server" CssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNom2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Segundo Apellido:</label>
                                        <asp:TextBox ID="txtApe2" runat="server" CssClass="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtApe2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Fecha De Nacimiento</label>
                                        <asp:HiddenField ID="hdFechaNac" runat="server" />
                                        <asp:TextBox ID="txtFechaNac" runat="server" Text="1997/01/15" CssClass="form-control DataPicker" placeholder="Fecha De Nacimiento" MaxLength="10"></asp:TextBox>
                                        <%--<ajaxToolkit:CalendarExtender ID="txtFechaNac_CalendarExtender" runat="server" BehaviorID="txtFechaNac_CalendarExtender" Format="yyyy/M/d" TargetControlID="txtFechaNac" />--%>
                                        <asp:RequiredFieldValidator ControlToValidate="txtFechaNac" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-group">
                                        <label for="usr">Ciudad:</label>
                                        <asp:DropDownList ID="dlCiudad" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Tipo De Usuario:</label>
                                        <asp:DropDownList ID="dlTipoDoc" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="usr">Dirección:</label>

                                        <asp:TextBox ID="txtDir" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDir" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="col-xs-12">
                                    <div class="panel-group">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" href="#collapse1">Terminos y Condiciones</a>
                                                </h4>
                                            </div>
                                            <div id="collapse1" class="panel-collapse collapse">
                                                <div class="panel-body">
                                                    <h2 style="text-align: center;"><strong>POLÍTICA DE PRIVACIDAD</strong></h2>
                                                    <p>&nbsp;</p>
                                                    <p>El presente Política de Privacidad establece los términos en que munarca usa y protege la información que es proporcionada por sus usuarios al momento de utilizar su sitio web. Esta compañía está comprometida con la seguridad de los datos de sus usuarios. Cuando le pedimos llenar los campos de información personal con la cual usted pueda ser identificado, lo hacemos asegurando que sólo se empleará de acuerdo con los términos de este documento. Sin embargo esta Política de Privacidad puede cambiar con el tiempo o ser actualizada por lo que le recomendamos y enfatizamos revisar continuamente esta página para asegurarse que está de acuerdo con dichos cambios.</p>
                                                    <p><strong>Información que es recogida</strong></p>
                                                    <p>Nuestro sitio web podrá recoger información personal por ejemplo: Nombre,&nbsp; información de contacto como&nbsp; su dirección de correo electrónica e información demográfica. Así mismo cuando sea necesario podrá ser requerida información específica para procesar algún pedido o realizar una entrega o facturación.</p>
                                                    <p><strong>Uso de la información recogida</strong></p>
                                                    <p>Nuestro sitio web emplea la información con el fin de proporcionar el mejor servicio posible, particularmente para mantener un registro de usuarios, de pedidos en caso que aplique, y mejorar nuestros productos y servicios. &nbsp;Es posible que sean enviados correos electrónicos periódicamente a través de nuestro sitio con ofertas especiales, nuevos productos y otra información publicitaria que consideremos relevante para usted o que pueda brindarle algún beneficio, estos correos electrónicos serán enviados a la dirección que usted proporcione y podrán ser cancelados en cualquier momento.</p>
                                                    <p>munarca está altamente comprometido para cumplir con el compromiso de mantener su información segura. Usamos los sistemas más avanzados y los actualizamos constantemente para asegurarnos que no exista ningún acceso no autorizado.</p>
                                                    <p><strong>Cookies</strong></p>
                                                    <p>Una cookie se refiere a un fichero que es enviado con la finalidad de solicitar permiso para almacenarse en su ordenador, al aceptar dicho fichero se crea y la cookie sirve entonces para tener información respecto al tráfico web, y también facilita las futuras <a href="https://gefalltmirbutton.org/en/" target="_blank">visitas a una web </a>recurrente. Otra función que tienen las cookies es que con ellas las web pueden reconocerte individualmente y por tanto brindarte el mejor servicio personalizado de su web.</p>
                                                    <p>Nuestro <a href="https://politicadeprivacidadplantilla.com/" target="_blank">sitio web</a> emplea las cookies para poder identificar las páginas que son visitadas y su frecuencia. Esta información es empleada únicamente para análisis estadístico y después la información se elimina de forma permanente. Usted puede eliminar las cookies en cualquier momento desde su ordenador. Sin embargo las cookies ayudan a proporcionar un mejor servicio de los sitios web, estás no dan acceso a información de su ordenador ni de usted, a menos de que usted así lo quiera y la proporcione directamente. Usted puede aceptar o negar el uso de cookies, sin embargo la mayoría de navegadores aceptan cookies automáticamente pues sirve para tener un mejor servicio web. También usted puede cambiar la configuración de su ordenador para declinar las cookies. Si se declinan es posible que no pueda utilizar algunos de nuestros servicios.</p>
                                                    <p><strong>Enlaces a Terceros</strong></p>
                                                    <p>Este sitio web pudiera contener en laces a otros sitios que pudieran ser de su interés. Una vez que usted de clic en estos enlaces y abandone nuestra página, ya no tenemos control sobre al sitio al que es redirigido y por lo tanto no somos responsables de los términos o privacidad ni de la protección de sus datos en esos otros sitios terceros. Dichos sitios están sujetos a sus propias políticas de privacidad por lo cual es recomendable que los consulte para confirmar que usted está de acuerdo con estas.</p>
                                                    <p><strong>Control de su información personal</strong></p>
                                                    <p>En cualquier momento usted puede restringir la recopilación o el uso de la información personal que es proporcionada a nuestro sitio web.&nbsp; Cada vez que se le solicite rellenar un formulario, como el de alta de usuario, puede marcar o desmarcar la opción de recibir información por correo electrónico. &nbsp;En caso de que haya marcado la opción de recibir nuestro boletín o publicidad usted puede cancelarla en cualquier momento.</p>
                                                    <p>Esta compañía no venderá, cederá ni distribuirá la información personal que es recopilada sin su consentimiento, salvo que sea requerido por un juez con un orden judicial.</p>
                                                    <p>munarca Se reserva el derecho de cambiar los términos de la presente Política de Privacidad en cualquier momento.</p>
                                                    <p>
                                                        Estas terminos y condiciones se han generado en <a href="https://plantillaterminosycondicionestiendaonline.com/" target="_blank">plantillaterminosycondicionestiendaonline.com</a>.<br>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-success">
                                <strong>Información</strong> Su contraseña será enviada a su correo electronio.
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
        <%-- modal 2 --%>
        <asp:Panel ID="pnResultado" runat="server" Style="display: none; background-color: white; width: 400px; height: auto; border-radius: 5px;">

            <div class="modal-body">
                <span class="center-block text-center glyphicon glyphicon-ok-circle" style="font-size: 150px; color: #0094ff"></span>
                <div class="alert alert-info">
                    <strong>Info!</strong> Usuario Registrado...
                </div>
            </div>
            <div class="modal-footer">
                <button id="cerrar" class="btn btn-danger btn-block">Aceptar</button>
            </div>

        </asp:Panel>
        <%-- modal fin --%>
    </form>

    <div id="pie">
        <div class="row">
            <div id="sudpie1" class="col-xs-12"></div>
            <div id="sudpie2" class="col-xs-12"></div>
        </div>

    </div>
</body>
</html>

