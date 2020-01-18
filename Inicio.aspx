<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Inicio.aspx.vb" Inherits="AppWeb.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Scrips y estilos-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header style="text-align: right;">
             <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" />
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
                <asp:ListBox ID="ListBox1" runat="server" Height="425px" Width="890px"></asp:ListBox>
        
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
            </div>
            
            <br />
            <br />
        </div>
</asp:Content>
