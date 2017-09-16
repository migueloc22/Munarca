<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="geoNegocioSuscriptor.aspx.cs" Inherits="Presentacion.geoNegocioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panel-primary">
            <div class="jumbotron">
                <h1>Buscar Negocio</h1>
            </div>
            <div class="panel-body">
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
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
                                            <asp:HiddenField ID="hfLon" runat="server" Value='<%# Eval("longitud") %>' />
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

                        <label for="exampleInputEmail1">Ubicación</label>
                        <asp:HiddenField ID="txtId" runat="server" />
                        <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control"></asp:TextBox>
                        <div class="form-group">
                            <div id="MapUbicacion" style="width: 100%; height: 300px;"></div>
                            <style>
                                /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
                                #map {
                                    width: 100%;
                                    height: 300px;
                                }

                                #floating-panel {
                                    position: absolute;
                                    top: 10px;
                                    left: 25%;
                                    z-index: 5;
                                    background-color: #fff;
                                    padding: 5px;
                                    border: 1px solid #999;
                                    text-align: center;
                                    font-family: 'Roboto','sans-serif';
                                    line-height: 30px;
                                    padding-left: 10px;
                                }
                            </style>
                            <div id="floating-panel">
                                <b>Mode of Travel: </b>
                                <select id="mode">
                                    <option value="DRIVING">Driving</option>
                                    <option value="WALKING">Walking</option>
                                    <option value="BICYCLING">Bicycling</option>
                                    <option value="TRANSIT">Transit</option>
                                </select>
                            </div>
                            <div id="map"></div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Lat.:</label>
                            <asp:TextBox ID="txtLat" runat="server" Text="4.710988599999999" CssClass="form-control"></asp:TextBox>
                            <label for="exampleInputPassword1">Laong.:</label>
                            <asp:TextBox ID="txtLon" runat="server" Text="-74.072092" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-danger" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                    <script>
                        $(document).ready(function () {
                            //Hide the div
                            $('#MapUbicacion').hide();
                            //conversely do the following to show it again if needed later
                            //$('#showdiv').show();
                        });
                        $('#MapUbicacion').locationpicker({
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
                            enableAutocomplete: true
                        });
                    </script>
                    <script>
                        function initMap() {
                            var directionsDisplay = new google.maps.DirectionsRenderer;
                            var directionsService = new google.maps.DirectionsService;
                            var map = new google.maps.Map(document.getElementById('map'), {
                                zoom: 14,
                                center: { lat: 37.77, lng: -122.447 }
                            });
                            directionsDisplay.setMap(map);

                            calculateAndDisplayRoute(directionsService, directionsDisplay);
                            document.getElementById('mode').addEventListener('change', function () {
                                calculateAndDisplayRoute(directionsService, directionsDisplay);
                            });
                        }

                        function calculateAndDisplayRoute(directionsService, directionsDisplay) {
                            var selectedMode = document.getElementById('mode').value;
                            directionsService.route({
                                origin: { lat: 37.77, lng: -122.447 },  // Haight.
                                destination: { lat: 37.768, lng: -122.511 },  // Ocean Beach.
                                // Note that Javascript allows us to access the constant
                                // using square brackets and a string value as its
                                // "property."
                                travelMode: google.maps.TravelMode[selectedMode]
                            }, function (response, status) {
                                if (status == 'OK') {
                                    directionsDisplay.setDirections(response);
                                } else {
                                    window.alert('Directions request failed due to ' + status);
                                }
                            });
                        }
                    </script>
                </div>

                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
</asp:Content>
