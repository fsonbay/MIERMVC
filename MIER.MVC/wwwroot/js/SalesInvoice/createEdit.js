
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
        if ($costSets.hasClass('d-none')) {
            $costSets.removeClass('d-none');
        }
        else
        {
            var newItem = $(".cost-set:first-child").clone(true);
            wrapperCost.append(newItem);
        }

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

            //Current index
            var index = $(this).index();

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