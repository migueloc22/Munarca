<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="IndexPropietario.aspx.cs" Inherits="Presentacion.IndexPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
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
    </script>    
        <div class="panel">
            <div class="panel-primary">
                <div class="jumbotron">
                    <h1>¡Bienvenido!...</h1>
                </div>
                <div class="panel-body">
                    <div id="donutchart" style="width: 900px; height: 500px;"></div>
                    <div class="scrolling">
                        <asp:DataList ID="dtlisNegocio" runat="server" CellPadding="3" CellSpacing="3" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" RepeatColumns="2" Width="100%" DataKeyField="id_negocio" ShowFooter="False" ShowHeader="False">

                            <FooterTemplate>
                            </FooterTemplate>

                            <HeaderTemplate>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <table align="center" class="nav-justified" style="height: 60px">
                                    <tr>
                                        <td style="border-style: solid; border-color: #FFFFFF; background-color: #FF5050; color: #FFFFFF; height: 20px;">
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("id_negocio") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" CssClass="h4" Text='<%# Eval("nombre") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; border-style: solid; border-color: #FFFFFF">
                                            <asp:Label ID="lbDescripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; border-style: solid; border-color: #FFFFFF">
                                            <asp:LinkButton ID="btnIrGeocio" runat="server" OnClick="btnIrGeocio_Click">Ir</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>

                                <br />
                            </ItemTemplate>

                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>    
</asp:Content>
