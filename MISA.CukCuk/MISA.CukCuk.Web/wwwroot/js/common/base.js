class BaseJS {
    constructor() {
        this.host = "";
        this.apiRouter = null;
        this.setApiRouter();
        this.loadData();
        this.initEvents();
    }

    //set api router
    setApiRouter() {

    }

    initEvents() {
        var me = this;

        //Event click on button add new
        $('.button-default').click(me.btnAddOnClick.bind(me));

        //Event reload data when click button load
        $('#button-refresh').click(function () {
            alert('Refresh data complete!');
            this.loadData();
        }.bind(this));

        //Hide form dialog when click button "Huy" and "X"
        $('#button-cancel').click(function () {
            $('.dialog-detail').removeClass('show-dialog');
            $('.dialog-detail').addClass('hide-dialog');
        });
        $('#button-x').click(function () {
            $('.dialog-detail').removeClass('show-dialog');
            $('.dialog-detail').addClass('hide-dialog');
        });

        //Event click on button "Xoa"
        $('#button-delete').click(me.btnDeleteOnClick.bind(me));

        //Excute save data when click button "Luu"
        $('#button-save').click(me.btnSaveOnClick.bind(me));

        //Show detail infor when double click on object in table(dynamic event definitions)
        $('table tbody').on('dblclick', 'tr', function () {
            //load data for combobox
            var selects = $('select[fieldName]');
            selects.empty();
            $.each(selects, function (index, select) {
                //get value of group customers
                var api = $(select).attr('api');
                var fieldName = $(select).attr('fieldName');
                var fieldValue = $(select).attr('fieldValue');
                $('.loading').show();
                $.ajax({
                    url: me.host + api,
                    method: "GET",
                    async: true
                }).done(function (res) {
                    if (res) {
                        console.log(res);
                        $.each(res, function (index, obj) {
                            var option = $(`<option value="${obj[fieldValue]}">${obj[fieldName]}</option>`);
                            console.log(select);
                            $(select).append(option);
                            console.log(option);
                        })
                    }
                    $('.loading').hide();
                }).fail(function (res) {
                    $('.loading').hide();
                })
            })

            me.FormMode = 'Edit';
            //Get primary key from table
            var recordId = $(this).data('recordId');
            me.recordId = recordId;
            //Call service to get detail infor by Id
            $.ajax({
                url: me.host + me.apiRouter + `/${recordId}`,
                method: "GET"
            }).done(function (res) {
                //binding date to dialog
                console.log(res);

                //data collection has been entered -> build to object
                var inputs = $('input[fieldName], select[fieldName]');
                $.each(inputs, function (index, input) {
                    var propertyName = $(this).attr('fieldName');
                    var value = res[propertyName];

                    //for combobox
                    if ($(this).attr('id') == 'cbxCustomerGroup') {
                        var propValueName = $(this).attr('fieldValue');
                        value = res[propValueName];
                        $(this).val(value);
                    }
                    //for input date type
                    else if ($(this).attr('type') == 'date') {
                        $(this).val(formatStringDate(value));
                    }
                    //for input radio type
                    else if ($(this).attr('type') == "radio") {
                        var inputValue = this.value;

                        if (value == inputValue) {
                            this.checked = true;
                        } else {
                            this.checked = false;
                        }
                    } else {
                        $(this).val(value);
                    }

                })
            }).fail(function (res) {

            })
            //show dialog
            $('.dialog-detail').addClass('show-dialog');
            $('.dialog-detail').removeClass('hide-dialog');
        });

        /*
         * validate empty input
         * createdBy: vtminh (30/12/2020)
         */
        $('input[required]').blur(function () {
            //check value input; if value is empty, web will give caution
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không được phép để trống!');
                $(this).attr("validate", false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr("validate", true);
            }
        });

        /*
         * validate email
         * createdBy: vtminh (30/12/2020)
         */
        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
            if (!testEmail.test(value)) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Email không đúng định dạng!');
                $(this).attr("validate", false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr("validate", true);
            }
        })
    }
    /**
    * load data
    * createdBy: minhvt (28/12/2020)
    * */
    loadData() {
        var me = this;
        try {
            $('table tbody').empty();
            //get value for column
            var columns = $('table thead th');
            $('.loading').show();
            //get data
            $.ajax({
                url: me.host + me.apiRouter,
                method: "GET",
            }).done(function (res) {
                var data = res;
                $.each(data, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    $(tr).data('recordId', obj.CustomerId);
                    //get value use for mapping with the corresponding columns
                    $.each(columns, function (index, th) {
                        var td = $(`<td></td>`);
                        var fieldName = $(th).attr('fieldName');
                        var value = obj[fieldName];
                        var formatType = $(th).attr('formatType');
                        switch (formatType) {
                            case "ddmmyyyy":
                                td.addClass("text-align-center");
                                value = formatDate(value);
                                break;
                            case "Money":
                                td.addClass("text-align-right");
                                value = formatMoney(value);
                                break;
                            default:
                                break;
                        }
                        td.append(value);
                        $(tr).append(td);
                    })
                    $('table tbody').append(tr);
                    $('.loading').hide();
                })
            }).fail(function (res) {
                $('.loading').hide();
            })
        } catch (e) {
            //log error
            console.log(e);
        }



    }

    /**
     * Function excute event when click "Thêm mới khách hàng" button 
     * createdBy: minhvt (4/1/2021)
     * */
    btnAddOnClick() {
        try {
            var me = this;
            me.FormMode = 'Add';
            //show dialog
            $('.dialog-detail').addClass('show-dialog');
            $('.dialog-detail').removeClass('hide-dialog');
            $('input[type !="radio"]').val(null);
            $('input[type="radio"]').prop('checked', false);
            //load data for combobox
            var selects = $('select[fieldName]');
            selects.empty();
            $.each(selects, function (index, select) {
                //get value of group customers
                var api = $(select).attr('api');
                var fieldName = $(select).attr('fieldName');
                var fieldValue = $(select).attr('fieldValue');
                $('.loading').show();
                $.ajax({
                    url: me.host + api,
                    method: "GET",
                    async: true
                }).done(function (res) {
                    if (res) {
                        console.log(res);
                        $.each(res, function (index, obj) {
                            var option = $(`<option value="${obj[fieldValue]}">${obj[fieldName]}</option>`);
                            console.log(select);
                            $(select).append(option);
                            console.log(option);
                        })
                    }
                    $('.loading').hide();
                }).fail(function (res) {
                    $('.loading').hide();
                })
            })
        } catch (e) {
            console.log(e);
        }
    }

    /**
     * Function excute event when click "Lưu" button
     * createdBy: minhvt (4/1/2021)
     * */
    btnSaveOnClick() {
        var me = this;
        //validate data
        var inputValidates = $('input[required], input[type="email"]');
        $.each(inputValidates, function (index, input) {
            $(input).trigger('blur');
        });
        var inputNotValids = $('input[validate="false"]');
        if (inputNotValids && inputNotValids.length > 0) {
            alert('Dữ liệu không hợp lệ vui lòng kiểm tra lại!');
            inputNotValids[0].focus();
            return;
        }
        //data collection has been entered -> build to object
        var inputs = $('input[fieldName], select[fieldName]');
        var entity = {};
        $.each(inputs, function (index, input) {
            var propertyName = $(this).attr('fieldName');
            var value = $(this).val();

            //Check value of radio, Give only checked
            if ($(this).attr('type') == "radio") {
                if (this.checked) {
                    entity[propertyName] = value;
                }
            } else {
                entity[propertyName] = value;
            }

            if (this.tagName == "SELECT") {
                var propertyName = $(this).attr('fieldValue');
                entity[propertyName] = value;
            }
        })
        var method = "POST";
        var id = ``;
        if (me.FormMode == 'Edit') {
            method = "PUT";
            id = `/${me.recordId}`;
        }
        //call service and save data
        $.ajax({
            url: me.host + me.apiRouter + id,
            method: method,
            data: JSON.stringify(entity),
            contentType: 'application/json',
        }).done(function (res) {
            //After save success -> Give a message, hide form dialog, reload data
            console.log(entity);
            if (me.FormMode == 'Add') {
                alert('Thêm thành công!');
            } if (me.FormMode == 'Edit') {
                alert('Cập nhật thành công!');
            }
            $('.dialog-detail').removeClass('show-dialog');
            $('.dialog-detail').addClass('hide-dialog');
            me.loadData();

        }).fail(function (res) {

        })
    }

    btnDeleteOnClick() {
        var me = this;
        try {
            var result = confirm("Bạn có chắc chắn muốn xóa?");
            if (result) {
                $.ajax({
                    url: me.host + me.apiRouter + `/${me.recordId}`,
                    method: "DELETE"
                }).done(function (res) {
                    alert('Xóa thành công!');
                    $('.dialog-detail').removeClass('show-dialog');
                    $('.dialog-detail').addClass('hide-dialog');
                    me.loadData();

                }).fail(function (res) {

                })
            }
        } catch (e) {

        }
    }
}
