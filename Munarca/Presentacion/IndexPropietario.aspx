<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexPropietario.aspx.cs" Inherits="Presentacion.IndexPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script type="text/javascript">
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=obtenerDatos()%>);

          var options = {
              title: 'Grafico de visitas',
              pieHole: 0.4,
          };

          var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
          chart.draw(data, options);
      }
    </script>   --%>
    <div class="col-xs-10 col-xs-offset-1">
        <div class="row">
            <div class="panel">
                <div class="panel-default">
                    <div class="panel-body">
                        <h1 class="text-muted">Home</h1>
                        <hr />
                        <%-- <div id="donutchart" style="width: 900px; height: 500px;"></div>--%>
                        <div class="scrolling container-fluid">
                            <div class="row">
                                <asp:DataList ID="dtlisNegocio" runat="server" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <div class="col-sm-4">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("id_negocio") %>' Visible="False"></asp:Label>
                                                    <asp:Label ID="Label1" runat="server" CssClass="h4" Text='<%# Eval("nombre") %>'></asp:Label>
                                                </div>

                                                <div class="panel-body">
                                                    <asp:Label ID="lbDescripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                </div>

                                                <div class="panel-footer">
                                                    <asp:LinkButton ID="btnIrGeocio" runat="server" OnClick="btnIrGeocio_Click">Ir</asp:LinkButton>
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
