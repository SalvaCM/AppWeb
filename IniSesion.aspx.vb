Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Web.UI.WebControls.Expressions
Public Class WebForm1
	Inherits System.Web.UI.Page

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
    Public conexion As New MySqlConnection
    Public usuarioIntroducido As String
    Private contrasenaIntroducida As String
    Private contrasenaIntroducidaEncriptada As String
    Dim listaNombres As New ArrayList
    Dim listaContrasenas As New ArrayList
    Public cierto As Boolean = False
    Public masterP As MasterPage
#End Region

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	End Sub

#Region "BOTONES CABECERA"
	Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Response.Redirect("Inicio.aspx") 'Ir a la página de inicio
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Registrarse.aspx", False)

    End Sub

#End Region

#Region "Métodos"
    Protected Sub cargarDatosUsuariosYContrasenas()
        usuarioIntroducido = txtBoxUsuario.Text
        contrasenaIntroducida = txtBoxContrasena.Text
        'Encriptamos
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
        'Acabamos de encriptara

        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()
            Dim sql As String = ""
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
            'Establecemos los parametros de la conexion a la BBDD
            conexion = New MySqlConnection(connectionString)
            conexion.Open() 'Abrimos la conexion a la BBDD

			sql = "SELECT * FROM tUsuarios  ;"


			Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read

                If sb.ToString() = Datos(2) And usuarioIntroducido.Equals(Datos(0)) Then
                    cierto = True
					HttpContext.Current.Session(“ID”) = usuarioIntroducido
					Session("logeado") = True
					Response.Redirect("Inicio.aspx?ID=" + usuarioIntroducido, False)
                Else
                    If cierto = True Then

					Else
                        cierto = False
                    End If
                End If

            End While
            If cierto.Equals(False) Then
                MsgBox("informacion introducida incorrecta", MsgBoxStyle.MsgBoxSetForeground)
            End If


        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
        End Try
    End Sub

    Protected Sub btnConectarse_Click(sender As Object, e As EventArgs) Handles btnConectarse.Click
        cargarDatosUsuariosYContrasenas()
    End Sub



#End Region




End Class