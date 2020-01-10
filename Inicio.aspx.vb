Imports MySql.Data.MySqlClient
Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Public Class Inicio
    Inherits System.Web.UI.Page
#Region "Variables"
    Public conexion As New MySqlConnection

    Dim fechaActual As String = DateTime.Now.ToString("dd/MM/yyyy")
    Dim fechaEntrada
    Dim fechaSalida

#End Region



#Region "Inicio"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then ' Estos eventos ocurrirán sólo la primer vez que se inicie la página
            cargarDatosAlojamientos()


            'Se hace invisible el div que contiene fechas (luego se hace visible cuando se pulse el botón reservar)
            divFechasReserva.Visible = False

        End If


        If (HttpContext.Current.Session("ID") = vbNullString) Then
            btnIniciarSesion.Visible = True
            btnReservas.Visible = False
            Response.Write("no estas logeado : ")
        Else

            Response.Write("Bienvenido : " & System.Web.HttpContext.Current.Session(“ID”))
            btnIniciarSesion.Visible = False
            btnReservas.Visible = True

        End If




    End Sub
#End Region




    Protected Sub cargarDatosAlojamientos()
        ListBox1.Items.Clear()

        Try
            'Cerramos la conexion a la BBDD

            Dim sql As String = ""

            'Establecemos los parametros de la conexion a la BBDD
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString



            conexion = New MySqlConnection(connectionString)
            'Abrimos la conexion a la BBDD
            conexion.Open()
            'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL

            sql = "SELECT cNombre FROM talojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ;"



            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read


                ListBox1.Items.Add(Datos(0))


            End While
            conexion.Close()

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try

    End Sub

#Region "BOTONES CABECERA"


    Protected Sub btnReservas_Click(sender As Object, e As EventArgs) Handles btnReservas.Click
        Response.Redirect("Reserva.aspx") 'Ir a la página Reservas
    End Sub




#End Region

#Region "BOTONES "
    Protected Sub btnAplicarFiltros_Click(sender As Object, e As EventArgs) Handles btnAplicarFiltros.Click
        ListBox1.Items.Clear()

        Try
            'Cerramos la conexion a la BBDD

            Dim sql As String = ""
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString



            conexion = New MySqlConnection(connectionString)
            conexion.Open()
            'Abrimos la conexion a la BBDD

            'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL

            sql = "SELECT cNombre FROM talojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ;"



            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read


                ListBox1.Items.Add(Datos(0))


            End While
            conexion.Close()

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btnReservarAlojamiento_Click(sender As Object, e As EventArgs) Handles btnReservarAlojamiento.Click
        divFechasReserva.Visible = True
    End Sub

    Protected Sub btnRealizarReserva_Click(sender As Object, e As EventArgs) Handles btnRealizarReserva.Click
        'Validar que el usuario se haya logeado:
        MsgBox("Debe iniciar sesión antes de realizar su reserva", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "¡Atención!")

        'Validar fechas
        validarFechas()

        'Si el usuario está logeado, realizar reserva
        Dim resp As MsgBoxResult
        resp = MsgBox("¿Desea finalizar su reserva? Si continúa su reserva se guardará.", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "Reserva")
        If resp = MsgBoxResult.Yes Then
            MsgBox("La reserva se guardó correctamente", , "Reserva")
        Else
            MsgBox("La reserva no se realizó.", , "Reserva")
        End If





    End Sub

#End Region

#Region "Fechas"
    Protected Sub validarFechas()
        fechaEntrada = Calendar1.SelectedDate.ToString("dd/MM/yyyy")
        fechaSalida = Calendar1.SelectedDate.ToString("dd/MM/yyyy")

        If fechaEntrada < fechaActual Then
            MsgBox("La fecha de entrada no puede ser menor a la fecha actual", , "Error")
        End If
        If fechaSalida < fechaEntrada Then
            MsgBox("La fecha de salida no puede ser menor a la fecha de entrada", , "Error")
        End If


        lblPruebas1.Text = "fechaActual" & fechaActual.ToString
        lblPruebas2.Text = "fechaEntrada" & fechaEntrada
        lblPruebas3.Text = "fechaSalida" & fechaSalida
    End Sub



#End Region

End Class