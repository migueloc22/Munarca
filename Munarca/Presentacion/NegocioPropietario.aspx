<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="NegocioPropietario.aspx.cs" Inherits="Presentacion.NegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
        <div class="panel">
            <div class="panel-primary">
                <div class="jumbotron">
                    <h1>Negocio</h1>
                </div>
                <div class="panel-body">
                    <center>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CrearNegocioPropietario.aspx" CssClass="btn btn-danger"><span class="glyphicon glyphicon-plus btn-md">Agregar</span></asp:HyperLink>

                    <div class="scrolling">
                    <br />
                    <br />
                    <asp:GridView ID="gvNegocio" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-responsive "   DataKeyNames="id_negocio" OnRowDeleting="gvNegocio_RowDeleting1" OnSelectedIndexChanged="gvNegocio_SelectedIndexChanged" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="id_negocio" ReadOnly="True" SortExpression="id_negocio" Visible="false"/>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre Negocio" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" />
                            <asp:BoundField DataField="telefono" HeaderText="telefono" />
                            <asp:ButtonField ButtonType="Button" CommandName="Delete" ControlStyle-CssClass="btn btn-danger" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar" >

                            <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                            </asp:ButtonField>
                            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-warning" HeaderText="Modificar" SelectText="Modificar" >

                            <ControlStyle CssClass="btn btn-warning"></ControlStyle>

                            </asp:CommandField>                         

                        </Columns>
                    </asp:GridView>
                        </div>
            </center>
                    <asp:Button ID="btnModal" runat="server" Text="Button" Style="display: none;" />
                    <ajaxToolkit:ModalPopupExtender runat="server" BehaviorID="btnModal_ModalPopupExtender" TargetControlID="btnModal" ID="btnModal_ModalPopupExtender" PopupControlID="PanelModal" CancelControlID="exit" BackgroundCssClass="fondo"></ajaxToolkit:ModalPopupExtender>
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
