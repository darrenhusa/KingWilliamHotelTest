//$(document).ready(function () {
//    var items = "<option value='0'>Select Room</option>";
//    $('#Room').html(items);
//    //$('#room_output').html(items);
//});

$(document).ready(function () {
    //alert("ready fired!");
    //var1 = $("#StartDate").val();
    //if (!var1) {
    //    alert("StartDate is empty!");
    //} else {
    //    alert("!StartDate = " + !var1);
    //}
    //alert("StartDate = " + var1);
    //customer = $("#CustomerId").val();
    //formData = CaptureControlValues();

    //TestControlValue(formData.customer, 'customer');
    //TestControlValue(formData.start_date, 'start_date');
    //TestControlValue(formData.end_date, 'end_date');
    //TestControlValue(formData.category, 'category');
   
    //$("#CustomerId").change(function () {
    //    formData = CaptureControlValues();
    //    //PrintControlValues(formData);
    //    //customer = $("#CustomerId").val();
    //    //alert("Customer changed to " + customer);
    //    //$('#room_output').empty();
    //    //$('#room_output').append('<tr><td>' + formData.customer + '</td></tr>');
    //});

    $("#StartDate").change(function () {
        formData = CaptureControlValues();
        //PrintControlValues(formData);
        //CallApiFunction();
        //LoadRoomDropDownList(formData);
        //alert("GET JSON DATA!!!");
        if (formData.StartDate && formData.EndDate && formData.Category) {
            //alert("all controls have non-empty values!");
            LoadRoomDropDownList(formData);
        }
        //cond1 = (formData.StartDate);
        //cond2 = (formData.EndDate);
        //cond3 = (formData.Category);
        //alert(cond1 && cond2 && cond3);
        //if (cond1 && cond2 && cond3) {
        //    alert("all controls have non-empty values!");
        //    LoadRoomDropDownList(formData);
        //}
    });
    $("#EndDate").change(function () {
        formData = CaptureControlValues();
        //PrintControlValues(formData);
        //CallApiFunction();
        //LoadRoomDropDownList(formData);
        //alert("GET JSON DATA!!!");
        if (formData.StartDate && formData.EndDate && formData.Category) {
            //alert("all controls have non-empty values!");
            LoadRoomDropDownList(formData);
        }
    });
    $("#Room_Category").change(function () {
        formData = CaptureControlValues();
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
    });
 
});

function CaptureControlValues() {
    //alert("inside CaptureControlValues");
    customer = $("#CustomerId").val();
    start_date = $("#StartDate").val();
    end_date = $("#EndDate").val();
    category = $("#Room_Category").val();

    formData = {
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
    //$.getJSON(url, inputData, MapRoomsToSelectControl(data));
    $.getJSON(url, inputData,
        function (data) {
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

//function CallApiFunction() {
//    //alert("inside call api function.");

//    // need to figure out how to pass input=control values to api call!!
//    // this is a test function!!!

//    //if (!input.start_date && !input.end_date && !input.category) {
//    //    alert("All the controls are filled!!  Call the API!!!");
//    //}

//    var url = '/api/reservationvalues';
//    $.getJSON(url,
//        function (data) {
//            $('#room_output').empty();
//            for (var i = 0; i < data.length; i++) {
//                $('#room_output').append('<tr><td>' + data[i].roomNo + '</td></tr>');
//            }
//        });
//}

//function MapRoomsToSelectControl(data) {
//    var items = '';
//    $("#Room").empty();
//    $.each(data,
//        function (room) {
//            items += "<option value='" + room.value + "'>" + room.text + "</option>";
//        });
//    //$('#room_output').html(items);
//    $('#Room').html(items);
//}

//function PrintControlValues(input) {
//    //alert("inside PrintControlValues");
//    $('#room_output')
//        .empty()
//        .append('<tr><td>Customer</td><td>Start Date</td><td>End Date</td><td>Category</td></tr>')
//        .append('<tr><td>' + input.customer + '</td>')
//        .append('<td>' + input.start_date + '</td>')
//        .append('<td>' + input.end_date + '</td>')
//        .append('<td>' + input.category + '</td></tr>');
//}

//function TestControlValue(control, name) {

//    if (!control) {
//        alert(name + " is blank!!");
//    } else {
//        alert(name + " is non-blank!!");
//    }
//}
