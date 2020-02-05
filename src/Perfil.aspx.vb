Imports MySql.Data.MySqlClient
Public Class Perfil
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Public metodos As Metodos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Session("SesionUsuario") Is Nothing) Then
            Response.Redirect("Login.aspx")
        Else
            cargarReservas()
        End If

    End Sub

    Protected Sub cargarReservas()
        Try
            Dim query As New MySqlDataAdapter("SELECT idReserva from reserva where idDni = '" & Session("SesionId") & "'", conexion)
            Dim campoTexto As New DataTable()
            query.Fill(campoTexto)
            Dim numero As Integer = campoTexto.Rows.Count

            If (numero <> 0) Then
                For i = 0 To campoTexto.Rows.Count - 1
                    phReservas.Controls.Add(New LiteralControl("<div class='card'> " & campoTexto.Rows(i).Item(0)))
                    Dim btnBorrarReserva As New Button()
                    btnBorrarReserva.ID = campoTexto.Rows(i).Item(0)
                    btnBorrarReserva.Text = "Cancelar reserva"
                    AddHandler btnBorrarReserva.Click, AddressOf btnBorrar_Click
                    phReservas.Controls.Add(btnBorrarReserva)
                    phReservas.Controls.Add(New LiteralControl("</div>"))
                Next
            Else
                Dim sinReserva As New Label
                sinReserva.Text = "No hay reservas realizadas"
                sinReserva.Font.Size = FontUnit.XLarge
                phReservas.Controls.Add(sinReserva)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ClientID

        conexion.Open()
        Dim cmd = New MySqlCommand("Delete from reserva where idReserva = @idReserva", conexion)

        cmd.Parameters.AddWithValue("@idReserva", id)
        cmd.ExecuteNonQuery()
        conexion.Close()

        Response.Redirect("Perfil.aspx")

    End Sub

    Protected Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Metodos.logout()
    End Sub

End Class