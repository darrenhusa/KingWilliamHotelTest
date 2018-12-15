$(document).ready(function () {

    $("#load").submit(function (e) {
        e.preventDefault();
        //var url = "reservation/GetAvailableRooms";
        var message = "From AJAX call!"
        //var url = "api/reservationvalues/";

        alert(message);

        //$.getJSON(url, function() {
        //    //console.log(data);
       
        //$("#rooms").text("From AJAX call!");
        //    //$("#rooms").html("From AJAX call!");
        //    //$("#rooms").html(data);
        ////$("#rooms").text(data);
        //    });

        //$.ajax({
        //    url: url,
        //    contentType: "application/json",
        //    method: "GET",
        //    data: JSON.stringify({
        //        RoomNo: this.elements["RoomId"].value
        //    }),
        //    success: function (data) {
        //        //$("#rooms").text(data);
        //        $("#rooms").html(data);

                //printRows(data);
            //}
        //});
    });
});

//var addTableRow = function (reservation) {
//    $("table tbody").append("<tr><td>" + reservation.reservationId + "</td><td>"
//        + reservation.clientName + "</td><td>"
//        + reservation.location + "</td></tr>");
}