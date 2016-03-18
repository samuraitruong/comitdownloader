import {Injectable} from 'angular2/core';
import {GenreInfo} from '../models/story'
import {Http, Response} from 'angular2/http';
import {Observable}     from 'rxjs/Observable';


@Injectable()

export class StoryGenresService {
    private _apiURL = '/api/story/genres';
    constructor(private http: Http) { }
    public getGenres() {
        return this.http.get(this._apiURL)
            .map(res => <GenreInfo[]>res.json())
            .catch(this.handleError)
    }
  
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Server error');
    }

}

