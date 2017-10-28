<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexNegocioPropietario.aspx.cs" Inherits="Presentacion.IndexNegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        #map {
            height: 350px;
            width: 100%;
        }

        .starRating {
            width: 50px;
            height: 50px;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
            border-radius: 2px;
        }

        .FilledStars {
            background-image: url("../img/star_amarrillo.png");
        }

        .WatingStars {
            background-image: url("../img/star_rojo.png");
        }

        .EmptyStars {
            background-image: url("../img/star_Plateado.png");
        }
    </style>

    <div class="panel">
        <div class="panel-default">
            <div class="panel-body">
                <asp:Literal ID="ltError" runat="server"></asp:Literal>
                <asp:Panel ID="pnContenido" runat="server">
                    <div class="row">
                        <%-- primera fila --%>
                        <div class="col-xs-8">
                            <fieldset>
                                <div id="rondellCarousel" style="width: 100%; height: 500px;" class="rondell-container rondell-theme-light rondell-instance-1">

                                    <asp:Repeater ID="rpGaleria" runat="server">
                                        <ItemTemplate>
                                            <a href='<%# Eval("media") %>' style="width: 100%; height: 300px;">
                                                <img src='<%# Eval("media") %>' class="img-responsives" style="width: 100%; height: 300px;"></img>
                                            </a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </fieldset>
                            <hr />
                            <fieldset>
                                <h1 class="text-muted">Servicios</h1>
                                <hr />
                                <asp:HyperLink ID="btnAgregarSv" runat="server" CssClass="btn btn-danger "><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>Agregar Sercicio</asp:HyperLink>
                                <br />
                                <br />
                                <div class="scrolling">
                                    <asp:GridView ID="gvServicio" runat="server" AutoGenerateColumns="False" DataKeyNames="id_servicio" OnRowDeleting="gvServicio_RowDeleting" OnSelectedIndexChanged="gvServicio_SelectedIndexChanged" CssClass="table table-hover table-bordered table-responsive" GridLines="none">
                                        <Columns>
                                            <asp:ImageField DataImageUrlField="imagen" ControlStyle-Height="75px" ControlStyle-Width="95px" ControlStyle-CssClass="img-thumbnail img-rounded" HeaderText="Imagen">
                                            </asp:ImageField>
                                            <asp:BoundField DataField="nombre_servicio" HeaderText="Nombre de Servio" />
                                            <asp:BoundField DataField="valor" HeaderText="Valor " />
                                            <asp:BoundField DataField="descripcion" HeaderText="Descripci&#243;n" />
                                            <asp:CommandField SelectText="Modificar" ShowSelectButton="True" />
                                            <asp:CommandField ShowDeleteButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                    <div id="modal">
                                        <asp:Button ID="btnNodal" runat="server" Text="Button" Style="display: none"></asp:Button>
                                        <ajaxToolkit:ModalPopupExtender runat="server" BehaviorID="btnNodal_ModalPopupExtender" TargetControlID="btnNodal" ID="btnNodal_ModalPopupExtender" BackgroundCssClass="fondo" PopupControlID="pnModal" CancelControlID="exit"></ajaxToolkit:ModalPopupExtender>
                                        <asp:Panel ID="pnModal" runat="server" Style="display: none; background-color: white; width: auto; height: auto;">
                                            <div class="modal-body">
                                                <h1>¿Desea eliminar el sevicio?</h1>
                                            </div>
                                            <div class="modal-footer">
                                                <button id="exit" class="btn btn-default">Cerrar</button>
                                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-danger" OnClick="btnAceptar_Click"></asp:Button>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>

                            </fieldset>
                            <fieldset>
                                <h2>Comentarios</h2>
                                <hr />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DataList ID="dtListComentario" runat="server">
                                            <ItemTemplate>
                                                <div class="media well">
                                                    <div class="media-left media-middle">
                                                        <asp:Image ID="Image1" runat="server" Width="60" Height="60" CssClass="img-rounded" ImageUrl='<%# Eval("avatar") %>' />
                                                    </div>
                                                    <div class="media-body ">
                                                        <h4 class="media-heading">
                                                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("nombre") %>'></asp:Literal>
                                                            <small><i></i>
                                                                <asp:Label ID="lbFecha" runat="server" Text='<%# Eval("fecha", "{0:D}") %>'></asp:Label>
                                                                <asp:Label ID="Label1" runat="server" Text=' <%# Eval("hora") %>'></asp:Label>
                                                            </small></h4>
                                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("comentario") %>'></asp:Literal>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </fieldset>
                        </div>
                        <div class="col-xs-4">
                            <div class="media">
                                <div class="media-body">
                                    <h1 class="media-heading">
                                        <asp:Label ID="lbNombreNeg" CssClass="h1 text-danger" runat="server" Text="Label"></asp:Label>
                                    </h1>
                                    <p>
                                        <asp:Literal ID="lbDescripcion" runat="server"></asp:Literal>
                                    </p>

                                </div>
                            </div>
                            <hr>
                            <div class="media">
                                <div class="media-body">
                                    <h2 class="media-heading">Rating
                                    </h2>
                                    <h3>
                                        <asp:Literal ID="lbRating" runat="server"></asp:Literal>/5
                                    </h3>
                                    <div class="form-group">

                                        <ajaxToolkit:Rating ID="Rating1" runat="server"
                                            StarCssClass="starRating"
                                            FilledStarCssClass="FilledStars"
                                            EmptyStarCssClass="EmptyStars"
                                            WaitingStarCssClass="WatingStars">
                                        </ajaxToolkit:Rating>
                                        <p>
                                        </p>
                                        <br />
                                    </div>
                                </div>
                                <hr />
                            </div>
                            <div class="media">
                                <div class="media">
                                    <h2 class="media-heading">Ubicación</h2>
                                    <br />
                                    <div id="map" class="well"></div>
                                    <asp:HiddenField ID="hdLat" runat="server" />
                                    <asp:HiddenField ID="hdLong" runat="server" />
                                    <%--                                    <asp:TextBox ID="txtLat" Text="4.710988599999999"  runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtLong" Text="-74.072092"  runat="server"></asp:TextBox>--%>
                                    <script>
                                        var Lat = parseFloat($('#<%=hdLat.ClientID%>').val());
                                        var long = parseFloat($('#<%=hdLong.ClientID%>').val());

                                        alert(lat);
                                        function initMap() {
                                            var uluru = { lat: Lat, lng: long };
                                            var map = new google.maps.Map(document.getElementById('map'), {
                                                zoom: 16,
                                                center: uluru
                                            });
                                            var marker = new google.maps.Marker({
                                                position: uluru,
                                                map: map
                                            });
                                        }
                                    </script>
                                    <script async defer
                                        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDlXrVL8twvDWaQKozKt01QloVH7CV1eYk&callback=initMap">
                                    </script>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
