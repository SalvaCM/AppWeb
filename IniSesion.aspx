<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IniSesion.aspx.vb" Inherits="AppWeb.WebForm1" %>

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
         <asp:Button ID="btnReservas" runat="server" Text="Ver reservas"/> 
         <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar sesión"/>
         <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión"/>
        </header>

        <div>

        <br />
        <p> &nbsp;
            <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label> &nbsp;
            <asp:TextBox ID="txtBoxUsuario" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Pasword:"></asp:Label> &nbsp;
            <input id="Password1" type="password" /></p>
        <p>
            <asp:Label ID="lblPruebas" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnConectarse" runat="server" Text="Conectarse" /> 
        </p>
        <p>&nbsp;</p>
        </div>
       
    </form>
</body>
</html>
