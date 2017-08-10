<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="VisitaPropietario.aspx.cs" Inherits="Presentacion.VisitaPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable([
              ['Year', 'Sales', 'Expenses'],
              ['2013', 1000, 400],
              ['2014', 1170, 460],
              ['2015', 660, 1120],
              ['2016', 1030, 540]
            ]);

            var options = {
                title: 'Company Performance',
                hAxis: { title: 'Year', titleTextStyle: { color: '#333' } },
                vAxis: { minValue: 0 }
            };

            var chart = new google.visualization.AreaChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }
    </script>
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
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger " NavigateUrl="~/IndexServicioPropietario.aspx"> <span class="glyphicon glyphicon-fire"></span> Servicios</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-danger active"><span class="glyphicon glyphicon-stats"></span> Visitas</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-danger" NavigateUrl="~/ComentarioPropietario.aspx"><span class="glyphicon glyphicon-comment"></span> Comentario</asp:HyperLink>
                    </div>
                    <br />
                    <br />
                    <div id="chart_div" style="width: 900px; height: 500px;"></div>
                    <div class="scrolling"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
