<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="geoNegocioSuscriptor.aspx.cs" Inherits="Presentacion.geoNegocioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <%-- Primera col --%>
        <div class="col-xs-4 well">
            <div class="form-group">
                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control input-lg" placeholder="Buscar"></asp:TextBox>


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
                        enableReverseGeocode: true,
                        markerDraggable: true
                    });

                </script>

                <%-- Fin de scrips --%>
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click1" CssClass="btn btn-danger btn-block" Text="Buscar" />
            </div>
        </div>

        <%-- Segunda col --%>
        <div class="col-xs-8">
            <div class="panel">
                <div class="panel-default">
                    <div class="panel-heading">
                        <h4>Lista de Negocios</h4>
                    </div>
                    <div class="panel-body ">
                        <%--<asp:DataList runat="server">
                            <ItemTemplate>
                                <% If CBool(Eval("Deleted")) Then%> 
                                    ...
                                <% Else%>
                                    ...
                                <% End If%>
                            </ItemTemplate>
                        </asp:DataList>
                            <ItemTemplate>
                <asp:Label Text='<%# Eval("Status").ToString() == "A" ? "Absent" : "Present" %>'
                    runat="server" />
            </ItemTemplate>
                        --%>
                        <asp:Panel ID="Panel1" runat="server" Height="500">
                            

                            <div class="jumbotron">
                                <div style="height: 40px"></div>
                                <span class="center-block text-center glyphicon glyphicon-map-marker" style="font-size: 150px; color: #808080"></span>
                                <br />
                                <h1>Busque el negocio mas cercanos</h1>
                               <%-- <p>
                                    Bootstrap is the most popular HTML, CSS, and JS framework for developing
                                    responsive, mobile-first projects on the web.
                                </p>--%>
                            </div>
                        </asp:Panel>

                        <asp:DataList ID="dtNegosios" runat="server">
                            <ItemTemplate>
                                <div class="media">
                                    <div class="media-left">
                                        <asp:ImageButton ID="imgNegocio" CssClass="media-object" OnClick="imgNegocio_Click" runat="server" Width="150px" Height="150px" ImageUrl='<%# Eval("foto_negocio") %>' />
                                    </div>
                                    <div class="media-body">
                                        <h2 class="media-heading ">
                                            <asp:LinkButton ID="btnNombre" OnClick="btnNombre_Click" CssClass="text-info" runat="server" Text='<%# Eval("nombre") %>'></asp:LinkButton>
                                        </h2>
                                        <h3 class="text-muted">
                                            <asp:Label ID="lbIdNegocio" Visible="false" runat="server" Text='<%# Eval("id_negocio") %>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("distancia","{0:0.00}") %>'></asp:Label>/KM</h3>
                                        <p>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                        </p>
                                    </div>
                                    <div class="media-right media-middle">
                                        <div class="panel">
                                            <h3 class="media-heading text-muted text-center" style="width: 120px; font-size: 45px"><span class="glyphicon glyphicon-star-empty"><strong style="font-size: 60px;">4.0</strong></span></h3>
                                            <small class="text-center text-muted center-block">1233232.23<span class="glyphicon glyphicon-user"></span></small>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                            </ItemTemplate>
                        </asp:DataList>

                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
