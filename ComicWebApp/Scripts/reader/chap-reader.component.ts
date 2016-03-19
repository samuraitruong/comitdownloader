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
        this.chapname = this._routeParams.get('chapname');
        this._service.getChapInfo(this.name, this.chapname).subscribe(res => {

            //ensure http protocal
            res.Pages.forEach((url, index, arr) => {
                url = url.replace("https", "http");
                console.log(url)
                arr[index] = url;
            });

            console.log(res.Pages);
            this.chapter = res;
            this.story = this.chapter.Story;
            let index = this.story.Chapters.findIndex((c) => { return c.Name === this.chapter.Name });
            if (index < this.story.Chapters.length) {
                this.nextChapter = this.story.Chapters[index + 1]
                this.hasNextChapter = true;
            }
            if (index > 0) {
                this.hasPrevChapter = true;
                this.prevChapter = this.story.Chapters[index -1]
            }
        },
            err=> {
                this.errorMessage = <any>err;
            }
        );
    }
    changeChap(ev: any) {
        let selected = ev.target.value;
        if (selected !== this.chapname) {
            var chap = this.story.Chapters.filter((s) => {
                return s.Name == selected;
            })[0]

            this._nav.readChapter(this.story, chap) 
        }
    }
    viewStory(s: Story) {
        this._nav.viewStory(s);
    }
    viewChapter(c: Chapter) {
        this._nav.readChapter(this.story, c);
    }
    chapname: string;
    story: Story;
    chapter: Chapter;
    hasNextChapter: boolean = false;
    hasPrevChapter: boolean = false;
    nextChapter: Chapter = null;
    prevChapter: Chapter = null;
    errorMessage: string;
    name: string;
}

