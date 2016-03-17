import {Component, Input} from 'angular2/core';
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
        console.log('on carousel class')
        console.log(win.nativeWindow)
        win.nativeWindow.onresize  = (ev: UIEvent) => {
            console.log('resize............')
        };
    }
    viewStory(s: Story) {
        this._nav.viewStory(s)
    }
    ngAfterContentInit() {
        this.initCarousel()
    }
    initCarousel() {
        $('#crsTruyenHotTrongNgay').carousel({
            interval: 10000
        })
        setTimeout(() => {
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

