<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Registrarse.aspx.vb" Inherits="AppWeb.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Scrips y estilos-->
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header style="text-align: right;">
            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion" CausesValidation="False" ValidateRequestMode="Disabled" ViewStateMode="Disabled" />
         <asp:Button ID="btnInicio" runat="server" Text="Inicio" CausesValidation="False" ValidateRequestMode="Disabled"/> 
        </header>
        
        <section class="content-header">
            <h1 style="text-align:center" > 
                 <asp:Label ID="lblTituloRegistro" runat="server" Text="  REGISTRO DE USUARIOS" ForeColor="#3333CC"></asp:Label>
            </h1>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-body">
                            <div class="form-group">
                                <p> &nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="DNI:"></asp:Label> &nbsp;
                                    <asp:TextBox ID="txtBoxUsuario" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxUsuario" ErrorMessage="Dato Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBoxUsuario" ErrorMessage=" No tiene un formato correcto " ValidationExpression="[0-9]{8}[A-Z]{1}" ForeColor="Red"></asp:RegularExpressionValidator>
                                </p>
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label> &nbsp;
                                    <asp:TextBox ID="txtBoxContrasena" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBoxContrasena" ErrorMessage="Dato Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBoxContrasena" ControlToValidate="txtBoxContrasena2" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                                </p>
                                     <p>
                                    <asp:Label ID="Label5" runat="server" Text="Repetir Contraseña: "></asp:Label> &nbsp;
                                    <asp:TextBox ID="txtBoxContrasena2" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBoxContrasena" ErrorMessage="Dato Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </p>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-body">
                            <div class="form-group">
                                 <p> &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label> &nbsp;
                                    <asp:TextBox ID="txtBoxNombre" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBoxNombre" ErrorMessage="Dato Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </p>
                                <p> &nbsp;
                                    <asp:Label ID="Label4" runat="server" Text="Apellido:"></asp:Label> &nbsp;
                                    <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxApellido" ErrorMessage="Dato Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                </p>
                                <p> &nbsp;
                                    <asp:Label ID="LabelTelefono" runat="server" Text="Telefono:"></asp:Label> &nbsp;
                                    <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage="Dato Obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage=" No tiene un formato correcto (*********)" ValidationExpression="[0-9]{9}" ForeColor="Red"></asp:RegularExpressionValidator>
                                </p>
                                    <p> 
                                    <asp:Label ID="LabelTelefono0" runat="server" Text="Correo: "></asp:Label> &nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Dato Obligatoria" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="No has introducido bien el formato (ejemplo@gmail.com)" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </p>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </section>

        <div>

        <br />
        
            
        <div style="text-align:center" >
             <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="btn bg-light-blue " Width="178px" /> 
        </div>
           
        </div>
</asp:Content>