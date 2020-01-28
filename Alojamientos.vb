

Public Class Alojamientos
	Inherits System.Object

	Private _codAlojamiento As Integer = -1
	Private _nombre As String = String.Empty
	Private _descripcion As String = String.Empty


	Public Sub New(ByVal id As Integer)

		Init(id, String.Empty, String.Empty, 0, 0)

	End Sub



	Public Sub New(ByVal id As Integer, ByVal name As String, ByVal descripcion As String)

		Init(id, name, descripcion, 0, 0)

	End Sub



	Private Sub Init(ByVal id As Integer, ByVal name As String, ByVal category As String, ByVal price As Double, ByVal rating As Integer)

		Dim _id As Integer = id

		Dim _name As String = name

		Dim _category As String = category


	End Sub



	Public ReadOnly Property ID() As Integer

		Get

			Return _codAlojamiento

		End Get

	End Property



	Public Property Name() As String

		Get

			Return _nombre

		End Get

		Set(ByVal value As String)

			_nombre = value

		End Set

	End Property



	Public Property Descripcion() As String

		Get

			Return _descripcion

		End Get

		Set(ByVal value As String)

			_descripcion = value

		End Set

	End Property

End Class

