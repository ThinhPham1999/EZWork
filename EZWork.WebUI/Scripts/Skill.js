//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadDataSkill();
    loadCareerName();
});

//Load Data function  
function loadDataSkill() {
    $.ajax({
        url: "/SkillAdmin/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.SkillId + '</td>';
                html += '<td>' + item.SkillName + '</td>';
                html += '<td>' + item.SkillDescription + '</td>';
                html += '<td>' + item.SkillUrlSlug + '</td>';
                html += '<td>' + item.CareerName + '</td>';
                html += '<td><a href="#" onclick="return getbyIDSkill(' + item.SkillId + ')">Edit</a> | <a href="#" onclick="DeleleSkill(' + item.SkillId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('#SkillTable').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function loadCareerName(){
    $.ajax({
        url: "/CareerAdmin/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<option value =' + item.CareerId + '>' + item.CareerName + '</option>';
            });
            $('#careerOption').append(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function AddSkill() {
    var res = validateSkill();
    if (res == false) {
        return false;
    }
    var optionValue = $('#careerOption').val();
    console.log(optionValue);
    var SkillObj = {
        SkillId: $('#SkillId').val(),
        SkillName: $('#SkillName').val(),
        SkillDescription: $('#SkillDescription').val(),
        SkillUrlSlug: $('#SkillUrlSlug').val(),
        CareerId: optionValue,
        CareerName: 'a'
    };
    debugger;
    $.ajax({
        url: "/SkillAdmin/Add",
        data: JSON.stringify(SkillObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
            loadDataSkill();
            $('#myModalSkill').modal('hide');
            $('#myModalSkill').trigger('click');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyIDSkill(id) {
    $('#SkillName').css('border-color', 'lightgrey');
    $('#SkillDescription').css('border-color', 'lightgrey');
    $('#SkillUrlSlug').css('border-color', 'lightgrey');
    $.ajax({
        url: "/SkillAdmin/GetbyID/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#SkillId').val(result.SkillId);
            $('#SkillName').val(result.SkillName);
            $('#SkillDescription').val(result.SkillDescription);
            $('#SkillUrlSlug').val(result.SkillUrlSlug);
            console.log(result.CareerId);
            $('#careerOption').val(result.CareerId).change();

            $('#myModalSkill').modal('show');
            $('#btnUpdateSkill').show();
            $('#btnAddSkill').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function UpdateSkill() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var SkillObj = {
        SkillId: $('#SkillId').val(),
        SkillName: $('#SkillName').val(),
        SkillDescription: $('#SkillDescription').val(),
        SkillUrlSlug: $('#SkillUrlSlug').val(),
    };
    $.ajax({
        url: "/SkillAdmin/Update",
        data: JSON.stringify(SkillObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadDataSkill();
            $('#myModalSkill').modal('hide');
            $('#SkillId').val("");
            $('#SkillName').val("");
            $('#SkillDescription').val("");
            $('#SkillUrlSlug').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function DeleleSkill(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/SkillAdmin/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadDataSkill();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBoxSkill() {
    $('#SkillId').val("");
    $('#SkillName').val("");
    $('#SkillDescription').val("");
    $('#SkillUrlSlug').val("");
    $('#careerOption option:first').prop('selected', true);
    $('#btnUpdateSkill').hide();
    $('#btnAddSkill').show();
    $('#SkillName').css('border-color', 'lightgrey');
    $('#SkillDescription').css('border-color', 'lightgrey');
    $('#SkillUrlSlug').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validateSkill() {
    var isValid = true;
    if ($('#SkillName').val().trim() == "") {
        $('#SkillName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SkillName').css('border-color', 'lightgrey');
    }
    if ($('#SkillDescription').val().trim() == "") {
        $('#SkillDescription').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SkillDescription').css('border-color', 'lightgrey');
    }
    if ($('#SkillUrlSlug').val().trim() == "") {
        $('#SkillUrlSlug').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SkillUrlSlug').css('border-color', 'lightgrey');
    }
    return isValid;
}