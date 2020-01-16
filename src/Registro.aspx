<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Registro.aspx.vb" Inherits="RetoAlojamientosYuuaAsp.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>YUUA Alojamientos</title>
    
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="../css/navbar.css"/>
    <link rel="stylesheet" type="text/css" href="../css/login.css"/>

    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/jquery-3.0.0.slim.min.js"></script>
    <!-- Datepicker -->
    <link rel="stylesheet" href="../css/datepicker.css" type="text/css"/>
    <script src="../Scripts/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap-datepicker.es.js" charset="UTF-8"></script>
    <script src="../Scripts/MyScripts/myscripts.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
        <!-- MENU -->
        <div id="menu">
        <nav class="navbar navbar-expand-lg py-3">
          <div class="container">
            <a href="Index.aspx" class="navbar-brand">
              <!-- Logo Image -->
              <img src="../img/logo.png" width="200" alt="" class="d-inline-block align-middle mr-2"/>
              <!-- Logo Text -->
              <!--<span class="text-uppercase font-weight-bold">Alojamientos</span>-->
            </a>

            <button type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" class="navbar-toggler"><span class="navbar-toggler-icon"></span></button>

            <div id="navbarSupportedContent" class="collapse navbar-collapse">
              <ul class="navbar-nav ml-auto">
                <li class="nav-item active"><a href="Index.aspx" class="nav-link">Alojamientos <span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a href="#" class="nav-link">Reservas</a></li>
                <li class="nav-item">
                    
                    <% if Session("SesionUsuario") Is Nothing Then %>
                    <asp:Label ID="lblLogin" runat="server">
                        <a href="Login.aspx" class="nav-link">Login</a>
                    </asp:Label>
                    <%else %>
                    <asp:Label ID="lblLogin2" runat="server">
                        <a href="#" class="nav-link"><% Response.Write(Session("SesionUsuario")) %></a>
                    </asp:Label>
                    <% end if %>
                    
                </li>
              </ul>
            </div>
          </div>
        </nav>
        </div>

        <!-- REGISTRO -->
        <div class="box">
            <h1>Iniciar Sesión</h1>

            <asp:TextBox ID="tbUsuario" runat="server" placeholder="Usuario" class="user"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="userValidator" runat="server" ErrorMessage="Campo usuario vacío" ControlToValidate="tbUsuario" EnableClientScript="False" ></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="tbContrasenia" type="password" placeholder="Contraseña" class="textboxGenerico" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="passValidator" runat="server" ErrorMessage="Campo contraseña vacío" ControlToValidate="tbContrasenia" EnableClientScript="False"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="tbDni" runat="server" placeholder="Dni" class="textboxGenerico"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="dniValidator" runat="server" ErrorMessage="Campo dni vacío" ControlToValidate="tbDni" EnableClientScript="False" ></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="tbNombre" placeholder="Nombre" class="textboxGenerico" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="nombreValidator" runat="server" ErrorMessage="Campo nombre vacío" ControlToValidate="tbNombre" EnableClientScript="False"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="tbApellidos" placeholder="Apellidos" class="textboxGenerico" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="apellidosValidator" runat="server" ErrorMessage="Campo apellidos vacío" ControlToValidate="tbApellidos" EnableClientScript="False"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="tbFechaNacimiento" placeholder="Fecha de nacimiento" class="textboxGenerico" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo fecha vacío" ControlToValidate="tbFechaNacimiento" EnableClientScript="False"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="tbCorreo" placeholder="Correo" class="textboxGenerico" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="correoValidator" runat="server" ErrorMessage="Campo correo vacío" ControlToValidate="tbCorreo" EnableClientScript="False"></asp:RequiredFieldValidator>
            <br />

            <asp:TextBox ID="tbTelefono" placeholder="Teléfono" class="textboxGenerico" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="telefonoValidator" runat="server" ErrorMessage="Campo telefono vacío" ControlToValidate="tbTelefono" EnableClientScript="False"></asp:RequiredFieldValidator>
            <br />

            <asp:Button ID="registro" runat="server" Text="Registrarse" class="btn3" />

        </div>
        <!-- FOOTER -->
        <div class="footer">
          <img src="../img/logo.png" width="100" alt="" class="d-inline-block align-middle mr-2"/>
        </div>
    </form>
</body>
</html>
