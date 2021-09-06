
//SalesOrder/create.js

(function ($) {

    //var from = $("#from").val();
    //var to = $("#to").val();

    //if (Date.parse(from) > Date.parse(to)) {
    //    alert("Invalid Date Range");
    //}
    //else {
    //    alert("Valid date Range");
    //}


    var _$deadline = $('#SalesOrder_Deadline');

    var _$todayBtn = $('#TodayButton');
    var _$minus1Btn = $('#Minus1Button');
    var _$plus1Btn = $('#Plus1Button');
    var _$plus2Btn = $('#Plus2Button');
    var _$plus3Btn = $('#Plus3Button');
    var _$plus4Btn = $('#Plus4Button');
    var _$plus5Btn = $('#Plus5Button');



    _$todayBtn.click(function (e) {
        e.preventDefault();
        var today = new Date();
        _$deadline.val(FormatDateToString(today));
    });


    _$minus1Btn.click(function (e) {
        e.preventDefault();
        var deadlineDt = FormatStringToDate(_$deadline.val());
        deadlineDt.setDate(deadlineDt.getDate() - 1);
        _$deadline.val(FormatDateToString(deadlineDt));
    });

    _$plus1Btn.click(function (e) {
        e.preventDefault();
        var deadlineDt = FormatStringToDate(_$deadline.val());
        deadlineDt.setDate(deadlineDt.getDate() + 1);
        _$deadline.val(FormatDateToString(deadlineDt));
    });

    _$plus2Btn.click(function (e) {
        e.preventDefault();
        var deadlineDt = FormatStringToDate(_$deadline.val());
        deadlineDt.setDate(deadlineDt.getDate() + 2);
        _$deadline.val(FormatDateToString(deadlineDt));
    });

    _$plus3Btn.click(function (e) {
        e.preventDefault();
        var deadlineDt = FormatStringToDate(_$deadline.val());
        deadlineDt.setDate(deadlineDt.getDate() + 3);
        _$deadline.val(FormatDateToString(deadlineDt));
    });

    _$plus4Btn.click(function (e) {
        e.preventDefault();
        var deadlineDt = FormatStringToDate(_$deadline.val());
        deadlineDt.setDate(deadlineDt.getDate() + 4);
        _$deadline.val(FormatDateToString(deadlineDt));
    });

    _$plus5Btn.click(function (e) {
        e.preventDefault();
        var deadlineDt = FormatStringToDate(_$deadline.val());
        deadlineDt.setDate(deadlineDt.getDate() + 5);
        _$deadline.val(FormatDateToString(deadlineDt));
    });

    function FormatDateToString(dt) {
        var year = dt.getFullYear();
        var month = (1 + dt.getMonth()).toString();
        month = month.length > 1 ? month : '0' + month;
        var day = dt.getDate().toString();
        day = day.length > 1 ? day : '0' + day;
        return day + '-' + month + '-' + year;
    }
    function FormatStringToDate(str) {
        var parts = str.split("-");
        var dt = new Date(+parts[2], parts[1] - 1, +parts[0]);
        return dt;
    }

}(jQuery));