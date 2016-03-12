﻿import {Injectable} from 'angular2/core'
import {Story, GenreRes} from '../models/story'
import {Chapter} from '../models/chapter'
import {Http, Response} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'

@Injectable()

export class DirectoryService {
    private _apiUrl = '/api/story/genre/';
    constructor(private http: Http) { }
    public getGenreStories(genre: string, page: number) {
        return this.http.get(this._apiUrl + encodeURIComponent(genre) + '/' + page.toString())
            .map(res => <GenreRes>res.json())
            .catch(this.handleError)
            .do(data=> console.log(data))
    }
    public getStories(genre: string, page: number) {
        return this.http.get(this._apiUrl + encodeURIComponent(genre) + '/' + page.toString())
            .map(res => <GenreRes>res.json())
            .catch(this.handleError)
            .do(data=> console.log(data))
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}

