$(document).on('click', '#t_p_c_0', function () {
    var seen_status = $(this).attr("data-seen");
    var me = this;
    var hide_status = $(this).attr("data-hide");
    if (seen_status == "0" && hide_status == "0") {
        $.ajax({
            type: 'POST',
            url: 'TakeAttandance.aspx/present_absent_student_list',
            data: JSON.stringify({ category: 2 }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (res) {
                $("#l_p_s_0").hide();
                $("#l_p_s_0").html(res.d);

                $("#l_p_s_0").slideDown("slow", function () { $("#t_p_c_0").find(".ic img").attr("src", "../Images/minus.png"); });
                $(me).attr("data-seen", "1");
                $(me).attr("data-hide", "1");
            },

            error: function () {
                alert(msg.responseText);
            }
        });

    }

    else if (seen_status == "1" && hide_status == "0") {

        $("#l_p_s_0").slideDown("slow", function () { $("#t_p_c_0").find(".ic img").attr("src", "../Images/minus.png"); });

        $(me).attr("data-hide", "1");
    }
    else if (seen_status == "1" && hide_status == "1") {

        $("#l_p_s_0").slideUp(function () { $("#t_p_c_0").find(".ic img").attr("src", "../Images/plus.png"); });

        $(me).attr("data-hide", "0");
    }
});


$(document).on('click', '.pr_ap a', function () {

    var me = this;
    $(this).parent().parent().hide(500, function () { $(me).parent().parent().remove(); });

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
                if (s == true) {
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



$(document).on('click', '#t_d_c_0', function () {
    $("#takeattandance").show();
    $("#attendananceview").empty();

});


$(document).on('click', '#abs', function () {
    var seen_status = $(this).attr("data-seen");
    var me = this;
    var hide_status = $(this).attr("data-hide");
    if (seen_status == "0" && hide_status == "0") {
        $.ajax({
            type: 'POST',
            url: 'TakeAttandance.aspx/present_absent_student_list',
            data: JSON.stringify({ category: 3 }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (res) {
                $("#l_a_s_0").hide();
                $("#l_a_s_0").html(res.d);
               
                $("#l_a_s_0").slideDown("slow", function () { $("#t_a_c_0").find(".ic img").attr("src", "../Images/minus.png"); });
                $(me).attr("data-seen", "1");
                $(me).attr("data-hide", "1");
            },

            error: function () {
                alert(msg.responseText);
            }
        });

    }

    else if (seen_status == "1" && hide_status == "0") {

        $("#l_a_s_0").slideDown("slow", function () { $("#abs").find(".ic img").attr("src", "../Images/minus.png"); });

        $(me).attr("data-hide", "1");
    }
    else if (seen_status == "1" && hide_status == "1") {

        $("#l_a_s_0").slideUp(function () { $("#abs").find(".ic img").attr("src", "../Images/plus.png"); });

        $(me).attr("data-hide", "0");
    }
});




