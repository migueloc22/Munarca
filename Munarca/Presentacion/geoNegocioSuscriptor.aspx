<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="geoNegocioSuscriptor.aspx.cs" Inherits="Presentacion.geoNegocioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <div class="panel">
            <div class="panel-primary">
                <div class="panel-heading">
                    <h3>Buscar Negocio</h3>
                </div>
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4">
                                    <div id="Negocio">
                                        <asp:DataList ID="dtUbicaion" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False">
                                            <ItemTemplate>
                                                <table class="nav-justified">
                                                    <tr>
                                                        <td style="background-color: #FF5050; color: #FFFFFF">Nombre Negocio</td>
                                                        <td style="background-color: #FF5050; color: #FFFFFF">
                                                            <asp:Label ID="lbNombre" runat="server" Text='<%# Eval("NombreNegocio") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="background-color: #EFEFEF;">
                                                            <asp:Label ID="lbDescripcion" runat="server" Text='<%# Eval("DescripNegocio") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color: #EFEFEF">Distancia(km)</td>
                                                        <td style="background-color: #EFEFEF">
                                                            <asp:Label ID="lbDistanacia" runat="server" Text='<%# Eval("distancia") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color: #EFEFEF">
                                                            <asp:Button ID="btnUbicacion" runat="server" CssClass="btn btn-danger" OnClick="btnUbicacion_Click" Text="Ver" />
                                                        </td>
                                                        <td style="background-color: #EFEFEF">
                                                            <asp:LinkButton ID="lkNegocio" runat="server" OnClick="lkNegocio_Click">Ir Negocio</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Bottom" />
                                        </asp:DataList>
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
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Negocio" CssClass="btn btn-primary btn-block" OnClick="btnBuscar_Click" />
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
    </div>
</asp:Content>
