Imports MySql.Data.MySqlClient

Public Class Index
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Rellenar dropdown tipo alojamientos
        Dim query As New MySqlDataAdapter("SELECT DISTINCT lodgingtype FROM talojamientos ORDER BY lodgingtype ASC", conexion)
        Dim campoTexto As New DataTable()
        query.Fill(campoTexto)
        Dim numero As Integer = campoTexto.Rows.Count
        For i = 0 To campoTexto.Rows.Count - 1
            ddlTipoAloj.Items.Add(campoTexto.Rows(i).Item(0))
        Next

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Session("tbBusqueda") = tbBusqueda.Text
        Response.Redirect("Alojamientos.aspx")
        'Dim query As New MySqlDataAdapter("SELECT documentname FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion in " &
        '                                  "(SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc, tmunicipio mun, tterritorio ter, tpais pais " &
        '                                  "WHERE(Loc.territorycode = (SELECT territorycode FROM tterritorio WHERE territory Like '%Biz%')) " &
        '                                  "Or (loc.countrycode = (SELECT countrycode FROM tpais WHERE country Like '%Biz%')) " &
        '                                  "Or (loc.municipalitycode = (SELECT municipalitycode FROM tmunicipio WHERE municipality like '%Biz%'))) ", conexion)
        '
        'Dim campoTexto As New DataTable()
        'query.Fill(campoTexto)
        'Dim numero As Integer = campoTexto.Rows.Count
        'For i = 0 To campoTexto.Rows.Count - 1
        '    ddlTipoAloj.Items.Add(campoTexto.Rows(i).Item(0))
        'Next

    End Sub
End Class