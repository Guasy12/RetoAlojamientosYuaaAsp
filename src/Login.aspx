<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="RetoAlojamientosYuuaAsp.Login" %>

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
                    <asp:Label ID="lblLogin" runat="server">
                        <a href="Login.aspx" class="nav-link">Login</a>
                    </asp:Label>
                </li>
              </ul>
            </div>
          </div>
        </nav>
        </div>

        <!-- LOGIN -->
        <div class="box">
            <h1>Iniciar Sesión</h1>

            <asp:TextBox ID="usuario" runat="server" placeholder="Usuario" class="user"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="userValidator" runat="server" ErrorMessage="Campo usuario vacío" EnableClientScript="False" ControlToValidate="usuario"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="contrasenia" type="password" placeholder="Contraseña" class="textboxGenerico" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="passValidator" runat="server" ErrorMessage="Campo contraseña vacío" ControlToValidate="contrasenia" EnableClientScript="False"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="login" runat="server" Text="Iniciar Sesión" class="btn" />
            <asp:Button ID="registro" runat="server" Text="Registrarse" class="btn2" />
        </div>
        <p>¿Olvidaste tu contraseña? <u style="color:#f1c40f;">¡Haz click aquí!</u></p>

        <!-- FOOTER -->
        <div class="footer">
          <img src="../img/logo.png" width="100" alt="" class="d-inline-block align-middle mr-2"/>
        </div>
    </form>
</body>
</html>
