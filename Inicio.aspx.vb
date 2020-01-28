Imports MySql.Data.MySqlClient
Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.Expressions

Public Class Inicio
    Inherits System.Web.UI.Page

#Region "Variables"
    Public conexion As New MySqlConnection
    Dim thisDay = DateTime.Today
    Dim fechaActual As String = DateTime.Now.ToString("yyyy/MM/dd")
    Dim fechaEntrada As String = DateTime.Now.ToString("yyyy/MM/dd")
    Dim fechaSalida As String = DateTime.Now.ToString("yyyy/MM/dd")
    Public CodigoAlojamiento As String
    Public reservas As Integer = 0
    Dim item As String = String.Empty
    Dim orden As String = "Asc"
    Dim buscadar As String = ""
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
            btnRegistrarse.Visible = True
            btnCerrarSesion.Visible = False

            Response.Write("no estas logeado : ")
        Else

            Response.Write("Bienvenido : " & System.Web.HttpContext.Current.Session(“ID”))
            btnIniciarSesion.Visible = False
            btnReservas.Visible = True
            btnCerrarSesion.Visible = True
            btnRegistrarse.Visible = False
        End If

    End Sub
#End Region

    Protected Sub cargarDatosAlojamientos()
        Try
            'Cerramos la conexion a la BBDD


            'Establecemos los parametros de la conexion a la BBDD
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
            conexion = New MySqlConnection(connectionString)
            conexion.Open() 'Abrimos la conexion a la BBDD


            'Query para ejecutar select de la localidad seleccionada
            Dim sql As String

            'Si se pasa por URL

            sql = "SELECT cNombre, cCodAlojamiento FROM tAlojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ;"



            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read


                ListBox1.Items.Add(Datos(0))


            End While
            conexion.Close()
        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
        End Try
    End Sub

#Region "BOTONES CABECERA"


    Protected Sub btnReservas_Click(sender As Object, e As EventArgs) Handles btnReservas.Click
        Response.Redirect("Reserva.aspx") 'Ir a la página Reservas
    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Response.Redirect("IniSesion.aspx") 'Ir a la página de iniciar sesión
    End Sub
    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        Session.RemoveAll()
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Inicio.aspx", False)

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

            If DropDownList3.SelectedValue.ToString <> "Ascendente" Then
                orden = "Desc"
            Else
                orden = "Asc"
            End If

            Console.WriteLine("Conexión a la BBDD realizada con éxito") 'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL
            If DropDownList2.SelectedValue.ToString <> "Todos" Then
                sql = "SELECT cNombre FROM tAlojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "'  AND cTipo = '" & DropDownList2.SelectedValue & "' ORDER BY  cNombre " & orden & ";"
            Else
                sql = "SELECT cNombre FROM tAlojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ORDER BY  cNombre " & orden & "  ;"
            End If



            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read


                ListBox1.Items.Add(Datos(0))


            End While
            conexion.Close()
            Console.WriteLine("Conexión a la BBDD cerrada con éxito") 'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL

            divFechasReserva.Visible = False 'Se hace no visible las opciones de hacer la reserva

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
        End Try
    End Sub
    Protected Sub btnReservarAlojamiento_Click(sender As Object, e As EventArgs) Handles btnReservarAlojamiento.Click
        Try
            item = ListBox1.SelectedItem.ToString
            divFechasReserva.Visible = True
        Catch ex As Exception
            MsgBox("Debe seleccionar algún alojamiento")
        End Try


    End Sub

    Protected Sub btnRealizarReserva_Click(sender As Object, e As EventArgs) Handles btnRealizarReserva.Click
        Dim continuar As Boolean = False
        'Validar fechas

        'Si el usuario está logeado, realizar reserva
        If (HttpContext.Current.Session("ID") = vbNullString) Then
            MsgBox("Debe iniciar sesión antes de realizar su reserva", MsgBoxStyle.OkOnly + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.MsgBoxSetForeground, "¡Atención!")
            Response.Redirect("IniSesion.aspx") 'Ir a la página de iniciar sesión
        Else

            Dim resp As MsgBoxResult
            resp = MsgBox("¿Desea finalizar su reserva? Si continúa su reserva se guardará.", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.MsgBoxSetForeground, "Reserva")
            If resp = MsgBoxResult.Yes Then
                IDAlojamiento()

                'Establecemos los parametros de la conexion a la BBDD
                Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
                conexion = New MySqlConnection(connectionString)
                conexion.Open() 'Abrimos la conexion a la BBDD
                Console.WriteLine("Conexión a la BBDD realizada con éxito") 'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL

                continuar = validarFechas()

                If continuar Then
                    'cambio de formato de fechas para que la insert funcione en mysql
                    fechaActual = fechaActual.Replace("/", "-")
                    fechaEntrada = fechaEntrada.Replace("/", "-")
                    fechaSalida = fechaSalida.Replace("/", "-")


                    Dim sql1 = "INSERT INTO `tReservas`(`cReserva`,`cCodAlojamiento`, `cCodUsuario`, `cFechaEntrada`, `cFechaRealizada`, `cFechaSalida`) VALUES (" + reservas.ToString + "," + CodigoAlojamiento.ToString + ",'" + HttpContext.Current.Session("ID").ToString + "','" + fechaEntrada + "','" + fechaActual + "','" + fechaSalida + "')"
                    Dim comando1 As New MySqlCommand(sql1, conexion)
                    Dim Datos As MySqlDataReader = comando1.ExecuteReader

                    MsgBox("La reserva se guardó correctamente", MsgBoxStyle.MsgBoxSetForeground, "Reserva")

                    'Cerramos la conexion a la BBDD
                    conexion.Close()
                    Console.WriteLine("Conexión a la BBDD cerrada con éxito") 'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL

                Else
                    MsgBox("La reserva no se realizó.", MsgBoxStyle.MsgBoxSetForeground, "Reserva")
                End If

            Else
                MsgBox("La reserva no se realizó.", MsgBoxStyle.MsgBoxSetForeground, "Reserva")
            End If
        End If

        'prueba para ver si pasa los parametros seleccionados
        'Response.Redirect("Inicio.aspx?ID=" + usuarioIntroducido + "&LOC=" + Localidad + "&ALOJ=" + CodigoAlojamiento)

    End Sub

