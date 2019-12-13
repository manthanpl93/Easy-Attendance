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




