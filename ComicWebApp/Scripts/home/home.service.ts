import {Injectable} from 'angular2/core';
import {Observable}     from 'rxjs/Observable';
import {Story} from '../models/story'
import {Http, Response} from 'angular2/http';

@Injectable()

export class HomeService {
    constructor(private _http: Http) {

    }
    _lastestStoriesApi: string = '/api/story/latest';
    _todayPopularApi: string = '/api/story/toptoday';
    _updatedPopularApi: string = '/api/story/updated';

    public getPopularTodayStores() {
        return this._http.get(this._todayPopularApi)
            .map(res=> <Story[] > res.json())
            .catch(this.handleError)
    }
    public loadLastestUpdateStories() {
        return this._http.get(this._updatedPopularApi)
            .map(res=> <Story[]>res.json())
            .catch(this.handleError)
    }

    public loadLastestPostStories() {
        return this._http.get(this._lastestStoriesApi)
            .map(res=> <Story[]>res.json())
            .catch(this.handleError)
    }


    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
