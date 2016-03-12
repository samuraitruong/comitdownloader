import {Component, OnInit} from 'angular2/core';
import {GenreInfo} from '../models/story'
import {Chapter} from '../models/chapter'
import {StoryGenresService} from './story-genres.service'
import {ROUTER_DIRECTIVES, ROUTER_PROVIDERS, RouteParams} from 'angular2/router';
import {NavigationHelper} from './navigation.helper'

@Component({
    selector: 'cmapp-top-nav',
    templateUrl: 'views/shared/topnav.html',
    providers: [StoryGenresService],
    directives: [ROUTER_DIRECTIVES]
})
export class TopNavComponent implements OnInit {
    constructor(private _service: StoryGenresService, private _nav: NavigationHelper) { }
    ngOnInit() {
        //this.selectedGenre = this._params.get('genre')
        this.loadGenres();
    }
    viewGenre(g: GenreInfo) {
        this._nav.viewGenre(g.Name);
    }
    selectedGenre: string;

    topGenres: GenreInfo[];
    errorMessage: string;
    loadGenres() {
        this._service.getGenres().subscribe(res=> {
            res.sort((a, b) => b.StoriesCount - a.StoriesCount);
            this.topGenres = res.slice(0, 5);
        }
            , err=> this.errorMessage = <any>err);

    }
}

