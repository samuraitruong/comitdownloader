"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var navigation_helper_1 = require('./navigation.helper');
var ngResize_1 = require('../directives/ngResize');
var window_service_1 = require('./window.service');
var StoryCarouselComponent = (function () {
    function StoryCarouselComponent(_nav, win) {
        this._nav = _nav;
        this.win = win;
        win.nativeWindow.onresize = function (ev) {
        };
    }
    StoryCarouselComponent.prototype.viewStory = function (s) {
        this._nav.viewStory(s);
    };
    StoryCarouselComponent.prototype.readChapter = function (s) {
        var chapter = s.Chapters[s.Chapters.length - 1];
        this._nav.readChapter(s, chapter);
    };
    StoryCarouselComponent.prototype.ngAfterContentInit = function () {
        this.initCarousel();
    };
    StoryCarouselComponent.prototype.initCarousel = function () {
        $('#crsTruyenHotTrongNgay').carousel({
            interval: 10000
        });
        setTimeout(function () {
            $('.bxslider').bxSlider({
                slideWidth: 134,
                minSlides: 2,
                maxSlides: 7,
                slideMargin: 15,
                preloadImages: 'visible',
                auto: true,
                autoStart: true
            });
            $('.carousel .item').each(function () {
                var next = $(this).next();
                if (!next.length) {
                    next = $(this).siblings(':first');
                }
                next.children(':first-child').clone().appendTo($(this));
                for (var i = 0; i < 5; i++) {
                    next = next.next();
                    if (!next.length) {
                        next = $(this).siblings(':first');
                    }
                    next.children(':first-child').clone().appendTo($(this));
                }
            });
        }, 1000);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], StoryCarouselComponent.prototype, "stories", void 0);
    StoryCarouselComponent = __decorate([
        core_1.Component({
            selector: 'cmapp-story-carousel',
            templateUrl: 'views/shared/story-carousel.html',
            directives: [ngResize_1.AutoResize]
        }), 
        __metadata('design:paramtypes', [navigation_helper_1.NavigationHelper, window_service_1.WINDOW])
    ], StoryCarouselComponent);
    return StoryCarouselComponent;
}());
exports.StoryCarouselComponent = StoryCarouselComponent;
