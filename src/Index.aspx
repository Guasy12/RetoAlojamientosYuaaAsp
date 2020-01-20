<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="RetoAlojamientosYuuaAsp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>YUUA Alojamientos</title>
    
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="../css/navbar.css"/>
    <link rel="stylesheet" type="text/css" href="../css/index.css"/>

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
        
        <div id="filtro-container">
            <div id="back-image-container"></div>
        </div>

        <div id="busqueda-container">
            <div id="busqueda-contenido">
                <asp:Label ID="titulo" runat="server" Text="Busque su lugar de alojamiento" Font-Size="XX-Large"></asp:Label>
                <br /><br />
                <asp:TextBox ID="tbBusqueda" runat="server" placeholder="Alojamiento/Localidad" Height="40px" Width="250px"></asp:TextBox>
                <asp:TextBox ID="fechaInicio" runat="server" placeholder="Fecha inicial" Height="40px" Width="150px"></asp:TextBox>
                <asp:TextBox ID="fechaFin" runat="server" placeholder="Fecha final" Height="40px" Width="150px"></asp:TextBox>
                <asp:DropDownList ID="ddlTipoAloj" runat="server" Height="40px" Width="150px">
                </asp:DropDownList>
                <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" Height="40px" />
            </div>
        </div>

        <asp:PlaceHolder ID="phInformacion" runat="server"></asp:PlaceHolder>

        <!--<div class="card">
          <h2>TITLE HEADING</h2>
          <h5>Title description, Dec 7, 2017</h5>
          <div class="fakeimg" style="height:200px;">Image</div>
          <p>Some text..</p>
          <p>Sunt in culpa qui officia deserunt mollit anim id est laborum consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
              Ut enim ad minim veniam, quis nostrud exercitation ullamco.</p>
        </div>-->
      
        <!-- FOOTER -->
        <div class="margen"></div>
        <div class="footer">
          <img src="../img/logo.png" width="100" alt="" class="d-inline-block align-middle mr-2"/>
        </div>
    </form>
</body>
</html>
