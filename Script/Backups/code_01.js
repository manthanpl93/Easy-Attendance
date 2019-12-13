$(document).on('click', '.pr_ap a', function () {
    $(this).parent().parent().hide(500);
    $(this).parent().parent().remove();
    var responce = false;
    var id = $(this).attr("data-reactid");
    var status = $(this).attr("data-status");
    if (id != "" || status == "a" || status == "p") {
       
        $.ajax({

            type: "POST",
            url: "TakeAttandance.aspx/Fill_Attandance",
            dataType: "json",
            data: JSON.stringify({ A_Id: id, STATUS: status }),
            contentType: "application/json; charset=utf-8",


            success: function (res) {

                var s = res.d;
                if (s == true)
                {
                    var h = "<div class=\"loading\"><img src=\"../Images/ajax-loader.gif\" /></div>";
                    $("#attendananceview").empty();
                    $("#attendananceview").append(h);

                    $.ajax({

                        type: "POST",
                        url: "TakeAttandance.aspx/Final_Attendance",
                        dataType: "json",
                        data: JSON.stringify({}),
                        contentType: "application/json; charset=utf-8",
                        success: function (res) {

                            
                            var s = res.d;
                            $("#attendananceview").empty();
                            $("#attendananceview").append(s);

                        },
                        error: function (msg) {
                            alert(msg.responseText);
                        },
                    });
                }
               
            },
            error: function (msg) {
                alert(msg.responseText);
            },
        });
    }

    if (responce == true) {

    }

});






