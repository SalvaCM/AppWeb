Imports MySql.Data.MySqlClient
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

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnConectarse_Click(sender As Object, e As EventArgs) Handles btnConectarse.Click
        Dim continuar As Boolean = False
        '(1º) Se cargan los datos de usuario y contrasena
        usuarioIntroducido = txtBoxUsuario.Text
        contrasenaIntroducida = txtBoxContrasena.Text
        ' contrasenaIntroducida = Password1.text

        '(2º) Se cargan los datos de los usuarios y contraseñas (encriptadas) de la bbdd 
        'y se guardan en arraylist: listaNombres y listaContrasenas
        cargarDatosUsuariosYContrasenas()
        mostrarArrayLists() 'para pruebas, luego borrar

        '(3º) Validar que usuario se introduzca y exista en la BBDD
        If listaNombres.Contains(usuarioIntroducido.ToString.ToUpper()) Then
            TextBox1.Text = TextBox1.Text & "Existe en bbdd"
            continuar = True
        Else
            MsgBox("El usuario introducido no se encuentra registrado")
        End If

        '(4º) Encriptar contrasena
        contrasenaIntroducidaEncriptada = contrasenaIntroducida

        If (continuar) Then 'si ha introducido usuario válido
            '(5º) Validar que contraseña se introduzca y exista
            If listaContrasenas.Contains(contrasenaIntroducidaEncriptada.ToString) Then
                continuar = True
            Else
                MsgBox("La contrasena introducida no es correcta")
                continuar = False
            End If
        End If

        '(6º) Si usuario y contraseña son válidos: entra en la página de inicio
        If continuar Then
            Response.Redirect("Inicio.aspx?ID=" + usuarioIntroducido)
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
    Protected Sub cargarDatosUsuariosYContrasenas()
        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()
            Dim servidor As String = "localhost"
            Dim usuario As String = "grupoAlojamientos"
            Dim pswd As String = "123456"
            Dim database As String = "alojamientos"
            'Establecemos los parametros de la conexion a la BBDD
            conexion.ConnectionString = "server=" & servidor & ";" & "database=" & database & ";" & "user id=" & usuario & ";" & "password=" & pswd & ";"
            conexion.Open() 'Abrimos la conexion a la BBDD

            Dim sql As String = "select cDni, cContrasena  from tUsuarios ;"
            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader

            Dim continuar As Boolean = True
            While continuar 'Mientras existan más dnis
                If Datos.Read Then
                    continuar = True
                    Dim usuarioIntroducido = Request.QueryString("ID")
                    ' usuarioIntroducido = Session("Mivar")
                    lblPruebas.Text = usuarioIntroducido

                    listaNombres.Add(Datos("cDni"))
                    listaContrasenas.Add(Datos("cContrasena"))
                Else
                    continuar = False
                End If
            End While

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub mostrarArrayLists()
        For i = 0 To listaNombres.Count - 1
            TextBox1.Text = TextBox1.Text & listaNombres(i).ToString & " *** " 
        Next
    End Sub

End Class