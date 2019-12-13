$(document).on("click", "#f_btnsearch", function () {
    var s = $(this).attr("data-s");

    if (s == "0") {
        $("#freg").hide(500, function () { $("#s_t_00").show(500); });
        $(this).attr("data-s", "1");
    }
    else if (s == "1") {
        var text = $("#txtsearch").val();
        $(this).attr("data-s", "0");

        $.ajax({

            type:'POST',
            url: 'facultyadd.aspx/Search_faculty',
            data: JSON.stringify({ searchterms: text }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',

            sucess: function (data) {
                $("#employees_info").empty();

                if (data.d.length > 0) {
                    $("#employees_info").append("<tr><th>Employee_Name</th><th>Department_Name</th></tr>");
                    for (var i = 0; i < data.d.length; i++) {

                        $("#grdDemo").append("<tr><td>" + 
                        data.d[i].Employee_Name + "</td> <td>" +
                        data.d[i].Department_Name + "</td> <td></tr>");
                    }
                }


            },
            error: function () {
                alert(msg.responseText);
            }

        });

    }  
});

