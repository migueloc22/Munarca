<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="NegocioPropietario.aspx.cs" Inherits="Presentacion.NegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            <div class="panel">
                <div class="panel-default">
                    <div class="panel-body">
                        <h1>Negocio</h1>
                        <hr />

                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CrearNegocioPropietario.aspx" CssClass="btn btn-danger"><span class="glyphicon glyphicon-plus btn-md">Agregar</span></asp:HyperLink>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Inicio Modal --%>
    <asp:Panel ID="PanelModal" runat="server" Style="display: none; background-color: white; width: auto; height: auto;">

        <div class="modal-body">
            <h3>¿Desea Eliminar el registro de Negocio?</h3>

        </div>
        <div class="modal-footer">

            <button id="exit" class=" btn btn-default">Cancelar</button>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger " CausesValidation="False" OnClick="btnEliminar_Click" />


        </div>

    </asp:Panel>
    <%-- Panel Modal --%>
</asp:Content>
