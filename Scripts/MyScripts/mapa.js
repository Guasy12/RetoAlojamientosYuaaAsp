
var nombre = document.getElementById('HiddenFieldNombre').value;
var lat = document.getElementById('HiddenFieldLat').value;
var latitud = lat.replace(",", ".")
var lon = document.getElementById('HiddenFieldLon').value;
var longitud = lon.replace(",", ".")


var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 10,
    center: new google.maps.LatLng(parseFloat(latitud), parseFloat(longitud)),
    mapTypeId: google.maps.MapTypeId.ROADMAP
});

var infowindow = new google.maps.InfoWindow();

var marker, i;


marker = new google.maps.Marker({
    position: new google.maps.LatLng(parseFloat(latitud), parseFloat(longitud)),
    map: map
});

google.maps.event.addListener(marker, 'click', (function (marker, i) {
    return function () {
        infowindow.setContent(nombre);
        infowindow.open(map, marker);
    }
})(marker, i));
