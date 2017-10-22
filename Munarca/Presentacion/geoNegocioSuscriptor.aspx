<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="geoNegocioSuscriptor.aspx.cs" Inherits="Presentacion.geoNegocioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <%-- Primera col --%>
        <div class="col-xs-4 well">
            <div class="form-group">
                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control input-lg" placeholder="Buscar"></asp:TextBox>


            </div>
            <div class="form-group">
                <div id="mapaFilter" style="width: 100%; height: 300px"></div>
            </div>
            <div class="form-group">
                <asp:HiddenField ID="hdLatFt" Value="4.710988599999999" runat="server" />
                <asp:HiddenField ID="hdLonft" Value="-74.072092" runat="server" />
                <%-- Inicio de scrips --%>
                <script>
                    $('#mapaFilter').locationpicker({
                        radius: 0,
                        zoom: 16,
                        location: {
                            latitude: $('#<%=hdLatFt.ClientID%>').val(),
                            longitude: $('#<%=hdLonft.ClientID%>').val()
                        },
                        inputBinding: {
                            latitudeInput: $('#<%=hdLatFt.ClientID%>'),
                            longitudeInput: $('#<%=hdLonft.ClientID%>'),
                            locationNameInput: $('#<%=txtUbicacion.ClientID%>')
                        },
                        enableAutocomplete: true,
                        enableReverseGeocode: true,
                        markerDraggable: true
                    });

                </script>

                <%-- Fin de scrips --%>
                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click1" CssClass="btn btn-danger btn-block" Text="Buscar" />
            </div>
        </div>

        <%-- Segunda col --%>
        <div class="col-xs-8">
            <div class="panel">
                <div class="panel-default">
                    <div class="panel-heading"><h4>Lista de Negocios</h4></div>
                    <div class="panel-body ">
                        <%--<asp:DataList runat="server">
                            <ItemTemplate>
                                <% If CBool(Eval("Deleted")) Then%> 
                                    ...
                                <% Else%>
                                    ...
                                <% End If%>
                            </ItemTemplate>
                        </asp:DataList>
                            <ItemTemplate>
                <asp:Label Text='<%# Eval("Status").ToString() == "A" ? "Absent" : "Present" %>'
                    runat="server" />
            </ItemTemplate>
                            --%>
                        <asp:DataList ID="dtNegosios" runat="server">
                            <ItemTemplate>
                                <div class="media">
                                    <div class="media-body">
                                        <h2 class="media-heading ">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                        </h2>
                                        <h3 class="text-muted">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("distancia","{0:0.00}") %>'></asp:Label>/KM</h3>
                                        <p>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
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

</asp:Content>
