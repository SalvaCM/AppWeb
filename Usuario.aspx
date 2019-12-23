<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Usuario.aspx.vb" Inherits="AppWeb.Usuario" %>

<!DOCTYPE html>

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

            <asp:ListBox ID="ListBox1" runat="server" Height="348px" Width="552px"></asp:ListBox>
        
            &nbsp;<br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="Modificar" />
&nbsp;
            <asp:Button ID="Button6" runat="server" Text="Eliminar" />
            &nbsp;
            <asp:Button ID="Button7" runat="server" Text="Atras" />
        </div>
    </form>
</body>
</html>
