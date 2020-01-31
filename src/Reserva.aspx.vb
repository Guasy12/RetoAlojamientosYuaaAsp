Imports MySql.Data.MySqlClient

Public Class Reserva
	Inherits System.Web.UI.Page
	Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
	Public conexion As New MySqlConnection(conector)

	Public alojamiento As Alojamiento
	Private metodos As New Metodos
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		alojamiento = metodos.queryAlojamientoPorId(Request.QueryString("idAlojamiento"))
		rellenarDatosEnUI(alojamiento)

		'Dim query As New MySqlDataAdapter("SELECT documentname, Loc.latwgs84, Loc.lonwgs84 " &
		'									 "from talojamientos aloj, tlocalizacion loc " &
		'									 "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and aloj.idAlojamiento = " & Request.QueryString("idAlojamiento"), conexion)
		'Dim campoTexto As New DataTable()
		'query.Fill(campoTexto)
		'HiddenFieldNombre.Value = campoTexto.Rows(0).Item(0)
		'HiddenFieldLat.Value = campoTexto.Rows(0).Item(1)
		'HiddenFieldLon.Value = campoTexto.Rows(0).Item(2)
	End Sub

	Private Sub rellenarDatosEnUI(aloj As Alojamiento)
		Me.lblNombreAlojamiento.Text = aloj.nombre
		Me.lblTelefonoAlojamiento.Text = aloj.telefono
		Me.lblTipoAlojamiento.Text = aloj.tipo
		Me.lblWebAlojmaiento.Text = aloj.web
		Me.lblEmailAlojamiento.Text = aloj.email
		Me.lblDescripcionAlojamiento.Text = aloj.descripcion

		Me.lblCodPostal.Text = aloj.localizacion.codPostal
		Me.lblDireccionAloj.Text = aloj.localizacion.direccion
		Me.lblMunicipio.Text = aloj.localizacion.municipio
		Me.lblTerritorio.Text = aloj.localizacion.territorio

		HiddenFieldLat.Value = aloj.localizacion.latitud
		HiddenFieldLon.Value = aloj.localizacion.longitud
	End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReservar.Click
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        metodos.logout()
    End Sub
End Class