/// <reference path="jquery-2.0.2.js" />
/// <reference path="https://maps.googleapis.com/maps/api/js?key=AIzaSyB7vJXXLxmo0Za0kzfzJPqyNfGpsYJ_2p8&sensor=false"/>

function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(52.373056, 4.892222),
        zoom: 5,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);

    capitals = ["Amsterdam", "Prague", "London", "Athens", "Madrid", "Washington", "Mexico City", "Buenos Aires", "Lima", "Brasilia", ];
    coordinates = [
        new google.maps.LatLng(52.373056, 4.892222), // Amsterdam
        new google.maps.LatLng(50.088182, 14.420210), // Prague
        new google.maps.LatLng(51.507222, 0.1275), // London
        new google.maps.LatLng(37.966667, 23.716667), // Athens
        new google.maps.LatLng(40.383333, -3.716667), // Madrid
        new google.maps.LatLng(38.895111, -77.036667), // Washington
        new google.maps.LatLng(19.433333, -99.133333), // Mexico City
        new google.maps.LatLng(-34.603333, -58.381667), // Buenos Aires
        new google.maps.LatLng(-12.043333, -77.028333), // Lima
        new google.maps.LatLng(-15.798889, -47.866667) // Brasilia
    ];

    markers = [];

    for (var i = 0; i < 10; i++) {
        var marker = new google.maps.Marker({
            map: map,
            animation: google.maps.Animation.DROP,
            position: coordinates[i],
        });
        markers.push(marker);

        var boxText = document.createElement("div");
        boxText.innerHTML = capitals[i];
        var options = {
            content: boxText,
            closeBoxMargin: "10px 2px 2px 2px",
            closeBoxURL: "http://www.google.com/intl/en_us/mapfiles/close.gif",
            enableEventPropagation: false
        };

        var info = new google.maps.InfoWindow(options);
        bindInfoWindow(markers[i], capitals[i], info);
    }
}

function bindInfoWindow(marker, contentString, infowindow) {
    google.maps.event.addListener(marker, 'click', function () {
        infowindow.open(map, marker);
    });
}

google.maps.event.addDomListener(window, 'load', initialize);

$(document).ready(function () {
    $("#capitals").on("click", "#amsterdam", function () {
        map.panTo(coordinates[0]);
    });
    $("#capitals").on("click", "#prague", function () {
        map.panTo(coordinates[1]);
    });
    $("#capitals").on("click", "#london", function () {
        map.panTo(coordinates[2]);
    });
    $("#capitals").on("click", "#athens", function () {
        map.panTo(coordinates[3]);
    });
    $("#capitals").on("click", "#madrid", function () {
        map.panTo(coordinates[4]);
    });
    $("#capitals").on("click", "#washington", function () {
        map.panTo(coordinates[5]);
    });
    $("#capitals").on("click", "#mexicoCity", function () {
        map.panTo(coordinates[6]);
    });
    $("#capitals").on("click", "#buenosAires", function () {
        map.panTo(coordinates[7]);
    });
    $("#capitals").on("click", "#lima", function () {
        map.panTo(coordinates[8]);
    });
    $("#capitals").on("click", "#brasilia", function () {
        map.panTo(coordinates[9]);
    });

    var currentCoords = 0;
    $("#previous").on("click", function () {
        if (currentCoords - 1 < 0) {
            currentCoords = 10;
        }
        currentCoords--;
        map.panTo(coordinates[currentCoords]);
    });

    $("#next").on("click", function () {
        if (currentCoords + 1 > 9) {
            currentCoords = -1;
        }
        currentCoords++;
        map.panTo(coordinates[currentCoords]);
    });
});