import {Injectable} from 'angular2/core'
import {Http, Response, Headers, RequestOptions} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'
import {User} from '../models/user'

@Injectable()

export class UserService {
    private _apiUrl = '/api/user/';
    constructor(private http: Http) { }

    public register(user: User) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        let body = JSON.stringify(user)
        return this.http.post(this._apiUrl, body, options)
            .map(res => <any>res.json())       
            .catch(this.handleError)
            .do(data=> console.log(data))
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}

