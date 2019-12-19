<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reserva.aspx.vb" Inherits="AppWeb.Reserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #Calendar1 {
            color:red;
            background-color:blueviolet;
            border-style: solid;
            
        }

    </style>
</head>
<body>
     <form id="form1" runat="server">
     <header style="text-align: right;">

   <asp:Button ID="Button4" runat="server" Text="Cerrar Sesion"/>

   <asp:Button ID="Button1" runat="server" Text="Inicia Sesion"/>
   <asp:Button ID="Button2" runat="server" Text="Reservas"/> 
  </header>

   
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Descripcion"></asp:Label>
            <br />
            <br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Reservar" />
        </div>
    &nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button5" runat="server" Text="Atras" />
    </form>
</body>
</html>
