Public Class Territorio
	Public id As Char()
	Public nombre As String

	Public Sub New(id() As Char, nombre As String)
		Me.id = id
		Me.nombre = nombre
	End Sub
End Class
