$(document).ready(function () {
    new CustomerJS();
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

