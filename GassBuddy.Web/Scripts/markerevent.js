﻿var map;

function initialize() {
    var lat = document.getElementById('MainContent_StationLat').value * 1;
    var lon = document.getElementById('MainContent_StationLon').value * 1;

    

    var mapOptions = {
        zoom: 13,
        center: new google.maps.LatLng(lat, lon),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById('mapCanvas'),
        mapOptions);

    var marker = new google.maps.Marker({
        position: map.getCenter(),
        map: map,
        title: 'Click to zoom'
    });

    google.maps.event.addListener(map, 'center_changed', function () {
        // 3 seconds after the center of the map has changed, pan back to the
        // marker.
        window.setTimeout(function () {
            map.panTo(marker.getPosition());
        }, 3000);
    });

    google.maps.event.addListener(marker, 'click', function () {
        map.setZoom(8);
        map.setCenter(marker.getPosition());
    });
}

google.maps.event.addDomListener(window, 'load', initialize());