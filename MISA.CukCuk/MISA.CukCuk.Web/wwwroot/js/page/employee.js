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
        $('#txtSearchEmployee, .cbxFilter1, .cbxFilter2').on('input', function (event) {
            me.setSubApi();
            me.loadData();
        })

    }

    setSubApi() {
        var inputValue = $('#txtSearchEmployee').val();

        var departmentId = $('select.cbxFilter1 option:selected').val();
        if (departmentId == undefined)
            departmentId = '';

        var positionId = $('select.cbxFilter2 option:selected').val();
        if (positionId == undefined)
            positionId = '';

        this.subApi = "/filter?inputValue=" + inputValue + "&departmentId=" + departmentId + "&positionId=" + positionId + "";


    }


    setApiRouter() {
        this.apiRouter = "/api/v1/employees";
    }

}
