Imports MySql.Data.MySqlClient
Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Public Class Inicio
    Inherits System.Web.UI.Page

#Region "Variables"
    Public conexion As New MySqlConnection

    Dim fechaActual As String = DateTime.Now.ToString("yyyy/MM/dd")
    Dim fechaEntrada
    Dim fechaSalida
    Public CodigoAlojamiento As String
    Public reservas As String


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
        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()

            'Establecemos los parametros de la conexion a la BBDD
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
            conexion = New MySqlConnection(connectionString)
            conexion.Open() 'Abrimos la conexion a la BBDD


            'Query para ejecutar select de la localidad seleccionada
            Dim sql As String

            'Si se pasa por URL
            sql = "SELECT cNombre, cCodAlojamiento FROM talojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ;"



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

        'Validar fechas
        validarFechas()

        'Si el usuario está logeado, realizar reserva
        If (HttpContext.Current.Session("ID") = vbNullString) Then
            MsgBox("Debe iniciar sesión antes de realizar su reserva", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "¡Atención!")
            Response.Redirect("IniSesion.aspx") 'Ir a la página de iniciar sesión
        Else

            Dim resp As MsgBoxResult
            resp = MsgBox("¿Desea finalizar su reserva? Si continúa su reserva se guardará.", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "Reserva")
            If resp = MsgBoxResult.Yes Then
                IDAlojamiento()
                'Cerramos la conexion a la BBDD
                conexion.Close()

                'Establecemos los parametros de la conexion a la BBDD
                Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
                conexion = New MySqlConnection(connectionString)
                conexion.Open() 'Abrimos la conexion a la BBDD


                'cambio de formato de fechas para que la insert funcione en mysql
                fechaActual = fechaActual.Replace("/", "-")
                fechaEntrada = fechaEntrada.Replace("/", "-")
                fechaSalida = fechaSalida.Replace("/", "-")


                Dim sql1 = "INSERT INTO `treservas`(`cCodAlojamiento`, `cCodUsuario`, `cFechaEntrada`, `cFechaRealizada`, `cFechaSalida`) VALUES (" + CodigoAlojamiento.ToString + ",'" + HttpContext.Current.Session("ID").ToString + "','" + fechaEntrada + "','" + fechaActual + "','" + fechaSalida + "')"
                Dim comando1 As New MySqlCommand(sql1, conexion)
                Dim Datos As MySqlDataReader = comando1.ExecuteReader


                MsgBox("La reserva se guardó correctamente", , "Reserva")

            Else
                MsgBox("La reserva no se realizó.", , "Reserva")
            End If
        End If

        'prueba para ver si pasa los parametros seleccionados
        'Response.Redirect("Inicio.aspx?ID=" + usuarioIntroducido + "&LOC=" + Localidad + "&ALOJ=" + CodigoAlojamiento)

    End Sub

#End Region

#Region "Fechas"
    Protected Sub validarFechas()
        fechaEntrada = Calendar1.SelectedDate.ToString("yyyy/MM/dd")
        fechaSalida = Calendar2.SelectedDate.ToString("yyyy/MM/dd")

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

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged


        'Copia el valor COMPLETO del item seleccionado
        Dim item As String = ListBox1.SelectedItem.ToString

        'variale para guardar los 4 primeros caracteres del value (Código de alojamiento)
        Dim Alojseleccionado As String = ""

        'Bucle para copiar los 4 primeros caracteres de la variable item y copiarlos a otra variable (en estos 4 primeros caracteres pueden existir espacios) 
        For x As Integer = 0 To 3
            Alojseleccionado += item(x)
        Next

        'Bucle para quitar el espacio si es que existe alguno
        CodigoAlojamiento = ""
        For y As Integer = 0 To Alojseleccionado.LastIndexOf(" ") - 1
            CodigoAlojamiento += Alojseleccionado(y)
        Next


    End Sub

    Public Sub IDAlojamiento()
        Dim item As String = ListBox1.SelectedItem.ToString
        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()

            'Establecemos los parametros de la conexion a la BBDD
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
            conexion = New MySqlConnection(connectionString)
            conexion.Open() 'Abrimos la conexion a la BBDD


            'Query para ejecutar select de la localidad seleccionada
            Dim sql As String = ""

            'Si se pasa por URL
            sql = "SELECT  cCodAlojamiento FROM talojamientos WHERE cNombre = '" & item & "' ;"
            MsgBox(sql)
            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read


                CodigoAlojamiento = Datos(0)


            End While
            Datos.Close()

            Dim sql1 As String = ""

            sql = "SELECT Max(cReserva) FROM treservas ;"

            Dim comando1 As New MySqlCommand(sql, conexion)

            Dim Datos1 As MySqlDataReader = comando1.ExecuteReader

            While Datos1.Read


                reservas = Datos1(0) + 1


            End While
            conexion.Close()
        Catch ex As MySqlException
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try

    End Sub



#End Region

End Class