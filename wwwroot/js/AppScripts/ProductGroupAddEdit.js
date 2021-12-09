var g_prodgrpid;

$(document).ready(function () {
    if ($("#Id").val() == 0) {
        $("#active").prop("checked", true);  
    }    

    //$("#GroupCode").keypress(function (e) {
    //    //if the letter is not digit then display error and don't type anything
    //    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
    //        //display error message
    //        $("#errmsg").html("Digits Only").show().fadeOut("slow");
    //        return false;
    //    }
    //});

});

$('#save').bind("click", function () {
    if ($("#GroupCode").val() === null || $("#GroupCode").val().trim() === "") {
        //$.notify('Please enter valid Group Code !!', warnOptions);
        document.getElementById("GroupCodeValid").innerHTML = 'Please enter valid Group Code !!';
        //const gcode = document.querySelector('#GroupCode');
        //gcode.setCustomValidity('Please enter valid Group Code');
        return;
    }
    if ($("#GroupName").val() === null || $("#GroupName").val().trim() === "") {
        $.notify('Please enter valid Group Name !!', warnOptions);
        return;
    }

    var groupcode = $("#GroupCode").val();
    var groupname = $("#GroupName").val();
    var Id = $("#Id").val();
    var status = $("input[type='radio'][name='Status']:checked").val();

    $.ajax({
        url: "/ProductGroup/SaveData",
        "async": false,
        type: "POST",
        data: {
            "Id": Id, "GroupCode": groupcode, "GroupName": groupname, "Status": status
        },
        success: function (result) {
            if (result.success) {
                setTimeout(function () {
                    window.location.href = "/ProductGroup";
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