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
        .auto-style7 {
            height: 23px;
            width: 220px;
        }
        .auto-style8 {
            height: 602px;
            width: 481px;
        }
        .auto-style10 {
            width: 360px;
            height: 70px;
        }
        .auto-style11 {
            width: 551px;
            height: 23px;
        }
        .auto-style12 {
            width: 551px;
        }
        .auto-style13 {
            height: 748px;
            width: 220px;
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
                <asp:Label ID="Label1" runat="server" Text="Localidad:"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="False" style="margin-left: 0px" Width="104px">
                    <asp:ListItem>Araba/Álava</asp:ListItem>
                    <asp:ListItem>Bizkaia</asp:ListItem>
                    <asp:ListItem>Gipuzkoa</asp:ListItem>
                </asp:DropDownList>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" />

                <br />
                Tipo de vivienda:
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="False" style="margin-left: 0px" Width="104px">
                    <asp:ListItem Value="Todos">Todos</asp:ListItem>
                    <asp:ListItem>Camping</asp:ListItem>
                    <asp:ListItem>Aloc</asp:ListItem>
                    <asp:ListItem>Rural</asp:ListItem>
                </asp:DropDownList>

                <br />
                Orden :
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="False" style="margin-left: 0px" Width="104px">
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
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Outset" BorderWidth="1px" CellPadding="4" CellSpacing="4" GridLines="Horizontal" PageSize="500" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="#99CCFF" />
                    <Columns>
                        <asp:BoundField DataField="cCodigo" HeaderText="CODIGO" Visible="False" />
                        <asp:TemplateField HeaderText="ALOJAMIENTO">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cNombre") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" Font-Bold="True" runat="server" Text='<%# Bind("cNombre") %>'></asp:Label>
                                &nbsp;<br />
                                <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="img/HOTEL.jpg" Width="150px" />
                                <br />
                                Localidad : <asp:Label ID="Label5" runat="server" ForeColor="Pink" Text='<%# Bind("cLocalidad") %>'></asp:Label>
                                <br />
                                Capacidad : <asp:Label ID="Label9" runat="server" ForeColor="Pink" Text='<%# Bind("cCapacidad") %>'></asp:Label>
                                <br />
                                E-Mail : <asp:Label ID="Label6" runat="server" ForeColor="Pink" Text='<%# Bind("cEmail") %>'></asp:Label>
                                <br />
                                Web: <asp:Label ID="Label7" runat="server" ForeColor="Pink" Text='<%# Bind("cWeb") %>'></asp:Label>
                                <br />
                                <asp:Label ID="Label3" runat="server" ForeColor="Transparent" Text='<%# Bind("cCodAlojamiento") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="500px" />
                            <HeaderStyle HorizontalAlign="Center" Width="300px" Wrap="False" />
                            <ItemStyle  Width="300px" Height="150px" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DESCRIPCION">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cDescripcion") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("cDescripcion") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="500px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" Wrap="True" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" Wrap="True" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TIPO">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("cTipo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("cTipo") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" Wrap="True" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" Wrap="True" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="Button3" runat="server" CommandName="Select" CssClass="btn bg-light-blue" OnClientClick="Button1_Click1" Text="RESERVAR" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            <br />
            <br />
            </div>

            <div id="divFechasReserva" runat="server">

                    <table >
                        <tr> <td > <asp:Label ID="Label4" runat="server" Text="Seleccione las fechas deseadas" Font-Names="Lucida Handwriting"></asp:Label></td></tr>
                    <tr>
                        <td > <asp:Label ID="lblFechaEntrada" runat="server" Text="Fecha de entrada"></asp:Label></td>
                        <td ><asp:Label ID="lblFechaSalida" runat="server" Text="Fecha de salida"></asp:Label></td>
                    </tr>
                    <tr>
                        <td > <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                            </asp:Calendar></td>
                        <td ><asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
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

