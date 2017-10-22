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
                    <fieldset>
                        <legend>Rango de precios</legend>                        
                        <div class="range range-danger">
                            <asp:TextBox ID="txtMin" value="0" runat="server" TextMode="Range"  MaxLength="10" min="0" max="2000000" step="50000" onchange="rangeMin.value=value"></asp:TextBox>
                            <output id="rangeMin">0</output>
                        </div>
                        <div class="range range-danger">
                            <asp:TextBox ID="txtMax"  value="3000000" runat="server" TextMode="Range"  MaxLength="10" min="0" max="3000000" step="50000" onchange="rangeMax.value=value"></asp:TextBox>
                            <output id="rangeMax">3000000</output>
                        </div>

                    </fieldset>
                    <fieldset>
                        <legend>Filtrar</legend>
                        <asp:Button ID="btnFiltrol" runat="server" Text="filtrol" CssClass="btn btn-danger" OnClick="btnFiltrol_Click"/>
                        <asp:Button ID="btnReset" runat="server" Text="Restablecer" CssClass="btn btn-default" OnClick="btnReset_Click" />
                    </fieldset>
                    <fieldset>
                        <legend>
                            <h3>Buscar por Nombre</h3>
                        </legend>
                        <div class="input-group">
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Buscar"></asp:TextBox>
                            <asp:LinkButton ID="btnBuscar" runat="server" CssClass="input-group-addon bg-danger" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                        </div>
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
