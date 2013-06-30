(function () {
    'use strict'

    $.fn.carousel = function () {
        this.each(function () {
            var panels = $(this).find('.carousel-panels'),
                totalPanels = panels.find('.carousel-panel').size(),
                currentPanel = 0

            function slideBy(delta) {
                currentPanel = (currentPanel + delta + totalPanels) % totalPanels
                panels.css('left', -(currentPanel * 100) + '%')
            }

            $(this).find('.carousel-arrow-left').click(function () {
                slideBy(-1);
            })

            $(this).find('.carousel-arrow-right').click(function () {
                slideBy(1);
            })

            // TODO: Clear interval after click
            setInterval(function () {
                slideBy(1);
            }, 5 * 1000)
        })
    }

    $('.carousel').carousel();
}())