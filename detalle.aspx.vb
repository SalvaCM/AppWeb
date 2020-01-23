Imports MySql.Data.MySqlClient

Public Class detalle
    Inherits System.Web.UI.Page

    Public conexion As New MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            'Establecemos los parametros de la conexion a la BBDD
            Dim connectionString = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
            conexion = New MySqlConnection(connectionString)
            conexion.Open() 'Abrimos la conexion a la BBDD


            'Query para ejecutar select de la localidad seleccionada
            Dim sql As String

            'Si se pasa por URL

            sql = "SELECT cNombre, cDescripcion, cLocalidad, cDireccion, cEmail, cTelefono FROM tAlojamientos WHERE cNombre = '" & Session("aloj") & "' ;"



            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            While Datos.Read

                lblNombre.Text = Datos(0)
                lblDesc.Text = Datos(1)
                lblLocalidad.Text = Datos(2)
                lblDirec.Text = Datos(3)
                lblCorreo.Text = Datos(4)
                lblTelefono.Text = Datos(5)

            End While
            conexion.Close()
        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message, MsgBoxStyle.MsgBoxSetForeground)
        End Try
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Inicio.aspx")
    End Sub
End Class