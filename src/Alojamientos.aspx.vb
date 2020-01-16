﻿Imports System.Net.WebRequestMethods
Imports MySql.Data.MySqlClient

Public Class Alojamientos
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        busqueda()

    End Sub

    Sub busqueda()
        Dim busqueda = UCase(Application("tbBusqueda"))
        Dim tipoAloj = UCase(Application("ddlTipoAloj"))


        Dim query As New MySqlDataAdapter("SELECT documentname from talojamientos where UPPER(documentname) like '%" & busqueda & "%' or idAlojamiento in" &
                                          "(SELECT idAlojamiento FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion in " &
                                          "(SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc, tmunicipio mun, tterritorio ter, tpais pais " &
                                          "WHERE(Loc.territorycode in (SELECT territorycode FROM tterritorio WHERE UPPER(territory) Like '%" & busqueda & "%')) " &
                                          "Or (loc.countrycode in (SELECT countrycode FROM tpais WHERE UPPER(country) Like '%" & busqueda & "%')) " &
                                          "Or (loc.municipalitycode in (SELECT municipalitycode FROM tmunicipio WHERE UPPER(municipality) like '%" & busqueda & "%')))" &
                                          "And UPPER(lodgingtype) = '" & tipoAloj & "')", conexion)

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