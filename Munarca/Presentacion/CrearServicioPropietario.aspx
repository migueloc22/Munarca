<%@ Page Title="" Language="C#" MasterPageFile="~/UsuarioPropietario.master" AutoEventWireup="true" CodeBehind="CrearServicioPropietario.aspx.cs" Inherits="Presentacion.CrearServicioPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
            <div class="panel">
                <div class="panel-primary">
                    <div class="panel-body">
                        <h1 class="text-muted">Nuevo Servicio</h1>
                        <div class="row">
                            <div class="col-xs-6">
                                <div class=" well">
                                    <label >Imagen de Servicio</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" accept="gif|jpg|png"  maxlength="1" />
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Cargue una imagen" ControlToValidate="FileUpload1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <script>
                                        $("#ContentPlaceHolder1_ContentPlaceHolder1_FileUpload1").fileinput({
                                            language: "es",
                                            uploadUrl: "/file-upload-batch/2",
                                            allowedFileExtensions: ["jpg", "png", "gif"]

                                        });
                                    </script>
                                </div>

                            </div>
                            <div class="col-xs-6">
                                <div class="form-group">
                                    <label >Nombre de Servicio:</label>
                                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="35" CssClass="form-control" placeholder="Nombre de Servicio"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNombre" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label >Desecripción de Servicio:</label>                                    
                                    <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="250" TextMode="MultiLine" CssClass="form-control" placeholder="Desecripción de Servicio"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDescripcion" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label >Valor de Servicio:</label>                                    
                                     <asp:TextBox ID="txtValor" runat="server" MaxLength="10" CssClass="form-control" placeholder="Valor de Servicio"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Numeros" ControlToValidate="txtValor" ForeColor="Red" ValidationExpression="([0-9]|-)*">*</asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtValor" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label >Valor de Servicio:</label>   
                                    <asp:DropDownList ID="dpListServicios" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        </div>
                        

                        <div class="form-group btn-group btn-group-lg">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Servicio" CssClass="btn btn-danger" OnClick="btnAgregar_Click" /><input type="reset" class="btn btn-default" />
                            <asp:HyperLink ID="bntRegresar2" runat="server" CssClass="btn btn-default" NavigateUrl="~/IndexNegocioPropietario.aspx">Regresar a Negocio</asp:HyperLink>
                        </div>
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
            <h1>Servicio  Agregado</h1>
        </div>
        <div class="modal-footer">
            <asp:HyperLink ID="bntRegresar" runat="server" CssClass="btn btn-danger" NavigateUrl="~/IndexNegocioPropietario.aspx">Regresar a Negocio</asp:HyperLink>
        </div>

    </asp:Panel>
</asp:Content>
