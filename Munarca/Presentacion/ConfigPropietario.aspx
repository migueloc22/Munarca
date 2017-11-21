<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="ConfigPropietario.aspx.cs" Inherits="Presentacion.ConfigPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="  panel-primary">
            <div class="panel-body">
                <fieldset>
                    <legend>
                        <p class="text-muted">Datos Pesonales</p>
                    </legend>
                    <div class="row">
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <%-- inicio primera columna --%>
                                    <div class="col-xs-4">
                                        <div class="form-group">
                                            <label>Primer Nombre</label>
                                            <asp:TextBox ID="txtNombre1" runat="server" CssClass="form-control" placeholder="Primer Nombre" MaxLength="15"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Segundo Nombre</label>
                                            <asp:TextBox ID="txtNombre2" runat="server" CssClass="form-control" placeholder="Segundo Nombre" MaxLength="15"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre2" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Primer Apellido</label>
                                            <asp:TextBox ID="txtApe1" runat="server" CssClass="form-control" placeholder="Primer Apellido" MaxLength="15"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtApe1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Segundo Apellido</label>
                                            <asp:TextBox ID="txtApe2" runat="server" CssClass="form-control" placeholder="Segundo Apellido" MaxLength="15"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtApe2" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Tipo de Documento</label>
                                            <asp:DropDownList ID="dtTpDoc" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>Numero de Documento</label>
                                            <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" placeholder="Numero de Documento" MaxLength="10"></asp:TextBox>
                                            <asp:RegularExpressionValidator ValidationGroup="Panel1" ControlToValidate="txtNumDoc" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo numero" ForeColor="Red" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNumDoc" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>


                                    </div>
                                    <%-- Fin segunda columna --%>
                                    <%-- inicio primera columna --%>
                                    <div class="col-xs-4">
                                        <div class="form-group">
                                            <label>TeleFono</label>
                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Numero de Telefono" MaxLength="10"></asp:TextBox>
                                            <asp:RegularExpressionValidator ValidationGroup="Panel1" ControlToValidate="txtTelefono" ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo numero" ForeColor="Red" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ControlToValidate="txtTelefono" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Dirección</label>
                                            <asp:TextBox ID="txtDir" runat="server" CssClass="form-control" placeholder="Dirección" MaxLength="25"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtDir" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Correo</label>
                                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo" MaxLength="35"></asp:TextBox>
                                            <asp:RegularExpressionValidator ValidationGroup="Panel1" ControlToValidate="txtCorreo" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Correo Invalido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ControlToValidate="txtCorreo" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Fecha De Nacimiento</label>
                                            <asp:HiddenField ID="hdFechaNac" runat="server" />
                                            <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control DataPicker" placeholder="Fecha De Nacimiento" MaxLength="10"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtFechaNac_CalendarExtender" runat="server" BehaviorID="txtFechaNac_CalendarExtender" Format="yyyy/M/d" TargetControlID="txtFechaNac" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtFechaNac" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Departamento</label>
                                            <asp:DropDownList ID="dtDepartamento" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dtDepartamento_SelectedIndexChanged"></asp:DropDownList>

                                        </div>
                                        <div class="form-group">
                                            <label>Ciudad</label>
                                            <asp:DropDownList ID="dtCiudad" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:Literal ID="ltDatos" runat="server"></asp:Literal>
                                        </div>
                                        <div class="form-group">
                                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Panel1" ForeColor="red" runat="server" />
                                            <asp:Button ID="btnDatos" runat="server" Text="Guardar Datos" CssClass="btn btn-danger" OnClick="btnDatos_Click" ValidationGroup="Panel1" CausesValidation="true" />
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>

                        <%-- Fin tercera columna --%>
                        <div class="col-xs-4">
                            <div class="row">
                                <div class="col-xs-7 col-xs-offset-4 well">
                                    <div class="form-group">
                                        <asp:Image ID="imgUser" CssClass="img-responsive img-circle" Width="170" Height="170" ImageUrl="media/img/user.png" runat="server" />
                                    </div>

                                    <div class="form-group">
                                        <asp:Button ID="btnImagen" CssClass="btn btn-danger btn-block" runat="server" Text="Cambiar Imagen" />
                                        <asp:Literal ID="ltImagen" runat="server"></asp:Literal>
                                        <ajaxToolkit:ModalPopupExtender ID="btnImagen_ModalPopupExtender" runat="server" BehaviorID="btnImagen_ModalPopupExtender" TargetControlID="btnImagen" PopupControlID="pnImagen" BackgroundCssClass="fondo" CancelControlID="cancel1">
                                        </ajaxToolkit:ModalPopupExtender>
                                        <asp:Panel ID="pnImagen" runat="server" Style="display: none; background-color: white; width: 400px; height: auto; border-radius: 5px;">
                                            <div class="modal-header">
                                                <button type="button" class="close" id="cancel1" data-dismiss="modal">&times;</button>
                                                <h4 class="modal-title text-danger">Subir Imagen</h4>
                                            </div>
                                            <div class="modal-body">
                                                <asp:Panel ID="Panel3" runat="server">
                                                    <asp:FileUpload ID="FileUpload1" accept="image/*" CssClass="form-control" runat="server" />
                                                    <asp:RequiredFieldValidator ControlToValidate="FileUpload1" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Campo vacio" ValidationGroup="pnImagen" ForeColor="Red">*</asp:RequiredFieldValidator>

                                                    <script>
                                                        $("#ContentPlaceHolder1_ContentPlaceHolder1_FileUpload1").fileinput({
                                                            language: "es",
                                                            uploadUrl: "/file-upload-batch/2",
                                                            allowedFileExtensions: ["jpg", "png", "gif"]

                                                        });
                                                    </script>
                                                </asp:Panel>

                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="txtGuadarImg" CssClass="btn btn-danger " runat="server" Text="Guardar Imangen" OnClick="txtGuadarImg_Click" ValidationGroup="pnImagen" CausesValidation="true" />
                                            </div>

                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <%-- Fin tercera columna --%>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Contraseña</legend>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-xs-4">
                                    <div class="form-group">
                                        <label>Contaseña</label>
                                        <asp:TextBox ID="txtPass1" runat="server" CssClass="form-control check-seguridad" TextMode="Password" placeholder="Contaseña" minlength="8" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPass1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel2" ForeColor="Red">*</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group">
                                        <label>Confirmar la Contraseña</label>

                                        <asp:TextBox ID="txtPass2" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar la Contraseña" minlength="8" MaxLength="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtPass1" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contraseñas no son iguales" ControlToValidate="txtPass2" ControlToCompare="txtPass1" ValidationGroup="Panel2"></asp:CompareValidator>

                                    </div>
                                    <div class="form-group">
                                        <asp:Literal ID="ltMsnPass" runat="server"></asp:Literal>
                                        <asp:Button ID="btnGuardarPass" runat="server" ValidationGroup="Panel2" Text="Cambiar la contaseña" OnClick="btnGuardarPass_Click" CssClass="btn btn-danger" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Panel ID="Panel2" runat="server">
                    </asp:Panel>


                </fieldset>
                <fieldset>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <h4 class="panel-heading">Agregar tipo Usuario
                                    <hr />
                                </h4>
                                
                                <div class="col-xs-4">                                    
                                    <div class="form-group">
                                        <asp:DropDownList ID="dpTipoUser" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:Literal ID="ltMsntpUserAgregar" runat="server"></asp:Literal>
                                        <asp:Button ID="btnUsuraio" runat="server" OnClick="btnUsuraio_Click" CssClass="btn btn-danger" Text="Agregar Tipo" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </fieldset>
                <fieldset>
                    <div class="row">
                        <h4 class="panel-heading" >Cambiar Usuario <hr /></h4>
                        
                        <div class="col-xs-4">                         
                            
                            <div class="form-group">
                                <asp:DropDownList ID="dpTipoUser2" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Literal ID="ltMsntpUserCambio" runat="server"></asp:Literal>
                                <asp:Button ID="btnCmbiarUser" OnClick="btnCmbiarUser_Click" CssClass="btn " runat="server" Text="Cambiar de tipo" />
                            </div>
                        </div>
                    </div>
                </fieldset>

            </div>
        </div>
    </div>
</asp:Content>
