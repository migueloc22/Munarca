<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexServicioPropietario.aspx.cs" Inherits="Presentacion.IndexServicioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-body">
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <%--<ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                </ol>--%>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <%-- <div class="item active">
                        <img src="img/logoFinal.png" alt="...">
                        <div class="carousel-caption">
                            ...
                        </div>
                    </div>
                    <div class="item">
                        <img src="img/tecnico.jpg" alt="...">
                        <div class="carousel-caption">
                            ...
                        </div>
                    </div>--%>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="item">
                            <img src="<%#Container.DataItem%>" alt="<%#Container.DataItem%>">
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
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-file"></span> Servicios</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/VisitaPropietario.aspx"><span class="glyphicon glyphicon-paperclip"></span> Visitas</asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger" NavigateUrl="~/ComentarioPropietario.aspx"><span class="glyphicon glyphicon-comment"></span> Comentario</asp:HyperLink>
            </div>
            <br />
            <br />
            <center>
                <asp:HyperLink ID="btnAgregarSv" runat="server" CssClass="btn btn-danger " NavigateUrl="~/CrearServicioPropietario.aspx"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>Agregar Sercicio</asp:HyperLink>
                <br />
                <br />
                <asp:GridView ID="gvServicio" runat="server" AutoGenerateColumns="False" DataKeyNames="id_servicio" OnRowDeleting="gvServicio_RowDeleting" OnSelectedIndexChanged="gvServicio_SelectedIndexChanged" CssClass="table table-hover">
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
            </center>

        </div>
    </div>
</asp:Content>
