Imports MySql.Data.MySqlClient

Public Class Registro
    Inherits System.Web.UI.Page
    Public metodos As New Metodos

    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)

    Dim cmd As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub registro_Click(sender As Object, e As EventArgs) Handles registro.Click
        If Me.IsValid Then
            registrar()
        End If

    End Sub


    Protected Sub registrar()

        Try

            conexion.Open()
            cmd = New MySqlCommand("INSERT INTO usuario (idDni, apellidos, contrasena, correo, fechaNacimiento, nombre, nombreUsuario, telefono, tipoUsuario) " &
                                   "VALUES (@idDni, @apellidos, @contrasena, @correo, @fechaNacimiento, @nombre, @nombreUsuario, @telefono, @tipoUsuario)", conexion)

            Dim dt = DateTime.ParseExact(tbFechaNacimiento.Text, "dd/MM/yyyy", Nothing)

            Dim dniEncriptada As String = metodos.MD5EncryptPass(tbDni.Text)
            Dim claveEncriptada As String = metodos.MD5EncryptPass(tbContrasenia.Text)

            cmd.Parameters.AddWithValue("@idDni", dniEncriptada)
            cmd.Parameters.AddWithValue("@apellidos", tbApellidos.Text)
            cmd.Parameters.AddWithValue("@contrasena", claveEncriptada)
            cmd.Parameters.AddWithValue("@correo", tbCorreo.Text)
            cmd.Parameters.AddWithValue("@fechaNacimiento", dt)
            cmd.Parameters.AddWithValue("@nombre", tbNombre.Text)
            cmd.Parameters.AddWithValue("@nombreUsuario", tbUsuario.Text)
            cmd.Parameters.AddWithValue("@telefono", tbTelefono.Text)
            cmd.Parameters.AddWithValue("@tipoUsuario", "cliente")
            cmd.ExecuteNonQuery()
            conexion.Close()

            Session("SesionId") = dniEncriptada
            Session("SesionUsuario") = tbUsuario.Text
            Response.Redirect("Index.aspx")

        Catch ex As MySqlException
            MsgBox(ex)
        End Try

    End Sub

End Class