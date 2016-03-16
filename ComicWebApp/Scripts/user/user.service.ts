import {Injectable, Injector} from 'angular2/core'
import {Http, Response, Headers, RequestOptions, ConnectionBackend, HTTP_PROVIDERS} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'
import {User, LoginRes} from '../models/user'

@Injectable()

export class UserService {
    private _apiUrl = '/api/user/';
    private _apiLoginUrl = '/api/user/login';
    private static _apiCheckUser = '/api/user/check';

    constructor(private http: Http) { }
    public requestOptions(authToken?:string): RequestOptions {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        if (authToken) {
            headers['Authorization'] = 'Beare ' + authToken;
        }
        let options = new RequestOptions({ headers: headers });
        return options;
    }
    public register(user: User) {
        let body = JSON.stringify(user)
        return this.http.post(this._apiUrl, body, this.requestOptions())
            .map(res => <any>res.json())       
            .catch(this.handleError)
            .do(data=> console.log(data))
    }
    static checkUsernameExist(username: string) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        var injector = Injector.resolveAndCreate([HTTP_PROVIDERS]);

        var http = injector.get(Http);

        return http.post(this._apiCheckUser, JSON.stringify({ Username: username }), options)
            .map(res => <any>res.json())
            .catch((error: Response) => {
                return Observable.throw(error.json().message || 'Unknow error');
            });
    }
    public login(username: string, password: string, remember: boolean, authToken?:string) {
        let body = JSON.stringify({
            Username: username,
            Password: password,
            Remember: remember,
            AuthToken: authToken
        });
        return this.http.post(this._apiLoginUrl, body, this.requestOptions(authToken))
            .map(res => <LoginRes>res.json())
            .catch(this.handleError)
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().message || 'Unknow error');
    }

}

