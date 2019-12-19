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

</style>
</head>
<body>
    <form id="form1" runat="server">
   <header style="text-align: right;">

   <asp:Button ID="Button4" runat="server" Text="Cerrar Sesion"/>

   <asp:Button class="button" ID="Button1" runat="server" Text="Inicia Sesion"/>
   <asp:Button ID="Button2" runat="server" Text="Reservas"/> 
  </header>
        <div style="height: 363px; width: 589px">

            <asp:Label ID="Label1" runat="server" Text="Localidad"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" style="margin-left: 0px" Width="104px">
                <asp:ListItem>Gipuzkoa</asp:ListItem>
                <asp:ListItem>Bizkaia</asp:ListItem>
                <asp:ListItem>Alaba</asp:ListItem>
            </asp:DropDownList>

            <asp:ListBox ID="ListBox1" runat="server" Height="147px" Width="552px" AutoPostBack="True"></asp:ListBox>
        
            <br />
            <br />
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
