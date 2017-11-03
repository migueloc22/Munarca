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
                            <div class="row well">
                                <asp:DataList ID="dtlisNegocio" runat="server" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <div class="col-sm-4">
                                            <div class="thumbnail">
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("foto") %>' Width="100%" Height="300" CssClass="img-thumbnail img-responsive" OnClick="ImageButton1_Click" />

                                                <div class="caption">
                                                    <p>
                                                        <strong>
                                                            <asp:Label ID="Label2" runat="server" CssClass="text-center" Text='<%# Eval("id_negocio") %>' Visible="False"></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" CssClass="h2 text-center" Text='<%# Eval("nombre") %>'></asp:Label>
                                                        </strong>
                                                    </p>
                                                    <p>
                                                        <asp:Label ID="lbDescripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                    </p>

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
