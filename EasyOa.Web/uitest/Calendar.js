/// <reference path="../Scripts/jquery-1.7.1.min.js" />
jQuery.fn.Calendar = function (options) {
    //默认配置
    var defaults = {
        date_pattern: "yyyy-mm-dd hh:mm:ss"  //日期模板yyyy-mm-dd hh:mm:ss
    };

    var week = ["日", "一", "二", "三", "四", "五", "六"],
        month = ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
        date = new Date(),
        curr_time_arr = [date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()],
        dur = 300,   //动画速度
        calendar,  //主日期框对象
        main_data_containter,  //主数据容器对象
        that = this;
    createCalendar();
    //创建日期主面板
    function createCalendar() {
        var calendar_div = "<div id=\"calendar\" class=\"calendar\">";
        calendar_div += "<div id=\"calendar_title_containter\" class=\"calendar_title_containter\">";
        calendar_div += "<div class=\"last_year\"><span id=\"last_year\"></span></div><div class=\"last_month\"><span id=\"last_month\"></span></div><div class=\"title_year\"><span id=\"title_year\">" + curr_time_arr[0] + "年</span></div><div class=\"title_month\"><span id=\"title_month\">" + monthFormat((curr_time_arr[1] + 1), 2) + "月</span></div><div class=\"next_month\"><span id=\"next_month\"></span></div><div class=\"next_year\"><span id=\"next_year\"></span></div></div>";  //title
        //容器部分
        calendar_div += "<div id=\"calendar_maindata_containter\" class=\"calendar_maindata_containter\">";
        calendar_div += "<div id=\"week_container\" class=\"week_container\"><div id=\"calendar_week\" class=\"calendar_week\">";
        for (var item in week) {
            calendar_div += "<div>" + week[item] + "</div>";
        }
        calendar_div += "</div></div>";
        calendar_div += createDataDiv();   //天数
        calendar = $(calendar_div);
        main_data_containter = calendar.find(".calendar_maindata_containter");
        main_data_containter.bind("click", DaySelected);
        if (needAddHeight()) {
            calendar.addClass("add_cal_len1");
            main_data_containter.addClass("add_main_date_len1");
        }
        $("body").append(calendar);
        init();
    }
    function init() {
        var con_year = createYearEle(curr_time_arr[0], main_data_containter.css("height")),
            con_month = createMonthEle(main_data_containter.css("height"));
        calendar.append(con_year, con_month);
        calendar.find("#title_year").bind("click", { con_year: con_year, con_month: con_month }, displayYearDiv);
        calendar.find("#title_month").bind("click", { con_year: con_year, con_month: con_month }, displayMonthDiv);
        calendar.find("#last_year").bind("click", lastYear);
        calendar.find("#next_year").bind("click", nextYear);
        calendar.find("#last_month").bind("click", lastMonth);
        calendar.find("#next_month").bind("click", nextMonth);
    }
    //显示年份div
    function displayYearDiv(event) {
        var con_year = event.data.con_year,
            con_month = event.data.con_month;
        con_year.stop(); con_month.stop();
        //重设年份容器的年份内容
        con_year.html(createYearEle(curr_time_arr[0], main_data_containter.css("height")).html());
        //让year层在month层上面
        con_year.css({ "z-index": parseInt(con_month.css("z-index"), 10) + 1 });
        if (con_year.attr("flag") == "0") {   //flag=0;表示年div未显示
            con_year.animate({ bottom: 0 }, dur, function () {
                con_month.css({ bottom: main_data_containter.css("height") });
                con_year.attr("flag", "1");
                con_month.attr("flag", "0");
            });
        } else {
            con_year.animate({ bottom: main_data_containter.css("height") }, dur);
            con_year.attr("flag", "0");
        }
    }
    //显示月份div
    function displayMonthDiv(event) {
        var con_year = event.data.con_year,
            con_month = event.data.con_month;
        con_year.stop(); con_month.stop();
        con_month.css({ "z-index": parseInt(con_year.css("z-index"), 10) + 1 });  //让moth层在year层上面
        if (con_month.attr("flag") == "0") {   //flag=0;表示月div未显示
            con_month.animate({ bottom: 0 }, dur, function () {
                con_year.css({ bottom: main_data_containter.css("height") });
                con_month.attr("flag", "1");
                con_year.attr("flag", "0");
            });
        } else {
            con_month.animate({ bottom: main_data_containter.css("height") }, dur);
            con_month.attr("flag", "0");
        }
    }
    //上一年
    function lastYear() {

        --curr_time_arr[0];
        calendar.find("#title_year").text(curr_time_arr[0] + "年");
        changeMainData("left");  //动画改变日期面板
    }
    //下一年
    function nextYear() {
        ++curr_time_arr[0];
        calendar.find("#title_year").text(curr_time_arr[0] + "年");
        changeMainData("right");  //动画改变日期面板
    }
    //上一月
    function lastMonth() {
        --curr_time_arr[1];
        if (curr_time_arr[1] < 0) {
            curr_time_arr[0]--;
            curr_time_arr[1] = 11;
            calendar.find("#title_year").text(curr_time_arr[0] + "年");
        }
        calendar.find("#title_month").text(monthFormat(parseInt(curr_time_arr[1], 10) + 1, 2) + "月");
        changeMainData("left");//动画改变日期面板
    }
    //下一月
    function nextMonth() {
        ++curr_time_arr[1];
        if (curr_time_arr[1] > 11) {
            curr_time_arr[0]++;
            curr_time_arr[1] = 0;
            calendar.find("#title_year").text(curr_time_arr[0] + "年");
        }
        calendar.find("#title_month").text(monthFormat(parseInt(curr_time_arr[1], 10) + 1, 2) + "月");
        changeMainData("right");
    }
    //以动画效果改变主日期面板,direction=动画方向
    function changeMainData(direction) {
        var calendar_width = calendar.css("width");  //主日期框宽度(数据面板的偏移量)
        var dataEle = $(createDataDiv()); //创建

        //在改变日期数据面板时,每个月天数不一样,有可能高度发生变化
        if (needAddHeight()) {
            calendar.addClass("add_cal_len1");
            main_data_containter.addClass("add_main_date_len1");
            calendar.find(".calendar_mainyear_containter").addClass("mainyear_height1").css("bottom","");
            calendar.find(".calendar_mainmonth_containter").addClass("mainmonth_height1").css("bottom","");
        } else {
            calendar.removeClass("add_cal_len1");
            main_data_containter.removeClass("add_main_date_len1");
            calendar.find(".calendar_mainyear_containter").removeClass("mainyear_height1");
            calendar.find(".calendar_mainmonth_containter").removeClass("mainmonth_height1");
        }
        if (direction == "left") {
            dataEle.css({ left: calendar_width }).attr("flag", "0");  //创建日期数据主面板element
            main_data_containter.append(dataEle);  //吧日期主面板加入父容器,这时连同以前一个数据面板，一共有2个数据面板
            var containter = calendar.find(".calendar_data_containter");   //获取这2个数据面板 
            //2个面板一同移动
            setTimeout(function () {
                containter.filter(":[flag=1]").animate({ left: "-" + calendar_width }, dur, function () {
                    $(this).remove();
                });
            }, 0);
            setTimeout(function () {
                containter.filter(":[flag=0]").animate({ left: 0 }, dur).attr("flag", "1");
            }, 0);
        }
        if (direction == "right") {
            dataEle.css({ left: "-" + calendar_width }).attr("flag", "0");
            main_data_containter.append(dataEle);
            var containter = $(".calendar_data_containter");
            setTimeout(function () {
                containter.filter(":[flag=1]").animate({ left: calendar_width }, dur, function () {
                    $(this).remove();
                });
            }, 0);
            setTimeout(function () {
                containter.filter(":[flag=0]").animate({ left: 0 }, dur).attr("flag", "1");
            }, 0);
        }
    }
    //格式化日期 time_arr=数组
    function dateFormat(time_arr) {
        var real_month = time_arr[1];
        real_month++;   //用来显示的月份,要加1
        var date_regex = /([yY]+)([/-])([mM]+)\2([dD]*)\s*([hH]*):?([mM]*):?([sS]*)/;
        var result = date_regex.exec(defaults.date_pattern);
        var year = yearFormat(time_arr[0], result[1].length),
            month = monthFormat(real_month, result[3].length),
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
    //根据年月获取该月的天数,第一天周几
    function getMonthDays(year, month) {
        var days = new Date(year, month + 1, 0).getDate();  //当前月的天数
        var first_day_week = new Date(year, month, 1).getDay();   //第一天周几
        return { days: days, first_day_week: first_day_week };
    }
    //是否需要增加日期框高度
    function needAddHeight() {
        var days_week_obj = getMonthDays(curr_time_arr[0], curr_time_arr[1]);  //对象包含当月的天数，第一天周几？
        if (days_week_obj.days == 30 && days_week_obj.first_day_week == 6) return true;
        if (days_week_obj.days == 31 && (days_week_obj.first_day_week == 5 || days_week_obj.first_day_week == 6)) return true;
        return false;
    }
    //创建日期主面板的天数据
    function createDataDiv() {
        var days_week_obj = getMonthDays(curr_time_arr[0], curr_time_arr[1]);  //对象包含当月的天数，第一天周几？
        var calendar_div = "<div class=\"calendar_data_containter\" flag=\"1\">";
        for (var i = 0; i < days_week_obj.first_day_week; i++) {   //前面部分
            calendar_div += "<span></span>";
        }
        for (var i = 1; i <= days_week_obj.days; i++) {      // 日期部分
            if (isToday(i)) {
                calendar_div += "<div class=\"today\">" + i + "</div>";
            } else {
                calendar_div += "<div>" + i + "</div>";
            }
        }
        calendar_div += "</div></div>";
        return calendar_div;
    }
    //创建年容器div
    function createYearEle(curr_year, height) {
        var start_disp_year = Math.floor(curr_year / 16) * 16;
        var year_div = "<div class=\"calendar_mainyear_containter\" flag=\"0\">";
        for (var i = start_disp_year; i < start_disp_year + 16; i++) {
            year_div += "<div>" + i + "</div>";
        }
        year_div += "</div>";
        var year_ele = $(year_div);
        if (needAddHeight()) year_ele.addClass("mainyear_height1");
        year_ele.bind("click", yearSelected);
        return year_ele;
    }
    //创建月容器div
    function createMonthEle(height) {
        var month_div = "<div class=\"calendar_mainmonth_containter\" flag=\"0\">";
        for (var i = 0; i < month.length; i++) {
            month_div += "<div>" + month[i] + "</div>";
        }
        month_div += "</div>";
        var month_ele = $(month_div);
        if (needAddHeight()) month_ele.addClass("mainmonth_height1");
        month_ele.bind("click", monthSelected);
        return month_ele;
    }
    function yearSelected(event) {
        var srcElement = $(event.target);  //触发事件的原对象
        if (srcElement.attr("class") != "calendar_mainyear_containter") {
            var txt = srcElement.text();  //点击的年份
            var curr_year = curr_time_arr[0];  //首先保存当前年
            curr_time_arr[0] = txt;   //吧全局的年份修改了
            if (txt > curr_year) {
                changeMainData("right");
            } if (txt < curr_year) {
                changeMainData("left");
            }
            calendar.find("#title_year").text(txt + "年");
            $(this).animate({ bottom: main_data_containter.css("height") }, dur).attr("flag", "0");
        }
    }
    function monthSelected(event) {
        var srcElement = $(event.target);  //触发事件的原对象
        if (srcElement.attr("class") != "calendar_mainmonth_containter") { //吧自身单击事件去掉
            var txt = srcElement.text();  //点击的月份
            for (var i = 0; i < month.length; i++) {
                if (month[i] == txt) {
                    var curr_month = curr_time_arr[1];   //保存当前的月份
                    curr_time_arr[1] = i;  //修改全局月份
                    if (i > curr_month) {
                        changeMainData("right");
                    }
                    if (i < curr_month) {
                        changeMainData("left");
                    }
                    calendar.find("#title_month").text(monthFormat(i + 1, 2) + "月");
                    $(this).animate({ bottom: main_data_containter.css("height") }, dur).attr("flag", "0");
                    return;
                }
            }
        }
    }
    function DaySelected(event) {
        var srcElement = $(event.target);  //触发事件的原对象
        var day = srcElement.text();
        if (srcElement.attr("class") != "calendar_maindata_containter" && day <= 31 && day > 0) {
            curr_time_arr[2] = day;
            var date = dateFormat(curr_time_arr);
            alert(date);
        }
    }
    function dispalyLastYearDiv(curr_year) {

        var start_disp_year = function () {

        }
    }
    function isYearDisplay() {
        if (calendar.find(".calendar_mainyear_containter").attr("flag") == "1") return true;
        return false;
    }
    function isMonthDisplay() {
        if (calendar.find(".calendar_mainmonth_containter").attr("flag") == "1") return true;
        return false;
    }
    //判断给定的日期是否今天
    function isToday(day) {
        var date = new Date();
        if (date.getFullYear() == curr_time_arr[0] && date.getMonth() == curr_time_arr[1] && date.getDate() == day) return true;
        return false;
    }
}
