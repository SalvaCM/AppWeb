Imports MySql.Data.MySqlClient
Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.Expressions

Public Class Inicio
    Inherits System.Web.UI.Page

#Region "Variables"
	Public conexion As New MySqlConnection
	Public connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString

	Dim thisDay = DateTime.Today
    Dim fechaActual As String = DateTime.Now.ToString("yyyy/MM/dd")
    Dim fechaEntrada As String = DateTime.Now.ToString("yyyy/MM/dd")
	Dim fechaSalida As String = DateTime.Now.ToString("yyyy/MM/dd")
	Public reservas As Integer = 0
    Dim item As String = String.Empty
    Dim orden As String = "Asc"
	Dim nombreHotel As String = ""
	Public codAlojamiento As String

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
		Dim query = "SELECT cCodAlojamiento,cNombre,cDescripcion,cCapacidad,cTelefono,cLocalidad,cWeb,cEmail,cTipo FROM tAlojamientos  WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ORDER BY cCodAlojamiento ;"
		If DropDownList3.SelectedValue.ToString <> "Ascendente" Then
			orden = "Desc"
		Else
			orden = "Asc"
		End If
		If DropDownList2.SelectedValue.ToString <> "Todos" Then
			query = "SELECT cCodAlojamiento,cNombre,cDescripcion,cCapacidad,cTelefono,cLocalidad,cWeb,cEmail,cTipo FROM tAlojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "'  AND cTipo = '" & DropDownList2.SelectedValue & "' ORDER BY  cNombre " & orden & ";"
		Else
			query = "SELECT cCodAlojamiento,cNombre,cDescripcion,cCapacidad,cTelefono,cLocalidad,cWeb,cEmail,cTipo FROM tAlojamientos WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ORDER BY  cNombre " & orden & "  ;"
		End If
		CargarGrid(GridView1, query)
		divFechasReserva.Visible = False 'Se hace no visible las opciones de hacer la reserva
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
				CodReserva()

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

					MsgBox(Session("codAlojamiento").ToString)
					Dim sql1 = "INSERT INTO `tReservas`(`cReserva`,`cCodAlojamiento`, `cCodUsuario`, `cFechaEntrada`, `cFechaRealizada`, `cFechaSalida`) VALUES (" + reservas.ToString + ",'" + Session("codAlojamiento").ToString + "','" + HttpContext.Current.Session("ID").ToString + "','" + fechaEntrada + "','" + fechaActual + "','" + fechaSalida + "')"
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
	Protected Sub btnRegistrarse_Click(sender As Object, e As EventArgs) Handles btnRegistrarse.Click
		Response.Redirect("Registrarse.aspx", False)
	End Sub

	Public Sub Button1_Click1(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
		Dim indice = GridView1.SelectedIndex
		Dim row As GridViewRow = GridView1.Rows(indice)
		codAlojamiento = TryCast(row.FindControl("Label3"), Label).Text
		Dim nombre As String = TryCast(row.FindControl("Label2"), Label).Text
		'Dim botton As Button = TryCast(row.FindControl("Button_1"), Button)
		'botton.Visible = False
		divFechasReserva.Visible = True
		Session("codAlojamiento") = codAlojamiento
		Dim query = "SELECT cCodAlojamiento,cNombre,cDescripcion,cCapacidad,cTelefono,cLocalidad,cWeb,cEmail,cTipo FROM tAlojamientos WHERE cCodAlojamiento LIKE '" & codAlojamiento & "';"
		CargarGrid(GridView1, query)

	End Sub
	Protected Sub Buscador_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
		Dim query = "SELECT cCodAlojamiento,cNombre,cDescripcion,cCapacidad,cTelefono,cLocalidad,cWeb,cEmail,cTipo FROM tAlojamientos WHERE cNombre LIKE '" & TextBox1.Text & "';"
		CargarGrid(GridView1, query)
		divFechasReserva.Visible = False 'Se hace no visible las opciones de hacer la reserva
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
#End Region

#Region "Funciones"
	Protected Sub cargarDatosAlojamientos()
		Dim query = "SELECT cCodAlojamiento,cNombre,cDescripcion,cCapacidad,cTelefono,cLocalidad,cWeb,cEmail,cTipo FROM tAlojamientos  WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ORDER BY cCodAlojamiento ;"
		CargarGrid(GridView1, query)
	End Sub
	Public Sub CodReserva()

		Try
			Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
			conexion = New MySqlConnection(connectionString)
			conexion.Open()
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


	'CargarGrid(GridView1, "SELECT cNombre, cCodAlojamiento,cDescripcion FROM tAlojamientos  WHERE cLocalidad = '" & DropDownList1.SelectedValue & "' ;")
	Public Sub CargarGrid(GridView1 As GridView, query As String)
		conexion = New MySqlConnection(connectionString)
		Dim adapter As New MySqlDataAdapter(query, conexion)
		Try
			conexion.Open()
			Dim tabla As New DataTable()
			adapter.Fill(tabla)
			GridView1.DataSource = tabla
			GridView1.DataBind()
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		Finally
			conexion.Close()
		End Try
	End Sub

#End Region


End Class