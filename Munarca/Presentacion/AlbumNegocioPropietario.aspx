<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="AlbumNegocioPropietario.aspx.cs" Inherits="Presentacion.AlbumNegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div class="panel">
            <div class="panel-primary">
                <div class="panel-body">
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">                      
                        
                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <div class="item active">
                                <img src="img/logoFinal.png" alt="...">
                                <div class="carousel-caption">
                                    ...
                                </div>
                            </div>
                            <%-- <div class="item">
                        <img src="img/tecnico.jpg" alt="...">
                        <div class="carousel-caption">
                            ...
                        </div>
                    </div>--%>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div class="item ">
                                        <img src='<%# Eval("media") %>' alt="<%# Eval("media") %>" width="300px" height="300px">
                                        <div class="carousel-caption">
                                            ...
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            ...
                        </div>

                        <!-- Controls -->
                        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                    <div class="panel-heading" role="tab" id="headingTwo">
                        <h4 class="panel-title">
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                <asp:Label ID="lbNombre" runat="server" Text="" CssClass="h1"></asp:Label>
                                <span class="glyphicon glyphicon-chevron-down"></span>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4"></div>
                                <div class="col-md-8">
                                    <table aling="left" class="nav-justified">
                                        <tr>
                                            <td>
                                                <label class="h4">Ubicación :</label></td>
                                            <td>
                                                <asp:Label ID="lbUbicacion" runat="server" Text="Label" CssClass="control-label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="h4">Telefono :</label></td>
                                            <td>
                                                <asp:Label ID="lbTelefono" runat="server" Text="Label" CssClass="control-label"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="h4">Descripción :</label></td>
                                            <td>
                                                <asp:Label ID="lbDescrip" runat="server" Text="Label" CssClass="control-label"></asp:Label></td>
                                        </tr>                                       
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="btn-group btn-group-justified btn-group-lg">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger " NavigateUrl="~/IndexServicioPropietario.aspx"><span class="glyphicon glyphicon-fire"></span><br /> Servicios</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/VisitaPropietario.aspx"><span class="glyphicon glyphicon-stats"></span><br /> Visitas</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger" NavigateUrl="~/ComentarioPropietario.aspx"><span class="glyphicon glyphicon-comment"></span><br /> Comentario</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink4" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-picture"></span><br /> <br />Album</asp:HyperLink>
                    </div>
                    <br />
                    <br />
                    <div class="scrolling">
                        <asp:DataList ID="dlPath" runat="server" RepeatColumns="2" ShowFooter="False" ShowHeader="False" CellSpacing="20" >                           
                            <ItemTemplate>
                                        <div class="thumbnail">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("media") %>' CssClass="img-responsive" Width="250px" Height="250px"/>
                                            <div class="caption">
                                                <asp:Button ID="idEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"/>
                                            </div>
                                        </div>                                    
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
