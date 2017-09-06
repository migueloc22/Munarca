<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="geoNegocioSuscriptor.aspx.cs" Inherits="Presentacion.geoNegocioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panel-primary">
            <div class="jumbotron">
                <h1>Buscar Negocio</h1>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-4">
                                <legend>Lista de Negocio</legend>
                                <br />
                                <asp:TextBox ID="txtlon2" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:TextBox ID="txtLan2" runat="server" CssClass="form-control"></asp:TextBox>
                                <div id="Negocio">
                                    <asp:Repeater ID="rpUbicacion" runat="server">
                                        <ItemTemplate>
                                            <div class="media">
                                                <a href="#" class="pull-left">
                                                    <asp:Image ID="Image1" runat="server" Style="width: 60px;" ImageUrl="~/img/imageUser.jpg" CssClass="media-object" />
                                                </a>
                                                <div class="media-body">
                                                    <h4 class="media-heading">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                    </h4>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("distancia") %>'></asp:Label>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                    <asp:HiddenField ID="hfLon" runat="server" Value='<%# Eval("longitud") %>'  />
                                                    <asp:HiddenField ID="hfLan" runat="server" Value='<%# Eval("latitud") %>' />
                                                    <br />                                                                                                 
                                                    <asp:LinkButton ID="btnUbicacion" CommandName="btnUbicacion" runat="server" CommandArgument='<%# Eval("id_negocio") %>'><span class="glyphicon glyphicon-play"></span></asp:LinkButton>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>


                            </div>
                            <div class="col-md-7">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Ubicación:</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" Text="Bogota"></asp:TextBox>
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
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Negocio" CssClass="btn btn-danger btn-block" OnClick="btnBuscar_Click" />
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

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
