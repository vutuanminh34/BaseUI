$(document).ready(function () {
    new EmployeeJS();
})

/**
 * Class used to manage events for Employee
 * createdBy: vtminh (28/12/2020)
 * */
class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }

    setDataUrl() {
        this.getDataUrl = "http://api.manhnv.net/api/employees";
    }
}
