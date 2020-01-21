<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IniSesion.aspx.vb" Inherits="AppWeb.WebForm1" %>

<!DOCTYPE html>
<script runat="server">

    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub
</script>


<html class="bg-info" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Alojamientos Euskadi</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="//cdnjs.cloudflare.com/ajax/libs/ont-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
   <link href="css/AdminLTE.css" rel="stylesheet" type="text/css"/>
</head>
<body class="bg-info" >
     <form id="form1" runat="server">
          <div class="form-box" id="login-box">
                <header style="text-align: right;">
                    <asp:Button ID="btnInicio" runat="server" Text="Inicio" CssClass="btn bg-light-blue "/> 
                </header>
               <div class="header" style="background-color:dodgerblue"> Iniciar sesión </div>
                        <div class="body bg-gray">
                             <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="DNI:"></asp:Label> &nbsp;
                                 <asp:TextBox ID="txtBoxUsuario" runat="server" CssClass="form-control" placeholder="Introduzca usuario..."></asp:TextBox>
                             </div>
                             <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label> &nbsp;
                                <asp:TextBox ID="txtBoxContrasena" runat="server" TextMode="Password" CssClass="form-control" placeholder="Introduzca contraseña..."></asp:TextBox>
                             </div>
                            <div class="footer">
                                <asp:Button ID="btnConectarse" runat="server" Text="Conectarse" CssClass="btn bg-primary btn-block"/> 
                                <asp:Button ID="Button1" runat="server" Text="Registrarse" CssClass="btn bg-primary btn-block"/>
                             </div>
                 </div>
           </div>
        </form>

</body>
</html>
