<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="CrearNegocioPropietario.aspx.cs" Inherits="Presentacion.CrearNegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panel-primary">
            <div class="jumbotron">
                <h1>Crear negocio</h1>
            </div>
            <div class="panel-body">
                    <div class="row">
                        <%--Inicio columna--%>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Nombre Negocio :"></asp:Label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNombre" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="Categoria :"></asp:Label>
                                <asp:DropDownList ID="dpCategoria" runat="server" CssClass="form-control dropdown"></asp:DropDownList>
                            </div>
                        </div>
                        <%--Final columna--%>
                        <%--Inicio columna--%>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Telefono :"></asp:Label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Numero" ControlToValidate="txtTelefono" ForeColor="Red" ValidationExpression="([0-9]|-)*">*</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtTelefono" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-control">
                                <asp:FileUpload ID="uploadFile1" runat="server" accept="gif|jpg|png" class="multi" maxlength="3" />
                            </div>                            
                        </div>
                        <%--Final columna--%>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Descripción :"></asp:Label>
                        <asp:TextBox ID="txtDesccrip" runat="server" CssClass="form-control" MaxLength="250" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDesccrip" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>

                    <%-- Inicio modal --%>


                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Ubicación :"></asp:Label>
                        <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" Text="Bogota"></asp:TextBox>
                    </div>
                    <div id="ModalMapPreview" style="width: 100%; height: 400px;"></div>
                    <div class="clearfix">&nbsp;</div>
                    <div class="m-t-small">
                        <label class="p-r-small col-sm-1 control-label">Lat.:</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtLat" runat="server" CssClass="form-control" Text="4.710988599999999"></asp:TextBox>
                        </div>
                        <label class="p-r-small col-sm-2 control-label">Long.:</label>

                        <div class="col-sm-3">
                            <asp:TextBox ID="txtLon" runat="server" CssClass="form-control" Text="-74.072092"></asp:TextBox>
                        </div>

                    </div>
                    <div class="clearfix"></div>
                    <script>
                        $('#ModalMapPreview').locationpicker({
                            radius: 0,
                            location: {
                                latitude: $('#<%=txtLat.ClientID%>').val(),
                                longitude: $('#<%=txtLon.ClientID%>').val()
                            },
                            inputBinding: {
                                latitudeInput: $('#<%=txtLat.ClientID%>'),
                                longitudeInput: $('#<%=txtLon.ClientID%>'),
                                locationNameInput: $('#<%=txtUbicacion.ClientID%>')
                            },
                            enableAutocomplete: true,
                            onchanged: function (currentLocation, radius, isMarkerDropped) {
                                $('#ubicacion').html($('#txtUbicacion').val());
                            }
                        });
                        $('#ModalMap').on('shown.bs.modal', function () {
                            $('#ModalMapPreview').locationpicker('autosize');
                        });
                        enableAutocomplete: true;
                    </script>
                    <%-- Inicio Final --%>

                    <div class="form-group">                        
                        <asp:Label ID="lbValidacion" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAgregarNegocio" runat="server" Text="Agregar" CssClass="btn btn-danger" OnClick="btnAgregarNegocio_Click" />
                    </div>

                </div>
        </div>
    </div>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />
    <ajaxToolkit:ModalPopupExtender ID="Button2_ModalPopupExtender" runat="server" BehaviorID="Button2_ModalPopupExtender" TargetControlID="Button2" PopupControlID="pnModal" BackgroundCssClass="fondo">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnModal" runat="server" Style="display: none; background-color: white; width: auto; height: auto;">

        <div class="modal-body">
            <h1>Negocio Fuel Agregado</h1>
        </div>
        <div class="modal-footer">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl="~/NegocioPropietario.aspx">Regresar a Negocio</asp:HyperLink>
        </div>

    </asp:Panel>
</asp:Content>
