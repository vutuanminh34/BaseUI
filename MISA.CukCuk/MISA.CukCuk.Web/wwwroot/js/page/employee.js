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
        this.objectName = "Employee";
    }

    initEvents() {
        var me = this;
        super.initEvents();
        $('#txtSearchEmployee, #cbxFilter1, #cbxFilter2').blur(function () {
            me.loadData();
        })
    }

    setSubApi() {
        /*let inputValue = ;
        let departmentId = ;
        let positionId = ;
        this.subApi = "/filter?inputValue" + $('#txtSearchEmployee').val() + "=&departmentId=" + $('select#cbxFilter1 option:selected').val() + "&positionId=" + $('select#cbxFilter1 option:selected').val() + "";*/
    }

    setApiRouter() {
        this.apiRouter = "/api/v1/employees";
    }

}
