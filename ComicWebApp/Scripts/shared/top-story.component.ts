import {Component, OnInit} from 'angular2/core';
import {Story} from '../models/story'
import {Chapter} from '../models/chapter'
import {TopStoryService} from './top-story.service'

@Component({
    selector: 'cmapp-top-story',
    templateUrl: 'views/shared/top-story.html',
    providers: [TopStoryService]
})
export class TopStoryComponent implements OnInit {
    constructor(private _storyService: TopStoryService) { }
    errorMessage:string;
    topStory: Story;
    lastChapter: Chapter;
    top10Stories: Story[];
    classes: Array<any> = new Array< any>();

    loadTopStory() {
        this._storyService.getTopStory().
            subscribe(
            story => {
                this.topStory = story
                this.lastChapter = story.Chapters[story.Chapters.length-1]
            },
            error => this.errorMessage = <any>error);
    }

    loadTop10Stories() {
        this._storyService.getTop10Stories().
            subscribe(
            top10stories => {
                this.top10Stories = top10stories;
                top10stories.forEach((s, index, list) => {
                    let item = {};
                    item["stt" + (index +1)] = true;
                    this.classes.push(item)
                });
                console.log(this.classes)
            },
            error => this.errorMessage = <any>error);
    }

    ngOnInit() {
        this.loadTopStory()
        this.loadTop10Stories();
    }
}

