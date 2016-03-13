import {Component, OnInit, AfterContentInit, Output} from 'angular2/core';
import {TopStoryComponent} from '../shared/top-story.component'
import {StoryCarouselComponent} from '../shared/story-carousel.component'
import {RouteParams, Router, ROUTER_DIRECTIVES} from 'angular2/router'
import {Story, GenreRes} from '../models/story'
import {Chapter} from '../models/chapter'
import {NavigationHelper} from '../shared/navigation.helper'
import {DirectoryService} from './directory.service'
import {StoryListComponent} from '../shared/story-list.component'
import {StoryGenresComponent} from  '../shared/story-genres.component'
import { Pagination} from 'ng2-bootstrap/ng2-bootstrap';

@Component({
    selector: 'cmapp-genre',
    templateUrl: 'views/directory/genre.html',
    directives: [StoryListComponent, StoryGenresComponent, Pagination, ROUTER_DIRECTIVES],
    providers: [DirectoryService]
})
export class GenreComponent implements OnInit, AfterContentInit {
    constructor(private _nav: NavigationHelper, private _service: DirectoryService, private _routeParams: RouteParams) {

    }
    ngAfterContentInit() {
    }
    ngOnInit() {
        this.genre = this._routeParams.get("genre");
        this.loadStories();
    }
    loadStories() {
        this._service.getGenreStories(this.genre, this.currentPage).subscribe(res => {
            this.stories = res.Stories;
            this.pageCount = res.PageCount;
            this.totalItems = res.TotalItems;
            this.pageSize = res.PageSize;
            console.log(this)
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
    pageCount: number;

    private totalItems: number = 0;
    private currentPage: number = 1;

    private maxSize: number = 10;
    private pageSize = 0;
    
    private setPage(pageNo: number): void {
        this.currentPage = pageNo;
    };

    private pageChanged(event: any): void {
        this.currentPage = event.page;
        this.loadStories();
    };

}

