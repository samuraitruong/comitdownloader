import {Injectable, Injector} from 'angular2/core';
import {Story} from '../models/story'
import {Http, Headers, Response, RequestOptions} from 'angular2/http';
import {Observable}     from 'rxjs/Observable';
import {AuthHttp} from 'angular2-jwt'


@Injectable()

export class StoryService {
    constructor(private _http: Http, private _authHttp: AuthHttp) {
        console.log(this._authHttp)
    }

    _storyDetailAPI: string = '/api/story/detail/';
    _storyRateAPI: string = '/api/story/rate';

    //better to use DI as single value?? or factory here
    public requestOptions(): RequestOptions {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        //TODO - Add more header....
        let options = new RequestOptions({ headers: headers });
        return options;
    }

    getStoryByName(name: string) {
        return this._http.get(this._storyDetailAPI + encodeURIComponent(name))
            .map(r=> <Story>r.json())
            .catch(this.handleError)
    }
    rateStory(story: Story, rateValue: number) {
        var data = {
            Name: story.Name,
            Rate: rateValue
        };
        
        return this._authHttp.post(this._storyRateAPI, JSON.stringify(data), this.requestOptions() ) 
            .map(r=> <Story>r.json())
            .catch(this.handleError)
    }
    private handleError(error: Response) {
        console.error(error.json());
        return Observable.throw(error.json().error || 'Server error');
    }
}
