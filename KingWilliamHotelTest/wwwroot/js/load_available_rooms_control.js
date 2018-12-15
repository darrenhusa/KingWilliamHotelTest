//$(document).ready(function () {
//    var items = "<option value='0'>Select Room</option>";
//    $('#Room').html(items);
//    //$('#room_output').html(items);
//});

function LoadRoomDropDownList(inputData) {
    var url = "/Reservation/GetAvailableRooms";
    //var url = '@Url.Content("~/")' + "";

    $.getJSON(url, inputData, MapRoomsToSelectControl(data));
}

function MapRoomsToSelectControl(data) {
    var items = '';
    $("#Room").empty();
    $.each(data,
        function (i, MyData) {
            items += "<option value='" + MyData.value + "'>" + MyData.text + "</option>";
        });
    $('#room_output').html(data);
    //$('#Room').html(items);
}

$(document).ready(function () {
    var customer = "#CustomerId";
    var start_date = "#StartDate";
    var end_date = "#EndDate";
    var category = "#Category";
    //var formData = {
    //    StartDate: $(start_date).val(),
    //    EndDate: $(end_date).val(),
    //    Category: $(category).val()
    //}

    $(customer).change(function () {

        $('#room_output').text($("#CustomerId".val()));
        $('#room_output').text("Customer control changed.");
    });

    $(start_date).change(function () {

        $('#room_output').text($("#StartDate".val()));
        $('#room_output').text("StartDate control changed.");
    });
    //$(start_date).change(LoadRoomDropDownList(formData));
    //$(end_date).change(LoadRoomDropDownList(formData));
    //$(category).change(LoadRoomDropDownList(formData));
});