<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexServicioPropietario.aspx.cs" Inherits="Presentacion.IndexServicioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panel-default">
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-12">
                        <section class="caja1">
                            <img src="img/tecnico.jpg" class="img-responsive">
                        </section>
                    </div>
                    <div class="col-xs-12">
                        <section class="caja2">
                            <div class="row">

                                <div class="col-xs-6">
                                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d254508.5164108755!2d-74.24789547304529!3d4.648283717013187!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8e3f9bfd2da6cb29%3A0x239d635520a33914!2zQm9nb3TDoQ!5e0!3m2!1ses!2sco!4v1506105571690" frameborder="0" style="border: 0; height: auto; width: 100%;" allowfullscreen id="mapaNeg"></iframe>
                                </div>
                                <div class="col-xs-6">
                                    <ul>
                                        <li><span class="glyphicon glyphicon-alert" style="width:30px;"></span></li>
                                        <li></li>
                                        <li></li>
                                        <li></li>
                                    </ul>
                                </div>

                            </div>
                        </section>
                    </div>
                    <div class="col-xs-12">
                        <section class="caja3"></section>
                    </div>
                </div>

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
    </div>
</asp:Content>
