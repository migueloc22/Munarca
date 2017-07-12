<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="NegocioPropietario.aspx.cs" Inherits="Presentacion.NegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>Negocio</h4>
        </div>
        <div class="panel-body">
            <center>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CrearNegocioPropietario.aspx" CssClass="btn btn-danger"><span class="glyphicon glyphicon-plus btn-md">Agregar</span></asp:HyperLink>
            </center>
        </div>
    </div>
</asp:Content>
