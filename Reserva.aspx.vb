Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Reserva
    Inherits System.Web.UI.Page
    Public conexion As New MySqlConnection
    Dim conn As New MySqlConnection("Server=192.168.101.24; Database=alojamientos; Uid=grupoAlojamientos; Pwd=123456")

#Region "Variables"
    Dim mydatatable As New DataTable
    Dim thisDay = DateTime.Today
    Dim listaCodReserva As New ArrayList
    Dim listaFechaReserva As New ArrayList
    Dim listaFechaEntrada As New ArrayList
    Dim listaFechaSalida As New ArrayList
    Dim listaNombreAlojamiento As New ArrayList
    Dim listaNombre As New ArrayList
    Dim listaApellidos As New ArrayList
	Dim listaTelefono As New ArrayList

	Dim listaDireccion As New ArrayList
	Dim listaLocalizacion As New ArrayList
	Dim listaEmail As New ArrayList
	Dim listaWeb As New ArrayList


	Dim codReservIntroducido As Integer
	Dim fechaReservaIntroducida As Date
	Dim fechaEntradaIntroducida As Date
	Dim fechaSalidaIntroducida As Date

#End Region

#Region "Inicio página Reservas"
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load





		If (HttpContext.Current.Session("ID") = vbNullString) Then
			Response.Redirect("Inicio.aspx")



		End If





		If Not IsPostBack Then ' Estos eventos ocurrirán sólo la primer vez que se inicie la página
			cargarDatosReservas()
			rellenarTablaDetallesReservas()

			'Si el usuario logeado no tiene ninguna reserva: 
			If listaCodReserva.Count = 0 Then
				lblSinReservas.Text = "No existe ninguna reserva"
			End If

			'Se hace invisible el div que contiene fechas (luego se hace visible cuando se pulse el botón reservar)
			divOpcionesModificarEliminar.Visible = False
			divModificarReservas.Visible = False

		End If


	End Sub
#End Region

