import {Component, OnInit, AfterContentInit} from 'angular2/core';
import {TopStoryComponent} from '../shared/top-story.component'
import {StoryCarouselComponent} from '../shared/story-carousel.component'
import {RouteParams, Router} from 'angular2/router'
import {Story, GenreRes} from '../models/story'
import {Chapter} from '../models/chapter'
import {NavigationHelper} from '../shared/navigation.helper'
import {DirectoryService} from './directory.service'
import {StoryListComponent} from '../shared/story-list.component'
import {StoryGenresComponent} from  '../shared/story-genres.component'

@Component({
    selector: 'cmapp-genre',
    templateUrl: 'views/directory/genre.html',
    directives: [StoryListComponent, StoryGenresComponent],
    providers: [DirectoryService]
})
export class GenreComponent implements OnInit, AfterContentInit {
    constructor(private _nav: NavigationHelper, private _service: DirectoryService, private _routeParams: RouteParams) {

    }
    ngAfterContentInit() {
    }
    ngOnInit() {
        this.genre = this._routeParams.get("genre");
        this._service.getGenreStories(this.genre, this.page).subscribe(res => {
            this.stories = res.Stories;
            this.pageCount = res.PageCount;
        },
            err=> {
                this.errorMessage = <any>err;
            }
        );
    }
    viewStory(s: Story) {
        this._nav.viewStory(s);
    }
    stories: Story[];
    errorMessage: string;
    genre: string;
    page: number = 1;
    pageCount: number;

    private totalItems: number = 64;
    private currentPage: number = 4;

    private maxSize: number = 5;
    private bigTotalItems: number = 175;
    private bigCurrentPage: number = 1;

    private setPage(pageNo: number): void {
        this.currentPage = pageNo;
    };

    private pageChanged(event: any): void {
        console.log('Page changed to: ' + event.page);
        console.log('Number items per page: ' + event.itemsPerPage);
    };

}

