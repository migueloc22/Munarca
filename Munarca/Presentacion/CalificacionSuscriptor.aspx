<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="CalificacionSuscriptor.aspx.cs" Inherits="Presentacion.CalificacionSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .starRating {
            width: 50px;
            height: 50px;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
        }

        .FilledStars {
            background-image: url("../img/star_rojo.png");
        }

        .WatingStars {
            background-image: url("../img/star_amarrillo.png");
        }

        .EmptyStars {
            background-image: url("../img/star_Plateado.png");
        }
    </style>
    <div class="well">
        <div class="panel">
            <div class="panel-primary">
                <div class="panel-body">
                    <div class="panel-heading" role="tab" id="headingTwo">
                        <h4 class="panel-title">
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                <asp:Label ID="lbNombre" runat="server" Text=""></asp:Label>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="panel-body">
                            <asp:Label ID="lbDescrip" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="btn-group btn-group-justified btn-group-lg">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger " NavigateUrl="~/IndexNegocioSuscriptor.aspx"><span class="glyphicon glyphicon-fire"></span> Servicios</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-check"></span> Calificar</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger" NavigateUrl="~/ComentarioSuscriptor.aspx"><span class="glyphicon glyphicon-comment"></span> Comentario</asp:HyperLink>

                    </div>

                    <div class="form-group">
                        <h1>Calificar</h1>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:Rating ID="Rating1" runat="server"
                                StarCssClass="starRating"
                                FilledStarCssClass="FilledStars"
                                EmptyStarCssClass="EmptyStars"
                                WaitingStarCssClass="WatingStars">
                            </ajaxToolkit:Rating>
                            <asp:Button ID="btnCalificar" runat="server" Text="Button" CssClass="btn btn-warning" OnClick="btnCalificar_Click" />
                            <asp:Label ID="lbCalificacion" runat="server" Text=""></asp:Label>
                            <div class="scrolling"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>

            </div>
        </div>

    </div>
</asp:Content>
