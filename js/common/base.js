class BaseJS {
    constructor() {
        this.getDataUrl = null;
        this.setDataUrl();
        this.loadData();
    }
    //set url
    setDataUrl() {

    }
    /**
    * load data
    * createdBy: minhvt (28/12/2020)
    * */
    loadData() {
        try {
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
