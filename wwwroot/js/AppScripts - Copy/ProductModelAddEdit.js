var g_prodgrpid;

$(document).ready(function () {
    if ($("#Id").val() == 0) {
        $("#active").prop("checked", true);  
    }   
});

$('#save').bind("click", function () {
    if ($("#ModelCode").val() === null || $("#ModelCode").val().trim() === "") {
        $.notify('Please enter valid Model Code !!', warnOptions);
        return;
    }
    if ($("#ModelName").val() === null || $("#ModelName").val().trim() === "") {
        $.notify('Please enter valid Model Name !!', warnOptions);
        return;
    }

    var modelcode = $("#ModelCode").val();
    var modelname = $("#ModelName").val();
    var Id = $("#Id").val();
    var status = $("input[type='radio'][name='Status']:checked").val();

    $.ajax({
        url: "/ProductModel/SaveData",
        "async": false,
        type: "POST",
        data: {
            "Id": Id, "ModelCode": modelcode, "ModelName": modelname, "Status": status
        },
        success: function (result) {
            if (result.success) {
                setTimeout(function () {
                    window.location.href = "/ProductModel";
                }, 1000);
                $.notify(result.message, successOptions);
            }
        },
        error: function () {
        }
    });
});

var warnOptions = {   
    globalPosition: "top center",    
    type: "info",
    delay: 500,
    animation: true,
    close: true
};