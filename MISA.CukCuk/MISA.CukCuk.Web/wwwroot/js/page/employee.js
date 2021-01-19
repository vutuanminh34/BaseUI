﻿$(document).ready(function () {
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
            me.loadFilter();
        })
    }

    setSubApi() {
        /*let inputValue = $('#txtSearchEmployee').val();
        let departmentId = $('select#cbxFilter1 option:selected').val();
        let positionId = $('select#cbxFilter2 option:selected').val();
        this.subApi = "/filter?inputValue" + inputValue + "=&departmentId=" + departmentId + "&positionId=" + positionId + "";*/
    }

    setApiRouter() {
        this.apiRouter = "/api/v1/employees";
    }

}
