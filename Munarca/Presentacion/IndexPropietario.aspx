<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexPropietario.aspx.cs" Inherits="Presentacion.IndexPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>¡Bienvenido!...</h4>
        </div>
        <div class="panel-body">

            <asp:DataList ID="dtlisNegocio" runat="server" RepeatDirection="Horizontal" CellPadding="3" CellSpacing="10" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" RepeatColumns="4" Width="100%" DataKeyField="id_negocio">

                <FooterTemplate>
                    
                </FooterTemplate>

                <HeaderTemplate>
                </HeaderTemplate>

                <ItemTemplate>                  
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("id_negocio") %>'  Visible="False"></asp:Label>  
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombre") %>' CssClass="h4"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" Enabled="False" Text='<%# Eval("descripcion") %>' TextMode="MultiLine"></asp:TextBox>

                    <br />
                    <asp:LinkButton ID="btnIrGeocio" runat="server" OnClick="btnIrGeocio_Click">Ir</asp:LinkButton>
                </ItemTemplate>

            </asp:DataList>

        </div>
    </div>
</asp:Content>
