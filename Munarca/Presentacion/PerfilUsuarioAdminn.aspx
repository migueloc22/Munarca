<%@ Page Title="" Language="C#" MasterPageFile="~/UsusarioAdminn.master" AutoEventWireup="true" CodeBehind="PerfilUsuarioAdminn.aspx.cs" Inherits="Presentacion.PerfilUsuarioAdminn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-8 col-xs-offset-2">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="media">
                        <div class="media-left media-middle">
                            <asp:Image ID="Image1" CssClass="media-object img-responsive img-rounded" Style="max-width: 80px; max-height: 80px" runat="server" />
                        </div>
                        <div class="media-body">
                            <div style="height: 10px"></div>
                            <h1 class="media-heading text-center media-middle center-block">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                <small>
                                    <asp:HyperLink CssClass="glyphicon glyphicon-option-vertical" ForeColor="Gray" ID="hLinkModificar" runat="server"></asp:HyperLink>
                                </small></h1>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <h2 class="text-muted">Perfil</h2>
                    <hr />

                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Nombres :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbNombres" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Primer Apellido :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbApellido1" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Segundo Apellido :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbApellido2" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Fecha Necimiento :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbFecNac" runat="server" Text=""></asp:Label>
                            </label>
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Tipo Documento :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbTpDoc" runat="server" Text=""></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">N° Documento :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbNumDoc" runat="server" Text="Label"></asp:Label>

                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Edad :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbEdad" runat="server" Text="Label"></asp:Label>

                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Dirreción :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbDir" runat="server" Text="Label"></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Telefono :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbTel" runat="server" Text="Label"></asp:Label>
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-xs-4 h3 text-muted">Correo :</label>
                        <div class="col-xs-8">
                            <label class="control-label h3 text-muted ">
                                <asp:Label ID="lbCorreo" runat="server" Text="Label"></asp:Label>
                            </label>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>



</asp:Content>
