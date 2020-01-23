Public Class Alojamiento

	Public id, capacidad As Integer
	Public nombre, descripcion, email, telefono, tipo, web As String
	Public localizacion As Localizacion

	Public Sub New(id As Integer, capacidad As Integer, nombre As String, descripcion As String, email As String, telefono As String, tipo As String, web As String, localizacion As Localizacion)
		Me.id = id
		Me.capacidad = capacidad
		Me.nombre = nombre
		Me.descripcion = descripcion
		Me.email = email
		Me.telefono = telefono
		Me.tipo = tipo
		Me.web = web
		Me.localizacion = localizacion
	End Sub
End Class
