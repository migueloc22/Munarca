<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="IndexSuscriptor.aspx.cs" Inherits="Presentacion.IndexSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-3 well">

                    <fieldset>
                        <legend>
                            <h3>Ordenar Precios</h3>
                        </legend>
                        <asp:RadioButtonList ID="rdListOrdenar" CssClass="checkbox" runat="server">
                            <asp:ListItem Selected="True" Value="desc">Maximo</asp:ListItem>
                            <asp:ListItem Value="asc">Minimo</asp:ListItem>
                        </asp:RadioButtonList>
                    </fieldset>
                    <%--<fieldset>
                        <legend>Rango de precios</legend>
                        <div class="form-group">
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtMin" runat="server" CssClass="form-control " TextMode="Number" placeholder="min" MaxLength="10" min="0" max="2000000"></asp:TextBox>
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtMax" runat="server" CssClass="form-control col-xs-2" TextMode="Number" placeholder="max" MaxLength="10" min="0" max="3000000"></asp:TextBox>
                            </div>
                        </div>

                    </fieldset>--%>
                    <fieldset>
                        <legend>
                            <h3>Buscar por Nombre</h3>
                        </legend>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Buscar por nombre"></asp:TextBox>
                        </div>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend>Filtrar</legend>
                        <asp:Button ID="btnFiltrol" runat="server" Text="filtrol" CssClass="btn btn-danger" OnClick="btnFiltrol_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Restablecer" CssClass="btn btn-default" OnClick="btnReset_Click" />
                    </fieldset>                    
                </div>


                <div class="col-xs-8">
                    <div class="panel">
                        <div class=" panel-default ">
                            <div class="panel-body">
                                <div class="scrolling">
                                    <asp:DataList ID="dtServicio" runat="server">
                                        <ItemTemplate>
                                            <div class="media">
                                                <div class="media-left media-middle">
                                                    <asp:Label ID="lbIdServicio" runat="server" Text='<%# Eval("fk_id_negocio") %>' Visible="false"></asp:Label>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("imagen") %>' Width="220" OnClick="ImageButton1_Click" />
                                                </div>
                                                <div class="media-body">
                                                    <h4 class="media-heading">
                                                        <asp:LinkButton ID="btnNomNegocio" runat="server" Text='<%# Eval("nombre_servicio") %>' OnClick="btnNomNegocio_Click"></asp:LinkButton>
                                                        <small><i></i>
                                                            <asp:Label ID="lbFecha" runat="server" Text='<%# Eval("fecha", "{0:D}") %>'></asp:Label></small></h4>
                                                    </h4>
                                            <h4>$<asp:Label ID="lbPrecio" runat="server" Text='<%# Eval("valor") %>'></asp:Label></h4>
                                                    <p>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                    </p>
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
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
