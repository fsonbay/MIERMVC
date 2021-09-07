
//SalesOrder/create.js

(function ($) {

    var _$deadline = $('#Deadline');
    var _$todayBtn = $('#TodayButton');
    var _$minus1Btn = $('#Minus1Button');
    var _$plus1Btn = $('#Plus1Button');
    var _$plus2Btn = $('#Plus2Button');
    var _$plus3Btn = $('#Plus3Button');
    var _$plus4Btn = $('#Plus4Button');
    var _$plus5Btn = $('#Plus5Button');

    //SALES ORDER LINE
    var $sets = $('.line-sets');
    var $set = $('.line-set');
    var _$addLineBtn = $('#AddLineButton');
    var _$delLineBtn = $('.delete-line');
    var $lineAmount = $(".line-amount");
    var _$lineCalc = $('.line-calculation');

    //TOTAL AMOUNT
    var _$total = $('.total-amount');

    ButtonVisibility();

    //DEADLINE EVENTS
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

    //SALES ORDER LINES
    var wrapper = $sets;
    _$addLineBtn.click(function (e) {

        //Cancel default postback
        e.preventDefault();

        //Create new item and show (to override case style display none)
        var newItem = $(".line-set:last").clone(true);
        // newItem.show();

        //Input Values
        newItem.find(':input').each(function () {

            //Texbox
            $(this).val('');

            //mark-for-delete
            if ($(this).hasClass("isActive")) {
                $(this).val('true');
            }

            //ID
            if ($(this).hasClass("line-id")) {
                $(this).val('0');
            }
        });

        //Add clone
        wrapper.append(newItem);

        //Focus
        $('.line-set:last-child :input:enabled:visible:first').focus();

        //Reorder index
        ReorderIndex();

        //Button
        ButtonVisibility();

    });

    _$delLineBtn.click(function (e) {

        //Cancel default postback
        e.preventDefault();

        //Set hidden value
        $(this).parents('.line-set').find('.isActive').val("false");

        //Check Id, if ID = 0 ==> new set, remove. else hide.
        var id = $(this).parents('.line-set').find('.line-id').val();

        if (id === '0') {
            $(this).parents('.line-set').remove();
        }
        else {
            $(this).parents('.line-set').hide();
        }

        ReorderIndex();
        ButtonVisibility();
        CalculateTotalAmount();
    });
    _$lineCalc.keyup(function (event) {

        var i = $(this).attr('name');
        var start_pos = i.indexOf('[') + 1;
        var end_pos = i.indexOf(']', start_pos);
        var index = i.substring(start_pos, end_pos);

        var quantityName = 'input[name="SalesOrderLines[' + index + '].Quantity"]';
        var priceName = 'input[name="SalesOrderLines[' + index + '].Price"]';
        var amountName = 'input[name="SalesOrderLines[' + index + '].Amount"]';

        var quantity = $(quantityName).val().replace(/\./g, '');
        var price = $(priceName).val().replace(/\./g, '');

        var amount = quantity * price;
        $(amountName).val(FormatCurrency(amount.toString(), '.', ',', '.'));

        $(this).val(function (index, value) {
            //reformat
            return FormatCurrency(value, '.', ',', '.');
        });

        CalculateTotalAmount();

    });

    function FormatCurrency(value, inD, outD, sep) {

        //clean previously added dot
        value = value.replace(/\./g, '');

        var nStr = value.replace(/\./g, '');
        nStr += '';
        var dpos = nStr.indexOf(inD);
        var nStrEnd = '';
        if (dpos !== -1) {
            nStrEnd = outD + nStr.substring(dpos + 1, nStr.length);
            nStr = nStr.substring(0, dpos);
        }
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(nStr)) {
            nStr = nStr.replace(rgx, '$1' + sep + '$2');
        }
        return nStr + nStrEnd;
    }
    function ReorderIndex() {
        $(".line-set").each(function () {

            //Current index
            var index = $(this).index();

            //Rename inputs
            $(":input", this).each(function () {
                this.name = this.name.replace(/[0-9]+/, index);
                this.id = this.id.replace(/[0-9]+/, index);
            });

            ////Rename spans
            //$(this).find('.field-validation-valid, .field-validation-error').each(function () {
            //    var oldName = $(this).attr('data-valmsg-for');
            //    var newName = $(this).attr('data-valmsg-for').replace(/[0-9]+/, index);
            //    $(this).attr("data-valmsg-for", newName);

            //});

        });
    }
    function ButtonVisibility() {

        var counter = $(".line-set").length;

        if (counter === 1) {
            $('.line-set .delete-line').hide();
        }
        else {
            $('.line-set .delete-line').show();
        }
    }
    function CalculateTotalAmount() {
        var sum = 0;

        //iterate through each textboxes and add the values
        $(".line-amount").each(function () {

            var lineAmount = this.value.replace(/\./g, '');

            //add only if the value is number and visible
            if (!isNaN(lineAmount) && lineAmount.length !== 0) {
                var parent = $(this).parents('.line-set');
                if (parent.is(':visible')) {
                    sum += parseFloat(lineAmount);
                    $(this).css("background-color", "#E1F0FF");
                }
            }
            else if (lineAmount.length !== 0) {
                $(this).css("background-color", "red");
            }
        });

        _$total.val(FormatCurrency(sum.toString(), '.', ',', '.'));

        // var totalAmount = addSeparatorsNF(sum.toFixed(0), '.', ',', '.');
        //_$total.val(totalAmount);
    }

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