//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
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
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Description + '</td>';
                html += '<td>' + item.UrlSlug + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.CareerId + ')">Edit</a> | <a href="#" onclick="Delele(' + item.CareerId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var careerObj = {
        CareerId: $('#CareerId').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        UrlSlug: $('#UrlSlug').val(),
    };
    $.ajax({
        url: "/CareerAdmin/Add",
        data: JSON.stringify(careerObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#myModal').trigger('click');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(id) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $('#UrlSlug').css('border-color', 'lightgrey');
    $.ajax({
        url: "/CareerAdmin/GetbyID/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CareerId').val(result.CareerId);
            $('#Name').val(result.Name);
            $('#Description').val(result.Description);
            $('#UrlSlug').val(result.UrlSlug);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var careerObj = {
        CareerId: $('#CareerId').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        UrlSlug: $('#UrlSlug').val(),
    };
    $.ajax({
        url: "/CareerAdmin/Update",
        data: JSON.stringify(careerObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#CareerId').val("");
            $('#Name').val("");
            $('#Description').val("");
            $('#UrlSlug').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/CareerAdmin/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#CareerId').val("");
    $('#Name').val("");
    $('#Description').val("");
    $('#UrlSlug').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $('#UrlSlug').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Description').val().trim() == "") {
        $('#Description').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Description').css('border-color', 'lightgrey');
    }
    if ($('#UrlSlug').val().trim() == "") {
        $('#UrlSlug').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UrlSlug').css('border-color', 'lightgrey');
    }
    return isValid;
}