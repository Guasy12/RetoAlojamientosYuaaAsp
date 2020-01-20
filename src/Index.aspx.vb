Imports MySql.Data.MySqlClient

Public Class Index
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        cargarTipoAlojamientos()
        cargarTarjetasInfomacion()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Application("tbBusqueda") = tbBusqueda.Text
        Application("ddlTipoAloj") = ddlTipoAloj.SelectedItem.Text
        Response.Redirect("Alojamientos.aspx")

    End Sub


    Protected Sub cargarTipoAlojamientos()
        'Rellenar dropdown tipo alojamientos
        Dim query As New MySqlDataAdapter("SELECT DISTINCT lodgingtype FROM talojamientos ORDER BY lodgingtype ASC", conexion)
        Dim campoTexto As New DataTable()
        query.Fill(campoTexto)
        Dim numero As Integer = campoTexto.Rows.Count
        ddlTipoAloj.Items.Add("Alojamientos")
        For i = 0 To campoTexto.Rows.Count - 1
            ddlTipoAloj.Items.Add(campoTexto.Rows(i).Item(0))
        Next
    End Sub

    Protected Sub cargarTarjetasInfomacion()


        Dim query As New MySqlDataAdapter("SELECT idAlojamiento,documentname,tourismemail,web,turismdescription FROM talojamientos ORDER BY RAND() LIMIT 2 ", conexion)

        Dim campoTexto As New DataTable()
        query.Fill(campoTexto)
        Dim numero As Integer = campoTexto.Rows.Count

        For i = 0 To campoTexto.Rows.Count - 1

            phInformacion.Controls.Add(New LiteralControl("<div class='card'>" &
                                                      "<h2>" & campoTexto.Rows(i).Item(1) & "</h2>" &
                                                      "<h5>" & campoTexto.Rows(i).Item(2) & "</h5>" &
                                                      "<div class='fakeimg'></div>" &
                                                      "<p>" & campoTexto.Rows(i).Item(3) & "</p>" &
                                                      "<p>" & campoTexto.Rows(i).Item(4) & "</p>" &
                                                      "</div>"))

        Next


    End Sub

End Class