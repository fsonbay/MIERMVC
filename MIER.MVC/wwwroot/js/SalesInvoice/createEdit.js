
//SalesInvoice/createEdit.js

(function ($) {

    //COST PARAMETERS
    var _$costSets = $('.cost-sets');
    var _$addCostBtn = $('#AddCostButton');
    var _$delCostBtn = $('.delete-cost');
    var _$costCalc = $('.cost-calculation');

    //PAYMENT PARAMETERS
    var _$paymentSets = $('.payment-sets');
    var _$addPaymentBtn = $('#AddPaymentButton');
    var _$delPaymentBtn = $('.delete-payment');
    var _$paymentCalc = $('.payment-calculation');

    //COST EVENTS
    _$addCostBtn.click(function (e) {

        //Cancel default postback
        e.preventDefault();

        //Check if class exist (meaning cost not exist yet)
        var newItem = $(".cost-template:first-child").clone(true);
        newItem.addClass('cost-set').removeClass('cost-template');
        newItem.show();

        //Input Values
        newItem.find(':input').each(function () {

            var id = $(this).attr('id');
            var name = $(this).attr('name');

            $(this).attr('id', 'SalesInvoiceCosts_0__' + name);
            $(this).attr('name', 'SalesInvoiceCosts[0].' + name);

            //Texbox
            $(this).val('');

            //isActive
            if ($(this).hasClass("isActive")) {
                $(this).val('True');
            }

            //id
            if ($(this).hasClass("cost-id")) {
                $(this).val('0');
            }
        });

        //Validation message
        newItem.find('span').each(function () {

            var name = $(this).attr('data-valmsg-for');
            $(this).attr('data-valmsg-for', 'SalesInvoiceCosts[0].' + name);

        });

        //Add clone
        _$costSets.append(newItem);

        //Focus
        $('.cost-set:last-child :input:enabled:visible:first').focus();

        //Reorder index
        ReorderCostIndex();

        //Reset validator
        ResetValidator();

    });
    _$delCostBtn.click(function (e) {

        //Cancel default postback
        e.preventDefault();

        //Set hidden value
        $(this).parents('.cost-set').find('.isActive').val("false");

        //Check Id, if ID = 0 ==> new set, remove. else hide.
        var id = $(this).parents('.cost-set').find('.cost-id').val();

        if (id === '0') {
            $(this).parents('.cost-set').remove();
        }
        else {
            $(this).parents('.cost-set').hide();
        }

        ReorderCostIndex();

        CalculateTotalAmount();

    });
    _$costCalc.keyup(function (event) {

        var i = $(this).attr('name');
        var start_pos = i.indexOf('[') + 1;
        var end_pos = i.indexOf(']', start_pos);
        var index = i.substring(start_pos, end_pos);

        var quantityName = 'input[name="SalesInvoiceCosts[' + index + '].Quantity"]';
        var priceName = 'input[name="SalesInvoiceCosts[' + index + '].Price"]';
        var amountName = 'input[name="SalesInvoiceCosts[' + index + '].CostAmount"]';

        var quantity = $(quantityName).val().replace(/\./g, '');
        var price = $(priceName).val().replace(/\./g, '');

        var formattedQuantity = FormatCurrency((quantity), '.', ',', '.');
        var formattedPrice = FormatCurrency((price), '.', ',', '.');
        var formattedAmount = FormatCurrency((price * quantity).toFixed(0), '.', ',', '.');

        $(quantityName).val(formattedQuantity);
        $(priceName).val(formattedPrice);
        $(amountName).val(formattedAmount);

        CalculateTotalAmount();

    });
    function ReorderCostIndex() {

        $(".cost-set").each(function () {

            //Current index (minus 1 to exclude hidden template)
            var index = $(this).index() - 1;

            //Rename inputs
            $(":input", this).each(function () {
                this.name = this.name.replace(/[0-9]+/, index);
                this.id = this.id.replace(/[0-9]+/, index);
            });

            //Rename validators span
            $(this).find('.field-validation-valid, .field-validation-error').each(function () {
                var oldName = $(this).attr('data-valmsg-for');
                var newName = $(this).attr('data-valmsg-for').replace(/[0-9]+/, index);
                $(this).attr("data-valmsg-for", newName);

            });

        });
    }

    //PAYMENT EVENTS
    _$addPaymentBtn.click(function (e) {

        //Cancel default postback
        e.preventDefault();

        //Check if class exist (meaning payment not exist yet)
        var newItem = $(".payment-template:first-child").clone(true);
        newItem.addClass('payment-set').removeClass('payment-template');
        newItem.show();

        //Input Values
        newItem.find(':input').each(function () {

            var id = $(this).attr('id');
            var name = $(this).attr('name');

            $(this).attr('id', 'SalesInvoicePayments_0__' + name);
            $(this).attr('name', 'SalesInvoicePayments[0].' + name);

            if (name === "Date") {

                var start = moment();

                $(this).daterangepicker({
                    "locale": {
                        "format": "DD-MM-YYYY"
                    },
                    singleDatePicker: true,
                    startDate: start
                });

            };

            if (name === "PaymentMethodId") {

                $(this).select2({
                    placeholder: "Please select...",
                    allowClear: true
                });
            };

            //isActive
            if ($(this).hasClass("isActive")) {
                $(this).val('True');
            }

            //id
            if ($(this).hasClass("payment-id")) {
                $(this).val('0');
            }
        });

        //Validation message
        newItem.find('span').each(function () {

            var name = $(this).attr('data-valmsg-for');
            $(this).attr('data-valmsg-for', 'SalesInvoicePayments[0].' + name);

        });

        //Add clone
        _$paymentSets.append(newItem);

        //Reorder index
        ReorderPaymentIndex();

        //Reset validator
        ResetValidator();

    });
    _$delPaymentBtn.click(function (e) {

        alert(1);
        //Cancel default postback
        e.preventDefault();

        //Set hidden value
        $(this).parents('.payment-set').find('.isActive').val("false");

        //Check Id, if ID = 0 ==> new set, remove. else hide.
        var id = $(this).parents('.payment-set').find('.payment-id').val();

        if (id === '0') {
            $(this).parents('.payment-set').remove();
        }
        else {
            $(this).parents('.payment-set').hide();
        }

        ReorderPaymentIndex();

        CalculateTotalAmount();

    });

    _$paymentCalc.keyup(function (event) {

        var i = $(this).attr('name');
        var start_pos = i.indexOf('[') + 1;
        var end_pos = i.indexOf(']', start_pos);
        var index = i.substring(start_pos, end_pos);

        var amountName = 'input[name="SalesInvoicePayments[' + index + '].PaymentAmount"]';
        var amount = $(amountName).val().replace(/\./g, '');
        var formattedAmount = FormatCurrency((amount), '.', ',', '.');

        $(amountName).val(formattedAmount);

        CalculateTotalAmount();

    });
    function ReorderPaymentIndex() {

   
        $(".payment-set").each(function () {

            //Current index (minus 1 to exclude hidden template)
            var index = $(this).index() - 1;
           

            //Rename inputs
            $(":input", this).each(function () {
                this.name = this.name.replace(/[0-9]+/, index);
                this.id = this.id.replace(/[0-9]+/, index);
            });

            //Rename validators span
            $(this).find('.field-validation-valid, .field-validation-error').each(function () {
                var oldName = $(this).attr('data-valmsg-for');
                var newName = $(this).attr('data-valmsg-for').replace(/[0-9]+/, index);
                $(this).attr("data-valmsg-for", newName);

            });

        });
    }

    //GENERIC METHODS
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
    function CalculateTotalAmount() {

        var TOTAL = 0.00;
        var PAID = 0.00;
        var OUTSTANDING = 0.00;

        var orderAmount = parseFloat($(".order-amount").val().replace(/\./g, ""));

        //Calculation
        TOTAL = orderAmount; //Start with order amount

        //iterate through each textboxes and add the values
        $('.cost-amount').each(function () {
            var costAmount = this.value.replace(/\./g, '');

            //add only if the value is number and visible
            if (!isNaN(costAmount) && costAmount.length !== 0) {
                var parent = $(this).parents('.cost-set');
                if (parent.is(':visible')) {
                    TOTAL += parseFloat(costAmount);
                    $(this).css("background-color", "#FEFFB0");

                }
            }
            else if (costAmount.length !== 0) {
                $(this).css("background-color", "red");
            }           
        });

        //iterate through each textboxes and add the values
        $('.payment-amount').each(function () {
            var paymentAmount = this.value.replace(/\./g, '');
          //  alert(paymentAmount);

            //add only if the value is number and visible
            if (!isNaN(paymentAmount) && paymentAmount.length !== 0) {
                var parent = $(this).parents('.payment-set');
                if (parent.is(':visible')) {
                    PAID += parseFloat(paymentAmount);
        /*            $(this).css("background-color", "#FEFFB0");*/

                }
            }
            else if (paymentAmount.length !== 0) {
                $(this).css("background-color", "red");
            }
        });

        OUTSTANDING = TOTAL - PAID;

        $(".total-amount").val(FormatCurrency(TOTAL.toFixed(0), '.', ',', '.'));
        $(".paid-amount").val(FormatCurrency(PAID.toFixed(0), '.', ',', '.'));
        $(".outstanding-amount").val(FormatCurrency(OUTSTANDING.toFixed(0), '.', ',', '.'));

        $(".total-amount").css("background-color", "#FEFFB0");
        $(".paid-amount").css("background-color", "#FEFFB0");
        $(".outstanding-amount").css("background-color", "#FEFFB0");

    }
    function ResetValidator() {

        //Reset validator
        $('#FormSalesInvoice').removeData('validator');
        $('#FormSalesInvoice').removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse('#FormSalesInvoice');
    }

}(jQuery));