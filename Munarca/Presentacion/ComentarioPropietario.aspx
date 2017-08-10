<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="ComentarioPropietario.aspx.cs" Inherits="Presentacion.ComentarioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger " NavigateUrl="~/IndexServicioPropietario.aspx"><span class="glyphicon glyphicon-fire"></span> Servicios</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/VisitaPropietario.aspx"><span class="glyphicon glyphicon-stats"></span> Visitas</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-comment"></span> Comentario</asp:HyperLink>
                    </div>
                    <br />
                    <br />
                    <center><asp:LinkButton ID="btnAgregarSv" runat="server" CssClass="btn btn-danger "><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>Agregar Sercicio</asp:LinkButton></center>
                    <div class="scrolling"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
