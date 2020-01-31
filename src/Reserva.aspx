<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reserva.aspx.vb" Inherits="RetoAlojamientosYuuaAsp.Reserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>YUUA Reserva</title>
    
    <link rel="stylesheet" href="../Content/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="../css/navbar.css"/>
    <link rel="stylesheet" type="text/css" href="../css/index.css" />
    

    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/jquery-3.0.0.slim.min.js"></script>

    <!-- MAPA -->
    <script src="https://api.mapbox.com/mapbox-gl-js/v1.6.1/mapbox-gl.js"></script>
    <link href="https://api.mapbox.com/mapbox-gl-js/v1.6.1/mapbox-gl.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- MENU -->
		<div id="menu">
			<nav class="navbar navbar-expand-lg py-3">
				<div class="container">
					<a href="Index.aspx" class="navbar-brand">
						<!-- Logo Image -->
						<img src="../img/logo.png" width="200" alt="" class="d-inline-block align-middle mr-2" />
						<!-- Logo Text -->
						<!--<span class="text-uppercase font-weight-bold">Alojamientos</span>-->
					</a>

					<button type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" class="navbar-toggler"><span class="navbar-toggler-icon"></span></button>

					<div id="navbarSupportedContent" class="collapse navbar-collapse">
						<ul class="navbar-nav ml-auto">
							<li class="nav-item active"><a href="Index.aspx" class="nav-link">Alojamientos <span class="sr-only">(current)</span></a></li>
							<li class="nav-item"><a href="#" class="nav-link">Reservas</a></li>
							<li class="nav-item">
								<%     If Session("SesionUsuario") Is Nothing Then %>
								<asp:Label ID="lblLogin" runat="server">
                                    <a href="Login.aspx" class="nav-link">Login</a>
								</asp:Label>
								<%else %>
								<asp:Label ID="lblLogin2" runat="server">
                                    <a href="#" class="nav-link"><% Response.Write(Session("SesionUsuario")) %></a>
								</asp:Label>
								<asp:Button ID="logout" runat="server" Text="Logout" />
								<% end if %>
							</li>
						</ul>
					</div>
				</div>
			</nav>
		</div>

        <div class='card'>
            <h2>
		        <asp:Label ID="lblNombreAlojamiento" runat="server" Text=""></asp:Label>
            </h2>
            <h5>
                <asp:Label ID="lblDireccionAloj" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblCodPostal" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblMunicipio" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblTerritorio" runat="server" Text=""></asp:Label>
            </h5>
            <h5>
                <asp:Label ID="lblEmailAlojamiento" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblTelefonoAlojamiento" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblWebAlojmaiento" runat="server" Text=""></asp:Label>
            </h5>
            <div class='fakeimg'></div>
            <p>
                <asp:Label ID="lblTipoAlojamiento" runat="server" Text=""></asp:Label>
            </p>
            <p>
		        <asp:Label ID="lblDescripcionAlojamiento" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnReservar" runat="server" Text="Reservar" />
            </p>
        </div>
		
		


		<div id="reemplazo-header" class="reemplazo">
		</div>

        <!-- Mapa -->
        <div id="map" class="mapa"></div>
        <asp:HiddenField ID="HiddenFieldNombre" runat="server" />
        <asp:HiddenField ID="HiddenFieldLat" runat="server" />
        <asp:HiddenField ID="HiddenFieldLon" runat="server" />
        <script src="../Scripts/MyScripts/mapa.js"></script>

		<!-- FOOTER -->
		<div class="margen"></div>
		<div class="footer">
			<img src="../img/logo.png" width="100" alt="" class="d-inline-block align-middle mr-2" />
		</div>
    </form>
</body>
</html>
