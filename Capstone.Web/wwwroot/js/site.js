// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//document.onload.setCookie("Unit", "F", 1);

//document.onload.setCookie("Unit", "F", 1);


function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
};

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
};

function switchCookie() {
    var unit = getCookie("Unit");
    if (unit == "F") {
        setCookie("Unit", "C", 1);
    } else if (unit == "C") {
        setCookie("Unit", "F", 1);
    } else if (unit == "") {
        setCookie("Unit", "C", 1);
    }

};


function toggleTemp() {
    var buttonTxt = document.getElementById("convertBtn");
    if (buttonTxt.innerHTML == 'Convert To Celsius') {
        buttonTxt.innerHTML = 'Convert To Fahrenheit';
        var weather = document.getElementById("weather");
        weather.href = "https://forecast7.com/en/40d71n74d01/new-york/";
        // console.log(temps[i]);
        whatJoeWouldDo(document, 'head', 'weatherwidget-io-js');

    }
    else {
        buttonTxt.innerHTML = 'Convert To Celsius';
        var weather = document.getElementById("weather");
        weather.href = "https://forecast7.com/en/40d71n74d01/new-york/?unit=us";
        //console.log(temps[i]);
        whatJoeWouldDo(document, 'head', 'weatherwidget-io-js');

    }

    switchCookie();
};

function whatJoeWouldDo(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    let ele = d.getElementById(id);
    if (ele) {
        ele.parentNode.removeChild(ele);
    }

    js = d.createElement('script');
    js.id = id;
    js.src = 'https://weatherwidget.io/js/widget.min.js';
    fjs.insertAdjacentElement('beforeend', js);


};

document.addEventListener('DOMContentLoaded', () => {

    whatJoeWouldDo(document, 'head', 'weatherwidget-io-js');
});