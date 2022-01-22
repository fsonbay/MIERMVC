
//site.js

$(function () {

    var _$listGrid = $('#ListGrid');
    var _$listSearch = $('#ListSearch');
    var _$showInactive = $('#ShowInactiveCheckbox');
    var _$showAudit = $('#ShowAuditLogCheckbox');
    var _$getList = $('#GetListButton');
    var _$clearFilter = $('#ClearSearchButton');
    var _$select2 = $('.select2');
    var _$select2Multiple = $('.select2-multiple');
    var _$selectTags = $('.select-tags');

    var _$datePicker = $('.date-picker');


    _$getList.click(function e() {
        _$listGrid.data('kendoGrid').dataSource.read();
    });
    _$clearFilter.click(function e() {
        _$listSearch.val("")
        _$listGrid.data('kendoGrid').dataSource.read();
    });
    _$showAudit.click(function e() {

        var grid = _$listGrid.data("kendoGrid");

        if (this.checked) {
            grid.showColumn(1);
            grid.showColumn(2);
            grid.showColumn(3);
            grid.showColumn(4);
            grid.showColumn(5);
        }
        else {
            grid.hideColumn(1);
            grid.hideColumn(2);
            grid.hideColumn(3);
            grid.hideColumn(4);
            grid.hideColumn(5);
        }

    });
    _$showInactive.click(function e() {
        _$listGrid.data('kendoGrid').dataSource.read();
    });


    //SELECT2
    _$select2.select2({
        placeholder: "Please select...",
        allowClear: true
    });
    _$select2Multiple.select2({
        placeholder: "Please select...",
        closeOnSelect: false
    });
    _$selectTags.select2({
        placeholder: "Please select...",
        allowClear: true,
        tags: true,
    });



    //TOASTR
    toastr.options.positionClass = 'toast-bottom-right';
    toastr.options.extendedTimeOut = 0; //1000;
    toastr.options.timeOut = 2000;
    toastr.options.fadeOut = 250;
    toastr.options.fadeIn = 250;
    //variable message value is assigned on cshtml page 
    if (message) { 
        if (message.includes("Error")) {
            toastr.error(message, "");
        }
        else {
            toastr.success(message, "");
        }
    };

    //_$datePicker.daterangepicker({
    //    locale: {
    //        format: 'DD-MM-YYYY',
    //    },
    //    singleDatePicker: true,
    //    showDropdowns: true
    //});



    _$datePicker.daterangepicker({
        "locale": {
            "format": "DD-MM-YYYY"
        },
        singleDatePicker: true
/*        startDate: moment(),*/
    });


    $(document).keypress(function (e) {
        if (e.which === 13) {
            _$listGrid.data('kendoGrid').dataSource.read();
        }
    });

});

