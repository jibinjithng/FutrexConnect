var g_userid = 0;
var g_roleid = 0;
var g_isvalid;

window.onload = function breadcrumbs() {
    document.getElementById('titleheader').innerHTML = 'Users & Access Rights';
    document.getElementById('breadLevel1').innerHTML = 'User Management';
    document.getElementById('breadLevel2').innerHTML = 'Users & Access Rights';
    document.getElementById("breadLevel2").href = '/UserRights';
};

$(document).ready(function () {

    loaddatatable("/UserRights/GetUserRolesRightsDetails/0/0"); //to display no data found in the data table intially

    document.getElementById('save').disabled = true;

    var sPageURL = window.location.href;
    var indexOfLastSlash = sPageURL.lastIndexOf("/");

    if (indexOfLastSlash > 0 && sPageURL.length - 1 !== indexOfLastSlash) {
        g_userid = sPageURL.substring(indexOfLastSlash + 1);
        if (g_userid !== null && g_userid > 0) {
            setUserDetails(g_userid);
            fnSubmit();
        } else {
            g_userid = 0;
            $("#active").prop("checked", true);
        }
    }

    function setUserDetails(g_userid) {
        $.ajax({
            url: "/UserRights/GetById/" + g_userid,
            "async": false,
            type: "GET",
            data: {},
            success: function (result) {
                //document.getElementById("FirstName").value = result.firstname;
                //document.getElementById("MiddleName").value = result.middlename;
                //document.getElementById("LastName").value = result.lastname;
                //document.getElementById("Email").value = result.email;
                g_roleid = result.roleId;
                if (result.status === true) {
                    $("#active").prop("checked", true);
                } else {
                    $("#inactive").prop("checked", true);
                }
            },
            error: function () {
            }
        });   
    }

    $.ajax({
        url: "/UserRights/GetModules",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: JSON,
        success: function (result) {
            $(result).each(function () {
                $("#ModulesList").append($("<option></option>").val(this.Value).html(this.Text));
            });
        },
        error: function (data) { }
    });

    $.ajax({
        url: "/UserRights/GetRoles",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: JSON,
        success: function (result) {
            $(result).each(function () {
                $("#RolesList").append($("<option></option>").val(this.Value).html(this.Text));
            });
        },
        error: function (data) { }
    });
});


$('#active').click(function () {
    if ($('#active').is(':checked')) {
        $('#add').attr('disabled', false);
    }
});

$('#inactive').click(function () {
    //if ($('#inactive').is(':checked')) {
    //    $('#add').attr('disabled', true);
    //    //document.getElementById('save').disabled = false;
    //}
});

$("#ModulesList").change(function () {
    var ModuleId = $("#ModulesList").val();

    if (!(ModuleId === "")) {
        $.ajax({
            cache: false,
            type: "GET",
            url: '/UserRights/GetRolesForModule/' + ModuleId,
            //url: '@Url.Action("GetRolesForModule", "UserRights")/' + ModuleId,
            //data: { "ModuleId": id },
            success: function (json, textStatus) {
                $("#RolesList").empty();
                json = json || {};
                for (var i = 0; i < json.length; i++) {
                    $("#RolesList").append('<option value="' + json[i].Value + '">' + json[i].Text + '</option>');
                }
                $("#RolesList").prop("disabled", false);
            },
            error: function () {
                alert("Data Not Found");
            }
        });
    }
});


$('#add').bind("click", function () {
    g_validfields = false;
    validateFields();
    if (g_validfields === false) {
        return false;
    } else {       
        fnSubmit();
        document.getElementById('save').disabled = false;
        return false;
    }
    return false;
});

$("#usergrid").on("click", "td input[type='checkbox']", function () {
    var isChecked = this.checked;
    var dtapi = $("#usergrid").DataTable();
    // set the data item associated with the row to match the checkbox
    var dtRow = dtapi.rows($(this).closest("tr"));
    var name = $(this).attr("id");
    switch (name) {
        case 'CreateChk':
            dtRow.data()[0].CreateCol = isChecked;
            break;
        case 'UpdateChk':
            dtRow.data()[0].UpdateCol = isChecked;
            break;
        case 'ViewChk':
            dtRow.data()[0].ViewCol = isChecked;
            break;
        case 'DelChk':
            dtRow.data()[0].DeleteCol = isChecked;
            break;
    }
});


