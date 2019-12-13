$(document).on('click', '#u_n_01', function () {
    var s = $(this).attr("data-seen");
    if (s == "0") {
        $("#nf_corner").slideDown("slow");
        $(this).attr("data-seen", "1");
    }
    else if (s == "1") {
        $("#nf_corner").slideUp();
        $(this).attr("data-seen", "0");
    }
});

$(document).on('click', '#openmenu img,#StudentProfile', function () {
    var s = $("#u_n_01").attr("data-seen");
    if (s == "1") {
        $("#nf_corner").slideUp();
        $(this).attr("#u_n_01", "0");
    }


});


