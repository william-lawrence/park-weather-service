// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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