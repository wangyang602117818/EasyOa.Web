/// <reference path="jquery-1.7.1.js" />
//增加全局函数
jQuery.extend({
    getRandom: function (lowerValue, upperValue) {
        var choices = upperValue - lowerValue + 1;
        return Math.floor(Math.random() * choices + lowerValue);
    }
});
