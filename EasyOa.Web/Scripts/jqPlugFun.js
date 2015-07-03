/// <reference path="jquery-1.7.1.js" />
//增加一个全局函数
jQuery.foo = function () {

}
//增加多个全局函数
jQuery.extend({
    getRandom: function (lowerValue, upperValue) {
        var choices = upperValue - lowerValue + 1;
        return Math.floor(Math.random() * choices + lowerValue);
    }
});

//增加对象函数
jQuery.fn.extend({
    get2: function () {
        alert("ss");
    }
})

//增加对象函数,
jQuery.fn.Calendar = function (options) {
    var defaults = {

    }
}