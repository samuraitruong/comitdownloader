import {Component, OnInit, AfterContentInit} from 'angular2/core';
import {CORE_DIRECTIVES, FORM_DIRECTIVES} from 'angular2/common';
import {TopStoryComponent} from '../shared/top-story.component'
import {StoryCarouselComponent} from '../shared/story-carousel.component'
import {RouteParams, Route, RouterLink} from 'angular2/router'
import {Story} from '../models/story'
import {Chapter} from '../models/chapter'
import {StoryService} from './story.service'
import {StoryGenresComponent} from  '../shared/story-genres.component'
import {NavigationHelper} from '../shared/navigation.helper'
import { Rating } from 'ng2-bootstrap/ng2-bootstrap';


@Component({
    selector: 'cmapp-story-detail',
    templateUrl: 'views/story/story-detail.html',
    directives: [StoryGenresComponent, Rating, RouterLink],
    providers: [StoryService ]
})
export class StoryDetailComponent implements OnInit, AfterContentInit {
    constructor(private _routeParams: RouteParams, private _storyService: StoryService, private _nav: NavigationHelper) {
        this.currentRating = 0;
    }
    ngAfterContentInit() {
        setTimeout(() => {
            $(".nano").nanoScroller({
                alwaysVisible: true,
                scroll: "top"
            });
        }, 1000);
    }
    ngOnInit() {
        this.name = this._routeParams.get('name');
        this._storyService.getStoryByName(this.name)
            .subscribe(d=> { this.story = d },
            err=> { this.errorMessage = <any>err });
    }
    readChapter(chapter: Chapter) {
        this._nav.readChapter(this.story, chapter);
    }
    private hoveringOver(value: number): void {
        //console.log(value)
    };
    private rateStory(value: number): void {
        //console.log(value);
        if (value != this.currentRating) {
            console.log('call rating service....');
            this._storyService.rateStory(this.story, value)
                .subscribe(
                res=> { },
                err=> { });
        }
    }
    private currentRating: number;
    story: Story;
    errorMessage: string;
    name: string;
    private max: number = 5;
    private rate: number = 4;

}

