var Popup, dataTable;
var g_countryid;

window.onload = function breadcrumbs() {
    document.getElementById('titleheader').innerHTML = 'Country';
    document.getElementById('breadLevel1').innerHTML = 'Settings';
    document.getElementById('breadLevel2').innerHTML = 'Country';
    document.getElementById("breadLevel2").href = 'Country';
    document.getElementById('staticBackdropLabel').innerHTML = 'Country';
    document.getElementById('msgtext').innerHTML = 'Are you sure to delete this record?';
    document.getElementById('msgOk').innerHTML = "Yes"
    document.getElementById('msgCancel').innerHTML = "No"
};

$(document).ready(function () {
    dataTable = $("#countryTable").DataTable({
        "processing": true,
        "responsive": true,
        "bLengthChange": false,
        "bFilter": true,
        "dom": 'lrtip',
        "bInfo": true,
        "bAutoWidth": false,
        "ajax": {
            "serverSide": true,
            "url": "/Country/GetData",
            "type": "GET",
            "datatype": "json",
            "contentType": "application/json",
            //"data": function (d) {
            //    /* console.log("data: ", d); */
            //    console.log(JSON.stringify(d));
            //    return JSON.stringify(d);
            //}
            //"lengthMenu": [5, 10, 25, 50, 75, 100],
            //"pageLength": 3,
            //"iDisplayLength": 3
        },

        "columns": [
            //{ "data": "Id" , "className": "text-center"},
            { "data": "CountryId", "className": "text-left" },
            { "data": "CountryName", "className": "text-left" },
            { "data": "ISOCode", "className": "text-center" },
            { "data": "CountryCode", "className": "text-center" },
            {
                "data": "Status", "className": "text-center",
                "render": function (data) {
                    if (data === true) { return "<span class='badge bg-success col-md-7' >Active</span>"; }
                    else { return "<span class='badge bg-danger col-md-7' >InActive</span>"; }
                }
            },
            {
                "data": "Id", "render": function (data) {
                    // onclick=showInPopup(" + data + ")   onclick=Delete(" + data + ")  
                    return "<a class='btn-default edit_btn'><img src='/icons/EditIcon.svg' class='align-middle img_md' data-toggle='modal' data-target='#form-modal'></a><a class='btn-danger del_btn' style='margin-left:5px' data-toggle='modal' data-target='#staticBackdrop' id='del'><img src='/icons/DeleteIcon.svg' class='align-middle img_md'></a>";
                },
                "orderable": false,
                "searchable": false,
                "width": '150px',
                "className": "text-center"
            }
        ],
        "language": {
            "emptyTable": "No data found, Please click on <b>Add New</b> button"
        },
        "dom": "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-4'i><'col-sm-8'p>>"  // to show the info and pagination in the same div i- info, (if required can be changed as l for length), p - pagination//
    });

    var table = $('#countryTable').DataTable();

    //$('#add').bind("click", function () {
    $('#search').on('keyup', function () {
        table
            .search(this.value)
            .draw();
    });
});

$('#countryTable').on('click', 'tbody .del_btn', function () {
    var data = dataTable.row($(this).closest('tr')).data();
    g_countryid = data.Id;
    document.getElementById('msgtext').innerHTML = 'Are you sure to delete this country  - ' + data.CountryName + ' ?';    
    Delete(g_countryid);
});

function Delete(id) {
    g_countryid = id;
}

$('#msgOk').click(function () {
    $('#staticBackdrop').modal().hide();
    $.ajax({
        type: "POST",
        url: "/Country/Delete/" + g_countryid,
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

$('#countryTable').on('click', 'tbody .edit_btn', function () {
    var data = dataTable.row($(this).closest('tr')).data();
    g_countryid = data.Id;
    fnEdit(g_countryid);
});

function fnEdit(Id) {
    showInPopup(Id);
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

showInPopup = (id) => {
    $.ajax({
        type: 'GET',
        url: "/Country/AddorEdit/" + id,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            if (id == 0) {
                $('#form-modal .modal-title').html('Country - Create');
            } else {
                $('#form-modal .modal-title').html('Country - Edit');
            }
            
            $('#form-modal').modal('show');
        }
    });
}

function SubmitForm(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $('#form-modal').modal("toggle");
                    $('#form-modal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    //$('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    dataTable.ajax.reload();
                    $.notify(data.message, successOptions);
                }
            }
        });
    }
    return false;
}