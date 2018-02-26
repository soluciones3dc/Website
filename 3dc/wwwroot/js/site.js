// Write your JavaScript code.
var app = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue!'
    }
});

var infiniteLoopAlternate = anime({
    targets: '#boxes .box',
    translateX: 250,
    direction: 'alternate',
    delay: function (el, i, l) { return i * 1000;},
    loop: true
});