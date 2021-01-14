/**
 * format data of datetime to dd/mm/yyyy
 * @param {Date} date any type of data
 * createdBy: vtminh (27/12/2020)
 */
function formatDate(date) {
    var date = new Date(date);
    if (!Date.parse(date)) {
        return "";
    } else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;

        return day + '/' + month + '/' + year;
    }
}

/**
 * function used to show value of money after format
 * @param {Number} money number of money
 * createdBy: vtminh (27/12/2020)
 */
function formatMoney(money) {
    if (money) {
        return money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$&.");
    }
    return "";
}

/**
 * function used to convert string to date dd-mm-yyyy
 * @param {Date} dateInput
 * createdBy : vtminh (29/12/2020)
 */
function formatStringDate(dateInput) {
    if (dateInput) {
        let year = parseInt(dateInput.substr(0, 4));
        let month = parseInt(dateInput.substr(5, 2));
        let day = parseInt(dateInput.substr(8, 2));

        day = day >= 10 ? day : '0' + day;
        month = month >= 10 ? month : '0' + month;

        var date = `${year}-${month}-${day}`;
        return date;
    }
    return "";
}

/**
 * function used to format gender
 * @param {Number} gender 
 * createdBy: vtminh(14/1/2021)
 */
function formatGender(gender) {
    if (gender == 1)
        return "Nam";
    else if (gender == 0)
        return "Nữ";
    else
        return "Khác";
}