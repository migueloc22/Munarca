<%@ Page Title="" Language="C#" MasterPageFile="~/UsusarioAdminn.master" AutoEventWireup="true" CodeBehind="NegociosAdmin.aspx.cs" Inherits="Presentacion.NegociosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default">
        <div class="panel-body">
            <h1 class="col-xs-offset-4">Gestión de Categorias Negocios</h1>

            <div class="row">
                <div class="col-lg-8 col-lg-offset-2">
                    <asp:TextBox ID="txtNomCategoria" runat="server" CssClass="form-control" placeholder="Categoria"></asp:TextBox>
                    <div class="input-group-btn">
                        <asp:LinkButton ID="btnAgregar" CssClass="btn btn-default " OnClick="btnAgregar_Click" runat="server" Text="Agregar"></asp:LinkButton>
                        <asp:Button ID="btnModificar" CssClass="btn btn-default " OnClick="btnModificar_Click" Visible="false" runat="server" Text="Modificar" />
                        <asp:HiddenField ID="hdCodCategoria" runat="server" />
                        <asp:Literal ID="ltRespuesta" runat="server"></asp:Literal>
                    </div>




                </div>

                <div class="row">
                    <div class="col-lg-8 col-lg-offset-2">
                        <asp:GridView ID="gvCategorias" runat="server" CssClass="table  table-striped" AutoGenerateColumns="False" GridLines="None" DataKeyNames="id_categoria" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged" OnRowDeleting="gvCategorias_RowDeleting1">

                            <Columns>
                                <asp:BoundField DataField="id_categoria" HeaderText="#"></asp:BoundField>
                                <asp:BoundField DataField="categoria" HeaderText="Categoria"></asp:BoundField>

                                <asp:CommandField SelectText="Modificar" ShowSelectButton="True" ControlStyle-CssClass="btn btn-warning" ButtonType="Button">
                                    <ControlStyle CssClass="btn btn-warning"></ControlStyle>
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" DeleteText="Eliminar" ShowDeleteButton="True">

                                    <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                </asp:CommandField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

            </div>

            <asp:Label ID="lbMensaje" CssClass="bg-success" runat="server" Text=""></asp:Label>
        </div>
    </div>


</asp:Content>
