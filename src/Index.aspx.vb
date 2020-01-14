Imports MySql.Data.MySqlClient

Public Class Index
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim query As New MySqlDataAdapter("SELECT DISTINCT lodgingtype FROM talojamientos ORDER BY lodgingtype ASC", conexion)
        Dim campoTexto As New DataTable()
        query.Fill(campoTexto)
        Dim numero As Integer = campoTexto.Rows.Count
        For i = 0 To campoTexto.Rows.Count - 1
            ddlTipoAloj.Items.Add(campoTexto.Rows(i).Item(0))
        Next

    End Sub

End Class