#End Region

#Region "Fechas"
    Protected Function validarFechas() As Boolean
        Dim continuar As Boolean = True

        fechaEntrada = Calendar1.SelectedDate.ToString("yyyy/MM/dd")
        fechaSalida = Calendar2.SelectedDate.ToString("yyyy/MM/dd")

        If fechaEntrada < thisDay Then
            fechaEntrada = fechaActual
        End If

        If fechaSalida < thisDay Then
            fechaSalida = fechaEntrada
        End If

        If fechaSalida <= fechaEntrada Then
            MsgBox("Lo sentimos, la fecha de salida no puede ser anterior a la fecha de entrada. Gracias.")
            continuar = False
        End If

        Return continuar
    End Function

    Protected Sub Calendar1_DayRender(sender As Object, e As DayRenderEventArgs) Handles Calendar1.DayRender
        If e.Day.Date < thisDay Then
            e.Day.IsSelectable = False
        End If
    End Sub
    Protected Sub Calendar2_DayRender(sender As Object, e As DayRenderEventArgs) Handles Calendar2.DayRender
        If e.Day.Date < fechaEntrada Then
            e.Day.IsSelectable = False
        End If
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

        item = ListBox1.SelectedItem.ToString



        'btnReservas.Visible = True

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
            sql = "SELECT  cCodAlojamiento FROM tAlojamientos WHERE cNombre = '" & item & "' ;"

            Dim comando As New MySqlCommand(sql, conexion)

			Dim Datos As MySqlDataReader = comando.ExecuteReader
			While Datos.Read
                Try
                    CodigoAlojamiento = Datos(0)
                Catch ex As Exception
                    Console.WriteLine("No se pudo obtener la lista de alojamientos, asegúrese de que la BBDD es la adecuada") 'Aqui saltó el error cuando los de open data cambiaron los xml de los alojamientos 
                End Try



            End While
			Datos.Close()

			Dim sql1 As String = ""

            sql1 = "SELECT Max(cReserva) FROM tReservas ;"

            Dim comando1 As New MySqlCommand(sql1, conexion)

			Dim Datos1 As MySqlDataReader = comando1.ExecuteReader

			While Datos1.Read

                Try
                    reservas = Datos1.GetInt32(0)
                    reservas = reservas + 1
                Catch ex As Exception
                    reservas = reservas + 1 'Si no hay reservas en la bbdd, codreserva = 1
                End Try

            End While
			conexion.Close()
		Catch ex As MySqlException
			'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
			MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
		End Try

	End Sub

	Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRegistrarse.Click
        Response.Redirect("Registrarse.aspx", False)
    End Sub

    Protected Sub Buscador_Click(sender As Object, e As EventArgs) Handles Buscador.Click
        ListBox1.Items.Clear()
        buscadar = TextBox1.Text
        Try
            'Cerramos la conexion a la BBDD

            Dim sql As String = ""
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString

            conexion = New MySqlConnection(connectionString)
            conexion.Open()
			'Abrimos la conexion a la BBDD
			sql = "SELECT cNombre FROM tAlojamientos WHERE cNombre = '" & buscadar.ToUpper & "';"


			Dim comando As New MySqlCommand(sql, conexion)
            Dim Datos As MySqlDataReader = comando.ExecuteReader
			While Datos.Read
				ListBox1.Items.Add(Datos(0))
			End While
            conexion.Close()
            Console.WriteLine("Conexión a la BBDD cerrada con éxito") 'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL

			'Si no se encuentran datos, se muestra el mensaje:
			If ListBox1.Items.Count = 0 Then
				'ListBox1.Items.Add("No se encontraron datos para la búsqueda realizada")
				lblSinAlojamientos.Text = "No se encontraron datos para la búsqueda realizada"
			End If


			divFechasReserva.Visible = False 'Se hace no visible las opciones de hacer la reserva

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
        End Try
    End Sub

    Protected Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim alojamiento As String
        Try
            alojamiento = ListBox1.SelectedItem.Value
        Catch ex As Exception
            alojamiento = Nothing
        End Try

        Session("aloj") = alojamiento
        If (Session("aloj") = Nothing) Then
            MsgBox("Tiene que elegir algun alojamiento para ver los detalles")
        Else
            Response.Redirect("detalle.aspx")
        End If





    End Sub


#End Region

End Class