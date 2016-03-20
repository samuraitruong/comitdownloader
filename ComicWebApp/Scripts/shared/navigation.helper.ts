﻿import {Injectable} from 'angular2/core';
import {Story} from '../models/story'
import {Chapter} from '../models/chapter'

import {RouteParams, Router} from 'angular2/router';

@Injectable()

export class NavigationHelper {
    constructor(private _router: Router ) { }
    viewStory(story: Story) {
        console.log(story)
        let link = ['StoryDetail', { name: story.AliasName || story.Name }];
        this._router.navigate(link);
    }
    readChapter(story: Story, chapter: Chapter) {
        let link = ['ChapReader', { storyname: encodeURIComponent(story.AliasName || story.Name), chapname: encodeURIComponent(chapter.AliasName || chapter.Name) }];
        this._router.navigate(link);
    }

    viewGenre(genre:string) {
        let link = ['Genre', { genre: genre }];
        this._router.navigate(link);
    }
    doSearch(keyword: string) {
        let link = ['Search', { keyword: keyword }];
        this._router.navigate(link);
    }
    getString(name: string): string {
        return "";
        //return this._routerParams.get(name); r
    }

}