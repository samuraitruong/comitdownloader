import {Injectable, Injector} from 'angular2/core'
import {Http, Response, Headers, RequestOptions, ConnectionBackend, HTTP_PROVIDERS} from 'angular2/http'
import {Observable}     from 'rxjs/Observable'
import {User, LoginRes} from '../models/user'
import {AuthHttp, AuthConfig} from 'angular2-jwt';

@Injectable()

export class UserService {
    private _apiUrl = '/api/user/';
    private _apiLoginUrl = '/api/user/login';
    private static _apiCheckUser = '/api/user/check';
    private _apiTokenUrl = '/api/user/refresh-token';

    constructor(private http: Http, private _authHttp: AuthHttp) {
        console.log(this._authHttp)
    }
    public requestOptions(authToken?:string): RequestOptions {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        if (authToken) {
            //headers['Authorization'] = 'Beare ' + authToken;
            headers.append('Authorization', 'Bearer ' + authToken)
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

    public refreshToken(authToken: string) {
        var myHeader = new Headers();
        myHeader.append('Content-Type', 'application/json');
        return this._authHttp.get(this._apiTokenUrl, { headers: myHeader } )
            .map(res => <LoginRes>res.json())
            .catch(this.handleError)
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().message || 'Unknow error');
    }

}

