var Popup, dataTable;
var g_userid;

window.onload = function breadcrumbs() {
    document.getElementById('titleheader').innerHTML = 'Users & Access Rights';
    document.getElementById('breadLevel1').innerHTML = 'User Management';
    document.getElementById('breadLevel2').innerHTML = 'Users & Access Rights';
    document.getElementById("breadLevel2").href = 'UserRights';
    document.getElementById('msgtext').innerHTML = 'Are you sure to delete this record?';
    document.getElementById('msgOk').innerHTML = "Yes"
    document.getElementById('msgCancel').innerHTML = "No"
};

$(document).ready(function () {
    dataTable = $("#userTable").DataTable({
        "processing": true,
        "responsive": true,
        "bLengthChange": false,
        "bFilter": true,
        "dom": 'lrtip',
        "bInfo": true,
        "bAutoWidth": false,
        "ajax": {
            "url": "/UserRights/GetData",
            "type": "GET",
            "datatype": "json"
        },        
        "columns": [          
            { "data": "FirstName", "className": "text-left" },
            { "data": "Email", "className": "text-center" },
            { "data": "Role", "className": "text-center" },
            {
                "data": "Status", "className": "text-center",
                "render": function (data) {
                    if (data === true) { return "<span class='badge bg-success col-md-7'>Active</span>";}
                    else { return "<span class='badge bg-danger col-md-7'>InActive</span>";}
                }
            },
            {
                "data": "UserId", "render": function (data) {
                    //onclick=fnEdit(" + data + ") 
                    return "<a class='btn-default edit_btn'><img src='/icons/EditIcon.svg' class='align-middle img_md'></a><a class='btn-danger' style='margin-left:5px' id='del' data-toggle='modal' data-target='#staticBackdrop'><img src='/icons/DeleteIcon.svg' onclick=Delete(" + data + ") class='align-middle img_md'></a>";
                },
                "orderable": false,
                "searchable": false,
                "width": '150px',
                "className": "text-center"
            },            
        ],
        "columnDefs": [{
            "defaultContent": "-",
            "targets": [5],
            "visible": false,
            "searchable": false
        }],
        "language": {
            "emptyTable": "No data found, Please click on <b>Add New</b> button"
        },
        "dom": "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-4'i><'col-sm-8'p>>"  // to show the info and pagination in the same div i- info, (if required can be changed as l for length), p - pagination//
    });

    var table = $('#userTable').DataTable();

    //$('#add').bind("click", function () {
    $('#search').on('keyup', function () {
        table
            .search(this.value)
            .draw();
    });
});

function Delete(id) {
    g_userid = id;
}

$('#msgOk').click(function () {
    $('#staticBackdrop').modal().hide();

    $.ajax({
        type: "POST",
        url: "/UserRights/Delete/" + g_userid,
        success: function (data) {
            if (data.success) {
                setTimeout(function () {
                    window.location.reload();
                }, 1000);
                $.notify(data.message, successOptions);
                //dataTable.ajax.reload();
                //$.notify(data.message, successOptions);
            }
        }
    });

});

function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}

$('#userTable').on('click', 'tbody .edit_btn', function () {
    var data = dataTable.row($(this).closest('tr')).data();
    g_userid = data.UserId;
    fnEdit(g_userid);
});

function fnEdit(UserId) {
    window.location = "/UserRights/AddorEdit/" + UserId;    
}

var successOptions = {
    autoHideDelay: 1000,
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