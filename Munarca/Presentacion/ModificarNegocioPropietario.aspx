<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="ModificarNegocioPropietario.aspx.cs" Inherits="Presentacion.ModificarNegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            <div class="panel">
                <div class="panel-primary">
                    <div class="panel-body">
                        <h1 class="h1">Modificar Negocio</h1>
                        <hr />
                        <div class="row">
                            <%--Inicio columna--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:HiddenField ID="hdCodNegocio" runat="server" />
                                    <asp:HiddenField ID="hdImag" runat="server" />
                                    <asp:FileUpload ID="uploadFile1" runat="server" accept="image/*" class="file" multiple data-show-upload="false" />
                                    <div class="alert alert-info">
                                        <strong>Info!</strong> EL cambio de la foto es opcional .
                                    </div>
                                    <%--<input id="input-id" type="file" class="file" data-preview-file-type="text" >--%>
                                    <script>
                                        $("#ContentPlaceHolder1_ContentPlaceHolder1_uploadFile1").fileinput({
                                            language: "es",
                                            uploadUrl: "/file-upload-batch/2",
                                            allowedFileExtensions: ["jpg", "png", "gif"]

                                        });
                                    </script>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Nombre Negocio :"></asp:Label>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNombre" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                 
                               
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Telefono :"></asp:Label>
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Numero" ControlToValidate="txtTelefono" ForeColor="Red" ValidationExpression="([0-9]|-)*">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtTelefono" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" Text="Descripción :"></asp:Label>
                                    <asp:TextBox ID="txtDescdrip" TextMode="MultiLine" row="3" runat="server" CssClass="form-control" MaxLength="250"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDescdrip" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-4 control-label" for="checkboxes">Categoria</label>
                                    <div class="col-md-4">
                                    <asp:CheckBoxList ID="chekListCategoria" CssClass="checkbox" runat="server"></asp:CheckBoxList>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Seleccione a menos una categoría"   ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
                                        
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Ubicación :"></asp:Label>
                            <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox>
                            <span class="help-block">Digite la dirección de su negocio o arrastre el pin para ubicarlo en el mapa</span>
                        </div>
                        <div class="form-group">
                            <div id="mapaFilter" style="width: 100%; height: 300px"></div>
                        </div>
                        <div class="form-group">
                            <asp:HiddenField ID="hdLatFt" Value="4.710988599999999" runat="server" />
                            <asp:HiddenField ID="hdLonft" Value="-74.072092" runat="server" />
                            <%-- Inicio de scrips --%>
                            <script>
                                $('#mapaFilter').locationpicker({
                                    radius: 0,
                                    zoom: 16,
                                    location: {
                                        latitude: $('#<%=hdLatFt.ClientID%>').val(),
                                        longitude: $('#<%=hdLonft.ClientID%>').val()
                                    },
                                    inputBinding: {
                                        latitudeInput: $('#<%=hdLatFt.ClientID%>'),
                                        longitudeInput: $('#<%=hdLonft.ClientID%>'),
                                        locationNameInput: $('#<%=txtUbicacion.ClientID%>')

                                    },
                                    enableAutocomplete: true,
                                    radius: 300,
                                    addressFormat: 'street_address'
                                });

                            </script>

                            <%-- Fin de scrips --%>
                        </div>



                        <div class="form-group">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                            <asp:Literal ID="ltRepuesta" runat="server"></asp:Literal>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnAgregarNegocio" runat="server" Text="Modificar" CssClass="btn btn-danger" OnClick="btnModificar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />
    <ajaxToolkit:ModalPopupExtender ID="Button2_ModalPopupExtender" runat="server" BehaviorID="Button2_ModalPopupExtender" TargetControlID="Button2" PopupControlID="pnModal" BackgroundCssClass="fondo">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnModal" runat="server" Style="display: none; background-color: white; width: auto; height: auto;">

        <div class="modal-body">
            <h1>Negocio Actulizado..</h1>
        </div>
        <div class="modal-footer">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl="~/NegocioPropietario.aspx">Regresar a Negocio</asp:HyperLink>
        </div>

    </asp:Panel>
</asp:Content>
