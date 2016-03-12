import {Component, OnInit} from 'angular2/core';
import {TopStoryComponent} from '../shared/top-story.component'
import {StoryCarouselComponent} from '../shared/story-carousel.component'
import {StoryListComponent} from '../shared/story-list.component'
import {HomeService} from './home.service'
import {Story} from '../models/story'
import {StoryGenresComponent} from  '../shared/story-genres.component'
import {ROUTER_DIRECTIVES} from 'angular2/router'

@Component({
    selector: 'cmapp-home',
    templateUrl: 'views/home/home.html',
    directives: [TopStoryComponent, StoryCarouselComponent, StoryListComponent, StoryGenresComponent, ROUTER_DIRECTIVES],
    providers: [HomeService]
})
export class HomeComponent implements OnInit {
    constructor(private _homeService: HomeService) {

    }
    ngOnInit() {
        this.loadCarouselItems();
        this.loadLastestUpdateStories();
        this.loadLastestPostStories();
    }

    loadCarouselItems() {
        this._homeService.getPopularTodayStores()
            .subscribe(res=> {
                this.carouselItems = res;
            },
            error=> { });

    }
    loadLastestUpdateStories() {
        this._homeService.loadLastestUpdateStories()
            .subscribe(res=> {
                this.lastestUpdateStories = res;
            },
            error=> { });
    }

    loadLastestPostStories() {
        this._homeService.loadLastestPostStories()
            .subscribe(res=> {
                this.latestPostedStories = res;
            },
            error=> { });
    }

    carouselItems: Story[];
    lastestUpdateStories: Story[];
    latestPostedStories: Story[];

}

