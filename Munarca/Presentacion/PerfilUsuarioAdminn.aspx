<%@ Page Title="" Language="C#" MasterPageFile="~/UsusarioAdminn.master" AutoEventWireup="true" CodeBehind="PerfilUsuarioAdminn.aspx.cs" Inherits="Presentacion.PerfilUsuarioAdminn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-8 col-xs-offset-2">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="media">
                        <div class="media-left media-middle">
                            <asp:Image ID="Image1" CssClass="media-object img-responsive img-rounded" Style="max-width: 80px; max-height: 80px" runat="server" />
                        </div>
                        <div class="media-body">
                            <div style="height: 10px"></div>
                            <h1 class="media-heading text-center media-middle center-block">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                <small>
                                    <asp:HyperLink CssClass="glyphicon glyphicon-option-vertical" ForeColor="Gray" ID="hLinkModificar" runat="server"></asp:HyperLink>
                                </small></h1>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <h2 class="text-muted">Perfil</h2>
                    <hr />

                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Nombres :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbNombres" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Primer Apellido :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbApellido1" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Segundo Apellido :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbApellido2" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Fecha Necimiento :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbFecNac" runat="server" Text=""></asp:Label>
                            </label>
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Tipo Documento :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbTpDoc" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">N° Documento :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbNumDoc" runat="server" Text="Label"></asp:Label>

                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Edad :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbEdad" runat="server" Text="Label"></asp:Label>

                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Dirreción :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbDir" runat="server" Text="Label"></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Telefono :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbTel" runat="server" Text="Label"></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Correo :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbCorreo" runat="server" Text="Label"></asp:Label>
                            </label>
                        </div>
                    </div>
                    <asp:Panel ID="pnNegocio" runat="server">
                        
                    <a href="NegocioPropietario.aspx">NegocioPropietario.aspx</a><asp:HyperLink ID="hplinkCreaNegocio" runat="server"  CssClass="btn btn-danger"><span class="glyphicon glyphicon-plus btn-md">Agregar</span></asp:HyperLink>

                        <br />
                        <br />
                        <div class="row">
                            <div class="col-xs-5">
                                <input class="form-control" id="myInput" type="text" placeholder="Buscar..">
                            </div>
                        </div>
                    <div class="scrolling">
                    <br />
                    <br />
                            <asp:GridView ID="gvNegocio" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-condensed " DataKeyNames="id_negocio" OnRowDeleting="gvNegocio_RowDeleting1" OnSelectedIndexChanged="gvNegocio_SelectedIndexChanged" GridLines="None">
                        <Columns>
                                    <asp:BoundField DataField="id_negocio" ReadOnly="True" SortExpression="id_negocio" Visible="false" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre Negocio" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" />
                            <asp:BoundField DataField="telefono" HeaderText="telefono" />
                                    <asp:ButtonField ButtonType="Button" CommandName="Delete" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar">

                                        <ControlStyle CssClass="btn btn-default"></ControlStyle>
                            </asp:ButtonField>
                                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-default" HeaderText="Modificar" SelectText="Modificar">

                                        <ControlStyle CssClass="btn btn-default"></ControlStyle>

                            </asp:CommandField>                         

                        </Columns>
                    </asp:GridView>
                        </div>
                        <script>
                            $(document).ready(function () {
                                $("#myInput").on("keyup", function () {
                                    var value = $(this).val().toLowerCase();
                                    $("#ContentPlaceHolder1_ContentPlaceHolder1_gvNegocio tr").filter(function () {
                                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                                    });
                                });
                            });
                        </script>

                    <asp:Button ID="btnModal" runat="server" Text="Button" Style="display: none;" />
                    <ajaxToolkit:ModalPopupExtender runat="server" BehaviorID="btnModal_ModalPopupExtender" TargetControlID="btnModal" ID="btnModal_ModalPopupExtender" PopupControlID="PanelModal" CancelControlID="exit" BackgroundCssClass="fondo"></ajaxToolkit:ModalPopupExtender>


                    </asp:Panel>
                </div>
            </div>

        </div>
    </div>



</asp:Content>