#Region "Cargar DatosReservas"
	Protected Sub cargarDatosReservas()
		'FALTA ACABAR: Se cargan los datos del USUARIO LOGEADO
		Dim usuarioLogeado As String = HttpContext.Current.Session("ID").ToString

		Try
			conn.Close() 'Cerramos la conexion a la BBDD

			conn.Open() 'Abrimos la conexion a la BBDD
			Dim query As String = "select R.cReserva, R.cFechaEntrada, R.cFechaSalida, R.cFechaRealizada, R.cCodUsuario,U.cNombre ""NombreUsuario"" ,U.cApellidos,R.cCodAlojamiento,A.cNombre ""NombreAlojamiento"", A.cDireccion, A.cLocalizacion, A.cEmail, A.cTelefono, A.cWeb   from tReservas R, tAlojamientos A, tUsuarios U where R.cCodAlojamiento=A.cCodAlojamiento and R.cCodUsuario=U.cDni and R.cCodUsuario='" & usuarioLogeado.ToString & "'"

			Dim cmd As New MySqlCommand(query, conn)
			cmd.ExecuteNonQuery()

			Dim comando As New MySqlCommand(query, conn)
			Dim Datos As MySqlDataReader = comando.ExecuteReader

			Dim continuar As Boolean = True
			While continuar 'Mientras existan más dnis
				If Datos.Read Then
					continuar = True

					listaCodReserva.Add(Datos("cReserva"))
					listaFechaReserva.Add(Datos("cFechaRealizada"))
					listaFechaEntrada.Add(Datos("cFechaEntrada"))
					listaFechaSalida.Add(Datos("cFechaSalida"))
					listaNombreAlojamiento.Add(Datos("NombreAlojamiento"))
					listaNombre.Add(Datos("NombreUsuario"))
					listaApellidos.Add(Datos("cApellidos"))
					listaTelefono.Add(Datos("cTelefono"))

					listaDireccion.Add(Datos("cDireccion"))
					listaLocalizacion.Add(Datos("cLocalizacion"))
					listaEmail.Add(Datos("cEmail"))
					listaWeb.Add(Datos("cWeb"))

				Else
					continuar = False
				End If
			End While

		Catch ex As Exception
			'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
			MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
		End Try
	End Sub



	Private Sub rellenarTablaDetallesReservas()
		' Create columns
		mydatatable.Columns.Add("Código de la reserva", Type.GetType("System.String"))
		mydatatable.Columns.Add("Fecha reserva", Type.GetType("System.String"))
		mydatatable.Columns.Add("Fecha entrada", Type.GetType("System.String"))
		mydatatable.Columns.Add("Fecha salida", Type.GetType("System.String"))
		mydatatable.Columns.Add("Nombre alojamiento", Type.GetType("System.String"))
		mydatatable.Columns.Add("Dirección", Type.GetType("System.String"))
		mydatatable.Columns.Add("Localización", Type.GetType("System.String"))
		mydatatable.Columns.Add("Email", Type.GetType("System.String"))
		mydatatable.Columns.Add("Teléfono", Type.GetType("System.String"))
		mydatatable.Columns.Add("Web", Type.GetType("System.String"))

		' Declare row
		For i = 0 To listaCodReserva.Count - 1
			Dim myrow As DataRow
			' create new row
			myrow = mydatatable.NewRow
			myrow("Código de la reserva") = listaCodReserva(i).ToString
			myrow("Fecha reserva") = listaFechaReserva(i).ToString
			myrow("Fecha entrada") = listaFechaEntrada(i).ToString
			myrow("Fecha salida") = listaFechaSalida(i).ToString
			myrow("Nombre alojamiento") = listaNombreAlojamiento(i).ToString
			myrow("Dirección") = listaDireccion(i).ToString
			myrow("Localización") = listaLocalizacion(i).ToString
			myrow("Email") = listaEmail(i).ToString
			myrow("Teléfono") = listaTelefono(i).ToString
			myrow("Web") = listaWeb(i).ToString
			mydatatable.Rows.Add(myrow)
		Next

		GridView1.DataSource = mydatatable
		GridView1.DataBind()

	End Sub

	Protected Sub cargarDatosReservaSeleccionada()
		Try
			conn.Close() 'Cerramos la conexion a la BBDD

			conn.Open() 'Abrimos la conexion a la BBDD
			Dim query As String = "select R.cReserva, R.cFechaEntrada, R.cFechaSalida, R.cFechaRealizada, R.cCodUsuario,U.cNombre ""NombreUsuario"" ,U.cApellidos,U.cTelefono,R.cCodAlojamiento,A.cNombre ""NombreAlojamiento""   from treservas R, talojamientos A, tusuarios U where R.cCodAlojamiento=A.cCodAlojamiento and R.cCodUsuario=U.cDni and R.cReserva= " & codReservIntroducido.ToString
			Dim cmd As New MySqlCommand(query, conn)

			cmd.ExecuteNonQuery()

			Dim comando As New MySqlCommand(query, conn)
			Dim Datos As MySqlDataReader = comando.ExecuteReader

			If Datos.Read Then

				txtBoxCodReserva.Text = Datos("cReserva")
				txtBoxFechaEntrada.Text = Datos("cFechaEntrada")
				txtBoxFechaSalida.Text = Datos("cFechaSalida")
				txtBoxFechaReserva.Text = Datos("cFechaRealizada")
				txtBoxDni.Text = Datos("cCodUsuario")
				txtBoxNombre.Text = Datos("NombreUsuario")
				txtBoxApellidos.Text = Datos("cApellidos")
				txtBoxTelefono.Text = Datos("cTelefono")
				txtBoxCodAlojamiento.Text = Datos("cCodAlojamiento")
				txtBoxNombreAlojamiento.Text = Datos("NombreAlojamiento")

			End If

		Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
        End Try
    End Sub
#End Region

#Region "BOTONES CABECERA"

    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Response.Redirect("Inicio.aspx") 'Ir a la página de inicio
    End Sub



