Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub registro_Click(sender As Object, e As EventArgs) Handles registro.Click
        Response.Redirect("Registro.aspx")
    End Sub
End Class