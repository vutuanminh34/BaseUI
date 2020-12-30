class BaseJS {
    constructor() {
        this.getDataUrl = null;
        this.setDataUrl();
        this.loadData();
        this.initEvents();
    }
    //set url
    setDataUrl() {

    }

    initEvents() {
        var me = this;
        //Event click on button add new
        $('.button-default').click(function () {
            $('.dialog-detail').addClass('show-dialog');
            $('.dialog-detail').removeClass('hide-dialog');
        });
        //Event reload data when click button load
        $('#button-refresh').click(function () {
            alert('Reloading data from server!');
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
        //Excute save data when click button "Luu"
        $('#button-save').click(function () {
            var self = this;
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
            var customer = {
                "CustomerCode": $('#txtCustomerCode').val(),
                "FullName": $('#txtFullName').val(),
                "Address": $('#txtAddress').val(),
                "DateOfBirth": $('#dtDateOfBirth').val(),
                "Email": $('#txtEmail').val(),
                "PhoneNumber": $('#txtPhoneNumber').val(),
                "CustomerGroupId": "3631011e-4559-4ad8-b0ad-cb989f2177da",
                "MemberCardCode": $('#txtMemberCardCode').val()
            }
            console.log(customer);
            //call service and save data
            $.ajax({
                url: 'http://api.manhnv.net/api/customers',
                method: 'POST',
                data: JSON.stringify(customer),
                contentType: 'application/json',
            }).done(function (res) {
                //After save success -> Give a message, hide form dialog, reload data
                alert('Thêm thành công!');
                $('.dialog-detail').removeClass('show-dialog');
                $('.dialog-detail').addClass('hide-dialog');
                me.loadData();

            }).fail(function (res) {
                
            }.bind(this))
            
        });
        //Show detail infor when double click on object in table(dynamic event definitions)
        $('table tbody').on('dblclick', 'tr', function () {
            alert(1);
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
        try {
            $('table tbody').empty();
            //get value for column
            var columns = $('table thead th');
            var getDataUrl = this.getDataUrl;

            //get data
            $.ajax({
                url: getDataUrl,
                method: "GET",
            }).done(function (res) {
                var data = res;
                $.each(data, function (index, obj) {
                    var tr = $(`<tr></tr>`);
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
                })
            }).fail(function (res) {

            })
        } catch (e) {
            //log error
            console.log(e);
        }



    }
}
