Imports MySql.Data.MySqlClient

Public Class Reserva
    Inherits System.Web.UI.Page
    Public conexion As New MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then ' Estos eventos ocurrirán sólo la primer vez que se inicie la página
            cargarDatosReserva()


            'Se hace invisible el div que contiene fechas (luego se hace visible cuando se pulse el botón reservar)
            divModificarReservas.Visible = False

        End If


    End Sub

#Region "BOTONES CABECERA"

    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Response.Redirect("Inicio.aspx") 'Ir a la página de inicio
    End Sub
    Protected Sub btnReservas_Click(sender As Object, e As EventArgs) Handles btnReservas.Click
        Response.Redirect("Reserva.aspx") 'Ir a la página Reservas
    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Response.Redirect("IniSesion.aspx") 'Ir a la página de iniciar sesión
    End Sub


#End Region
#Region "Botones"
    Protected Sub btnModificarReserva_Click(sender As Object, e As EventArgs) Handles btnModificarReserva.Click
        divModificarReservas.Visible = True
    End Sub
    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        divModificarReservas.Visible = False
    End Sub
#End Region

#Region "DatosReservas"
    Protected Sub cargarDatosReserva()
        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()
            Dim servidor As String = "localhost"
            Dim usuario As String = "grupoAlojamientos"
            Dim pswd As String = "123456"
            Dim database As String = "alojamientos"
            'Establecemos los parametros de la conexion a la BBDD
            conexion.ConnectionString = "server=" & servidor & ";" & "database=" & database & ";" & "user id=" & usuario & ";" & "password=" & pswd & ";"
            conexion.Open()
            'Abrimos la conexion a la BBDD

            'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL


            Dim sql As String = "SELECT * FROM treservas  ;"

            Dim comando As New MySqlCommand(sql, conexion)





            Dim Datos As MySqlDataReader = comando.ExecuteReader
            If Datos.Read Then
                Dim usuarioIntroducido = Request.QueryString("ID")
                ' usuarioIntroducido = Session("Mivar")
                Label1.Text = usuarioIntroducido
                Label2.Text = Trim(Datos("cCodAlojamiento"))
                Label3.Text = Trim(Datos("cCodUsuario"))
                Label4.Text = Trim(Datos("cFechaRealizada"))

                txtBoxCodReserva.Text = Datos("cReserva")
                txtBoxFechaEntrada.Text = Datos("cFechaEntrada")
                txtBoxFechaSalida.Text = Datos("cFechaSalida")
                txtBoxFechaReserva.Text = Datos("cFechaRealizada")
                txtBoxDni.Text = Datos("cCodUsuario")
                '  txtBoxNombre.Text = Datos("cNombre")
                '  txtBoxApellidos.Text = Datos("cApellidos")
                ' txtBoxTelefono.Text = Datos("cTelefono")
                txtBoxCodAlojamiento.Text = Datos("cCodAlojamiento")
                'txtBoxNombreAlojamiento.Text = Datos("cNombre")


            End If

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub



#End Region
End Class