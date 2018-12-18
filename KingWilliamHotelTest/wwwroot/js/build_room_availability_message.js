$(document).ready(function () {
    //alert("inside script #2");
    $("#Room").change(GetRoomAvailability);

});

function GetRoomAvailability() {
    var currentRoom = $("#Room").val();
    //alert(currentRoom);
    var url = "/Room/CheckRoomAvailability?room=" + currentRoom;
    //alert("inside GetRoomAvailability.");
    $.getJSON(url, currentRoom, BuildRoomAvailabilityMessage);
}

function BuildRoomAvailabilityMessage(data) {
    $('#RoomAvailability').empty();
    var roomAvailability = data;
    //var roomAvailability = data.roomAvailability;
    alert(roomAvailability);
    var result = "";
    if (!roomAvailability) {
        result = "<p>Needs Cleaning.</p>";
    }
    $('#RoomAvailability').html(result);
}
