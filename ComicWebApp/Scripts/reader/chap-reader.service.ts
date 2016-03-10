import {Injectable} from 'angular2/core'
import {Story} from '../models/story'
import {Chapter} from '../models/chapter'
import {Http, Response} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'

@Injectable()

export class ChapReaderService {
    private _apiUrl = '/api/story/detail/';
    constructor(private http: Http) { }
    public getChapInfo(storyName: string, chapName: string) {
        return this.http.get(this._apiUrl + encodeURIComponent(storyName) + '/' + encodeURIComponent(chapName))
            .map(res => <Chapter>res.json())
            .catch(this.handleError)
            .do(data=> console.log(data))
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}

