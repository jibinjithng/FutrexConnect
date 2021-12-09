var g_mymoduleid = 0;
var g_myroleid = 0;
var g_isvalid = false;
var g_selectedmodule = 0;
var g_validfields = false;

window.onload = function breadcrumbs() {
    document.getElementById('titleheader').innerHTML = 'Role';
    document.getElementById('breadLevel1').innerHTML = 'User Management';
    document.getElementById('breadLevel2').innerHTML = 'Role';
    document.getElementById("breadLevel2").href = '/Role';
};

$(document).ready(function () {

    loadDataTable("/Role/GetModulesFeaturesAndAccess/0");

    $("#ModulesList").chosen({
        width: "100%"
    });   

    document.getElementById('save').disabled = true;
    
    $.ajax({
        url: "/Role/GetModules",
        type: "GET",
        //"async": false,
        contentType: "application/json; charset=utf-8",
        datatype: JSON,       
        success: function (response) {
                   // ModulesList.append($("<option disabled></option>"));
                        $.each(response, function () {
                            ModulesList.append($("<option></option>").val(this['Value']).html(this['Text']));
                        });
                        // After updated data from database you need to trigger chosen:updated.
                    $("[data-rel='chosen']").trigger("chosen:updated");
            if (g_mymoduleid > 0) {
                $("#ModulesList").val(g_mymoduleid).trigger("chosen:updated");               
            }
            
            },
            failure: function (response) { alert(response.responseText); },
            error: function (response) { alert(response.responseText); }
    });

    $("[data-rel='chosen']").chosen();
    var ModulesList = $("[data-rel='chosen']");
           
    var sPageURL = window.location.href;
    var indexOfLastSlash = sPageURL.lastIndexOf("/");
    var varRoleidPosition = sPageURL.indexOf("AddorEdit");
    if (indexOfLastSlash > 0 && sPageURL.length - 1 !== indexOfLastSlash) {
        // g_myroleid = sPageURL.substring(indexOfLastSlash + 1);
        g_mymoduleid = sPageURL.substring(indexOfLastSlash + 1);
        g_myroleid = sPageURL.substring(varRoleidPosition + 10, indexOfLastSlash);

        if (g_myroleid !== null && g_myroleid > 0) {   
            $("#ModulesList").prop('disabled', true);
            setRoleName(g_myroleid);
            fnSubmit();
        } else {
            g_mymoduleid = 0;
            g_myroleid = 0;
            $("#active").prop("checked", true);
        }
    }   
});

