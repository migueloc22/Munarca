<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="ConfigSuscriptor.aspx.cs" Inherits="Presentacion.ConfigSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="  panel-primary">
            <div class="jumbotron">
                <h1>Configuarción de Usuario</h1>
            </div>
            <div class="panel-body">
                <fieldset>
                    <legend>
                        <p class="text-muted">Datos Pesonales</p>
                    </legend>
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <%-- inicio primera columna --%>
                                    <div class="col-xs-4">
                                        <div class="form-group">
                                            <label>Primer Nombre</label>
                                            <asp:TextBox ID="txtNombre1" runat="server" CssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Segundo Nombre</label>
                                            <asp:TextBox ID="txtNombre2" runat="server" CssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Primer Apellido</label>
                                            <asp:TextBox ID="txtApe1" runat="server" CssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Segundo Apellido</label>
                                            <asp:TextBox ID="txtApe2" runat="server" CssClass="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Tipo de Documento</label>
                                            <asp:DropDownList ID="dtTpDoc" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:Button ID="btnDatos" runat="server" Text="Guardar Datos" CssClass="btn btn-danger" OnClick="btnDatos_Click" ValidationGroup="Panel1" />
                                        </div>


                                    </div>
                                    <%-- Fin segunda columna --%>
                                    <%-- inicio primera columna --%>
                                    <div class="col-xs-4">
                                        <div class="form-group">
                                            <label>Numero de Documento</label>
                                            <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" placeholder="Numero de Documento"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Correo</label>
                                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label>Fecha De Nacimiento</label>
                                            <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" placeholder="Fecha De Nacimiento"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtFechaNac_CalendarExtender" runat="server" BehaviorID="txtFechaNac_CalendarExtender" Format="yyyy/M/d" TargetControlID="txtFechaNac" />
                                            <asp:RequiredFieldValidator ControlToValidate="txtNombre1" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel1" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>


                        <%-- Fin tercera columna --%>
                        <div class="col-xs-4">
                            <div class="row">
                                <div class="col-xs-6 col-xs-offset-4 well">
                                    <div class="form-group">
                                        <asp:Image ID="imgUser" CssClass="img-responsive img-circle" Width="100%" ImageUrl="media/img/user.png" runat="server" />
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
                                                    <asp:FileUpload ID="FileUpload1" accept="image/*" CssClass="form-control" required="" runat="server" />
                                                </asp:Panel>

                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="txtGuadarImg" CssClass="btn btn-danger "  runat="server" Text="Guardar Imangen" OnClick="txtGuadarImg_Click" CausesValidation="true" />
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
                    <asp:Panel ID="Panel2" runat="server">
                        <div class="row">
                            <div class="col-xs-4">
                                <div class="form-group">
                                    <label>Contaseña</label>

                                    <asp:TextBox ID="txtPass1" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contaseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPass1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel2" ForeColor="Red">*</asp:RequiredFieldValidator>

                                </div>
                                <div class="form-group">
                                    <label>Confirmar la Contraseña</label>

                                    <asp:TextBox ID="txtPass2" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar la Contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtPass1" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Campo vacio" ValidationGroup="Panel2" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="txtPass2" ControlToCompare="txtPass1" ValidationGroup="Panel2"></asp:CompareValidator>

                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnGuardarPass" runat="server" ValidationGroup="Panel2" Text="Cambiar la contaseña" OnClick="btnGuardarPass_Click" CssClass="btn btn-danger" />
                                </div>
                            </div>

                        </div>
                    </asp:Panel>


                </fieldset>
                <fieldset>
                    <legend>Agregar Usuario</legend>
                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control"></asp:DropDownList>

                </fieldset>
                <fieldset>
                    <legend>Cambiar Usuario</legend>
                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control"></asp:DropDownList>

                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
