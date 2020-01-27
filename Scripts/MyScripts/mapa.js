
var nombre = document.getElementById('HiddenFieldNombre').value;
var nombreArray = nombre.split('~');
var lat = document.getElementById('HiddenFieldLat').value;
var latArray = lat.split('~');
var lon = document.getElementById('HiddenFieldLon').value;
var lonArray = lon.split('~');

var locations = [
    ['Bondi Beach', 43.4248797, - 2.8199686],
    ['Coogee Beach', 43.41918534, - 2.80358616],
    ['Cronulla Beach', 43.42069147, - 2.81916843]
];

var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 10,
    center: new google.maps.LatLng(43.2603479, -2.9334110),
    mapTypeId: google.maps.MapTypeId.ROADMAP
});

var infowindow = new google.maps.InfoWindow();

var marker, i;

for (i = 0; i < nombreArray.length; i++) {
    marker = new google.maps.Marker({
        position: new google.maps.LatLng(parseFloat(latArray[i]), parseFloat(lonArray[i])),
        map: map
    });

    google.maps.event.addListener(marker, 'click', (function (marker, i) {
        return function () {
            infowindow.setContent(nombreArray[i]);
            infowindow.open(map, marker);
        }
    })(marker, i));
}


/*for (i = 0; i < locations.length; i++) {
    marker = new google.maps.Marker({
        position: new google.maps.LatLng(locations[i][1], locations[i][2]),
        map: map
    });

    google.maps.event.addListener(marker, 'click', (function (marker, i) {
        return function () {
            infowindow.setContent(locations[i][0]);
            infowindow.open(map, marker);
        }
    })(marker, i));
}*/
