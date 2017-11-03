<%@ Page Title="" Language="C#" MasterPageFile="~/UsusarioAdminn.master" AutoEventWireup="true" CodeBehind="BuscarUsuarioaspx.aspx.cs" Inherits="Presentacion.BuscarUsuarioaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">

        <div class="panel-body">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <h1 class="col-xs-offset-4">Gestión de Usuarios</h1>
                        <br />
                        <div class="col-lg-8 col-lg-offset-2">
                            <div class="input-group">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ModificarUsuAdmin.aspx" CssClass="btn btn-danger"><span class="glyphicon glyphicon-plus btn-md">Agregar Usuario</span></asp:HyperLink>

                                <asp:TextBox ID="txtBuscador" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                                
                                <div class="input-group-btn">
                                    <asp:LinkButton ID="btnBuscar" CssClass="btn btn-default " runat="server" OnClick="btnBuscar_Click"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>

                                </div>
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col-lg-8 col-lg-offset-2">
                                <asp:GridView ID="GvUsuario" runat="server" CssClass="table  table-striped" AutoGenerateColumns="False" GridLines="None">

                                    <Columns>
                                        <asp:BoundField DataField="nombre_1" HeaderText="Primer nombre"></asp:BoundField>
                                        <asp:BoundField DataField="apellido_1" HeaderText="Primer Apellido"></asp:BoundField>
                                        <asp:BoundField DataField="num_documento" HeaderText="Documento"></asp:BoundField>
                                       
                                        <asp:CommandField ButtonType="Button" DeleteText="Eliminar" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>

        </div>

    </div>



</asp:Content>
