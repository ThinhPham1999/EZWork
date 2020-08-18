//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadDataCareer();
});

//Load Data function  
function loadDataCareer() {
    $.ajax({
        url: "/CareerAdmin/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.CareerId + '</td>';
                html += '<td>' + item.CareerName + '</td>';
                html += '<td>' + item.CareerDescription + '</td>';
                html += '<td>' + item.CareerUrlSlug + '</td>';
                html += '<td><a href="#" onclick="return getbyIDCareer(' + item.CareerId + ')">Edit</a> | <a href="#" onclick="DeleleCareer(' + item.CareerId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('#CareerTable').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function AddCareer() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var careerObj = {
        CareerId: $('#CareerId').val(),
        CareerName: $('#CareerName').val(),
        CareerDescription: $('#CareerDescription').val(),
        CareerUrlSlug: $('#CareerUrlSlug').val(),
    };
    $.ajax({
        url: "/CareerAdmin/Add",
        data: JSON.stringify(careerObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataCareer();
            $('#myModalCareer').modal('hide');
            $('#myModalCareer').trigger('click');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyIDCareer(id) {
    $('#CareerName').css('border-color', 'lightgrey');
    $('#CareerDescription').css('border-color', 'lightgrey');
    $('#CareerUrlSlug').css('border-color', 'lightgrey');
    $.ajax({
        url: "/CareerAdmin/GetbyID/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CareerId').val(result.CareerId);
            $('#CareerName').val(result.CareerName);
            $('#CareerDescription').val(result.CareerDescription);
            $('#CareerUrlSlug').val(result.CareerUrlSlug);

            $('#myModalCareer').modal('show');
            $('#btnUpdateCareer').show();
            $('#btnAddCareer').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function UpdateCareer() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var careerObj = {
        CareerId: $('#CareerId').val(),
        CareerName: $('#CareerName').val(),
        CareerDescription: $('#CareerDescription').val(),
        CareerUrlSlug: $('#CareerUrlSlug').val(),
    };
    $.ajax({
        url: "/CareerAdmin/Update",
        data: JSON.stringify(careerObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataCareer();
            $('#myModalCareer').modal('hide');
            $('#CareerId').val("");
            $('#CareerName').val("");
            $('#CareerDescription').val("");
            $('#CareerUrlSlug').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function DeleleCareer(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/CareerAdmin/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadDataCareer();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBoxCareer() {
    $('#CareerId').val("");
    $('#CareerName').val("");
    $('#CareerDescription').val("");
    $('#CareerUrlSlug').val("");
    $('#btnUpdateCareer').hide();
    $('#btnAddCareer').show();
    $('#CareerName').css('border-color', 'lightgrey');
    $('#CareerDescription').css('border-color', 'lightgrey');
    $('#CareerUrlSlug').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#CareerName').val().trim() == "") {
        $('#CareerName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CareerName').css('border-color', 'lightgrey');
    }
    if ($('#CareerDescription').val().trim() == "") {
        $('#CareerDescription').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CareerDescription').css('border-color', 'lightgrey');
    }
    if ($('#CareerUrlSlug').val().trim() == "") {
        $('#CareerUrlSlug').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CareerUrlSlug').css('border-color', 'lightgrey');
    }
    return isValid;
}