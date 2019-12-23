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
    Public usuarioIntroducido As String
    Private contrasenaIntroducida As String
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnConectarse_Click(sender As Object, e As EventArgs) Handles btnConectarse.Click
        '(1º) Validar que usuario se introduzca y exista
        '(2º) Validar que contraseña se introduzca y exista
        '(3º) Validar que contraseña correcta

        usuarioIntroducido = txtBoxUsuario.Text
        ' contrasenaIntroducida = Password1.text
        lblPruebas.Text = usuarioIntroducido

        If usuarioIntroducido.Equals("Alba") Then
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
End Class