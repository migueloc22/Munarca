<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexServicioPropietario.aspx.cs" Inherits="Presentacion.IndexServicioPropietario" %>

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
                </div>
                <div class="btn-group btn-group-justified btn-group-lg">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-fire"></span> Servicios</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/VisitaPropietario.aspx"><span class="glyphicon glyphicon-stats"></span> Visitas</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger" NavigateUrl="~/ComentarioPropietario.aspx"><span class="glyphicon glyphicon-comment"></span> Comentario</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="btn btn-danger" NavigateUrl="~/AlbumNegocioPropietario.aspx"><span class="glyphicon glyphicon-picture"></span> Album</asp:HyperLink>
                </div>
                <br />
                <br />
                <center>
                
                <asp:HyperLink ID="btnAgregarSv" runat="server" CssClass="btn btn-danger " NavigateUrl="~/CrearServicioPropietario.aspx"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>Agregar Sercicio</asp:HyperLink>
                <br />
                <br />
                <div class="scrolling">
                <asp:GridView ID="gvServicio" runat="server" AutoGenerateColumns="False" DataKeyNames="id_servicio" OnRowDeleting="gvServicio_RowDeleting" OnSelectedIndexChanged="gvServicio_SelectedIndexChanged" CssClass="table table-hover" GridLines="none">
                    <Columns>
                        <asp:ImageField DataImageUrlField="imagen" ControlStyle-Height="75px" ControlStyle-Width="95px" ControlStyle-CssClass="img-thumbnail">
                        </asp:ImageField>
                        <asp:BoundField DataField="nombre_servicio" />
                        <asp:BoundField DataField="valor" />
                        <asp:BoundField DataField="descripcion" />
                        <asp:CommandField SelectText="Modificar" ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
                <div id="modal">
                    <asp:Button ID="btnNodal" runat="server" Text="Button" Style="display:none"></asp:Button>
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
            </center>
            </div>
        </div>
</asp:Content>
