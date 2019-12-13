window.status = "false";
function callmethod() {
    PageMethods.pre_abs();
}



$(document).ready(function () {
    $('#openmenu img').click(function(){
        $('#openmenu img').hide(200);
        $('#menu').show(500);
    });

   



    $(document).on('click', '.number', function () {
        $(this).hide();
        $(this).parent().children('.stu_name').show(100);
    });

    $(document).on('click', '#icon img', function () {
        var status = $(this).attr("data-s");
        if (status == "1") {
            $('#categorylist').show(100);
            $(this).attr("data-s", "2");
        }
        else if(status=="2"){
            $('#categorylist').hide(100);
            $(this).attr("data-s", "1");
        }
    });

    $(document).on('click', '#categorylist li', function () {
        var status = $(this).attr("data-s");
        if(status=="1")
        {
            $(".number").hide();
            $(".stu_name").show();
            $('#categorylist li').removeClass('select');
            $(this).addClass('select');
        }
        else if(status=="2")
        {
            $(".number").show();
            $(".stu_name").hide();
            $('#categorylist li').removeClass('select');
            $(this).addClass('select');
        }
        
        $('#categorylist').hide();

        $('#icon img').attr("data-s", "1");

    });

$(document).on('click', '#student_info i', function () { $('#info').toggle("slow"); $('#student_info i').hide(); $('#info i').show(); });
$(document).on('click', '#arrow', function () { $('#searchmodule').show(500); });
$(document).on('click', '#info i', function () { $('#info').hide(500); $('#student_info i').show();});
$(document).on('click', '.stu_name', function () { $(this).hide(); $(this).parent().children('.number').show(100); });

$(document).on('click', '.timetabledlt img', function () {
    $(this).parent().parent().hide(500);
    var responce = false;
    var id = $(this).attr('data-reactid');

    if(id!="")
    {
     
        $.ajax({
            type: 'POST',
            url: 'TimeTable.aspx/DeleteTimeTableRecord',
            data: JSON.stringify({TimeTableId:id}),
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            complete: function () {
                responce = true;
            },

            error: function () {
                alert(msg.responseText);
            }
        });


        if(responce==true)
        {
            alert("hi");
        }
    }



});


$(document).on('click', '#abc', function () {
           $.ajax({
            type: 'POST',
            url: 'TakeAttandance.aspx/pre_abs',
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg){
                alert("success");
            },
            error: function (msg){
                alert(msg.responseText);
            }
        });
});

 $('#attendananceview p').click(function () {
    });
    function takeattendancefrm_updateattendance()
    {
        $('takeattandance').hide();
        $('attendananceview').show();
    }
});


$(document).ready(function () {
    $('#btn').click(function () {

        if (status == "false")
        {
            $('.maininfo').hide();
            $('.editinfo').show();
            event.preventDefault();
            status = "true";
        }
        else if(status="true")
        {
            $('.maininfo').show();
            $('.editinfo').hide();
            status = "false";
            return true;
        }
             
    });
});


$(document).ready(function () {
    $('#menu a.back').click(function () {
        $('#menu').hide(500);
        $('#openmenu img').show(200);
       
    });


    $('#timetablecategory ul li.1').click(function () {
        $('#block2').hide();
        $('#block1').show();

    });

    $('#timetablecategory ul li.2').click(function () {
        $('#block1').hide();
        $('#block2').show();
    });

});


