var g_prodcolid;

$(document).ready(function () {
    if ($("#Id").val() == 0) {
        $("#active").prop("checked", true);  
    }   
});

$('#save').bind("click", function () {
    if ($("#ColorCode").val() === null || $("#ColorCode").val().trim() === "") {
        $.notify('Please enter valid Color Code !!', warnOptions);
        return;
    }
    if ($("#ColorName").val() === null || $("#ColorName").val().trim() === "") {
        $.notify('Please enter valid Color Name !!', warnOptions);
        return;
    }

    var colorcode = $("#ColorCode").val();
    var colorname = $("#ColorName").val();
    var Id = $("#Id").val();
    var status = $("input[type='radio'][name='Status']:checked").val();

    $.ajax({
        url: "/ProductColor/SaveData",
        "async": false,
        type: "POST",
        data: {
            "Id": Id, "ColorCode": colorcode, "ColorName": colorname, "Status": status
        },
        success: function (result) {
            if (result.success) {
                setTimeout(function () {
                    window.location.href = "/ProductColor";
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