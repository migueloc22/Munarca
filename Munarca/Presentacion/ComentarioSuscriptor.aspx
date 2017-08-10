

<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="ComentarioSuscriptor.aspx.cs" Inherits="Presentacion.ComentarioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <div class="panel">
            <div class="panel-primary">
                <div class="panel-body">
                    <div class="panel-heading" role="tab" id="headingTwo">
                        <h4 class="panel-title">
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                <asp:Label ID="lbNombre" runat="server" Text=""></asp:Label>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="panel-body">
                            <asp:Label ID="lbDescrip" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="btn-group btn-group-justified btn-group-lg">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl="~/IndexNegocioSuscriptor.aspx"><span class="glyphicon glyphicon-fire"></span> Servicios</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/CalificacionSuscriptor.aspx"><span class="glyphicon glyphicon-check"></span> Calificar</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-comment"></span> Comentario</asp:HyperLink>

                    </div>

                    <div class="form-group">
                        <h1 class="h1">Comentario</h1>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="Comentario">
                                        <asp:DataList ID="dtComentario" runat="server" CellPadding="2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" RepeatColumns="1" ShowFooter="False" ShowHeader="False" CellSpacing="2" Width="80%">
                                            <ItemTemplate>
                                                <table style="width: 100%; border-radius:10px ; background-color:#5149494d; margin: 10px 20% 0px 20%">
                                                    <tr>
                                                        <td style="margin: 2px">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombre_1") %>'></asp:Label>
                                                            &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("apellido_1") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("fecha") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="margin: 2px">
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("comentario") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="margin: 2px">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:DataList ID="dtComentarioMod" runat="server" CellPadding="2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" RepeatColumns="1" Visible="false" ShowFooter="False" ShowHeader="False" CellSpacing="2" Width="80%" >
                                            <ItemTemplate>
                                                <table style="width: 100%; border-radius:10px ; background-color:#5149494d; margin: 10px 20% 0px 20%">
                                                    <tr>
                                                        <td style="margin: 2px">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombre_1") %>'></asp:Label>
                                                            &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("apellido_1") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("fecha") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="margin: 2px">
                                                            <asp:Label ID="lbComentario" runat="server" Text='<%# Eval("comentario") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="margin: 2px"><asp:Label Visible="false" ID="lbIdComentario" runat="server" Text='<%# Eval("id_comentario") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:LinkButton ID="btnModificar" runat="server" OnClick="btnModificar_Click" CausesValidation="false">Modificar</asp:LinkButton></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:DropDownList ID="dlComentario" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dlComentario_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Modificar</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" Rows="7" placeholder="Comentario" requiere="" TextMode="MultiLine" MaxLength="150 "></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo vacio" ControlToValidate="txtComentario" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-offset-9">
                                            <asp:LinkButton ID="btnComentario" runat="server" CssClass="btn btn-danger" OnClick="btnComentario_Click"><span class="glyphicon glyphicon-send"> Enviar</span></asp:LinkButton>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
