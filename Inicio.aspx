<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="AppWeb.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>hola</title>
    <style>
        .button span:hover {
   background-color: blue;
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
}

        .auto-style1 {
            height: 661px;
            width: 776px;
        }

        .auto-style2 {
            width: 244px;
        }
        .auto-style3 {
            width: 245px;
        }
        .auto-style4 {
            width: 773px;
            height: 81px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
         <header style="text-align: right;">
             <asp:Button ID="btnInicio" runat="server" Text="Inicio"/> 
             <asp:Button ID="btnReservas" runat="server" Text="Ver reservas"/> 
             <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar sesión"/>
             <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión"/>
         </header>
   
        <div runat="server" class="auto-style1">
            <div id="divFiltros" runat="server" class="auto-style4">
                <asp:Label ID="lblFiltros" runat="server" Text="Seleccione los filtros que desee aplicar:"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Localidad"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" style="margin-left: 0px" Width="104px">
                    <asp:ListItem>Araba/Álava</asp:ListItem>
                    <asp:ListItem>Bizkaia</asp:ListItem>
                    <asp:ListItem>Gipuzkoa</asp:ListItem>
                </asp:DropDownList>

                <asp:Button ID="btnAplicarFiltros" runat="server" Text="Aplicar filtros"/>
            </div>
            
            <div id="divAlojamientos" runat="server">
                 <asp:Label ID="lblAlojamientos" runat="server" Text="Seleccione el alojamiento que desee reservar:"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server" Height="425px" Width="890px" AutoPostBack="True"></asp:ListBox>
        
                <asp:Button ID="btnReservarAlojamiento" runat="server" Text="Reservar alojamiento seleccionado"/>
            <br />
            <br />
            </div>

            <div id="divFechasReserva" runat="server">
                <asp:Label ID="lblTituloFechas" runat="server" Text="Seleccione la fecha de inicio y fin de su reserva"></asp:Label>
                <table>
                    <tr>
                        <td class="auto-style3"> <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha de entrada"></asp:Label></td>
                        <td class="auto-style2"><asp:Label ID="lblFechaSalida" runat="server" Text="Fecha de salida"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style3"> <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                            </asp:Calendar></td>
                        <td class="auto-style2"><asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                            </asp:Calendar></td>
                    </tr>
                </table>
               
                
                <br />
                <asp:Button ID="btnRealizarReserva" runat="server" Text="Reservar"/>
                <br />
                <br />
                <asp:Label ID="lblPruebas1" runat="server" Text="Label"></asp:Label>
                 <asp:Label ID="lblPruebas2" runat="server" Text="Label"></asp:Label>
                 <asp:Label ID="lblPruebas3" runat="server" Text="Label"></asp:Label>
            </div>
            
            <asp:Table ID="Table1" runat="server" Height="145px" Width="339px">
            </asp:Table>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
