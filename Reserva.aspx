<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Reserva.aspx.vb" Inherits="AppWeb.Reserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 508px;
        }
        .auto-style4 {
            width: 724px;
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <header style="text-align: right;">
         <asp:Button ID="btnInicio" runat="server" Text="Inicio" CssClass="btn bg-light-blue "/> 
         <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" CssClass="btn bg-light-blue "/>
     </header>
        <div id="divVerReservas" runat="server">
            <br />
            <section class="content-header">
                <h1 style="text-align:center">
                    <asp:Label ID="lblDetallesReservas" runat="server" Text="DETALLES DE SUS RESERVAS" ForeColor="#3333CC"></asp:Label>
                </h1> 
            </section>
            <section  class="content">
                <div class="row">
                    <div>
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
                    </div>
                    <div>
                        <asp:Label ID="lblSinReservas" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                     <div id="divOpcionesReservas" runat="server" class="auto-style1">
             <table class="auto-style3">
                 <tr>
                     <td>
                        <asp:Button ID="btnNuevaReserva" runat="server" Text="Nueva reserva" CssClass="btn bg-light-blue "/>
                     </td>
                     <td>
                         <asp:Button ID="btnModificarEliminar" runat="server" Text="Modificar/eliminar reserva" CssClass="btn bg-light-blue "/>
                     </td>
                 </tr>
             </table>
         </div>
                </div>
                <div class="row">
                    <div >
                        <div >
                            <div id="divOpcionesModificarEliminar" runat="server" class="box box-primary" style="left: 2px; top: 41px; width: 97%; height: 70px;">
                                <div class="auto-style4">
                                    <asp:Label ID="lblIntroduzca" runat="server" Text="Introduzca el código de la reserva que desea modificar/eliminar: "></asp:Label>
                                  <asp:TextBox ID="txtBoxCodReservIntroducido" runat="server" type="number" min="0"></asp:TextBox>
                                  <asp:Button ID="btnBuscar" runat="server" Text="Buscar reserva" CssClass="btn bg-light-blue "/>
                                    <br />
                                </div>
                                 
                             </div>
                              <div id="divModificarReservas" runat="server" class="box box-primary" style="left: 2px; top: 41px; width: 104%; height: 840px;">
                                  <div style="text-align:center">
                                      <h2> 
                                        <asp:Label ID="Label5" runat="server" Text="MODIFIQUE SU RESERVA" ForeColor="#3333CC"></asp:Label>
                                      </h2> 
                                  </div>
                                  
                                  <br />
                                  <h3>
                                    <asp:Label ID="Label6" runat="server" Text="Datos de la reserva:" ForeColor="#3333CC"></asp:Label>
                                  </h3>  
                                
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
                                  <asp:TextBox ID="txtBoxFechaReserva" runat="server" Enabled="False"></asp:TextBox>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBoxFechaReserva" ErrorMessage="Introduzca la fecha en un formato válido: dd/mm/aaaa" ForeColor="Red" ValidationExpression="([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}"></asp:RegularExpressionValidator>
                                  <br />
                                  <br />
                                  <h3>
                                       <asp:Label ID="Label7" runat="server" Text="Datos del alojamiento:" ForeColor="#3333CC"></asp:Label>
                                  </h3>
                                 
                                  <br />
                                  <asp:Label ID="lblNombre0" runat="server" Text="NOMBRE: "></asp:Label>
                                  <asp:TextBox ID="txtBoxNombreAlojamiento" runat="server" Enabled="False"></asp:TextBox>
                                  <br />
                                  <asp:Label ID="lblNombre1" runat="server" Text="DIRECCIÓN: "></asp:Label>
                                  <asp:TextBox ID="txtBoxDireAloj" runat="server" Enabled="False"></asp:TextBox>
                                  <br />
                                  <asp:Label ID="lblNombre2" runat="server" Text="LOCALIZACIÓN: "></asp:Label>
                                  <asp:TextBox ID="txtBoxLocalizAloj" runat="server" Enabled="False"></asp:TextBox>
                                  <br />
                                  <asp:Label ID="lblNombre3" runat="server" Text="EMAIL: "></asp:Label>
                                  <asp:TextBox ID="txtBoxEmailAloj" runat="server" Enabled="False"></asp:TextBox>
                                  <br />
                                  <asp:Label ID="lblNombre4" runat="server" Text="TELÉFONO: "></asp:Label>
                                  <asp:TextBox ID="txtBoxTelfAloj" runat="server" Enabled="False"></asp:TextBox>
                                  <br />
                                  <asp:Label ID="lblNombre5" runat="server" Text="WEB: "></asp:Label>
                                  <asp:TextBox ID="txtBoxWebAloj" runat="server" Enabled="False"></asp:TextBox>
                                  <br />
                                  <br />
                                  <h3>
                                      <asp:Label ID="Label8" runat="server" Text="Datos del usuario:" ForeColor="#3333CC"></asp:Label>
                                  </h3>
                                  <br />
                                  <asp:Label ID="lblDni" runat="server" Text="DNI: "></asp:Label>
                                  <asp:TextBox ID="txtBoxDni" runat="server" Enabled="False"></asp:TextBox><br />
                                  <asp:Label ID="lblNombre" runat="server" Text="NOMBRE: "></asp:Label>
                                  <asp:TextBox ID="txtBoxNombre" runat="server" Enabled="False"></asp:TextBox><br />
                                  <asp:Label ID="lblApellidos" runat="server" Text="APELLIDOS: " ></asp:Label>
                                  <asp:TextBox ID="txtBoxApellidos" runat="server" Enabled="False"></asp:TextBox><br />
                                  <asp:Label ID="lblTelefono" runat="server" Text="TELEFONO: "></asp:Label>
                                  <asp:TextBox ID="txtBoxTelefono" runat="server" MaxLength="9" Enabled="False"></asp:TextBox><br />
                                  <br />
                                  <br />

                                  <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn bg-light-blue "/> &nbsp;
                                  <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn bg-red-gradient "/> &nbsp;
                                  <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn bg-light-blue "/>

                                  <br />
                             </div>


                        </div>
                    </div>
                </div>

            </section>
           
        </div>
        
         
</asp:Content>