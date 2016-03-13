import {Component, Input} from 'angular2/core'
import {Story} from '../models/story'
import {NavigationHelper} from './navigation.helper'

import {OnChanges, SimpleChange,OnInit,AfterContentInit,AfterContentChecked,AfterViewInit,AfterViewChecked,OnDestroy} from 'angular2/core';

@Component({
    selector: 'cmapp-story-list',
    templateUrl: 'views/shared/story-list.html'
})
export class StoryListComponent implements AfterViewChecked {
    constructor(private _nav: NavigationHelper) { }
    viewStory(story: Story) {
        this._nav.viewStory(story)
    }
    viewLatestChap(story: Story) {
        if (story.Chapters.length > 0) {
            this._nav.readChapter(story, story.Chapters[story.Chapters.length -1])
        }
    }
    @Input() stories: Story[];
    ngAfterViewChecked() {
    }
}

