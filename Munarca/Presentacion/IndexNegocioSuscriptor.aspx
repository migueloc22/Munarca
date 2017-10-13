<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioSuscriptor.master" AutoEventWireup="true" CodeBehind="IndexNegocioSuscriptor.aspx.cs" Inherits="Presentacion.IndexNegocioSuscriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" data-spy="scroll" data-target="#myScrollspy" data-offset="20">
        <%--  --%>
        <nav class="col-sm-3" id="myScrollspy">
            <ul class="nav  nav-pills nav-stacked" style="top: 20px; position:static">
                <li><a href="#section1">Section 1</a></li>
                <li><a href="#section2">Section 2</a></li>
                <li><a href="#section3">Section 2</a></li>
                <li><a href="#section4">Section 2</a></li>
            </ul>
        </nav>
        <%--  --%>
        <div class="col-xs-9">
            <div class="panel">
                <div class="panel-default">
                    <div class="panel-body">
                        <asp:Literal ID="ltError" runat="server"></asp:Literal>
                        <asp:Panel ID="pnContenido" runat="server">
                            <section id="section1" style="height: 250px;font-size: 28px;">
                                <h1>Section 1</h1>
                                <p>Try to scroll this page and look at the navigation list while scrolling!</p>
                            </section>
                            <section id="section2" style="height: 250px;font-size: 28px;">
                                <h1>Section 1</h1>
                                <p>Try to scroll this page and look at the navigation list while scrolling!</p>
                            </section>
                            <section id="section3" style="height: 250px;font-size: 28px;">
                                <h1>Section 1</h1>
                                <p>Try to scroll this page and look at the navigation list while scrolling!</p>
                            </section>
                            <section id="section4" style="height: 250px;font-size: 28px;">
                                <h1>Section 1</h1>
                                <p>Try to scroll this page and look at the navigation list while scrolling!</p>
                            </section>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>

    </div>



</asp:Content>
