Imports MySql.Data.MySqlClient

Public Class Reserva
	Inherits System.Web.UI.Page
	Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
	Public conexion As New MySqlConnection(conector)
	Public cmd As MySqlCommand

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

        If Session("tbCheckIn") <> "" And Session("tbCheckOut") <> "" Then
            Me.fechaInicio.Text = Session("tbCheckIn")
            Me.fechaFin.Text = Session("tbCheckOut")
        End If

        HiddenFieldLat.Value = aloj.localizacion.latitud
		HiddenFieldLon.Value = aloj.localizacion.longitud
	End Sub

	Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReservar.Click
        If Session("SesionUsuario") Is Nothing Then
            Response.Redirect("Login.aspx")
        Else
            If MsgBox("¿Está seguro de realizar esta reserva?", MsgBoxStyle.YesNo, MsgBoxStyle.MsgBoxSetForeground) = MsgBoxResult.Yes Then

                Try

                    Dim query As New MySqlDataAdapter("SELECT MAX(idReserva) from reserva", conexion)
                    Dim campoTexto As New DataTable()
                    query.Fill(campoTexto)

                    conexion.Open()
                    cmd = New MySqlCommand("INSERT INTO reserva (idReserva, fechaEntrada, fechaSalida, idAlojamiento, idDni) " &
                                       "VALUES (@idReserva, @fechaEntrada, @fechaSalida, @idAlojamiento, @idDni)", conexion)

                    Dim dtCheckIn = DateTime.ParseExact(fechaInicio.Text, "dd/MM/yyyy", Nothing)
                    Dim dtCheckOut = DateTime.ParseExact(fechaFin.Text, "dd/MM/yyyy", Nothing)


                    cmd.Parameters.AddWithValue("@idReserva", campoTexto.Rows(0).Item(0) + 1)
                    cmd.Parameters.AddWithValue("@fechaEntrada", dtCheckIn)
                    cmd.Parameters.AddWithValue("@fechaSalida", dtCheckOut)
                    cmd.Parameters.AddWithValue("@idAlojamiento", Request.QueryString("idAlojamiento"))
                    cmd.Parameters.AddWithValue("@idDni", Session("SesionId"))
                    cmd.ExecuteNonQuery()
                    conexion.Close()

                Catch ex As MySqlException
                    MsgBox(ex.Message)
                End Try
            End If
        End If

    End Sub

	Protected Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        metodos.logout()
    End Sub

    Protected Sub fechaInicio_TextChanged(sender As Object, e As EventArgs) Handles fechaInicio.TextChanged

    End Sub
End Class