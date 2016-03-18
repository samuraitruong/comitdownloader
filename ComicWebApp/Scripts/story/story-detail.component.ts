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
import {tokenNotExpired, JwtHelper} from 'angular2-jwt';

@Component({
    selector: 'cmapp-story-detail',
    templateUrl: 'views/story/story-detail.html',
    directives: [StoryGenresComponent, Rating, RouterLink],
    providers: [StoryService]
})
export class StoryDetailComponent implements OnInit, AfterContentInit {
    constructor(private _routeParams: RouteParams, private _storyService: StoryService, private _nav: NavigationHelper) {
        this.currentRating = 0;
        this.allowRating = tokenNotExpired('auth_token');
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
            .subscribe(d=> {
                this.story = d;
                this.rate = this.story.Rating;
            },
            err=> { this.errorMessage = <any>err });
    }
    readChapter(chapter: Chapter) {
        this._nav.readChapter(this.story, chapter);
    }
    private hoveringOver(value: number): void {
        //console.log(value)
    };
    private rateStory(value: number): void {
        if (this.allowRating && value != this.currentRating) {
            this._storyService.rateStory(this.story, value)
                .subscribe(
                res=> {
                    this.rate = <number>res,
                        this.currentRating = value
                        this.story.Rating = this.rate;
                },
                err=> { });
        }
    }
    private allowRating: boolean = tokenNotExpired();
    private currentRating: number;
    story: Story;
    errorMessage: string;
    name: string;
    private max: number = 5;
    private rate: number = 0;

}

