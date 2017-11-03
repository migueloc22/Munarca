<%@ Page Title="" Language="C#" MasterPageFile="~/UsusarioAdminn.master" AutoEventWireup="true" CodeBehind="ModificarUsuAdmin.aspx.cs" Inherits="Presentacion.ModificarUsuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-xs-10 col-xs-offset-1">
        <div class="panel">
            <div class="panel-default">
                <div class="panel-body">


                    <div class="row">

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:TextBox ID="txtNom1" runat="server" CssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNom1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtApe1" runat="server" CssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtApe1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Telefono"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtTelefono" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="dlDpto" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="label">Tipo de Usuario</label>
                                <asp:DropDownList ID="dlTipoUsuario" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtCorreo" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" placeholder="Fecha de Nacimiento"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtFechaNac" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="txtFechaNac_CalendarExtender" TargetControlID="txtFechaNac" ID="txtFechaNac_CalendarExtender" Format="yyyy/M/d"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:TextBox ID="txtNom2" runat="server" CssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNom2" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtApe2" runat="server" CssClass="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtApe2" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" placeholder="Numero Documento"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtNumDoc" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group">
                                <asp:DropDownList ID="dlCiudad" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="label">Tipo de Usuario</label>
                                <asp:DropDownList ID="dlTipoDoc" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:TextBox ID="txtDir" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Llene el campo vacio" ControlToValidate="txtDir" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                        </div>

                    </div>
                    <asp:Literal ID="ltMensaje" runat="server"></asp:Literal>
                    <asp:Button ID="btnAgregar" CssClass="btn btn-danger" OnClick="btnAgregar_Click" runat="server" Text="Button" />
                </div>
                


            </div>

        </div>
        </div>
    </div>

</asp:Content>
