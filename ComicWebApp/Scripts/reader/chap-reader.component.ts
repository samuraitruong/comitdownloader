import {Component, OnInit, AfterContentInit} from 'angular2/core';
import {TopStoryComponent} from '../shared/top-story.component'
import {StoryCarouselComponent} from '../shared/story-carousel.component'
import {RouteParams, Router} from 'angular2/router'
import {Story} from '../models/story'
import {Chapter} from '../models/chapter'
import {NavigationHelper} from '../shared/navigation.helper'
import {ChapReaderService} from './chap-reader.service'

@Component({
    selector: 'cmapp-chap-reader',
    templateUrl: 'views/reader/chap-reader.html',
    directives: [],
    providers: [ChapReaderService]
})
export class ChapReaderComponent implements OnInit, AfterContentInit {
    constructor(private _nav: NavigationHelper, private _service: ChapReaderService, private _routeParams: RouteParams) {

    }
    ngAfterContentInit() {
    }
    ngOnInit() {
        this.name = this._routeParams.get("storyname");
        console.log('storyname : ' + this.name)
        this.chapname = this._routeParams.get('chapname');
        console.log('chapname : ' + this.chapname)
        this._service.getChapInfo(this.name, this.chapname).subscribe(res => {
            this.chapter = res;
            this.story = this.chapter.Story;
            console.log('data callback complete.....')
        },
            err=> {
                this.errorMessage = <any>err;
            }
        );
    }
    chapname: string;
    story: Story;
    chapter: Chapter;
    errorMessage: string;
    name: string;
}

