
//SalesInvoice/createEdit.js

(function ($) {

    //COST
    var $costSets = $('.cost-sets');
    var _$addCostBtn = $('#AddCostButton');
    var _$delCostBtn = $('.delete-cost');
    //var _$delCostBtn = $('.delete-line');
    //var $costAmount = $(".cost-amount");
    //var _$costCalc = $('.cost-calculation');

    var wrapperCost = $('.cost-sets');


    //Line
    _$addCostBtn.click(function (e) {

        //Cancel default postback
        e.preventDefault();

        //Check if class exist (meaning cost not exist yet)
        var newItem = $(".cost-template:first-child").clone(true);
        newItem.addClass('cost-set').removeClass('cost-template');
        newItem.show();

        //Add clone
        wrapperCost.append(newItem);

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
                $(this).val('False');
            }

            //id
            if ($(this).hasClass("cost-id")) {
                $(this).val('0');
            }
        });

        //Focus
        $('.cost-set:last-child :input:enabled:visible:first').focus();

        //Reorder index
        ReorderCostIndex();

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

        //ButtonVisibility();
        //CalculateTotalAmount();

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

}(jQuery));