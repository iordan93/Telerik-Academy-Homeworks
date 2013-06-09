function menus() {
    'use strict';

    var appName = navigator.appName;
    var addScroll = false;
    var theLayer;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    var positionX = 0;
    var positionY = 0;
    document.onmousemove = mouseMove;

    if (appName === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(netscapeEvent) {
        if (appName === "Netscape") {
            positionX = netscapeEvent.pageX - 5;
            positionY = netscapeEvent.pageY;
        }
        else {
            positionX = event.x - 5;
            positionY = event.y;
        }

        if (appName === "Netscape") {
            if (document.layers.ToolTip.visibility === 'show') {
                popTip();
            }
        }
        else {
            if (document.all.ToolTip.style.visibility === 'visible') {
                popTip();
            }
        }
    }

    function popTip() {
        if (appName === "Netscape") {
            theLayer = document.layers.ToolTip;

            if ((positionX + 120) > window.innerWidth) {
                positionX = window.innerWidth - 150;
            }

            theLayer.left = positionX + 10;
            theLayer.top = positionY + 15;
            theLayer.visibility = 'show';
        }
        else {
            theLayer = document.layers.ToolTip;
            if (theLayer) {
                positionX = event.x - 5;
                positionY = event.y;

                if (addScroll) {
                    positionX = positionX + document.body.scrollLeft;
                    positionY = positionY + document.body.scrollTop;
                }

                if ((positionX + 120) > document.body.clientWidth) {
                    positionX = positionX - 150;
                }

                theLayer.style.pixelLeft = positionX + 10;
                theLayer.style.pixelTop = positionY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function hideTip() {
        if (appName === "Netscape") {
            document.layers.ToolTip.visibility = 'hide';
        }
        else {
            document.all.ToolTip.style.visibility = 'hidden';
        }
    }

    function hideMenu1() {
        if (appName === "Netscape") {
            document.layers.menu1.visibility = 'hide';
        }
        else {
            document.all.menu1.style.visibility = 'hidden';
        }
    }

    function showMenu1() {
        if (appName === "Netscape") {
            theLayer = document.layers.menu1;
            theLayer.visibility = 'show';
        }
        else {
            theLayer = document.all.menu1;
            theLayer.style.visibility = 'visible';
        }
    }

    function hideMenu2() {
        if (appName === "Netscape") {
            document.layers.menu2.visibility = 'hide';
        }
        else {
            document.all.menu2.style.visibility = 'hidden';
        }
    }

    function showMenu2() {
        if (appName === "Netscape") {
            theLayer = document.layers.menu2;
            theLayer.visibility = 'show';
        }
        else {
            theLayer = theLayer = document.all.menu2;
            theLayer.style.visibility = 'visible';
        }
    }
}