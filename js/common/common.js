/**
 * format data of datetime to dd/mm/yyyy
 * @param {any} date any type of data
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