// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//document.onload.setCookie("Unit", "F", 1);


if (document.getElementsByClassName("detail-img") != null) {
    window.onload = showTemp();
}

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

function showTemp() {
    var currentUnit = getCookie("Unit");
    var temps = document.getElementsByClassName("temperature");
    var btnTxt = document.getElementById("convertBtn");
    if (currentUnit == "C") {
        btnTxt.innerHTML = 'Convert To Fahrenheit';

        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToC(temps[i].textContent);
            console.log(temps[i]);

        }
    }
};

function toggleTemp() {
    var buttonTxt = document.getElementById("convertBtn");
    if (buttonTxt.innerHTML == 'Convert To Celsius') {
        buttonTxt.innerHTML = 'Convert To Fahrenheit';
        var temps = document.getElementsByClassName("temperature");
        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToC(temps[i].textContent);
            // console.log(temps[i]);

        }

    }
    else {
        buttonTxt.innerHTML = 'Convert To Celsius';
        var temps = document.getElementsByClassName("temperature");
        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToF(temps[i].textContent);
            //console.log(temps[i]);
        }
    }
    switchCookie();
};



function convertToF(num) {
    var intNum = parseInt(num);
    // console.log("this is convert to F");
    return (intNum * (9.0 / 5.0) + 32).toPrecision(2);
};
function convertToC(num) {
    var intNum = parseInt(num);
    // console.log("this is convert to C");
    return ((intNum - 32) * 5 / 9).toPrecision(2);
};