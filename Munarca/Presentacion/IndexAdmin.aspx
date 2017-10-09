<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioAdmin.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="Presentacion.IndexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel-primary">
        <div class="panel-heading">
            <%-- Colocamos un griview  --%>
            <asp:GridView ID="gvUsuarios" runat="server"></asp:GridView>
        </div>
        <div class="panel-body"></div>
    </div>
    
</asp:Content>