function fnSubmit() {
    
    var UserId = g_userid;
    var moduleid = $("#ModulesList").val();
    var roleid = $("#RolesList").val();
    g_isvalid = true;

    if (UserId === 0) {
        fnValidate($("#Email").val(), $("#RolesList").val());
        if (!g_isvalid) {
            return;
        }        
    }

    //if (g_isvalid) {
    if (moduleid > 0 && roleid > 0) {
        if (UserId === 0) {
            var url = "/UserRights/GetUserRolesRightsDetails/" + moduleid + "/" + roleid; //'@Url.Action("GetUserRolesDetails", "UserRights")/' + moduleid + "/" + roleid; //
        } else {
            url = "/UserRights/GetUserRightsDetails/" + UserId + "/" + moduleid + "/" + roleid; //'@Url.Action("GetUserRightsDetails", "UserRights")/' + UserId + "/" + moduleid + "/" + roleid; //
        }

        loaddatatable(url);

    }  
    return false;
}

function loaddatatable(url) {
        $("#usergrid").DataTable({
            "processing": true, // for show progress bar
            "serverSide": false, // for process server side. Pagination is correct if 'false'
            "filter": true, // this is for disable filter (search box)
            "orderMulti": false, // for disable multiple column at once                       
            "bDestroy": true,//to avoid "Cannot reinitialise DataTable." error

            "ajax": {
                "serverSide": true,
                "url": url,
                "async": false,
                "type": "GET",
                "datatype": "json",
                //"lengthMenu": [5, 10, 25, 50, 75, 100],
                //"pageLength": 3,
                //"iDisplayLength": 3
            },
            "columns":
                [
                    {
                        "data": "ModuleName", "name": "Group", "autoWidth": true //, "className": "text-center"
                    },
                    {
                        "data": "FeatureName", "name": "Features", "autoWidth": true //, "className": "text-center"
                    },
                    {
                        "data": "ViewCol", "name": "View", "autoWidth": true, //"className": "dt-body-center",
                        "render": function (data) {
                            if (data === true) { return '<input type="checkbox" id="ViewChk" class="dt-checkboxes" checked = true>'; }
                            else { return '<input type="checkbox" id="ViewChk" class="dt-checkboxes">'; }
                        }
                    },
                    {
                        "data": "CreateCol", "name": "Create", "autoWidth": true, //"className": "dt-body-center",
                        "render": function (data) {
                            if (data === true) { return '<input type="checkbox"  id="CreateChk" class="dt-checkboxes" checked = true>'; }
                            else { return '<input type="checkbox" id="CreateChk" class="dt-checkboxes">'; }
                        }
                    },
                    {
                        "data": "UpdateCol", "name": "Update", "autoWidth": true, //"className": "dt-body-center",
                        "render": function (data) {
                            if (data === true) { return '<input type="checkbox"  id="UpdateChk" class="dt-checkboxes" checked = true>'; }
                            else { return '<input type="checkbox" id="UpdateChk" class="dt-checkboxes">'; }
                        }
                    },
                    {
                        "data": "DeleteCol", "name": "Delete", "autoWidth": true, //"className": "dt-body-center",
                        "render": function (data) {
                            if (data === true) { return '<input type="checkbox"  id="DelChk" class="dt-checkboxes" checked = true>'; }
                            else { return '<input type="checkbox" id="DelChk" class="dt-checkboxes">'; }
                        }
                    }

                    //{ "data": "ModuleId", "name": "ModuleId", "visible": false },
                    //{ "data": "RoleId", "name": "RoleId", "visible": false },
                    //{ "data": "FeatureId", "name": "FeatureId", "visible": false }
                ],
            "language": {
                "emptyTable": "Data Not Found."
            },
            "columnDefs": [{
                "defaultContent": "-", //to avioid Dattable : not found error
                "targets": [6, 7, 8],
                "visible": false,
                "searchable": false
            }],
            "bFilter": false,
            "bInfo": false,
            "bPaginate": false,
            "searching": false
        });
        //$("#usergrid").DataTable.columns([6,7,8]).visible(false);
   
}

