'use strict';

$(function () {

    var width = 720;
    var animationSpeed = 1000;
    var pause = 5000;
    var currentSlide = 1;

    var $slideshow = $('#slideshow');
    var $slideContainer = $slideshow.find('.slides');
    var $slides = $slideContainer.find('.slide');
    var $leftArrow = $('.left');
    var $rightArrow = $('.right');

    var interval;

    function changeSlideForward() {
        $slideContainer.animate({ 'margin-left': '-=' + width + 'px' }, animationSpeed, function () {
            currentSlide++;
            if (currentSlide === $slides.length) {
                $slideContainer.css('margin-left', 0);
                currentSlide = 1;
            }
        });
    }

    function changeSlideBackwards() {
        if (currentSlide === 1) {
            $slideContainer.css('margin-left', -720 * ($slides.length - 1));
            currentSlide = $slides.length;
        }

        $slideContainer.animate({ 'margin-left': '+=' + width + 'px' }, animationSpeed, function () {
            currentSlide--;
        });
    }

    function startSlider() {
        interval = setInterval(changeSlideForward, pause);
    }

    function pauseSlider() {
        clearInterval(interval);
    }

    $slideshow.on('mouseenter', pauseSlider).on('mouseleave', startSlider);
    $rightArrow.on('click', changeSlideForward);
    $leftArrow.on('click', changeSlideBackwards);

    startSlider();
});