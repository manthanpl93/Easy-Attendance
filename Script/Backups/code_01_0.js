$(document).on('click', '#l_p_s_0 .pr_ap_0 a', function () {
    alert("hi");
    var me = this;
  

    var responce = false;
    var id = $(this).attr("data-reactid");
    var status = $(this).attr("data-status");
    if (id != "" || status == "a") {

        $.ajax({
            type: "POST",
            url: "TakeAttandance.aspx/Fill_Attandance",
            dataType: "json",
            data: JSON.stringify({ A_Id: id, STATUS: status }),
            contentType: "application/json; charset=utf-8",


            success: function (res) {
                $(me).parent().parent().hide(500, function () { $(me).parent().parent().remove(); });
                
            },
            error: function (msg) {
                alert(msg.responseText);
            },
        });
    }

});