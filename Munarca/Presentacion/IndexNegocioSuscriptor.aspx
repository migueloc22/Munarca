<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="IndexNegocioSuscriptor.aspx.cs" Inherits="Presentacion.IndexNegocioSuscriptor" %>

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
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-fire"></span> Servicios</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger" NavigateUrl="~/CalificacionSuscriptor.aspx"><span class="glyphicon glyphicon-check"></span> Calificar</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger" NavigateUrl="~/ComentarioSuscriptor.aspx"><span class="glyphicon glyphicon-comment"></span> Comentario</asp:HyperLink>
                    </div>
                    <br />
                    <br />
                    <center>
                <br />
                <br />
               <div class="scrolling">
                <asp:GridView ID="gvServicio" runat="server" AutoGenerateColumns="False" DataKeyNames="id_servicio" CssClass="table table-hover" GridLines="None">
                    <Columns>
                        <asp:ImageField DataImageUrlField="imagen" ControlStyle-Height="75px" ControlStyle-Width="75px">
                        <ControlStyle Height="75px" Width="75px"></ControlStyle>
                        </asp:ImageField>
                        <asp:BoundField DataField="nombre_servicio" />
                        <asp:BoundField DataField="valor" />
                        <asp:BoundField DataField="descripcion" />
                    </Columns>
                </asp:GridView>   
              </div>             
            </center>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
