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
        .auto-style1 {
            height: 42px;
            margin-top: 0px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
     <header style="text-align: right;">
         <asp:Button ID="btnInicio" runat="server" Text="Inicio"/> 
         <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión"/>
     </header>

   
        <div id="divVerReservas" runat="server">
            <br />
            <br />
            <br />
            <asp:Label ID="lblDetallesReservas" runat="server" Text="DETALLES DE SUS RESERVAS" ForeColor="#3333CC"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
            <br />
                 <asp:Label ID="lblSinReservas" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
        </div>
         <div id="divOpcionesReservas" runat="server" class="auto-style1">
              <asp:Button ID="btnNuevaReserva" runat="server" Text="Nueva reserva" />
              <asp:Button ID="btnModificarEliminar" runat="server" Text="Modificar/eliminar reserva" />
             
         </div>
         <div id="divOpcionesModificarEliminar" runat="server" class="auto-style1">
                <asp:Label ID="lblIntroduzca" runat="server" Text="Introduzca el código de la reserva que desea modificar/eliminar: "></asp:Label>
              <asp:TextBox ID="txtBoxCodReservIntroducido" runat="server" type="number" min="0"></asp:TextBox>
              <asp:Button ID="btnBuscar" runat="server" Text="Buscar reserva" />
         </div>
          <div id="divModificarReservas" runat="server">
              <asp:Label ID="Label5" runat="server" Text="MODIFIQUE SU RESERVA" ForeColor="#3333CC"></asp:Label><br />
              
              <br />
              
              <asp:Label ID="lblCodReserva" runat="server" Text="CÓDIGO DE RESERVA: "></asp:Label>
              <asp:TextBox ID="txtBoxCodReserva" runat="server" Enabled="False"></asp:TextBox>
              <br />
              <asp:Label ID="lblFechaEntrada" runat="server" Text="FECHA DE ENTRADA: "></asp:Label>
              <asp:TextBox ID="txtBoxFechaEntrada" runat="server"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtBoxFechaEntrada" ErrorMessage="Introduzca la fecha en un formato válido: dd/mm/aaaa" ForeColor="Red" ValidationExpression="([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}"></asp:RegularExpressionValidator>
              <br />
               <asp:Label ID="lblFechaSalida" runat="server" Text="FECHA DE SALIDA: "></asp:Label>
              <asp:TextBox ID="txtBoxFechaSalida" runat="server"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBoxFechaSalida" ErrorMessage="Introduzca la fecha en un formato válido: dd/mm/aaaa" ForeColor="Red" ValidationExpression="([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}"></asp:RegularExpressionValidator>
              <br />
              <asp:Label ID="lblFechaReserva" runat="server" Text="FECHA DE RESERVA: "></asp:Label>
              <asp:TextBox ID="txtBoxFechaReserva" runat="server"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBoxFechaReserva" ErrorMessage="Introduzca la fecha en un formato válido: dd/mm/aaaa" ForeColor="Red" ValidationExpression="([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}"></asp:RegularExpressionValidator>
              <br />
              <asp:Label ID="lblDni" runat="server" Text="DNI: "></asp:Label>
              <asp:TextBox ID="txtBoxDni" runat="server" Enabled="False"></asp:TextBox><br />
              <asp:Label ID="lblNombre" runat="server" Text="NOMBRE: "></asp:Label>
              <asp:TextBox ID="txtBoxNombre" runat="server" Enabled="False"></asp:TextBox><br />
              <asp:Label ID="lblApellidos" runat="server" Text="APELLIDOS: " ></asp:Label>
              <asp:TextBox ID="txtBoxApellidos" runat="server" Enabled="False"></asp:TextBox><br />
              <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO: "></asp:Label>
              <asp:TextBox ID="txtBoxTelefono" runat="server" MaxLength="9" Enabled="False"></asp:TextBox><br />
               <asp:Label ID="lblCodAlojamiento" runat="server" Text="CÓDIGO ALOJAMIENTO: "></asp:Label>
              <asp:TextBox ID="txtBoxCodAlojamiento" runat="server" Enabled="False"></asp:TextBox><br />
               <asp:Label ID="lblNombreAloj" runat="server" Text="NOMBRE ALOJAMIENTO: "></asp:Label>
              <asp:TextBox ID="txtBoxNombreAlojamiento" runat="server" Enabled="False"></asp:TextBox>
              <br />
              <br />

              <asp:Button ID="btnModificar" runat="server" Text="Modificar" /> &nbsp;
              <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" /> &nbsp;
              <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />

              <br />
         </div>
    &nbsp;&nbsp;&nbsp;
         </form>
</body>
</html>