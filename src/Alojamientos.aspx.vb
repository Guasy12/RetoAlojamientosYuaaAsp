Imports System.Net.WebRequestMethods
Imports MySql.Data.MySqlClient

Public Class Alojamientos
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        busqueda()

    End Sub

    Sub busqueda()
        Dim busqueda = UCase(Session("tbBusqueda"))
        Dim tipoAloj = UCase(Session("ddlTipoAloj"))


        Dim query As New MySqlDataAdapter("SELECT documentname FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion in " &
                                          "(SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc, tmunicipio mun, tterritorio ter, tpais pais " &
                                          "WHERE(Loc.territorycode = (SELECT territorycode FROM tterritorio WHERE UPPER(territory) Like '%" & busqueda & "%')) " &
                                          "Or (loc.countrycode = (SELECT countrycode FROM tpais WHERE UPPER(country) Like '%" & busqueda & "%')) " &
                                          "Or (loc.municipalitycode = (SELECT municipalitycode FROM tmunicipio WHERE UPPER(municipality) like '%" & busqueda & "%')))" &
                                          "And UPPER(lodgingtype) = '" & tipoAloj & "' ", conexion)

        Dim campoTexto As New DataTable()
        query.Fill(campoTexto)
        Dim numero As Integer = campoTexto.Rows.Count

        For i = 0 To campoTexto.Rows.Count - 1
            Dim lbl As New Label
            lbl.Text = (i + 1) & " - " & campoTexto.Rows(i).Item(0)
            Me.Controls.Add(lbl)
            Me.Controls.Add(New LiteralControl("<br />"))
        Next
    End Sub

End Class