<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="CalificacionSuscriptor.aspx.cs" Inherits="Presentacion.CalificacionSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .starRating {
            width: 50px;
            height: 50px;
            cursor: pointer;
            background-repeat: no-repeat;
            display: block;
            border-radius:2px;
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
        .auto-style1 {
            width: 18%;
            height: 76px;
            border: 1px solid #000000;
        }
        .auto-style2 {
            width: 20px;
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
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style2"> <asp:Label ID="lbPorcentaje" runat="server" Text="" CssClass="h1"></asp:Label></td>
                                </tr>
                            </table>
                            <ajaxToolkit:Rating ID="Rating1" runat="server"
                                StarCssClass="starRating"
                                FilledStarCssClass="FilledStars"
                                EmptyStarCssClass="EmptyStars"
                                WaitingStarCssClass="WatingStars">
                            </ajaxToolkit:Rating>
                            <asp:Button ID="btnCalificar" runat="server" Text="Calificar" CssClass="btn btn-danger" OnClick="btnCalificar_Click" />                            
                            <br />
                            <asp:Label ID="lbCalificacion" runat="server" Text=""></asp:Label>
                            <div class="scrolling"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>

            </div>
        </div>

    </div>
</asp:Content>
