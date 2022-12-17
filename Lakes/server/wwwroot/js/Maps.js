var map;

var polygons = [];

function initMap(UniqueID) {
    if(map==null)
    map = Radzen[UniqueID].instance;
}

function drawPolygon( data,  UniqueID,content) {
    initMap(UniqueID);
    var bounds = new google.maps.LatLngBounds();
    const obj = eval(data);
  

    const shape = new google.maps.Polygon({
        paths: obj,
        strokeColor: "#FF0000",
        strokeOpacity: 0.8,
        strokeWeight: 2,
        fillColor: "#FF0000",
        fillOpacity: 0.35,

    });

    for (i = 0; i < obj.length; i++) {
        bounds.extend(obj[i]);
    }


    attachPolygonInfoWindow(shape,content);
  polygons.push(shape);
    shape.setMap(map);
  

    northWest = new google.maps.LatLng(
        bounds.getNorthEast().lat(),
        bounds.getNorthEast().lng()
    );

//Can add Marker

//    new google.maps.Marker({
//        position: northWest, 
//        map: map,
   
//});

}


 




function attachPolygonInfoWindow(polygon, html) {
    polygon.infoWindow = new google.maps.InfoWindow({
        content: html,
    });
    google.maps.event.addListener(polygon, 'mouseover', function (e) {
        var latLng = e.latLng;
        this.setOptions({ fillOpacity: 0.1 });
        polygon.infoWindow.setPosition(latLng);
        polygon.infoWindow.open(map);
    });
    google.maps.event.addListener(polygon, 'mouseout', function () {
        this.setOptions({ fillOpacity: 0.35 });
        polygon.infoWindow.close();
    });
}

function clearMap(UniqueID) {
    initMap(UniqueID);
        if (polygons.length > 0) {
            for (var i = 0; i < polygons.length; i++) {
                polygons[i].setMap(null);
            }
        }
    }

function centreMap(UniqueID) {
    initMap(UniqueID);
    if (polygons.length > 0) {
        for (var i = 0; i < polygons.length; i++) {
            polygons[i].setMap(null);
        }
        map.fitBounds(bounds);
    }
}

