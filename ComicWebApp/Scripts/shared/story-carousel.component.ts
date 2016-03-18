﻿import {Component, Input} from 'angular2/core';
import {Story} from '../models/story'
import {NavigationHelper} from './navigation.helper'
import {AutoResize} from '../directives/ngResize'
import {WINDOW_PROVIDERS, WINDOW} from './window.service';

import {
OnChanges, SimpleChange,
OnInit,
AfterContentInit,
AfterContentChecked,
AfterViewInit,
AfterViewChecked,
OnDestroy
} from 'angular2/core';

@Component({
    selector: 'cmapp-story-carousel',
    templateUrl: 'views/shared/story-carousel.html',
    directives: [AutoResize]
})
export class StoryCarouselComponent implements AfterContentInit {
    @Input() stories: Story[];
    constructor(private _nav: NavigationHelper, private win: WINDOW) {
        win.nativeWindow.onresize  = (ev: UIEvent) => {
        };
    }
    viewStory(s: Story) {
        this._nav.viewStory(s)
    }
    readChapter(s: Story) {
        let chapter = s.Chapters[s.Chapters.length - 1];
        this._nav.readChapter(s, chapter)
    }
    ngAfterContentInit() {
        this.initCarousel()
    }
    initCarousel() {
        $('#crsTruyenHotTrongNgay').carousel({
            interval: 10000
        })
        setTimeout(() => {
            $('.bxslider').bxSlider(
                {
                    slideWidth: 134,
                    minSlides: 2,
                    maxSlides: 7,
                    slideMargin: 15,
                    preloadImages: 'visible',
                    auto: true,
                    autoStart: true
                }
            );
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

    }
}