#End Region
#Region "Botones"
    Protected Sub btnNuevaReserva_Click(sender As Object, e As EventArgs) Handles btnNuevaReserva.Click
        Response.Redirect("Inicio.aspx") 'Ir a la página de inicio
    End Sub
    Protected Sub btnModificarEliminar_Click(sender As Object, e As EventArgs) Handles btnModificarEliminar.Click
        divOpcionesModificarEliminar.Visible = True
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtBoxCodReservIntroducido.Text <> Nothing Then
            codReservIntroducido = txtBoxCodReservIntroducido.Text
            cargarDatosReservas()
        End If

        If listaCodReserva.Contains(0) Then
            divModificarReservas.Visible = True
            cargarDatosReservaSeleccionada()
        ElseIf listaCodReserva.Contains(codReservIntroducido) Then
            divModificarReservas.Visible = True
            cargarDatosReservaSeleccionada()
        ElseIf codReservIntroducido = Nothing Then
            MsgBox("Debe introducir el código de la reserva que desea modificar/eliminar", MsgBoxStyle.MsgBoxSetForeground)




            MsgBox("El código introducido no pertenece a ninguna de sus reservas.", MsgBoxStyle.MsgBoxSetForeground)
        End If

    End Sub
    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        fechaEntradaIntroducida = txtBoxFechaEntrada.Text
        fechaSalidaIntroducida = txtBoxFechaSalida.Text
        If fechaEntradaIntroducida > thisDay And fechaSalidaIntroducida >= fechaEntradaIntroducida Then
            'Se cargan las fechas nuevas introducidas por el usuario
            fechaReservaIntroducida = txtBoxFechaReserva.Text

            'Se modifica la fecha en la BBDD
            Try
                conn.Open()

                Dim query As String = "UPDATE `treservas` SET `cFechaEntrada` = '" & Format(fechaEntradaIntroducida, "yyyy/MM/dd") & " 00:00:00', `cFechaRealizada` = '" & Format(fechaReservaIntroducida, "yyyy/MM/dd") & " 00:00:00', `cFechaSalida` = '" & Format(fechaSalidaIntroducida, "yyyy/MM/dd") & " 00:00:00' WHERE `treservas`.`cReserva` =" & txtBoxCodReserva.Text.ToString
                Dim cmd As New MySqlCommand(query, conn)

                'cmd.Parameters.AddWithValue("?id", id)

                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
                MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
            End Try

            'Una vez modificada la reserva se actualizan los datos de la tabla
            MsgBox("La reserva se modificó.", MsgBoxStyle.MsgBoxSetForeground, "Reserva")

            cargarDatosReservas()
            rellenarTablaDetallesReservas()
        Else
            MsgBox("Las fechas deben ser superiores a la actual", MsgBoxStyle.MsgBoxSetForeground, "Reserva")

        End If

        'Para pruebas
        ' lblPruebasFechas.Text = Format(fechaReservaIntroducida, "yyyy/MM/dd") & Format(fechaEntradaIntroducida, "yyyy/MM/dd") & Format(fechaSalidaIntroducida, "yyyy/MM/dd")
    End Sub
    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        'Si el usuario está logeado, realizar reserva
        Dim resp As MsgBoxResult
        resp = MsgBox("¿Está seguro de que desea eliminar su reserva? Si continúa su reserva se eliminará permanentemente.", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.MsgBoxSetForeground, "Reserva")
        If resp = MsgBoxResult.Yes Then
            eliminarReserva()
            MsgBox("La reserva se eliminó.", MsgBoxStyle.MsgBoxSetForeground, "Reserva")

            'Se vuelven a cargar los datos de la tabla
            cargarDatosReservas()
            rellenarTablaDetallesReservas()

            'Se hace invisible el div que contiene fechas (luego se hace visible cuando se pulse el botón reservar)
            divOpcionesModificarEliminar.Visible = False
            divModificarReservas.Visible = False
        Else
            MsgBox("La reserva no se eliminó.", MsgBoxStyle.MsgBoxSetForeground, "Reserva")
        End If



    End Sub
    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        divModificarReservas.Visible = False
    End Sub
#End Region

    Protected Sub eliminarReserva()
        Try
            '  Dim conn As New MySqlConnection("Server=192.168.101.24; Database=alojamientos; Uid=grupoAlojamientos; Pwd=123456")
            conn.Open()

            Dim query As String = "DELETE FROM treservas where cReserva=" & txtBoxCodReserva.Text.ToString
            Dim cmd As New MySqlCommand(query, conn)

            'cmd.Parameters.AddWithValue("?id", id)

            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
        End Try
    End Sub

    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        Session.RemoveAll()
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Inicio.aspx", False)

    End Sub
End Class