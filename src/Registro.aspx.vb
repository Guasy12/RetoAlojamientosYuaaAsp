Imports MySql.Data.MySqlClient

Public Class Registro
    Inherits System.Web.UI.Page

    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)

    Dim da As MySqlDataAdapter = New MySqlDataAdapter()
    Dim cmd As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub registro_Click(sender As Object, e As EventArgs) Handles registro.Click
        registrar()
    End Sub


    Sub registrar()

        Try

            conexion.Open()
            cmd = New MySqlCommand("INSERT INTO usuario (idDni, apellidos, contrasena, correo, fechaNacimiento, nombre, nombreUsuario, telefono, tipoUsuario) " &
                                   "VALUES (@idDni, @apellidos, @contrasena, @correo, @fechaNacimiento, @nombre, @nombreUsuario, @telefono, @tipoUsuario)", conexion)

            Dim dt = DateTime.ParseExact(tbFechaNacimiento.Text, "dd/MM/yyyy", Nothing)

            cmd.Parameters.AddWithValue("@idDni", tbDni.Text)
            cmd.Parameters.AddWithValue("@apellidos", tbApellidos.Text)
            cmd.Parameters.AddWithValue("@contrasena", tbContrasenia.Text)
            cmd.Parameters.AddWithValue("@correo", tbCorreo.Text)
            cmd.Parameters.AddWithValue("@fechaNacimiento", dt)
            cmd.Parameters.AddWithValue("@nombre", tbNombre.Text)
            cmd.Parameters.AddWithValue("@nombreUsuario", tbUsuario.Text)
            cmd.Parameters.AddWithValue("@telefono", tbTelefono.Text)
            cmd.Parameters.AddWithValue("@tipoUsuario", "Cliente")
            cmd.ExecuteNonQuery()
            conexion.Close()

            Session("SesionUsuario") = tbUsuario.Text
            Response.Redirect("Index.aspx")

        Catch ex As MySqlException

        End Try

    End Sub

End Class