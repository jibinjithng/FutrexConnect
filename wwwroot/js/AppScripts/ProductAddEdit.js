var g_prodid;

$(document).ready(function () {
        if ($("#Id").val() == 0) {
            $("#active").prop("checked", true);
        }
});

function fillSelectBoxes(id,ProdGrpId, ProdModId, ProdColId) {

    g_prodid = id;

    $("#PrdGrpList").empty();
    $("#PrdModList").empty();
    $("#PrdColList").empty();

    //alert("AddEditJs : " + ProdGrpId + " " + ProdModId + " " + ProdColId);

    $.ajax({
        url: "/Product/GetProductGroup",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: JSON,
        success: function (result) {
            $(result).each(function () {                
                $("#PrdGrpList").append($("<option></option>").val(this.Value).html(this.Text));
            }); 
            $("#PrdGrpList").val(ProdGrpId);
        },
        
        error: function (data) { }
    });

    $.ajax({
        url: "/Product/GetProductModel",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: JSON,
        success: function (result) {
            $(result).each(function () {                
                $("#PrdModList").append($("<option></option>").val(this.Value).html(this.Text));
            });    
            $("#PrdModList").val(ProdModId);
        },
        error: function (data) { }
    });

    $.ajax({
        url: "/Product/GetProductColor",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        datatype: JSON,
        success: function (result) {
            $(result).each(function () {                
                $("#PrdColList").append($("<option></option>").val(this.Value).html(this.Text));
            });      
            $("#PrdColList").val(ProdColId);
        },
        error: function (data) { }
    });
                
    //element = document.getElementById('PrdColList');
    //if (element != null) {
    //    console.log('value from func : ' + document.getElementById('#PrdColList').val());
    //}
    //else {
    //    console.log('element is null');
    //}

}

$('#save').bind("click", function () {
       
    if ($("#ProductName").val() === null || $("#ProductName").val().trim() === "") {
        $.notify('Please enter valid Product Name !!', warnOptions);
        return;
    }
    
    if ($("#PrdGrpList").val() === null || $("#PrdGrpList").val().length === 0 || $("#PrdGrpList").val() ==="") {
        $.notify('Please enter valid Product Group !!', warnOptions);
        return;
    }
    if ($("#PrdModList").val() === null || $("#PrdModList").val().length === 0 || $("#PrdModList").val() ==="") {
        $.notify('Please enter valid Product Model !!', warnOptions);
        return;
    }
    if ($("#PrdColList").val() === null || $("#PrdColList").val().length === 0 || $("#PrdColList").val() === "") {
        $.notify('Please enter valid Product Color !!', warnOptions);
        return;
    }
    if ($("#ProductCode").val() === null || $("#ProductCode").val().trim() === "") {
        $.notify('Please enter valid Product Code !!', warnOptions);
        return;
    }
       
    var prodcode = $("#ProductCode").val();
    var prodname = $("#ProductName").val();
    var prodgrpid = $("#PrdGrpList").val();
    var prodmodid = $("#PrdModList").val();
    var prodcolid = $("#PrdColList").val();

    //alert(id + " " + $("#Id").val() +" " + g_prodid);
    
    var formData = {
        "id": $("#Id").val(),
        "prodname": prodname,
        "prodgrpid": prodgrpid,
        "prodmodid": prodmodid,
        "prodcolid": prodcolid,
        "prodcode": prodcode,
        "status": $("input[type='radio'][name='Status']:checked").val()
    };

    var jsonData = JSON.stringify(formData);

    $.ajax({
        url: "/Product/SaveData",
        "async": false,
        type: "POST",
        data: { "jsonFormData": JSON.stringify(formData) },      
        success: function (result) {
            if (result.success) {
                setTimeout(function () {
                    window.location.href = "/Product";
                }, 1000);
                $.notify(result.message, successOptions);
            }
        },
        error: function () {
        }
    });
});

function SelectElement(selectElementId, valueToSelect) {
    //alert(selectElementId + ' ' + valueToSelect);
    //alert($("#PrdColList").val());
    //$("PrdColList").selectElementId = valueToSelect;
    //var dd = document.getElementById(selectElementId);
    //for (var i = 0; i < dd.options.length; i++) {
    //    if (dd.options[i].val === valueToSelect) {
    //        console.log(dd.options[i].val);
    //        dd.selectedIndex = i;
    //        break;
    //    }
    //}
    //var element = document.getElementById(selectElementId);
    //element.value = valueToSelect;
    //for (var option of document.getElementById(selectElementId).options) {
    //    if (option.value === valueToSelect) {
    //        option.selected = true;
    //        return;
    //    }
    //}
}

var warnOptions = {   
    globalPosition: "top center",    
    type: "info",
    delay: 500,
    animation: true,
    close: true
};