Imports MySql.Data.MySqlClient

Public Class Registro
    Inherits System.Web.UI.Page

    Public conector As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
    Public conexion As New MySqlConnection(conector)

    Dim da As MySqlDataAdapter = New MySqlDataAdapter()
    Dim cmd As MySqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub registrar()

        cmd = New MySqlCommand("INSERT INTO usuario (idDni,apellidos,contrasena,correo,fechaNacimiento,nombre,nombreUsuario,telefono,tipoUsuario) " &
                               "VALUES (@id, @name)", conexion)

        cmd.Parameters.Add("@id", MySqlDbType.VarChar, 225, "idDni")
        cmd.Parameters.Add("@apellidos", MySqlDbType.VarChar, 225, "apellidos")
        cmd.Parameters.Add("@contrasena", MySqlDbType.VarChar, 225, "contrasena")
        cmd.Parameters.Add("@correo", MySqlDbType.VarChar, 225, "correo")
        cmd.Parameters.Add("@fechaNacimiento", MySqlDbType.DateTime, 225, "fechaNacimiento")
        cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 225, "nombre")
        cmd.Parameters.Add("@nombreUsuario", MySqlDbType.VarChar, 225, "nombreUsuario")
        cmd.Parameters.Add("@telefono", MySqlDbType.Int32, 20, "telefono")
        cmd.Parameters.Add("@tipoUsuario", MySqlDbType.VarChar, 225, "tipoUsuario")


    End Sub

End Class