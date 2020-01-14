Public Class Index
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString;
    Public conexion As New MySqlConnection(conector)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class