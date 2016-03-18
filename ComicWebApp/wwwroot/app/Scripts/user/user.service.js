var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var http_1 = require('angular2/http');
var Observable_1 = require('rxjs/Observable');
var angular2_jwt_1 = require('angular2-jwt');
var UserService = (function () {
    function UserService(http, _authHttp) {
        this.http = http;
        this._authHttp = _authHttp;
        this._apiUrl = '/api/user/';
        this._apiLoginUrl = '/api/user/login';
        this._apiTokenUrl = '/api/user/refresh-token';
        console.log(this._authHttp);
    }
    UserService.prototype.requestOptions = function (authToken) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        if (authToken) {
            //headers['Authorization'] = 'Beare ' + authToken;
            headers.append('Authorization', 'Bearer ' + authToken);
        }
        var options = new http_1.RequestOptions({ headers: headers });
        return options;
    };
    UserService.prototype.register = function (user) {
        var body = JSON.stringify(user);
        return this.http.post(this._apiUrl, body, this.requestOptions())
            .map(function (res) { return res.json(); })
            .catch(this.handleError)
            .do(function (data) { return console.log(data); });
    };
    UserService.checkUsernameExist = function (username) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        var injector = core_1.Injector.resolveAndCreate([http_1.HTTP_PROVIDERS]);
        var http = injector.get(http_1.Http);
        return http.post(this._apiCheckUser, JSON.stringify({ Username: username }), options)
            .map(function (res) { return res.json(); })
            .catch(function (error) {
            return Observable_1.Observable.throw(error.json().message || 'Unknow error');
        });
    };
    UserService.prototype.login = function (username, password, remember, authToken) {
        var body = JSON.stringify({
            Username: username,
            Password: password,
            Remember: remember,
            AuthToken: authToken
        });
        return this.http.post(this._apiLoginUrl, body, this.requestOptions(authToken))
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.refreshToken = function (authToken) {
        var myHeader = new http_1.Headers();
        myHeader.append('Content-Type', 'application/json');
        return this._authHttp.get(this._apiTokenUrl, { headers: myHeader })
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().message || 'Unknow error');
    };
    UserService._apiCheckUser = '/api/user/check';
    UserService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, angular2_jwt_1.AuthHttp])
    ], UserService);
    return UserService;
})();
exports.UserService = UserService;
//# sourceMappingURL=user.service.js.map