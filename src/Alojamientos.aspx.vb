Imports System.Net.WebRequestMethods
Imports MySql.Data.MySqlClient

Public Class Alojamientos
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Public metodos As New Metodos

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        cargarTipoAlojamientos()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        buscar()

    End Sub

    Protected Sub cargarTipoAlojamientos()
        Dim tipos() As String = Metodos.recogerTipoAlojamientos
        For i = 0 To tipos.Length - 1
            ddlTipoAloj.Items.Add(tipos(i))
        Next
    End Sub
    'Private Function queryBusqueda()
    '
    '    Dim busqueda = UCase(Application("tbBusqueda"))
    '    Dim tipoAloj = UCase(Application("ddlTipoAloj"))
    '    Dim queryDA As MySqlDataAdapter
    '
    '    If busqueda <> "" And tipoAloj = "ALOJAMIENTOS" Then
    '
    '        queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
    '                                       "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
    '                                       "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode and " &
    '                                       "(UPPER(documentname) like '%" & busqueda & "%' or idAlojamiento in" &
    '                                       "(SELECT idAlojamiento FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion in " &
    '                                       "(SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc, tmunicipio mun, tterritorio ter, tpais pais " &
    '                                       "WHERE(Loc.territorycode in (SELECT territorycode FROM tterritorio WHERE UPPER(territory) Like '%" & busqueda & "%')) " &
    '                                       "Or (loc.countrycode in (SELECT countrycode FROM tpais WHERE UPPER(country) Like '%" & busqueda & "%')) " &
    '                                       "Or (loc.municipalitycode in (SELECT municipalitycode FROM tmunicipio WHERE UPPER(municipality) like '%" & busqueda & "%'))))) " &
    '                                       "ORDER BY aloj.idAlojamiento ASC", conexion)
    '
    '    ElseIf busqueda <> "" Then
    '        queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
    '                                       "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
    '                                       "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode and " &
    '                                       "(UPPER(documentname) like '%" & busqueda & "%' or idAlojamiento in" &
    '                                       "(SELECT idAlojamiento FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion in " &
    '                                       "(SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc, tmunicipio mun, tterritorio ter, tpais pais " &
    '                                       "WHERE(Loc.territorycode in (SELECT territorycode FROM tterritorio WHERE UPPER(territory) Like '%" & busqueda & "%')) " &
    '                                       "Or (loc.countrycode in (SELECT countrycode FROM tpais WHERE UPPER(country) Like '%" & busqueda & "%')) " &
    '                                       "Or (loc.municipalitycode in (SELECT municipalitycode FROM tmunicipio WHERE UPPER(municipality) like '%" & busqueda & "%')))" &
    '                                       "And UPPER(lodgingtype) like '%" & tipoAloj & "%')) ORDER BY aloj.idAlojamiento ASC", conexion)
    '
    '    ElseIf tipoAloj = "ALOJAMIENTOS" Then
    '        queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
    '                                       "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
    '                                       "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode " &
    '                                       "ORDER BY aloj.idAlojamiento ASC", conexion)
    '    Else
    '
    '        queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
    '                                       "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
    '                                       "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode " &
    '                                       "and (UPPER(lodgingtype) Like '%" & tipoAloj & "%') ORDER BY aloj.idAlojamiento ASC", conexion)
    '    End If
    '
    '    Return queryDA
    'End Function

    Protected Sub buscar()

        Try
            Dim query As New MySqlDataAdapter
            query = metodos.queryBusqueda()

            Dim campoTexto As New DataTable()
            query.Fill(campoTexto)
            Dim numero As Integer = campoTexto.Rows.Count

            For i = 0 To campoTexto.Rows.Count - 1

                phInformacion.Controls.Add(New LiteralControl("<div class='card'>" &
                                                              "<h2>" & campoTexto.Rows(i).Item(1) & "</h2>" &
                                                              "<h5>" & campoTexto.Rows(i).Item(7) & ", " & campoTexto.Rows(i).Item(8) & ", " & campoTexto.Rows(i).Item(8) & "</h5>" &
                                                              "<h5>" & campoTexto.Rows(i).Item(5) & "</h5>" &
                                                              "<div class='fakeimg'></div>" &
                                                              "<p>" & campoTexto.Rows(i).Item(3) & "</p>" &
                                                              "<p>" & campoTexto.Rows(i).Item(4) & "</p>"))
                Dim btnReserva As New Button()
                btnReserva.ID = campoTexto.Rows(i).Item(0)
                btnReserva.Text = "Reservar"
                AddHandler btnReserva.Click, AddressOf btnReserva_Click
                phInformacion.Controls.Add(btnReserva)
                phInformacion.Controls.Add(New LiteralControl("</div>"))
            Next '
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btnReserva_Click(sender As Object, e As EventArgs)

        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ClientID
        Dim url As String = String.Format("Reserva.aspx?IdAlojamiento={0}", id)
        Response.Redirect(url)
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Session("tbBusqueda") = tbBusqueda.Text
        Session("ddlTipoAloj") = ddlTipoAloj.SelectedItem.Text
        Session("tbCheckIn") = fechaInicio.Text
        Session("tbCheckOut") = fechaFin.Text
    End Sub
End Class