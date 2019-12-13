$(document).on("click", "#f_btnsearch", function () {
    var s = $(this).attr("data-s");

    if (s == "0") {
        $("#freg").hide(500, function () { $("#s_t_00").show(100); });
        $(this).attr("data-s", "1");
    }
    else if (s == "1") {
        var text = $("#txtsearch").val();
        $.ajax({
            type: "POST",
            url: "facultyadd.aspx/Search_faculty",
            data: JSON.stringify({ searchterms: text }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success:OnSuccess,
            error:OnError
        });

        function OnSuccess(data){
                $("#employees_info").empty();

                if (data.d.length > 0) {
                    $("#employees_info").append("<tr style=\"color:White;background-color:#1C5E55;font-weight:bold;\"><th>Employee_Name</th><th>Department_Name</th></tr>");
                    for (var i = 0; i < data.d.length; i++) {
                        var l = "<tr style=\"color:#333333;background-color:#F7F6F3;\">";
                        if (i % 2 != 0) {
                            l = "<tr>";
                        }
                        $("#employees_info").append(l+"<td>" +
                        data.d[i].Employee_Name + "</td> <td>" +
                      data.d[i].Department_Name + "</td> <td></tr>");
                    }
                }


        }

        function OnError(){
                alert(msg.responseText);
            }
        }

});

