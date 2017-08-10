<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="ModificarServicioPropietario.aspx.cs" Inherits="Presentacion.ModificarServicioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <div class="panel">
            <div class="panel-primary">
                <div class="panel-heading">Agregar Servicio</div>
                <div class="panel-body">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/IndexServicioPropietario.aspx" CssClass=" btn-default"><span class="glyphicon glyphicon-arrow-left">Regresar</span></asp:HyperLink>
                    <div class="form-group">
                        Nombre de Servicio:
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="15" CssClass="form-control" placeholder="Nombre de Servicio" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNombre" ForeColor="Red">*</asp:RequiredFieldValidator> 
                         </div>
                    <div class="form-group">
                        Desecripción de Servicio:
                <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="250" CssClass="form-control" placeholder="Desecripción de Servicio" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDescripcion" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        Valor de Servicio:
                <asp:TextBox ID="txtValor" runat="server"  MaxLength="10" CssClass="form-control" placeholder="Valor de Servicio" required=""></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Numeros" ControlToValidate="txtValor" ForeColor="Red" ValidationExpression="([0-9]|-)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtValor" ForeColor="Red">*</asp:RequiredFieldValidator>                    
                    </div>
                    <div class="form-group">
                        Cargar Imagen:
                <asp:FileUpload ID="FileUpload1" runat="server" accept="gif|jpg|png" class="multi" maxlength="1" />
                        <asp:Label ID="lbImagen" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnAgregar" runat="server" Text="btnAgregar" CssClass="btn btn-danger" OnClick="btnAgregar_Click" /><input type="reset" class="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none;" />
    <ajaxToolkit:ModalPopupExtender ID="Button2_ModalPopupExtender" runat="server" BehaviorID="Button2_ModalPopupExtender" TargetControlID="Button2" PopupControlID="pnModal" BackgroundCssClass="fondo">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnModal" runat="server" Style="display: none; background-color: white; width: auto; height: auto;">

        <div class="modal-body">
            <h1>Servicio Fuel Modificado</h1>
        </div>
        <div class="modal-footer">
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-danger" NavigateUrl="~/IndexServicioPropietario.aspx">Regresar a Negocio</asp:HyperLink>
        </div>

    </asp:Panel>
</asp:Content>
