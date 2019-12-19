Imports MySql.Data.MySqlClient
Public Class Inicio
    Inherits System.Web.UI.Page
    Public conexion As New MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Cerramos la conexion a la BBDD
            conexion.Close()
            Dim servidor As String = "localhost"
            Dim usuario As String = "grupoAlojamientos"
            Dim pswd As String = "123456"
            Dim database As String = "talojamientos"
            'Establecemos los parametros de la conexion a la BBDD
            conexion.ConnectionString = "server=" & servidor & ";" & "database=" & database & ";" & "user id=" & usuario & ";" & "password=" & pswd & ";"
            conexion.Open()
            'Abrimos la conexion a la BBDD

            'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL



            Dim sql As String = "SELECT * FROM tabla  ;"

            Dim comando As New MySqlCommand(sql, conexion)

            Dim Datos As MySqlDataReader = comando.ExecuteReader
            If Datos.Read Then


                ListBox1.Items.Add(Datos(0) & "" & Datos(1))


            End If

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub

End Class