import {Component, OnInit, Injector} from 'angular2/core';
import {Story, GenreInfo} from '../models/story'
import {StoryGenresService} from './story-genres.service'
import {RouteParams, Router} from 'angular2/router'
import {NavigationHelper} from './navigation.helper'

@Component({
    selector: 'cmapp-story-genres',
    templateUrl: 'views/shared/story-genres.html',
    providers: [StoryGenresService]
})
export class StoryGenresComponent implements OnInit {
    constructor(private _service: StoryGenresService, private _nav: NavigationHelper, private _routeParams: RouteParams) {
        this.currentGenre = this._routeParams.get('genre');
    }
    errorMessage: string;
    currentGenre: string;
    genres: GenreInfo[];
    ngOnInit() {
        this.loadGenres();
    }
    loadGenres() {
        this._service.getGenres().subscribe(res=> this.genres = res, err=> this.errorMessage = <any>err)
    }
    viewGenre(genre: GenreInfo) {
        this._nav.viewGenre(genre.Name);
    }
}

