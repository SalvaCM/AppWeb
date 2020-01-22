<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="detalle.aspx.vb" Inherits="AppWeb.detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Nombre del alojamiento</h3>
    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
    <h3>Descripcion</h3>
    <asp:Label ID="lblDesc" runat="server" Text="Descripcion"></asp:Label>
    <h3>Localidad</h3>
    <asp:Label ID="lblLocalidad" runat="server" Text="Descripcion"></asp:Label>
    <h3>Direccion</h3>
    <asp:Label ID="lblDirec" runat="server" Text="Direccion"></asp:Label>
    <h3>Correo electronico</h3>
    <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
    <h3>Telefono</h3>
    <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
  </asp:Content>