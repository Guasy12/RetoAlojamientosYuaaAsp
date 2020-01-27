Imports MySql.Data.MySqlClient

Public Class Reserva
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim query As New MySqlDataAdapter("SELECT documentname, Loc.latwgs84, Loc.lonwgs84 " &
                                             "from talojamientos aloj, tlocalizacion loc " &
                                             "where aloj.localizacion_idLocalizacion = loc.idLocalizacion and aloj.idAlojamiento = " & Request.QueryString("idAlojamiento"), conexion)
        Dim campoTexto As New DataTable()
        query.Fill(campoTexto)

        HiddenFieldNombre.Value = campoTexto.Rows(0).Item(0)
        HiddenFieldLat.Value = campoTexto.Rows(0).Item(1)
        HiddenFieldLon.Value = campoTexto.Rows(0).Item(2)
    End Sub

End Class