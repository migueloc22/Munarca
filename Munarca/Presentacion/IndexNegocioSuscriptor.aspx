﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="IndexNegocioSuscriptor.aspx.cs" Inherits="Presentacion.IndexNegocioSuscriptor" %>

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
                                <h2>Comentarios</h2>
                                <hr />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnComentar" runat="server">
                                            <div class="well">

                                                <div class="form-group">
                                                    <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" Rows="3" MaxLength="150" TextMode="MultiLine" placeholder="Comentar"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo vacio" ControlToValidate="txtComment" ForeColor="Red" ValidationGroup="pnComentar"></asp:RequiredFieldValidator>
                                                </div>
                                                <asp:LinkButton ID="btnComment" CssClass="btn btn-danger col-xs-offset-10" runat="server" OnClick="btnComment_Click" ValidationGroup="pnComentar"><span class="glyphicon glyphicon-share" ></span> Comentar</asp:LinkButton>
                                            </div>
                                        </asp:Panel>
                                        <br />
                                        <br />
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
                                        <div class="form-group">
                                            <asp:Button ID="btnCalificacion" runat="server" CssClass="btn btn-default" OnClick="btnCalificacion_Click" Text="Calificar" />
                                        </div>
                                        <asp:Literal ID="lbCalificacion" runat="server"></asp:Literal>
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
