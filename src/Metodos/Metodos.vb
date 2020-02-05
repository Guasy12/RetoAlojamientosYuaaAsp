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
        Try
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

    Public Function queryBusqueda() As MySqlDataAdapter
        Try
            Dim busqueda = UCase(Session("tbBusqueda"))
            Dim tipoAloj = UCase(Session("ddlTipoAloj"))
            Dim checkInString = UCase(Session("tbCheckIn"))
            Dim checkOutString = UCase(Session("tbCheckOut"))
            Dim queryDA As MySqlDataAdapter
            Dim condicionTipoAlojamiento As String = " AND UPPER(lodgingtype) LIKE '%" & tipoAloj & "%'"
            Dim condicionFechasDisponibilidad As String = ""
            If checkInString <> "" And checkOutString <> "" Then
                Dim checkInDate As DateTime = Convert.ToDateTime(checkInString)
                Dim checkOutDate As DateTime = Convert.ToDateTime(checkOutString)
                If DateTime.Compare(checkInDate, checkOutDate) < 0 Then
                    checkInString = checkInDate.ToString("yyyy-MM-dd")
                    checkOutString = checkOutDate.ToString("yyyy-MM-dd")
                    condicionFechasDisponibilidad = " AND idAlojamiento NOT IN(SELECT idAlojamiento FROM reserva res WHERE (CAST(res.fechaEntrada AS DATE) BETWEEN CAST('" & checkInString & "' AS DATE) AND CAST('" & checkOutString & "' AS DATE)) OR (CAST(res.fechaSalida AS DATE)BETWEEN CAST('" & checkInString & "' AS DATE) AND CAST('" & checkOutString & "' AS DATE)))"
                End If
            End If

            If busqueda <> "" Then
                If tipoAloj = "ALOJAMIENTOS" Then
                    condicionTipoAlojamiento = ""
                End If
                Dim sqlBusquedaPorNombre As String = "SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, loc.municipality, loc.territory,loc.country " &
                                               "FROM talojamientos aloj, tlocalizacion loc " &
                                               "WHERE aloj.localizacion_idLocalizacion = loc.idLocalizacion AND (UPPER(documentname) LIKE '%" & busqueda & "%'" & condicionTipoAlojamiento &
                                               " OR idAlojamiento IN(" &
                                                    "SELECT idAlojamiento FROM talojamientos aloj WHERE aloj.localizacion_idLocalizacion IN(" &
                                                        "SELECT DISTINCT loc.idLocalizacion FROM tlocalizacion loc " &
                                                        "WHERE UPPER(territory) LIKE '%" & busqueda & "%' OR UPPER(country) LIKE '%" & busqueda & "%' OR UPPER(municipality) LIKE '%" & busqueda & "%')" &
                                                    ")" & condicionTipoAlojamiento &
                                               ")" & condicionFechasDisponibilidad &
                                               "ORDER BY aloj.idAlojamiento ASC"
                queryDA = New MySqlDataAdapter(sqlBusquedaPorNombre, conexion)
            Else
                If tipoAloj = "ALOJAMIENTOS" Then
                    condicionTipoAlojamiento = ""
                End If
                Dim sqlBusquedaSinNombre As String = "SELECT idAlojamiento,documentname,tourismemail,web,turismdescription,lodgingtype,loc.postalcode, loc.address, loc.municipality, loc.territory,loc.country " &
                                               "FROM talojamientos aloj, tlocalizacion loc " &
                                               "WHERE aloj.localizacion_idLocalizacion = loc.idLocalizacion" &
                                               condicionTipoAlojamiento & condicionFechasDisponibilidad &
                                               " ORDER BY aloj.idAlojamiento ASC"
                queryDA = New MySqlDataAdapter(sqlBusquedaSinNombre, conexion)
            End If
            Return queryDA
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function queryAlojamientoPorId(id As String) As Alojamiento
        Dim busqueda = UCase(Session("tbBusqueda"))
        Dim tipoAloj = UCase(Session("ddlTipoAloj"))
        Dim queryAloj As New MySqlDataAdapter("SELECT * " &
                                       "FROM talojamientos aloj, tlocalizacion loc " &
                                       "WHERE aloj.localizacion_idLocalizacion = loc.idLocalizacion and aloj.idAlojamiento='" & id & "'", conexion)

        Dim alojsDS As DataSet = New DataSet
        queryAloj.Fill(alojsDS, "Alojamiento")
        Dim aloj As Alojamiento
        Dim loc As Localizacion
        For Each cmp As DataRow In alojsDS.Tables(0).Rows
            loc = New Localizacion(cmp("idLocalizacion").ToString(), cmp("postalcode").ToString(), cmp("address").ToString(), cmp("latwgs84").ToString(), cmp("lonwgs84").ToString(), cmp("country").ToString(), cmp("territory").ToString(), cmp("municipality").ToString())
            aloj = New Alojamiento(id, cmp("capacity"), cmp("documentname").ToString(), cmp("turismdescription").ToString(), cmp("tourismemail").ToString(), cmp("phone").ToString(), cmp("lodgingtype").ToString(), cmp("web").ToString(), loc)
        Next

        Return aloj
    End Function

End Class
