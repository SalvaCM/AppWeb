Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Web.UI.WebControls.Expressions
Imports System
Imports System.Windows.Forms
Public Class Registrarse
    Inherits System.Web.UI.Page
    Public conexion As New MySqlConnection
    Public DNIIntroducido As String
    Public NombreIntroducido As String
    Public ApellidoIntroducido As String
    Public TelefonoIntroducido As String
    Public cierto As Boolean = False
    Private contrasenaIntroducida As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub
    Protected Sub btnRegistrarse_Click(sender As Object, e As EventArgs) Handles btnRegistrarse.Click

        DNIIntroducido = txtBoxUsuario.Text
        NombreIntroducido = txtBoxNombre.Text
        ApellidoIntroducido = TextBoxApellido.Text
        TelefonoIntroducido = TextBoxTelefono.Text

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


            sql = "SELECT * FROM tusuarios  ;"

            Dim comando As New MySqlCommand(sql, conexion)
            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read

                If DNIIntroducido.Equals(Datos(0)) Then
                    cierto = True

                Else
                    If cierto = True Then

                    Else
                        cierto = False


                    End If
                End If

            End While
            If cierto.Equals(False) Then
                Insertar(DNIIntroducido, ApellidoIntroducido, sb.ToString, NombreIntroducido, TelefonoIntroducido)
            End If


        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub Insertar(DNIIntroducido, ApellidoIntroducido, sb, NombreIntroducido, TelefonoIntroducido)

        Dim sql As String = ""
        Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        'Establecemos los parametros de la conexion a la BBDD

        Dim conexion1 As New MySqlConnection(connectionString)
        conexion1.Open() 'Abrimos la conexion a la BBDD
        Try
            '  Dim conn As New MySqlConnection("Server=192.168.101.24; Database=alojamientos; Uid=grupoAlojamientos; Pwd=123456")
            Dim Query As String = "INSERT INTO tusuarios(cDni,cApellidos,cContrasena,cNombre,cTelefono,cTipoUsuario)VALUES('" + DNIIntroducido.ToString + "','" + ApellidoIntroducido.ToString + "','" + sb.ToString + "','" + NombreIntroducido.ToString + "'," + TelefonoIntroducido + ", 'Normal' )"



            Dim comando1 As New MySqlCommand(Query, conexion1)



            comando1.ExecuteNonQuery()
            conexion1.Close()
        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("IniSesion.aspx", True)
    End Sub
End Class