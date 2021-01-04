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
    setApiRouter() {
        this.apiRouter = "/api/customers";
    }

}

