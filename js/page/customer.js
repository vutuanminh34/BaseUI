$(document).ready(function () {
    new CustomerJS();
    // show and hide modal
    $('.button-default').click(function () {
        $('.dialog-detail').addClass('show-dialog');
        $('.dialog-detail').removeClass('hide-dialog');
    });$('#button-x').click(function () {
        $('.dialog-detail').removeClass('show-dialog');
        $('.dialog-detail').addClass('hide-dialog');
    });
    /*$(".dialog-detail").hide();
    $("#button-add").click(function () {
        $(".dialog-detail").show();
    });
    $("#button-x").click(function () {
        $(".dialog-detail").hide();
    });*/
})

/**
 * Class used to manage events for Customer
 * createdBy: minhvt (28/12/2020)
 * */
class CustomerJS extends BaseJS {
    constructor() {
        super();
    }

    setDataUrl() {
        this.getDataUrl = "http://api.manhnv.net/api/customers";
    }
}

