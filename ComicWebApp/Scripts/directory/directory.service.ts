﻿import {Injectable} from 'angular2/core'
import {Story, GenreRes, StoryListRes} from '../models/story'
import {Chapter} from '../models/chapter'
import {Http, Response} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'

@Injectable()

export class DirectoryService {
    private _apiUrl = '/api/story/genre/';
    private _listApiUrl ='/api/story/list/'
    constructor(private http: Http) { }
    public getGenreTopStories(genre: string) {
        return this.http.get(this._apiUrl + encodeURIComponent(genre) + '/top')
            .map(res => <Story[]>res.json())
            .catch(this.handleError)
    }
    public getGenreStories(genre: string, page: number) {
        return this.http.get(this._apiUrl + encodeURIComponent(genre) + '/' + page.toString())
            .map(res => <GenreRes>res.json())
            .catch(this.handleError)
    }

    public getStories(filter: string, page: number, sort?: string) {
        sort = sort || "Name";
        var url = this._listApiUrl + encodeURIComponent(filter) +  '/' + encodeURIComponent(sort) + '/' + page.toString()
        return this.http.get(url)
            .map(res => <StoryListRes>res.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}

