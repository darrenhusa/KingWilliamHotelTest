$(document).ready(function () {
    var items = "<option value='0'>Select Room</option>";
    $('#Room').html(items);
    //alert("ready fired!");

    $("#StartDate").change(ReloadData);

    $("#EndDate").change(ReloadData);

    // syntax with named function - works!
    $("#Room_Category").change(ReloadData);

    // syntax with anonymous function - works!
    //$("#Room_Category").change(function () {
    //    var formData = CaptureControlValues();
    //    if (formData.StartDate && formData.EndDate && formData.Category) {
    //        //alert("all controls have non-empty values!");
    //        LoadRoomDropDownList(formData);
    //    }
    //});
});

function ReloadData() {
    var formData = CaptureControlValues();
    //PrintControlValues(formData);
    //LoadRoomDropDownList(formData);
    //CallApiFunction();
    //alert("Room category changed!");
    //alert("Room category changed to " + formData.category);
    //alert("GET JSON DATA!!!");
    if (formData.StartDate && formData.EndDate && formData.Category) {
        //alert("all controls have non-empty values!");
        LoadRoomDropDownList(formData);
    }
}

function CaptureControlValues() {
    //alert("inside CaptureControlValues");
    var customer = $("#CustomerId").val();
    var start_date = $("#StartDate").val();
    var end_date = $("#EndDate").val();
    var category = $("#Room_Category").val();

    var formData = {
        Customer: customer,
        StartDate: start_date,
        EndDate: end_date,
        Category: category
    }
    return formData;
}

function LoadRoomDropDownList(inputData) {
    var url = "/Reservation/GetAvailableRooms";
    //alert("inside Load Room drop down.");
    $.getJSON(url, inputData, function (data) {
        $('#Room').empty();
        var items = '';
        for (var i = 0; i < data.length; i++) {
            room = data[i].roomNo;
            //$('#Room').append('<tr><td>' + data[i].roomNo + '</td></tr>');
            items += "<option value='" + room + "'>" + room + "</option>";
        }
        $('#Room').html(items);
    });
}

//function LoadRoomDropDownList(inputData) {
//    var url = "/Reservation/GetAvailableRooms";
//    //alert("inside Load Room drop down.");
//    $.getJSON(url, inputData, MapRoomsToSelectControl($, data));
//}

//function MapRoomsToSelectControl(data) {
//    $('#Room').empty();
//    var items = '';
//    for (var i = 0; i < data.length; i++) {
//        room = data[i].roomNo;
//        //$('#Room').append('<tr><td>' + data[i].roomNo + '</td></tr>');
//        items += "<option value='" + room + "'>" + room + "</option>";
//    }
//    $('#Room').html(items);
//}