<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexPropietario.aspx.cs" Inherits="Presentacion.IndexPropietario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading"><h4>¡Bienvenido!...</h4></div>
        <div class="panel-body">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/img/logoFinal.png" Width="5%" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Calificación"></asp:Label>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server">NombreNegocio</asp:LinkButton>
                </ItemTemplate>
            </asp:DataList>
         </div>
    </div>
</asp:Content>
