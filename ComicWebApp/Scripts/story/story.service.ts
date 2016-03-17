import {Injectable} from 'angular2/core';
import {Story} from '../models/story'
import {Http, Response} from 'angular2/http';
import {Observable}     from 'rxjs/Observable';

@Injectable()

export class StoryService {
    constructor(private _http: Http) { }

    _storyDetailAPI: string = '/api/story/detail/';
    getStoryByName(name: string) {
        return this._http.get(this._storyDetailAPI + encodeURIComponent(name))
            .map(r=> <Story>r.json())
            .catch(this.handleError)
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
