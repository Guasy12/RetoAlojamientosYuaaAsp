Public Class Localizacion
	Public id As Char()
	Public codPostal, direccion, latitud, longitud, pais, territorio, municipio As String


	Public Sub New(id() As Char, codPostal As String, direccion As String, latitud As String, longitud As String, pais As String, territorio As String, municipio As String)
		Me.id = id
		Me.codPostal = codPostal
		Me.direccion = direccion
		Me.latitud = latitud
		Me.longitud = longitud
		Me.pais = pais
		Me.territorio = territorio
		Me.municipio = municipio
	End Sub
End Class
