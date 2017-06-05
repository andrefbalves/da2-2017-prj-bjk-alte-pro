$(document).ready(function () {

    $(".btnrules").hide();

    $("#btnhit").click(function () {
        $("#hit").toggle();
        $("#stand").hide();
        $("#double").hide();
        $("#surrender").hide();
    });

    $("#btnstand").click(function () {
        $("#stand").toggle();
        $("#hit").hide();
        $("#double").hide();
        $("#surrender").hide();
    });

    $("#btndouble").click(function () {
        $("#double").toggle();
        $("#hit").hide();
        $("#stand").hide();
        $("#surrender").hide();
    });

    $("#btnsurrender").click(function () {
        $("#surrender").toggle();
        $("#hit").hide();
        $("#stand").hide();
        $("#double").hide();
    });
});

$('.roundbtn').click(function () {
    $(this).toggleClass('active')
    $(this).siblings().removeClass('active');
});

$(document).ready(function () {

    $("#projeto").hide();

    $("#btnequipa").click(function () {
        $("#equipa").toggle();
        $("#projeto").hide();
    });

    $("#btnmembros").click(function () {
        $("#membros").toggle();
        $("#projeto").hide();
    });

    $("#btnprojeto").click(function () {
        $("#projeto").toggle();
        $("#equipa").hide();
        $("#membros").hide();
    });
});

$(document).ready(function () {

    $("#details").hide();

    $("#btndetail").click(function () {
        $("#details").toggle();
        $("#global").hide();        
    });

    $("#btnglobal").click(function () {
        $("#global").toggle();
        $("#details").hide();
    });
});