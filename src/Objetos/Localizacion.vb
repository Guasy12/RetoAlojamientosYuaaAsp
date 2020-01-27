Public Class Localizacion
	Public id As Char()
	Public codPostal, direccion, latitud, longitud As String
	Public pais As Pais
	Public territorio As Territorio
	Public municipio As Municipio

	Public Sub New(id() As Char, codPostal As String, direccion As String, latitud As String, longitud As String, pais As Pais, territorio As Territorio, municipio As Municipio)
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
