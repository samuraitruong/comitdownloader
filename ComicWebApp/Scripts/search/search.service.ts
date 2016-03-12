import {Injectable} from 'angular2/core'
import {Story, GenreRes, StoryListRes} from '../models/story'
import {Chapter} from '../models/chapter'
import {Http, Response} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'

@Injectable()

export class SearchService {
    private _apiUrl = '/api/story/search/';
    constructor(private http: Http) { }
   
    public search(keyword: string, page: number) {
        return this.http.get(this._apiUrl + encodeURIComponent(keyword) + '/' + page.toString())
            .map(res => <StoryListRes>res.json())
            .catch(this.handleError)
            .do(data=> console.log(data))
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}

