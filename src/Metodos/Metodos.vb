Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient

Public Class Metodos
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Public Function MD5EncryptPass(ByVal StrPass As String)
        Dim md5 As MD5CryptoServiceProvider
        Dim bytValue() As Byte
        Dim bytHash() As Byte
        Dim txtEncriptado As String
        Dim i As Integer
        txtEncriptado = ""

        md5 = New MD5CryptoServiceProvider
        bytValue = Text.Encoding.UTF8.GetBytes(StrPass)
        bytHash = md5.ComputeHash(bytValue)
        md5.Clear()

        For i = 0 To bytHash.Length - 1
            txtEncriptado &= bytHash(i).ToString("x").PadLeft(2, "0")
        Next

        Return txtEncriptado
    End Function

    Public Sub logout()

        Session("SesionId") = Nothing
        Session("SesionUsuario") = Nothing
    End Sub

    Public Function recogerTipoAlojamientos()
        'Recoger tipo alojamientos
        Dim query As New MySqlDataAdapter("SELECT DISTINCT lodgingtype FROM talojamientos ORDER BY lodgingtype ASC", conexion)
        Dim campoTexto As New DataTable()
        query.Fill(campoTexto)
        Dim numero As Integer = campoTexto.Rows.Count
        Dim tipos(campoTexto.Rows.Count - 1) As String
        tipos(0) = "Alojamientos"
        For i = 1 To campoTexto.Rows.Count - 1
            tipos(i) = campoTexto.Rows(i).Item(0)
        Next
        Return tipos
    End Function

    Public Function queryBusqueda() As MySqlDataAdapter

        Dim busqueda = UCase(Session("tbBusqueda"))
        Dim tipoAloj = UCase(Session("ddlTipoAloj"))
        Dim queryDA As MySqlDataAdapter

        If busqueda <> "" And tipoAloj = "ALOJAMIENTOS" Then

            queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
                                           "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
                                           "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode and " &
                                           "(UPPER(documentname) like '%" & busqueda & "%' or idAlojamiento in" &
                                           "(SELECT idAlojamiento FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion in " &
                                           "(SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc, tmunicipio mun, tterritorio ter, tpais pais " &
                                           "WHERE(Loc.territorycode in (SELECT territorycode FROM tterritorio WHERE UPPER(territory) Like '%" & busqueda & "%')) " &
                                           "Or (loc.countrycode in (SELECT countrycode FROM tpais WHERE UPPER(country) Like '%" & busqueda & "%')) " &
                                           "Or (loc.municipalitycode in (SELECT municipalitycode FROM tmunicipio WHERE UPPER(municipality) like '%" & busqueda & "%'))))) " &
                                           "ORDER BY aloj.idAlojamiento ASC", conexion)

        ElseIf busqueda <> "" Then
            queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
                                           "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
                                           "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode and " &
                                           "(UPPER(documentname) like '%" & busqueda & "%' or idAlojamiento in" &
                                           "(SELECT idAlojamiento FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion in " &
                                           "(SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc, tmunicipio mun, tterritorio ter, tpais pais " &
                                           "WHERE(Loc.territorycode in (SELECT territorycode FROM tterritorio WHERE UPPER(territory) Like '%" & busqueda & "%')) " &
                                           "Or (loc.countrycode in (SELECT countrycode FROM tpais WHERE UPPER(country) Like '%" & busqueda & "%')) " &
                                           "Or (loc.municipalitycode in (SELECT municipalitycode FROM tmunicipio WHERE UPPER(municipality) like '%" & busqueda & "%')))" &
                                           "And UPPER(lodgingtype) like '%" & tipoAloj & "%')) ORDER BY aloj.idAlojamiento ASC", conexion)

        ElseIf tipoAloj = "ALOJAMIENTOS" Then
            queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
                                           "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
                                           "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode " &
                                           "ORDER BY aloj.idAlojamiento ASC", conexion)
        Else

            queryDA = New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, mun.municipality, ter.territory,pais.country " &
                                           "from talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
                                           "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode " &
                                           "and (UPPER(lodgingtype) Like '%" & tipoAloj & "%') ORDER BY aloj.idAlojamiento ASC", conexion)
        End If

        Return queryDA
    End Function

    Public Function queryAlojamientoPorId(id As String) As Alojamiento

        Dim busqueda = UCase(Session("tbBusqueda"))
        Dim tipoAloj = UCase(Session("ddlTipoAloj"))
        Dim queryAloj As New MySqlDataAdapter("SELECT * " &
                                       "FROM talojamientos aloj, tlocalizacion loc, tmunicipio mun, tpais pais, tterritorio ter " &
                                       "WHERE aloj.localizacion_idLocalizacion = loc.idLocalizacion and loc.municipalitycode = mun.municipalitycode and loc.countrycode = pais.countrycode and loc.territorycode = ter.territorycode and aloj.idAlojamiento='" & id & "'", conexion)


        Dim alojsDS As DataSet = New DataSet
        queryAloj.Fill(alojsDS, "Alojamiento")
        Dim aloj As Alojamiento
        For Each cmp As DataRow In alojsDS.Tables(0).Rows
            aloj = New Alojamiento()
        Next

        Return aloj
    End Function

End Class
