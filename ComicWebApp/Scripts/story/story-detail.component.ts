import {Component, OnInit, AfterContentInit} from 'angular2/core';
import {TopStoryComponent} from '../shared/top-story.component'
import {StoryCarouselComponent} from '../shared/story-carousel.component'
import {RouteParams, Route} from 'angular2/router'
import {Story} from '../models/story'
import {Chapter} from '../models/chapter'
import {StoryService} from './story.service'
import {StoryGenresComponent} from  '../shared/story-genres.component'
import {NavigationHelper} from '../shared/navigation.helper'


@Component({
    selector: 'cmapp-story-detail',
    templateUrl: 'views/story/story-detail.html',
    directives: [StoryGenresComponent],
    providers: [StoryService]
})
export class StoryDetailComponent implements OnInit, AfterContentInit {
    constructor(private _routeParams: RouteParams, private _storyService: StoryService, private _nav: NavigationHelper) {

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
    story: Story;
    errorMessage: string;
    name: string;
}

