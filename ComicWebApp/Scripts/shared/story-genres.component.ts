import {Component, OnInit} from 'angular2/core';
import {Story} from '../models/story'
import {Chapter} from '../models/chapter'
import {TopStoryService} from './top-story.service'
import {RouteParams, Router} from 'angular2/router'
import {NavigationHelper} from './navigation.helper'

@Component({
    selector: 'cmapp-story-genres',
    templateUrl: 'views/shared/story-genres.html',
    providers: [TopStoryService]
})
export class StoryGenresComponent implements OnInit {
    constructor(private _storyService: TopStoryService,  private _nav: NavigationHelper) { }
    errorMessage: string;
    genres: string[];
    ngOnInit() {
    }
}

