<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registrarse.aspx.vb" Inherits="AppWeb.Registrarse" %>

<!DOCTYPE html>
<script runat="server">

    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header style="text-align: right;">
         <asp:Button ID="btnInicio" runat="server" Text="Inicio"/> 
        </header>

        <div>

        <br />
        <p> &nbsp;
            <asp:Label ID="Label1" runat="server" Text="DNI:"></asp:Label> &nbsp;
            <asp:TextBox ID="txtBoxUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoxUsuario" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Pasword:"></asp:Label> &nbsp;
            <asp:TextBox ID="txtBoxContrasena" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBoxContrasena" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBoxContrasena" ControlToValidate="txtBoxContrasena2" ErrorMessage="CompareValidator"></asp:CompareValidator>
        </p>
             <p>
            <asp:Label ID="Label5" runat="server" Text="Pasword:"></asp:Label> &nbsp;
            <asp:TextBox ID="txtBoxContrasena2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBoxContrasena" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </p>
            <p>
                &nbsp;</p>
        <p> &nbsp;
            <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label> &nbsp;
            <asp:TextBox ID="txtBoxNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBoxNombre" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </p>
        <p> &nbsp;
            <asp:Label ID="Label4" runat="server" Text="Apellido:"></asp:Label> &nbsp;
            <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxApellido" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </p>
        <p> &nbsp;
            <asp:Label ID="LabelTelefono" runat="server" Text="Telefono:"></asp:Label> &nbsp;
            <asp:TextBox ID="TextBoxTelefono" runat="server" Height="16px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage="RegularExpressionValidator" ValidationExpression="[0-9]{9}"></asp:RegularExpressionValidator>
        </p>
        <p>
            <asp:Label ID="TextBox1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" /> 
        </p>
        <p>&nbsp;</p>
        </div>
       
    </form>
</body>
</html>