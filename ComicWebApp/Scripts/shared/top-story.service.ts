import {Injectable} from 'angular2/core';
import {Story} from '../models/story'
import {Http, Response} from 'angular2/http';
import {Observable}     from 'rxjs/Observable';


@Injectable()

export class TopStoryService {
    private _topStoryAPI = '/api/story/top';
    private _top10StoryAPI = '/api/story/top10';
    constructor(private http: Http) { }
    public getTopStory() {
        return this.http.get(this._topStoryAPI)
            .map(res => <Story>res.json())
            .catch(this.handleError)
            .do (data=> console.log(data) )
    }
    public getTop10Stories() {
        return this.http.get(this._top10StoryAPI)
            .map(res => <Story[]>res.json())
            .catch(this.handleError)
            .do(data=> console.log(data))
    }
    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}

