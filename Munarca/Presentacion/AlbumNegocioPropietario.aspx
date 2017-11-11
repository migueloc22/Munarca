<%@ Page Title="" Language="C#" validateRequest="false" enableEventValidation="false" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="AlbumNegocioPropietario.aspx.cs" Inherits="Presentacion.AlbumNegocioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" row">
        <div class=" col-xs-8 col-xs-offset-2">
            <div class="panel">
                <div class="panel-default">
                    <div class="panel-body">
                        <span class="glyphicon glyphicon-picture center-block" style="font-size:100px; color:gray;text-align:center"></span>
                        <h1 class="text-center">Galeria</h1>
                        <div class="form-group">
                            <asp:FileUpload ID="FileUpload1" CssClass="form-control"  runat="server" />
                        </div>
                        <div class="btn-group">
                            <asp:Literal ID="ltMsnMultimedia" runat="server"></asp:Literal>
                            <asp:Button ID="btnAgregar" CssClass="btn btn-danger" OnClick="btnAgregar_Click" runat="server" Text="Agregar" /><asp:HyperLink ID="HyperLink1"  CssClass="btn btn-default" runat="server">Volver</asp:HyperLink>
                        </div>
                        <br />
                        <br />
                        <div class="scrolling">
                            <div class="row">
                                <asp:DataList ID="dlPath" runat="server" RepeatColumns="2" ShowFooter="False"  ShowHeader="False" RepeatLayout="Flow">
                                    <ItemTemplate>
                                        <div class="col-xs-4" >
                                            <div class="thumbnail" style="box-shadow: 3px 3px 5px #888888;">
                                                <asp:Label ID="lbIdPath" runat="server" Text='<%# Eval("id_path") %>' Visible="false"></asp:Label>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("media") %>' CssClass="img-responsive" style="width:100%" />
                                                <div class="caption">
                                                    <asp:Button ID="btnEliminar" Enabled="true"  runat="server" Text="Eliminar" CssClass="btn btn-danger btn-block"  OnClick="btnEliminar_Click1" />
                                                   <%-- <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Button" />--%>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
