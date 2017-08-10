<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="CrearNegocioPropietario.aspx.cs" Inherits="Presentacion.CrearNegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <div class="panel">
            <div class="panel-primary">
                <div class="panel-heading">
                    <h4>Crear Negocio</h4>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Nombre Negocio :"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="15" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNombre" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Telefono :"></asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Numero" ControlToValidate="txtTelefono" ForeColor="Red" ValidationExpression="([0-9]|-)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtTelefono" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Descripción :"></asp:Label>
                        <asp:TextBox ID="txtDesccrip" runat="server" CssClass="form-control" MaxLength="250" TextMode="MultiLine" Rows="3" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDesccrip" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Categoria :"></asp:Label>
                        <asp:DropDownList ID="dpCategoria" runat="server" CssClass="form-control dropdown"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <button type="button" data-toggle="modal" data-target="#ModalMap" class="btn btn-default">
                            <span class="glyphicon glyphicon-map-marker"></span><span id="ubicacion">Seleccionar Ubicación:</span>
                        </button>

                    </div>
                    <div class="form-group">
                        <asp:GridView ID="gvUbicacion" runat="server" CssClass="table table-responsive" AutoGenerateColumns="False" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="laptitup" HeaderText="laptitup" />
                                <asp:BoundField DataField="longitup" HeaderText="longitup" />
                                <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="form-group">
                        <asp:FileUpload ID="uploadFile1" runat="server" accept="gif|jpg|png" class="multi" maxlength="3" />
                    </div>
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAgregarNegocio" runat="server" Text="Agregar" CssClass="btn btn-danger" OnClick="btnAgregarNegocio_Click" />
                    </div>
                    <%-- Inicio modal --%>
                    <div class="modal fade" id="ModalMap" tabindex="-1" role="dialog">
                        <style>
                            .pac-container {
                                z-index: 99999;
                            }
                        </style>
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label">Ubicación:</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" Text="Bogota"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-1">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            </div>
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
                                            <div class="col-sm-3">
                                                <asp:Button ID="btnAgregarUbicacion" runat="server" Text="Agregar" CssClass="btn btn-primary btn-block" OnClick="btnAgregarUbicacion_Click" CausesValidation="False" />
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
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- Inicio Final --%>
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
            <h1>Negocio Fuel Agregado</h1>
        </div>
        <div class="modal-footer">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl="~/NegocioPropietario.aspx">Regresar a Negocio</asp:HyperLink>
        </div>

    </asp:Panel>
</asp:Content>
