/// <reference path="../Scripts/jquery-1.7.1.min.js" />
jQuery.fn.extend({

    calendar: function () {

    }
});
var date_pattern = "yyyy-mm-dd hh:mm:ss";   //日期模板
//格式化日期 time_arr=数组
function dateFormat(time_arr) {
    var date_regex = /([yY]+)([/-])([mM]+)\2([dD]*)\s*([hH]*):?([mM]*):?([sS]*)/;
    var result = date_regex.exec(date_pattern);
    var year = yearFormat(time_arr[0], result[1].length),
        month = monthFormat(time_arr[1], result[3].length),
        day = monthFormat(time_arr[2], result[4].length),
        hour = monthFormat(time_arr[3], result[5].length),
        minutes = monthFormat(time_arr[4], result[6].length),
        seconds = monthFormat(time_arr[5], result[7].length);
    var newdate = year + result[2] + month;
    if (day.length != 0) newdate += result[2] + day;
    if (hour.length != 0) newdate += " " + hour;
    if (minutes.length != 0) newdate += ":" + minutes;
    if (seconds.length != 0) newdate += ":" + seconds;
    return newdate;
}
//格式化年，len=位数
function yearFormat(year, len) {
    if (year.toString().length == len) return year.toString();
    if (year.toString().length == 4 && len == 2) return year.toString().substr(2, 2);
    if (year.toString().length == 2 && len == 4) return new Date().getFullYear().toString().substr(0, 2) + year;
}
//格式化月，天，小时，
function monthFormat(month, len) {
    if (len == 1) return month;
    if (len == 2) return month.toString().length == 1 ? "0" + month : month;
    if (len == 0) return "";
}