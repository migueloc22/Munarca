<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="IndexNegocioSuscriptor.aspx.cs" Inherits="Presentacion.IndexNegocioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panel-default">
            <div class="panel-body">
                <asp:Literal ID="ltError" runat="server"></asp:Literal>
                <asp:Panel ID="pnContenido" runat="server">
                    <div class="row">
                        <%-- primera fila --%>
                        <div class="col-xs-8">
                            <fieldset>
                                <legend>Fotos</legend>


                                 
                            </fieldset>
                        </div>
                        <div class="col-xs-4">
                            <fieldset>
                                <legend>Infomacion</legend>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque vestibulum non lorem vel commodo. Pellentesque laoreet purus non sodales lacinia. Sed justo turpis, hendrerit eget imperdiet sed, lobortis at neque. Aenean ornare elit et nibh viverra, rhoncus maximus mi blandit. Nam scelerisque sollicitudin tortor non accumsan. Maecenas tristique tristique orci fringilla imperdiet. Mauris in pretium sem. Nulla euismod diam vitae mattis gravida. Nam pharetra lorem ex, ut finibus turpis fermentum a. Vivamus consectetur laoreet fringilla. Aenean nisi leo, semper nec fermentum ut, bibendum nec erat. Praesent nec nulla sed mi tempor ullamcorper. Aenean ac volutpat ligula. Nunc tincidunt luctus maximus.
                                <legend></legend>
                            </fieldset>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>




</asp:Content>
