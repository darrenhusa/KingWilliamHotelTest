$(document).ready(function () {

    $("form #load").submit(function (e) {
        e.preventDefault();
        var url = "reservation/GetAvailableRooms";
        //var url = "api/reservationvalues/";

        //$.getJSON(url, function() {
        //    //console.log(data);
       
        //  $("#rooms").text(data);
        //    });

        $.ajax({
            url: url,
            contentType: "application/json",
            method: "POST",
            data: JSON.stringify({
                RoomNo: this.elements["RoomId"].value
            }),
            success: function (data) {
                //$("#rooms").text(data);
                $("#rooms").html(data);

                //printRows(data);
            }
        });
    });
});

//var addTableRow = function (reservation) {
//    $("table tbody").append("<tr><td>" + reservation.reservationId + "</td><td>"
//        + reservation.clientName + "</td><td>"
//        + reservation.location + "</td></tr>");
}