Imports MySql.Data.MySqlClient

Public Class Login
    Inherits System.Web.UI.Page
    Public metodos As New Metodos
    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)
    Public sqlAdapter As New MySqlDataAdapter
    Public dsUsuario As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub registro_Click(sender As Object, e As EventArgs) Handles registro.Click
        Response.Redirect("Registro.aspx")
    End Sub

    Protected Sub login_Click(sender As Object, e As EventArgs) Handles login.Click

        If Me.IsValid Then
            loginSesion()
        End If

    End Sub

    Protected Sub loginSesion()
        Try
            Dim claveEncriptada As String = metodos.MD5EncryptPass(tbContrasenia.Text)
            passValidator.ErrorMessage = claveEncriptada
            conexion.Open()
            Dim cmdUsuario = New MySqlCommand("SELECT idDni, nombreUsuario FROM usuario " &
                                              "WHERE nombreUsuario = '" & tbUsuario.Text & "' and contrasena = '" & claveEncriptada & "' and tipoUsuario='cliente'", conexion)
            sqlAdapter = New MySqlDataAdapter(cmdUsuario)

            sqlAdapter.Fill(dsUsuario, "usuario")

            If dsUsuario.Tables(0).Rows.Count > 0 Then

                Session("SesionId") = dsUsuario.Tables(0).Rows(0).Item(0)
                Session("SesionUsuario") = dsUsuario.Tables(0).Rows(0).Item(1)
                Response.Redirect("Index.aspx")

            Else
                errorLogin.text = "Usuario o contraseña incorrectos"
            End If

        Catch ex As MySqlException

        End Try
    End Sub

End Class