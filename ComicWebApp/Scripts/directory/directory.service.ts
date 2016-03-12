import {Injectable} from 'angular2/core'
import {Story, GenreRes, StoryListRes} from '../models/story'
import {Chapter} from '../models/chapter'
import {Http, Response} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'

@Injectable()

export class DirectoryService {
    private _apiUrl = '/api/story/genre/';
    private _listApiUrl ='/api/story/list/'
    constructor(private http: Http) { }
    public getGenreStories(genre: string, page: number) {
        return this.http.get(this._apiUrl + encodeURIComponent(genre) + '/' + page.toString())
            .map(res => <GenreRes>res.json())
            .catch(this.handleError)
            .do(data=> console.log(data))
    }
    public getStories(filter: string, page: number, sort?:string) {
        return this.http.get(this._listApiUrl + encodeURIComponent(filter) + '/' + page.toString())
            .map(res => <StoryListRes>res.json())
            .catch(this.handleError)
            .do(data=> console.log(data))
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}