function convertTableToArrayObject() {
    //debugger
    var rightsObjects = [];
    var table = $('#usergrid').DataTable();
    var data = table.rows().data();

    for (var i = 0; i < data.length; i++) {
        rightsObjects.push(data[i]);
    }
    return rightsObjects;
}

function ValidateEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return true;
    }    
    return false;
}

function validateFields() {
    g_validfields = false;

    if ($("#FirstName").val() === null || $("#FirstName").val().trim() === "") {       
        $.notify('Please enter valid First Name !!', warnOptions);
        return;
    }

    if (ValidateEmail($("#Email").val().trim()) === false) {
        $.notify('Please enter valid email !!', warnOptions);
        return;
    }

    if ($("#Email").val() === null || $("#Email").val().trim() === "") {
        $.notify('Please enter valid email !!', warnOptions);
        return;
    }

    //if ($('#active').is(':checked')) {
        if ($("#ModulesList").val() === null || $("#ModulesList").val().length === 0) {
            $.notify('Please select Modules !!', warnOptions);
            return;
        }

        if ($("#RolesList").val() === null || $("#RolesList").val().length === 0) {
            $.notify('Please select Roles !!', warnOptions);
            return;
        }
    //}
    g_validfields = true;
    return;
}

$('#save').click(function () {
    ///$('#staticBackdrop').modal('show');
    document.getElementById('staticBackdropLabel').innerHTML = 'Users & Access Rights';
    document.getElementById('msgtext').innerHTML = 'Do you want to save the changes?';    
});

$('#msgOk').click(function () {
    $('#staticBackdrop').modal('hide');
    validateFields();
    if (g_validfields === false) {
        return;
    } else {
        return fnSave();
    }
});

function fnSave() {
    var rightsObj = convertTableToArrayObject();
    //alert('Rights JSON : ' + JSON.stringify(rightsObj));

    var formData = {
        "MasDat": {
            "FirstName": $("#FirstName").val(), "MiddleName": $("#MiddleName").val(), "LastName": $("#LastName").val(),
            "Email": $("#Email").val(), "RoleId": (($("#RolesList").val() == "") ? g_roleid : $("#RolesList").val()), "Status": $("input[type='radio'][name='Status']:checked").val()
            //"Status": true
        }
        ,
        "URDetDat": rightsObj
    };

    var jsonData = JSON.stringify(formData);
    
    $.ajax({
        url: "/UserRights/SaveUserRightsHeaderDetail/" + g_userid,
        async: false,
        type: "POST",
        data: { "jsonFormData": JSON.stringify(formData) },
        success: function (result) {
            if (result.success) { 
                setTimeout(function () {
                    window.location.href = "/UserRights";
                    //window.location.reload();
                }, 1000);
                $.notify(result.message, successOptions); 
                return;
            } 
        },
        error: function () {
        }
    });
    return false; ///for successful page redirect
}

function fnValidate(email, roleid) {
    $.ajax({
        cache: false,
        type: "GET",
        async: false,
        url: "/UserRights/ValidateData"+ "/" + email,
        success: function (result) {           
            if (!result.success) {
                g_isvalid = false;
                $.notify(result.message, warnOptions);
            } else {
                g_isvalid = true;
            }
        },
        error: function () {
        }
    });
}

var successOptions = {
    autoHideDelay: 10,
    showAnimation: "fadeIn",
    hideAnimation: "fadeOut",
    hideDuration: 700,
    arrowShow: false,
    globalPosition: "top center",
    className: "success"
};

var warnOptions = {
    globalPosition: "top center",
    type: "info",
    delay: 2000,
    animation: true,
    close: true
};