Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Reserva
    Inherits System.Web.UI.Page
    Public conexion As New MySqlConnection
    Public con As New MySqlConnection("Server=192.168.0.7; Database=alojamientos; Uid=grupoAlojamientos; Pwd=123456")
    Public adapter As New MySqlDataAdapter("SELECT * FROM TALOJAMIENTOS", con)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then ' Estos eventos ocurrirán sólo la primer vez que se inicie la página
            cargarDatosReserva()
            BindGrid()
            'cargarDatosGridView()

            'Se hace invisible el div que contiene fechas (luego se hace visible cuando se pulse el botón reservar)
            divModificarReservas.Visible = False

        End If


    End Sub

    Private Sub BindGrid()
        Dim mydatatable As New DataTable
        '' Create columns
        mydatatable.Columns.Add("Código de la reserva", Type.GetType("System.String"))
        mydatatable.Columns.Add("Fecha reserva", Type.GetType("System.String"))
        mydatatable.Columns.Add("Fecha entrada", Type.GetType("System.String"))
        mydatatable.Columns.Add("Fecha salida", Type.GetType("System.String"))
        mydatatable.Columns.Add("Nombre alojamiento", Type.GetType("System.String"))
        mydatatable.Columns.Add("Nombre", Type.GetType("System.String"))
        mydatatable.Columns.Add("Apellidos", Type.GetType("System.String"))
        mydatatable.Columns.Add("Teléfono", Type.GetType("System.String"))
        '' Declare row
        'Dim myrow As DataRow
        '' create new row
        'myrow = mydatatable.NewRow
        'myrow("cReserva") = "a"
        'myrow("Fecha reserva") = "aaa"
        'myrow("Fecha entrada") = "aaa"
        'myrow("Fecha salida") = "aaa"
        'myrow("Nombre") = "aaa"
        'myrow("Nombre") = "aaa"
        'myrow("Apellidos") = "aaa"
        'myrow("Telefono") = "aaa"

        ' Create columns
        'mydatatable.Columns.Add("field_a", Type.GetType("System.String"))
        ' mydatatable.Columns.Add("field_b", Type.GetType("System.String"))
        ' Declare row
        Dim myrow As DataRow
        ' create new row
        myrow = mydatatable.NewRow
        myrow("Código de la reserva") = "aaa"
        myrow("Fecha reserva") = "aaa"
        myrow("Fecha entrada") = "aaa"
        myrow("Fecha salida") = "aaa"
        myrow("Nombre alojamiento") = "aaa"
        myrow("Nombre") = "aaa"
        myrow("Apellidos") = "aaa"
        myrow("Teléfono") = "aaa"
        mydatatable.Rows.Add(myrow)

        GridView1.DataSource = mydatatable
        GridView1.DataBind()



        '    Using conect As New SqlConnection("Server=192.168.0.7; Database=alojamientos; Uid=grupoAlojamientos; Pwd=123456")
        '        Using cmd As New SqlCommand("SELECT * FROM TALOJAMIENTOS")
        '            Using sda As New SqlDataAdapter()
        '                cmd.Connection = conect
        '                MsgBox("Conectado1")
        '                sda.SelectCommand = cmd
        '                MsgBox("Conectado2")
        '                Using dt As New DataTable()
        '                    sda.Fill(dt)
        '                    GridView1.DataSource = dt
        '                    GridView1.DataBind()
        '                End Using
        '            End Using
        '        End Using
        '    End Using
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        Me.BindGrid()
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
#Region "Botones"
    Protected Sub btnModificarReserva_Click(sender As Object, e As EventArgs) Handles btnModificarReserva.Click
        divModificarReservas.Visible = True
    End Sub
    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        divModificarReservas.Visible = False
    End Sub
#End Region

#Region "DatosReservas"
    Protected Sub cargarDatosReserva()
        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()
            Dim servidor As String = "localhost"
            Dim usuario As String = "grupoAlojamientos"
            Dim pswd As String = "123456"
            Dim database As String = "alojamientos"
            'Establecemos los parametros de la conexion a la BBDD
            conexion.ConnectionString = "server=" & servidor & ";" & "database=" & database & ";" & "user id=" & usuario & ";" & "password=" & pswd & ";"
            conexion.Open()
            'Abrimos la conexion a la BBDD
            MsgBox("Conectado")

            'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL


            Dim sql As String = "select R.cReserva, R.cFechaEntrada, R.cFechaSalida, R.cFechaRealizada, R.cCodUsuario,U.cNombre ""NombreUsuario"" ,U.cApellidos,U.cTelefono,R.cCodAlojamiento,A.cNombre ""NombreAlojamiento""   from treservas R, talojamientos A, tusuarios U where R.cCodAlojamiento=A.cCodAlojamiento and R.cCodUsuario=U.cDni  ;"

            Dim comando As New MySqlCommand(sql, conexion)



            Dim Datos As MySqlDataReader = comando.ExecuteReader
            If Datos.Read Then
                Dim usuarioIntroducido = Request.QueryString("ID")
                ' usuarioIntroducido = Session("Mivar")
                Label1.Text = usuarioIntroducido

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
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub cargarDatosGridView()


        Try
            Dim sql As String
            Dim cn As MySqlConnection
            Dim cm As MySqlCommand
            Dim da As MySqlDataAdapter
            Dim ds As DataSet

            sql = "SELECT * FROM treservas"
            cn = New MySqlConnection("Server=192.168.0.7; Database=alojamientos; Uid=grupoAlojamientos; Pwd=123456")
            cn.Open()

            cm = New MySqlCommand()
            cm.CommandType = CommandType.Text
            cm.CommandText = sql
            da = New MySqlDataAdapter("SELECT * FROM TALOJAMIENTOS", cn)
            ds = New DataSet()
            da.Fill(ds)
            GridView1.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

#End Region
    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim conn As New MySqlConnection("Server=192.168.0.7; Database=alojamientos; Uid=grupoAlojamientos; Pwd=123456")
            conn.Open()

            Dim query As String = "DELETE FROM treservas where cReserva=3"
            Dim cmd As New MySqlCommand(query, conn)

            'cmd.Parameters.AddWithValue("?id", id)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub

End Class