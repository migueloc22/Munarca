<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Presentacion.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Button trigger modal -->
    <div class="panel panel-default">
        <div class="panel-heading">Panel Heading</div>
        <div class="panel-body">Panel Content<asp:Button ID="Button2" runat="server" Text="Button" /></div>
    </div>
    
    <!-- Modal -->
    <ajaxToolkit:ModalPopupExtender runat="server" BehaviorID="Button2_ModalPopupExtender" TargetControlID="Button2" ID="Button2_ModalPopupExtender" PopupControlID="Panel1"
        BackgroundCssClass="fondo" CancelControlID="exit">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" Style="display: none; background-color: white; width: auto; height: auto;">

        <div class="modal-header">
            <button id="exit2" type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
        </div>
        <div class="modal-body">
            <asp:Label ID="Label1" runat="server" Text="Hola Mundo"></asp:Label>

        </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal" id="exit">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
        </div>

    </asp:Panel>

</asp:Content>
