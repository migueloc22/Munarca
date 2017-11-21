<%@ Page Title="" Language="C#" MasterPageFile="~/UsusarioAdminn.master" AutoEventWireup="true" CodeBehind="ReportesAdminn.aspx.cs" Inherits="Presentacion.ReportesAdminn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-8 col-xs-offset-2">
            <div class="panel panel-default">
                <div class="panel-body">
                    <h1>Reportes</h1>
                    <hr />
                    <asp:Literal ID="ltMsn" runat="server"></asp:Literal>
                    <div class="form-inline">
                        <div class="form-group">
                            <label class="control-label">Inicio</label>
                            <asp:TextBox ID="txtInicio" CssClass="form-control dateInicio"  runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label">a</label>
                            <asp:TextBox ID="txtFinal" CssClass="form-control dateFinal" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnFilter" CssClass="btn btn-default" OnClick="btnFilter_Click" runat="server" Text="Filtrar" />
                    </div>
        <script>
            $.datepicker.regional['es'] = {
                closeText: 'Cerrar',
                prevText: '<Ant',
                nextText: 'Sig>',
                currentText: 'Hoy',
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                weekHeader: 'Sm',
                dateFormat: 'dd/mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);
            $(function () {
                var dateFormat = "yy/mm/dd",
                  from = $(".dateInicio")
                    .datepicker({
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 2
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    }),
                  to = $(".dateFinal").datepicker({
                      defaultDate: "+1w",
                      changeMonth: true,
                      numberOfMonths: 2
                  })
                  .on("change", function () {
                      from.datepicker("option", "maxDate", getDate(this));
                  });

                function getDate(element) {
                    var date;
                    try {
                        date = $.datepicker.parseDate(dateFormat, element.value);
                    } catch (error) {
                        date = null;
                    }

                    return date;
                }
            });


    </script>
                    
                    <br />
                    <div class="btn-group btn-group-lg">
                        <asp:Button ID="btnCalificacion" CssClass="btn btn-danger" OnClick="btnCalificacion_Click" runat="server" Text="Calificacion" />
                        <asp:Button ID="btnVisita" CssClass="btn btn-default" OnClick="btnVisita_Click" runat="server" Text="Visita" />

                    </div>


                    <br />
                    <br />
                    <div class="scrolling" id="Reporte">
                        <asp:GridView ID="gvCalificaion" runat="server" GridLines="None" CssClass="table table-bordered table-responsive table-hover"></asp:GridView>
                        <asp:GridView ID="gvVisita" runat="server" Visible="false" GridLines="None" CssClass="table table-bordered table-responsive table-hover"></asp:GridView>
                    </div>
                    <div class="btn-group btn-group-lg">
                        <button type="button" class="btn btn-danger btn-lg" onclick="DescargarPDF('Reporte','ReporteCliente')" value="Decargar Reporte">
                            <span class="glyphicon glyphicon-save-file"></span>PDF
                        </button>
                        <%--<asp:LinkButton ID="btnExcel" CssClass="btn btn-success btn-sm" runat="server" OnClick="btnExcel_Click"><span class="glyphicon glyphicon-save-file" ></span>Excel</asp:LinkButton>--%>
                        <button type="button" class="btn btn-success btn-lg" onclick="tableToExcel('Reporte', 'W3C Example Table')" value="Decargar Reporte">
                            <span class="glyphicon glyphicon-save-file"></span>EXCEL
                        </button>
                    </div>
                    <script>
                        function DescargarPDF(ContenidoID, nombre) {
                            var pdf = new jsPDF('p', 'pt', 'letter');
                            html = $('#' + ContenidoID).html();
                            specialElementHandlers = {};
                            margins = { top: 10, bottom: 20, left: 20, width: 522 };
                            pdf.fromHTML(html, margins.left, margins.top, { 'width': margins.width }, function (dispose) { pdf.save(nombre + '.pdf'); }, margins);
                        };
                    </script>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
