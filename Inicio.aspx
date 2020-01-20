<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Inicio.aspx.vb" Inherits="AppWeb.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Scrips y estilos-->
    <style type="text/css">
        .auto-style3 {
            width: 784px;
            height: 127px;
        }
        .auto-style4 {
            width: 448px;
        }
        .auto-style5 {
            width: 458px;
        }
        .auto-style6 {
            width: 428px;
            height: 37px;
        }
        .auto-style7 {
            height: 37px;
        }
        .auto-style8 {
            height: 620px;
            width: 835px;
        }
        .auto-style9 {
            width: 428px;
            height: 139px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header style="text-align: right;">
             <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="btn bg-light-blue "/>
             <asp:Button ID="btnReservas" runat="server" Text="Ver reservas" CssClass="btn bg-light-blue "/> 
             <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar sesión" CssClass="btn bg-light-blue "/>
             <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" CssClass="btn bg-light-blue "/>
         </header>
   
        <div runat="server" class="auto-style1">
            <div id="divFiltros" runat="server" class="auto-style3">
                <asp:Label ID="lblFiltros" runat="server" Text="Seleccione los filtros que desee aplicar:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Label ID="Label1" runat="server" Text="Localidad"></asp:Label>
                :
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" style="margin-left: 0px" Width="104px">
                    <asp:ListItem>Araba/Álava</asp:ListItem>
                    <asp:ListItem>Bizkaia</asp:ListItem>
                    <asp:ListItem>Gipuzkoa</asp:ListItem>
                </asp:DropDownList>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Buscador" runat="server" Text="Buscar" />

                <br />
                Tipo de vivienda:
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" style="margin-left: 0px" Width="104px">
                    <asp:ListItem Value="Todos">Todos</asp:ListItem>
                    <asp:ListItem>Camping</asp:ListItem>
                    <asp:ListItem>Aloc</asp:ListItem>
                    <asp:ListItem>Rural</asp:ListItem>
                </asp:DropDownList>

                <br />
                Orden :
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" style="margin-left: 0px" Width="104px">
                    <asp:ListItem Value="Ascendente">Ascendente</asp:ListItem>
                    <asp:ListItem>Descendiente</asp:ListItem>
                </asp:DropDownList>

                <br />

                <asp:Button ID="btnAplicarFiltros" runat="server" Text="Aplicar filtros" CssClass="btn bg-light-blue " Height="27px" Width="134px"/>
                <br />
                <br />
                <br />
                <br />
            </div>
            
            <div id="divAlojamientos" runat="server">
               <div class="auto-style4">
                    <asp:Label ID="lblAlojamientos" runat="server" Text="Seleccione el alojamiento que desee reservar:"></asp:Label>
               </div>
               <asp:ListBox ID="ListBox1" runat="server" Height="425px" Width="890px"></asp:ListBox>
            <div>
                <br />
                <asp:Button ID="btnReservarAlojamiento" runat="server" Text="Reservar alojamiento seleccionado" CssClass="btn bg-light-blue "/>
           
            </div>
            <br />
            <br />
            </div>

            <div id="divFechasReserva" runat="server">
                <div class="auto-style5">
                <asp:Label ID="lblTituloFechas" runat="server" Text="Seleccione la fecha de inicio y fin de su reserva"></asp:Label>
               </div>
                    <table class="auto-style8">
                    <tr>
                        <td class="auto-style6"> <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha de entrada"></asp:Label></td>
                        <td class="auto-style7"><asp:Label ID="lblFechaSalida" runat="server" Text="Fecha de salida"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style9"> <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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
                 <div style="text-align:center" >
                    <asp:Button ID="btnRealizarReserva" runat="server" Text="Reservar" CssClass="btn bg-light-blue "/>
                </div>
                <br />
                <br />
            </div>
            
            <br />
            <br />
        </div>
</asp:Content>
