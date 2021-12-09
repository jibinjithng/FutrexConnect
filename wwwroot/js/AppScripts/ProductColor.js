﻿

var g_prodcolid;
history.navigationMode = 'compatible';

window.onload = function breadcrumbs() {
    document.getElementById('titleheader').innerHTML = 'Product Color';
    document.getElementById('breadLevel1').innerHTML = 'Catalog';
    document.getElementById('breadLevel2').innerHTML = 'Product Color';
    document.getElementById("breadLevel2").href = 'ProductColor';
    document.getElementById('staticBackdropLabel').innerHTML = 'Product Color';
    document.getElementById('msgtext').innerHTML = 'Are you sure to delete this record?';
    document.getElementById('msgOk').innerHTML = "Yes"
    document.getElementById('msgCancel').innerHTML = "No"
};

$(document).ready(function () {
    dataTable = $("#prodColTable").DataTable({
        "processing": true,
        "responsive": true,
        "bLengthChange": false,
        "bFilter": true,
        "dom": 'lrtip',
        "bAutoWidth": false,
        "ajax": {
            "url": "/ProductColor/GetData",
            "type": "GET",
            // "async":false,
            "dataType": "json",
            "contentType": "application/json",
            "data": function (d) {
                /* console.log("data: ", d); */
                console.log(JSON.stringify(d));
                return JSON.stringify(d);
            }
        },
        "columns": [
            { "data": "ColorId", "className": "text-left" },
            { "data": "ColorCode", "className": "text-left" },
            { "data": "ColorName", "className": "text-left" },
            {
                "data": "Status", "className": "text-center",
                "render": function (data) {
                    if (data === true) { return "<span class='badge bg-success col-md-7'>Active</span>"; }
                    else { return "<span class='badge bg-danger col-md-7'>InActive</span>"; }
                }
            },
            {
                "data": "Id", "render": function (data, type, row) {
                    return "<a class='btn-default edit_btn'><img src='/icons/EditIcon.svg' class='align-middle img_md' data-toggle='modal' data-target='#form-modal' onclick=showInPopup(" + data + ")></a><a class='btn-danger del_btn' style='margin-left:5px' data-toggle='modal' data-target='#staticBackdrop' id='del'><img src='/icons/DeleteIcon.svg' class='align-middle img_md'></a>";
                },
                "orderable": false,
                "searchable": false,
                "width": '150px',
                "className": "text-center"
            },
            { "data": "Id", "name": "Id", "visible": false }
        ],
        "language": {
            "emptyTable": "No data found, Please click on <b>Add New</b> button"
        },
        "dom": "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-4'i><'col-sm-8'p>>"  // to show the info and pagination in the same div//
    });

    var table = $('#prodColTable').DataTable();

    $('#search').on('keyup', function () {
        table
            .search(this.value)
            .draw();
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

$('#prodColTable').on('click', 'tbody .del_btn', function () {
    var data = dataTable.row($(this).closest('tr')).data();
    g_prodcolid = data.Id;
    document.getElementById('msgtext').innerHTML = 'Are you sure to delete this Product Color  - ' + data.ColorName + ' ?';
});

$('#prodColTable').on('click', 'tbody .edit_btn', function () {
    var data = dataTable.row($(this).closest('tr')).data();
    g_prodcolid = data.Id;
});

$('#msgOk').click(function () {

    $('#staticBackdrop').modal().hide();
              
    $.ajax({
        type: "POST",
        url: '/ProductColor/Delete/' + g_prodcolid,
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



showInPopup = (id) => {
    $.ajax({
        type: 'GET',        
        url: "/ProductColor/AddorEdit/" + id,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            document.getElementById('Id').value = id;
            if (id == 0) {
                $('#form-modal .modal-title').html('Product Color - Create');                
            } else {
                $('#form-modal .modal-title').html('Product Color - Edit');
                $.ajax({
                    type: 'GET',         
                    async: false,
                    url: "/ProductColor/GetById/" + id,
                    success: function (result) {
                        document.getElementById('ColorCode').value = result.data[0].ColorCode;
                        document.getElementById('ColorName').value = result.data[0].ColorName;
                        if (result.data[0].Status === true) {
                            $("#active").prop("checked", true);
                        } else {
                            $("#inactive").prop("checked", true);
                        }
                    }
                });               
            }
            $('#form-modal').modal('show');
        }
    });
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