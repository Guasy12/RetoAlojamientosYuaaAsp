Imports MySql.Data.MySqlClient
Public Class Perfil
    Inherits System.Web.UI.Page
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Public metodos As New Metodos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Session("SesionUsuario") Is Nothing) Then
            Response.Redirect("Login.aspx")
        Else
            cargarReservas()
        End If

    End Sub

    Protected Sub cargarReservas()
        Try
            Dim query As New MySqlDataAdapter("SELECT res.idReserva, res.fechaEntrada, res.fechaSalida, taloj.documentname " &
                                              "FROM reserva res, talojamientos taloj where res.idAlojamiento = taloj.idAlojamiento and idDni = '" & Session("SesionId") & "'", conexion)
            Dim campoTexto As New DataTable()
            query.Fill(campoTexto)
            Dim numero As Integer = campoTexto.Rows.Count

            If (numero <> 0) Then
                phReservas.Controls.Add(New LiteralControl("<div class='cardReservas'>"))
                phReservas.Controls.Add(New LiteralControl("<table id='tablaReservas'> <tr>"))
                phReservas.Controls.Add(New LiteralControl("<th> Alojamiento </th>"))
                phReservas.Controls.Add(New LiteralControl("<th> Fecha entrada </th>"))
                phReservas.Controls.Add(New LiteralControl("<th> Fecha salida </th>"))
                phReservas.Controls.Add(New LiteralControl("<th>  </th> </tr>"))
                For i = 0 To campoTexto.Rows.Count - 1
                    Dim fechaEntrada As DateTime = campoTexto.Rows(i).Item(1)
                    Dim fechaSalida As DateTime = campoTexto.Rows(i).Item(2)
                    'phReservas.Controls.Add(New LiteralControl("<div class='cardReservas'> <h2 class='h2style'>" & campoTexto.Rows(i).Item(3) & "&nbsp&nbsp&nbsp&nbsp" & fechaEntrada.ToShortDateString & "&nbsp&nbsp-&nbsp&nbsp" & fechaSalida.ToShortDateString & "</h2>"))
                    Dim btnBorrarReserva As New Button()
                    btnBorrarReserva.ID = campoTexto.Rows(i).Item(0)
                    btnBorrarReserva.CssClass = "boton_cancelar_reserva"
                    btnBorrarReserva.Text = "Cancelar reserva"
                    AddHandler btnBorrarReserva.Click, AddressOf btnBorrar_Click

                    'phReservas.Controls.Add(New LiteralControl("</div>"))



                    phReservas.Controls.Add(New LiteralControl("<tr><td> " & campoTexto.Rows(i).Item(3) & " </td>"))
                    phReservas.Controls.Add(New LiteralControl("<td> " & fechaEntrada.ToShortDateString & " </td>"))
                    phReservas.Controls.Add(New LiteralControl("<td> " & fechaSalida.ToShortDateString & " </td>"))
                    phReservas.Controls.Add(New LiteralControl("<td>"))
                    phReservas.Controls.Add(btnBorrarReserva)
                    phReservas.Controls.Add(New LiteralControl("</td></tr>"))

                Next
                phReservas.Controls.Add(New LiteralControl("</table>"))
                phReservas.Controls.Add(New LiteralControl("</div>"))
            Else
                Dim sinReserva As New Label
                sinReserva.Text = "No hay reservas realizadas"
                phReservas.Controls.Add(New LiteralControl("<div class='sinReserva'>"))
                phReservas.Controls.Add(sinReserva)
                phReservas.Controls.Add(New LiteralControl("</div>"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ClientID

        If MsgBox("¿Está seguro de cancelar esta reserva?", MsgBoxStyle.YesNo, MsgBoxStyle.MsgBoxSetForeground) = MsgBoxResult.Yes Then

            Try
                conexion.Open()
                Dim cmd = New MySqlCommand("Delete from reserva where idReserva = @idReserva", conexion)

                cmd.Parameters.AddWithValue("@idReserva", id)
                cmd.ExecuteNonQuery()
                conexion.Close()

                Response.Redirect("Perfil.aspx")
            Catch ex As Exception
            End Try
        End If

    End Sub

    Protected Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        metodos.logout()
        Response.Redirect("Login.aspx")
    End Sub
End Class