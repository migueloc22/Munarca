<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="IndexSuscriptor.aspx.cs" Inherits="Presentacion.IndexSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="panel">
            <div class=" panel-danger ">
                <div class="panel-heading">
                    <h1>Bienvenido querido Usuario...</h1>
                </div>
                <div class="panel-body">
                    <div class="scrolling">
                        <asp:GridView ID="gvServicio" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="fk_id_negocio" EnableTheming="False" OnSelectedIndexChanged="gvServicio_SelectedIndexChanged" GridLines="None">
                            <Columns>
                                <asp:ImageField DataImageUrlField="imagen" ControlStyle-Height="75px" ControlStyle-Width="75px">
                                    <ControlStyle Height="75px" Width="75px"></ControlStyle>
                                </asp:ImageField>
                                <asp:BoundField DataField="nombre_servicio" />
                                <asp:BoundField DataField="valor" />
                                <asp:BoundField DataField="descripcion" />
                                <asp:CommandField SelectText="Ir a negocio" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
