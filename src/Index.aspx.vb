Imports MySql.Data.MySqlClient

Public Class Index
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Public metodos As New Metodos

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        cargarTipoAlojamientos()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarTarjetasInfomacion()
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Session("tbBusqueda") = tbBusqueda.Text
        Session("ddlTipoAloj") = ddlTipoAloj.SelectedItem.Text
        Session("tbCheckIn") = fechaInicio.Text
        Session("tbCheckOut") = fechaFin.Text
        Response.Redirect("Alojamientos.aspx")
    End Sub


    Protected Sub cargarTipoAlojamientos()
        Try
            Dim tipos() As String = metodos.recogerTipoAlojamientos
            For i = 0 To tipos.Length - 1
                ddlTipoAloj.Items.Add(tipos(i))
            Next
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub cargarTarjetasInfomacion()
        Try
            Dim query As New MySqlDataAdapter("SELECT idAlojamiento, documentname, tourismemail, web, turismdescription,lodgingtype , Loc.postalcode, Loc.address, mun.municipality, ter.territory, pais.country " &
                                              "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
                                              "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode " &
                                              "ORDER BY RAND() LIMIT 2 ", conexion)
            Dim campoTexto As New DataTable()
            query.Fill(campoTexto)
            Dim numero As Integer = campoTexto.Rows.Count
            For i = 0 To campoTexto.Rows.Count - 1
                phIndexInformacion.Controls.Add(New LiteralControl("<div class='card'>" &
                                                              "<h2>" & campoTexto.Rows(i).Item(1) & "</h2>" &
                                                              "<h5>" & campoTexto.Rows(i).Item(7) & ", " & campoTexto.Rows(i).Item(8) & ", " & campoTexto.Rows(i).Item(9) & "</h5>" &
                                                              "<h5>" & campoTexto.Rows(i).Item(5) & "</h5>" &
                                                              "<div class='fakeimg'></div>" &
                                                              "<p>" & campoTexto.Rows(i).Item(3) & "</p>" &
                                                              "<p>" & campoTexto.Rows(i).Item(4) & "</p>"))
                Dim btnIndexReserva As New Button()
                btnIndexReserva.ID = campoTexto.Rows(i).Item(0)
                btnIndexReserva.Text = "Reservar"
                btnIndexReserva.PostBackUrl = String.Format("Reserva.aspx?IdAlojamiento={0}", campoTexto.Rows(i).Item(0))
                phIndexInformacion.Controls.Add(btnIndexReserva)
                phIndexInformacion.Controls.Add(New LiteralControl("</div>"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        metodos.logout()
    End Sub

End Class