function setRoleName(g_myroleid) {
    $.ajax({
        url: "/Role/GetRoleById/" + g_myroleid,
        "async": false,
        type: "GET",
        data: { },
        success: function (result) {
            document.getElementById("RoleName").value = result.roleName;
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

$('#add').bind("click", function () {    
    submitId();
    return false;
});

function submitId() {  
    validateFields();
    if (g_validfields === false) {
        return;
    } else {
        g_mymoduleid = $("#ModulesList").val().toString();
        fnSubmit();
        document.getElementById('save').disabled = false;
        return ;
    }
    return ;
}

function fnSubmit() {
    var RoleId = g_myroleid;

    if (RoleId === 0) {
        moduleid = $("#ModulesList").val().toString();
        fnValidate($("#RoleName").val(), moduleid);
        var url = '/Role/GetModulesFeaturesAndAccess/' + moduleid;
    } else {
        moduleid = g_mymoduleid;
        g_isvalid = true;
        url = '/Role/GetUserRolesDetails/' + moduleid + "/" + Number(RoleId);
    }

    if (!g_isvalid) {       
        //$.notify('Duplicate Role. Already role exists for the module(s). !! ', "warn").addStyle("clickToHide", true);
        $.notify('Duplicate Role. Already role exists for the module(s). !! ', warnOptions);
        return;
    }

    if ($('#active').is(':checked')) {
        loadDataTable(url);
        return ;
    }
    return ;
}

function loadDataTable(url) {
    $("#userrolesgrid").DataTable({
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
            "pageLength": 3,
            "iDisplayLength": 3
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
                    "data": "ViewCol", "name": "View", "autoWidth": true, "className": "text-center",
                    "render": function (data) {
                        if (data === true) { return '<input type="checkbox" id="ViewChk" class="dt-checkboxes" checked = true>'; }
                        else { return '<input type="checkbox" id="ViewChk" class="dt-checkboxes">'; }
                    }
                },
                {
                    "data": "CreateCol", "name": "Create", "autoWidth": true, "className": "text-center",//"className": "dt-body-center",
                    "render": function (data) {
                        if (data === true) { return '<input type="checkbox" id="CreateChk" class="dt-checkboxes" checked = true>'; }
                        else { return '<input type="checkbox" id="CreateChk" class="dt-checkboxes">'; }
                    }
                },
                {
                    "data": "UpdateCol", "name": "Update", "autoWidth": true, "className": "text-center",//"className": "dt-body-center",
                    "render": function (data) {
                        if (data === true) { return '<input type="checkbox" id="UpdateChk" class="dt-checkboxes" checked = true>'; }
                        else { return '<input type="checkbox" id="UpdateChk" class="dt-checkboxes">'; }
                    }
                },
                {
                    "data": "DeleteCol", "name": "Delete", "autoWidth": true, "className": "text-center",//"className": "dt-body-center",
                    "render": function (data) {
                        if (data === true) { return '<input type="checkbox" id="DelChk" class="dt-checkboxes" checked = true>'; }
                        else { return '<input type="checkbox" id="DelChk" class="dt-checkboxes">'; }
                    }
                }

                //,{ "data": "ModuleId", "name": "ModuleId", "visible": false },
                //{ "data": "FeatureId", "name": "FeatureId", "visible": false }
                //,{ "aTargets": [6, 7] ,"visible": false} 
            ],
        "columnDefs": [{
            "defaultContent": "-",
            "targets": [6, 7],
            "visible": false,
            "searchable": false
        }],
        "language": {
            "emptyTable": "Data Not Found."
        },
        "bFilter": false,
        "bInfo": false,
        "bPaginate": false,
        "searching": false
    });
    return false;
}

function validateFields() {
    g_validfields = false;

    if ($("#RoleName").val() === null || $("#RoleName").val().trim() === "") {      
        $.notify('Please enter valid Role Name !!', warnOptions);
        return;
    }
    //if ($('#active').is(':checked')) {
        if ($("#ModulesList").val() === null || $("#ModulesList").val().length === 0) {
            $.notify('Please select Modules !!', warnOptions);
            return;
        //}
    }
    g_validfields = true;
    return false;
}

function fnValidate(rolename, ModuleStr) {   
    $.ajax({
        cache: false,
        type: "GET",
        async: false,
        url: "/Role/ValidateData" + "/" + rolename + "/" + ModuleStr,
        success: function (result) {
            if (!result.success) {
                window.g_isvalid = false;
                return;               
            } else {
                window.g_isvalid = true;
                return;
            }           
        },
        error: function () {           
        }
    });

    return false;
}

$('#save').click(function () {
    ///$('#staticBackdrop').modal('show');
    document.getElementById('staticBackdropLabel').innerHTML = 'Role';
    document.getElementById('msgtext').innerHTML = 'Do you want to save the changes?';
});

$('#msgOk').click(function () {
    //alert('msg ok');  
    $('#staticBackdrop').modal('hide');
    validateFields();
    if (g_validfields === false) {
        return;
    } else {
        return fnSave();
    }
});

$('#active').click(function () {
    if ($('#active').is(':checked')) {       
        $('#add').attr('disabled', false);
    }
});

$('#inactive').click(function () {
    //if ($('#inactive').is(':checked')) {
    //    $('#add').attr('disabled', true);
    //}
});

$('select#ModulesList').on('change', function (evt, params) {
    var selectedValue = params.selected;  
    //alert('selected : ' + selectedValue);
});



$("#userrolesgrid").on("click", "td input[type='checkbox']", function () {
    var isChecked = this.checked;
    var dtapi = $("#userrolesgrid").DataTable();
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


function convertTableToArrayObject() {

    var rightsObjects = [];
    var table = $('#userrolesgrid').DataTable();
    var data = table.rows().data();

    for (var i = 0; i < data.length; i++) {
        rightsObjects.push(data[i]);
    }

    return rightsObjects;
}

function fnSave() {
    var rolesObj = convertTableToArrayObject();        
    let str = $('#ModulesList').val();
    var LstModuleIdArr = [];
    LstModuleIdArr = str.toString().split(',');
       
    var formData = {
        "RoleMasDat": {
            "RoleId": g_myroleid,
            "RoleName": $("#RoleName").val(),
            "LstModuleId": LstModuleIdArr,
            "Status": $("input[type='radio'][name='Status']:checked").val()
        }
        ,
        "URoleDetDat": rolesObj
    };
    var jsonData = JSON.stringify(formData);
    //alert('FormData JSON : ' + jsonData);
    console.log(jsonData);

    $.ajax({
        url: "/Role/SaveUserRolesHeaderDetail",
        "async": false,
        type: "POST",
        data: { "jsonFormData": JSON.stringify(formData) },
        success: function (result) {
            if (result.success) {  
                setTimeout(function () {   
                    window.location.href = "/Role";
                    //window.location.reload();
                }, 1000);
                $.notify(result.message, successOptions);                         
            }
        },
        error: function () {
        }
    });   

    return false; ///for successful page redirect
}

function fnExit(){
    window.location.href =  '@Url.Action("", "Role")';
}

var successOptions = {
   // autoHideDelay: 1000,
    classname : "error",
    showAnimation: "fadeIn",
    hideAnimation: "fadeOut",
    //hideDuration: 2000,
    clickToHide: true,
    arrowShow: false,
    globalPosition: "top center",
    className: "success"
};

var warnOptions = {
    //autoHideDelay: 1000,  
    //showAnimation: "fadeIn",
    //hideAnimation: "fadeOut",
    //hideDuration: 2000,
    //arrowShow: false,
    globalPosition: "top center",
    //className: "success",
    type: "info",
    delay: 2000,
    animation: true,
    close:true
};


function url_redirect(url) {
    var X = setTimeout(function () {
        window.location.replace(url);
        return true;
    }, 300);

    if (window.location === url) {
        clearTimeout(X);
        return true;
    } else {
        if (window.location.href === url) {
            clearTimeout(X);
            return true;
        } else {
            clearTimeout(X);
            window.location.replace(url);
            return true;
        }
    }
};