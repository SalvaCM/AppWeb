Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page
    Public conexion As New MySqlConnection

#Region "Propiedades publicas"
    Public Property usuario As String
        Get
            Return usuario
        End Get

        Set(ByVal usuario As String)
            usuario = usuario
        End Set
    End Property

#End Region

#Region "VARIABLES"
    Public usuarioIntroducido As String
    Public contrasenaIntroducida As String
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub btnConectarse_Click(sender As Object, e As EventArgs) Handles btnConectarse.Click

        usuarioIntroducido = txtBoxUsuario.Text
        contrasenaIntroducida = txtBoxUsuario0.Text

        Dim enc As New UTF8Encoding
        Dim data() As Byte = enc.GetBytes(contrasenaIntroducida)
        Dim result() As Byte

        Dim sha As New SHA1CryptoServiceProvider

        result = sha.ComputeHash(data)

        Dim sb As New StringBuilder

        Dim max As Int32 = result.Length


        For i As Integer = 0 To max - 1

            'Convertimos los valores en hexadecimal
            'cuando tiene una cifra hay que rellenarlo con cero
            'para que siempre ocupen dos dígitos.
            If (result(i) < 16) Then
                sb.Append("0")
            End If

            sb.Append(result(i).ToString("x"))

        Next

        'Devolvemos la cadena con el hash en mayúsculas para que quede más chuli :)
        'lblPruebas.Text = sb.ToString().ToUpper()


        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()

            Dim sql As String = ""
            Dim servidor As String = "192.168.101.24"
            Dim usuario As String = "grupoAlojamientos"
            Dim pswd As String = "123456"
            Dim database As String = "alojamientos"
            'Establecemos los parametros de la conexion a la BBDD
            conexion.ConnectionString = "server=" & servidor & ";" & "database=" & database & ";" & "user id=" & usuario & ";" & "password=" & pswd & ";"
            conexion.Open()
            'Abrimos la conexion a la BBDD

            'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL

            sql = "SELECT * FROM tusuarios  ;"



            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read

                If sb.ToString() = Datos(2) Then
                    Response.Redirect("Inicio.aspx?ID=" + usuarioIntroducido)


                Else

                End If

            End While


        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
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
End Class