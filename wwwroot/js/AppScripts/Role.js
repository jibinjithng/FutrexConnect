var Popup, dataTable;

var g_roleid, g_moduleid, g_delvalid;

window.onload = function breadcrumbs() {    
    document.getElementById('titleheader').innerHTML = 'Role';
    document.getElementById('breadLevel1').innerHTML = 'User Management';
    document.getElementById('breadLevel2').innerHTML = 'Role';
    document.getElementById("breadLevel2").href = 'Role';
    document.getElementById('staticBackdropLabel').innerHTML = 'Role';
    document.getElementById('msgtext').innerHTML = 'Are you sure to delete this record?';
    document.getElementById('msgOk').innerHTML = "Yes"
    document.getElementById('msgCancel').innerHTML = "No"
};

$(document).ready(function () {

    dataTable = $("#rolesTable").DataTable({
        "processing": true,        
        "responsive": true,
        "bLengthChange": false,        
        "bFilter": true,
        "dom": 'lrtip',
        "bAutoWidth": false,       
        "ajax": {
            "url": "/Role/GetData",            
            "type": "GET",
            "dataType": "json",
            "contentType": "application/json",
            "data": function (d) {
                /* console.log("data: ", d); */
                console.log(JSON.stringify(d));
                return JSON.stringify(d);
            }
        },        
        "columns": [
            { "data": "RoleName", "className": "text-left" },
            { "data": "Module", "className": "text-left" },
            {
                "data": "Status", "className": "text-center",
                "render": function (data) {
                    if (data === true) { return "<span class='badge bg-success col-md-7'>Active</span>";}
                    else { return "<span class='badge bg-danger col-md-7'>InActive</span>";}
                }
            },
            {
                "data": "RoleId", "render": function (data, type, row) {
                    //onclick=fnEdit(" + data + ") data-toggle='modal' data-target='#staticBackdrop'   
                    return "<a class='btn-default edit_btn' ><img src='/icons/EditIcon.svg' class='align-middle img_md'></a><a class='btn-danger' style='margin-left:5px'  id='del' data-toggle='modal' data-target='#staticBackdrop' ><img src='/icons/DeleteIcon.svg' onclick=Delete(" + data + ") class='align-middle img_md'></a>";
                },
                "orderable": false,
                "searchable": false,
                "width": '150px',
                "className": "text-center"              
            },
            { "data": "ModuleId", "name": "ModuleId", "visible": false }
        ],
        "language": {
            "emptyTable": "No data found, Please click on <b>Add New</b> button"
        },
        "dom": "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-4'i><'col-sm-8'p>>"  // to show the info and pagination in the same div//
    }); 

    var table = $('#rolesTable').DataTable();
   
    $('#search').on('keyup', function () {
        table
            .search(this.value)
            .draw();
    });   
});


function Delete(id) {
    g_roleid = id;
}

function toast() {
    var template = document.createElement('template')
    html = htmlMarkup.trim()
    template.innerHTML = html
    return template.content.firstChild
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}

$('#msgOk').click(function () {
    //alert('selected role id : ' + g_roleid);  

    $('#staticBackdrop').modal().hide();
    
    ValidateDeletion(g_roleid);

    if (!g_delvalid) {
        setTimeout(function () {
            window.location.reload();
        }, 2000);
        $.notify("Users are defined for the role. Can't delete !!", warnOptions);        
        return;
    }

    $.ajax({
        type: "POST",
        url: '/Role/Delete/' + g_roleid,
        success: function (data) {
            if (data.success) {    
                setTimeout(function () {  
                    window.location.reload();
                }, 1000);
                $.notify(data.message, successOptions);
            }
        }
    });
});


function ValidateDeletion(id) {
    $.ajax({
        cache: false,
        type: "GET",
        async: false,
        url: "/Role/ValidateDeletion" + "/" + id,
        success: function (result) {
            if (!result.success) {
                g_delvalid = false;
            } else {
                g_delvalid = true;
            }           
        },
        error: function () {
        }
    });
}

$('#rolesTable').on('click', 'tbody .edit_btn', function () {
    var data = dataTable.row($(this).closest('tr')).data(); 
    g_roleid = data.RoleId;
    g_moduleid = data.ModuleId;
    fnEdit(g_roleid, g_moduleid);
});

function fnEdit(RoleId,ModuleId) { 
    window.location = "/Role/AddorEdit/" + RoleId + "/" + ModuleId;
}   

var successOptions = {
    showAnimation: "fadeIn",
    hideAnimation: "fadeOut",
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